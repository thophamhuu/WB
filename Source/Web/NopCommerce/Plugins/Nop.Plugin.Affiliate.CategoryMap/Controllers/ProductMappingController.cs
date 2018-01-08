using Nop.Services.Catalog;
using Nop.Services.Configuration;
using Nop.Services.Directory;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Stores;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Security;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using Nop.Core.Data;
using Nop.Core;
using Nop.Core.Plugins;
using Nop.Web.Framework.Kendoui;
using Nop.Plugin.Affiliate.CategoryMap.Domain;
using Nop.Plugin.Affiliate.CategoryMap.Models;
using Nop.Core.Domain.Catalog;
using Nop.Core.Infrastructure;
using Nop.Services.Logging;
using Nop.Core.Caching;

namespace Nop.Plugin.Affiliate.CategoryMap.Controllers
{
    [AdminAuthorize]
    public class ProductMappingController : BasePluginController
    {
        private readonly IWorkContext _workContext;
        private readonly IStoreContext _storeContext;
        private readonly IStoreService _storeService;
        private readonly ISettingService _settingService;
        private readonly ILocalizationService _localizationService;

        private readonly IRepository<ProductMapping> _productMappingRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IProductService _productService;
        private readonly ICacheManager _cacheManager;
        private const string PRODUCTS_PATTERN_KEY = "Nop.product.";
        public ProductMappingController(IWorkContext workContext,
            IStoreContext storeContext,
            IStoreService storeService,
            ISettingService settingService,
            ILocalizationService localizationService,
            IRepository<ProductMapping> productMappingRepository,
            IRepository<Product> productRepository,
            IProductService productService,
            ICacheManager cacheManager,
            IPluginFinder pluginFinder)
        {
            this._localizationService = localizationService;
            this._settingService = settingService;
            this._storeContext = storeContext;
            this._storeService = storeService;
            this._workContext = workContext;
            this._productMappingRepository = productMappingRepository;
            this._productRepository = productRepository;
            this._productService = productService;
            this._cacheManager = cacheManager;
        }
        public ActionResult LoadUrl(int productId = 0)
        {
            string url = "#";
            if (productId > 0)
            {
                var productMapping = _productMappingRepository.TableNoTracking.FirstOrDefault(x => x.ProductId == productId);
                if (productMapping != null)
                    url = productMapping.ProductSourceLink;
            }
            return Json(url, JsonRequestBehavior.AllowGet);
        }
        [ChildActionOnly]
        public ActionResult Configure()
        {
            var storeScope = this.GetActiveStoreScopeConfiguration(_storeService, _workContext);
            var mappingSettings = _settingService.LoadSetting<ProductMappingSettings>(storeScope);
            var model = new ConfigurationModel()
            {
                ActiveStoreScopeConfiguration = storeScope,
                AdditionalCostPercent = mappingSettings.AdditionalCostPercent
            };
            return View("~/Plugins/Affiliate.CategoryMap/Views/Configure.cshtml", model);
        }
        [HttpPost]
        [ChildActionOnly]
        public ActionResult Configure(ConfigurationModel model)
        {
            var storeScope = this.GetActiveStoreScopeConfiguration(_storeService, _workContext);
            var mappingSettings = _settingService.LoadSetting<ProductMappingSettings>(storeScope);

            mappingSettings.AdditionalCostPercent = model.AdditionalCostPercent;
            model.ActiveStoreScopeConfiguration = storeScope;

            _settingService.SaveSetting(mappingSettings);

            _settingService.ClearCache();
            SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));

            return Configure();
        }
        [HttpPost]
        public ActionResult UpdatePrice()
        {
            int size = 100;
            var storeScope = this.GetActiveStoreScopeConfiguration(_storeService, _workContext);
            var mappingSettings = _settingService.LoadSetting<ProductMappingSettings>(storeScope);
            var query = _productMappingRepository.TableNoTracking.Where(x => x.ProductId > 0).Select(x => new ProductMappingId
            {
                Id = x.Id,
                Price = x.Price,
                ProductId = x.ProductId
            }).OrderByDescending(x => x.Id).ToList();
            var count = query.Count();
            int PageCount = (int)Math.Ceiling((decimal)count / size);
            foreach (var item in query)
            {
                if (item.Price > 0)
                {
                    var thread = new Thread(new ThreadStart(() =>
                    {
                        var _productRepo = EngineContext.Current.Resolve<IRepository<Product>>();
                        var product = _productRepo.GetById(item.ProductId);
                        if (product != null)
                        {
                            try
                            {
                                var oldPercent = (product.Price - item.Price) / item.Price;
                                var oldPrice = product.OldPrice / (1 + oldPercent);

                                var _currencyService = EngineContext.Current.Resolve<ICurrencyService>();

                                product.OldPrice = _currencyService.ConvertToPrimaryStoreCurrency(oldPrice * (1 + mappingSettings.AdditionalCostPercent / 100), _currencyService.GetCurrencyByCode("USD"));
                                product.Price = _currencyService.ConvertToPrimaryStoreCurrency(item.Price * (1 + mappingSettings.AdditionalCostPercent / 100), _currencyService.GetCurrencyByCode("USD"));
                                _productRepo.Update(product);
                                var attrCombinations = product.ProductAttributeCombinations.ToList();
                                if (attrCombinations != null)
                                {
                                    attrCombinations.ForEach(x =>
                                    {
                                        decimal oldPriceCombination =x.OverriddenPrice.HasValue ? x.OverriddenPrice.Value / (1 + oldPercent) : 0;
                                        x.OverriddenPrice = _currencyService.ConvertToPrimaryStoreCurrency(oldPriceCombination * (1 + mappingSettings.AdditionalCostPercent / 100), _currencyService.GetCurrencyByCode("USD"));
                                    });
                                    var _productCombination = EngineContext.Current.Resolve<IRepository<ProductAttributeCombination>>();
                                    _productCombination.Update(attrCombinations);
                                }
                            }
                            catch (Exception ex)
                            {
                                var logger = EngineContext.Current.Resolve<ILogger>();
                                logger.Error(ex.Message, ex);
                            }
                        }
                    }));
                    thread.Start();
                }
            };
            _cacheManager.RemoveByPattern(PRODUCTS_PATTERN_KEY);
            return Json(new { Status = true });
        }
        public class ProductMappingId
        {
            public int Id { get; set; }
            public int ProductId { get; set; }
            public decimal Price { get; set; }
        }
    }
}
