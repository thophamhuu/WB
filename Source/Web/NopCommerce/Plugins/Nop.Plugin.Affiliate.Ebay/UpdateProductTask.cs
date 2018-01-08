using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Plugin.Affiliate.CategoryMap;
using Nop.Plugin.Affiliate.CategoryMap.Services;
using Nop.Plugin.Affiliate.Ebay.Models;
using Nop.Plugin.Affiliate.Ebay.Services;
using Nop.Services.Catalog;
using Nop.Services.Configuration;
using Nop.Services.Directory;
using Nop.Services.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Affiliate.Ebay
{
    public partial class UpdateProductTask : ITask
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IProductMappingService _productMappingService;
        private readonly ISettingService _settingService;

        public UpdateProductTask(ICategoryService categoryService, IProductService productService, IProductMappingService productMappingService,
            ISettingService settingService)
        {
            this._categoryService = categoryService;
            this._productService = productService;
            this._productMappingService = productMappingService;
            this._settingService = settingService;
        }

        public void Execute()
        {
            GetProduct().Wait();
        }

        private async Task<string> GetProduct()
        {
            var mappingSettings = _settingService.LoadSetting<ProductMappingSettings>();
            var allProductMapping = _productMappingService.GetAllProductMappingBySource((int)Source.Ebay);
            var tokenebay = EbayExtensions.GetToken();
            foreach (var item in allProductMapping)
            {
                var product = _productService.GetProductById(item.ProductId);
                var clientapi = new HttpClient();
                clientapi.BaseAddress = new Uri("https://api.ebay.com/");
                clientapi.DefaultRequestHeaders.Clear();
                clientapi.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                clientapi.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenebay);
                clientapi.Timeout = TimeSpan.FromMinutes(60);

                HttpResponseMessage Res = await clientapi.GetAsync("buy/browse/v1/item/" + item.ProductSourceId);

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<ProductModelApi>(EmpResponse);
                    var price = Convert.ToDecimal(result.price.value);
                    if (price != item.Price)
                    {
                        var currencyService = EngineContext.Current.Resolve<ICurrencyService>();
                        product.Price = currencyService.ConvertToPrimaryStoreCurrency(Math.Round((price * (decimal)(mappingSettings.AdditionalCostPercent / 100)) + price, 2), currencyService.GetCurrencyByCode("USD"));
                        _productService.UpdateProduct(product);

                        item.Price = price;
                        _productMappingService.UpdateProductMapping(item);
                    }
                }
                else if (Res.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    product.Deleted = true;
                    _productService.UpdateProduct(product);
                }
            }
            return null;
        }
    }
}
