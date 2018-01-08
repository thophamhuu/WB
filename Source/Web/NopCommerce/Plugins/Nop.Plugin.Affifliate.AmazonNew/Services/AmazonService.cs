using Newtonsoft.Json;
using Nop.Core;
using Nop.Core.Data;
using Nop.Core.Domain.Catalog;
using Nop.Core.Infrastructure;
using Nop.Plugin.Affiliate.Amazon.Core;
using Nop.Plugin.Affiliate.Amazon.Domain;
using Nop.Plugin.Affiliate.Amazon.Models;
using Nop.Plugin.Affiliate.Amazon.Models.Response;
using Nop.Plugin.Affiliate.CategoryMap;
using Nop.Plugin.Affiliate.CategoryMap.Domain;
using Nop.Plugin.Affiliate.CategoryMap.Services;
using Nop.Services.Catalog;
using Nop.Services.Configuration;
using Nop.Services.Directory;
using Nop.Services.Logging;
using Nop.Services.Media;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Nop.Plugin.Affiliate.Amazon.Services
{
    public class AmazonService : IAmazonService
    {

        private const string responseBrowseLookup = "BrowseNodeInfo";
        private const string responseItemSearch = "Small";
        private const string responseItemLookup = "Accessories,EditorialReview,Images,ItemAttributes,OfferFull,OfferListings,Offers,Reviews,SalesRank,Variations,VariationImages,VariationMatrix,VariationOffers";
        private readonly ICategoryAmazonService _categoryAmazonService;

        private readonly IProductMappingService _productMappingService;
        private readonly ISettingService _settingService;
        private readonly ICurrencyService _currencyService;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IProductAmazonService _productAmazonService;

        private readonly IRepository<CategoryMapping> _categoryMapRepo;
        private readonly IRepository<CategoryAmazon> _categoryAmazonRepo;
        private readonly IRepository<Product> _productRepo;
        private readonly IRepository<ProductMapping> _productMappingRepo;

        private readonly IRepository<ProductAttribute> _productAttributeRepo;
        private readonly IRepository<ProductAttributeMapping> _productAttributeMappingRepo;
        private readonly IRepository<ProductAttributeValue> _productAttributeValueRepo;
        private readonly IRepository<ProductAttributeCombination> _productAttributeCombinationRepo;

        private readonly IRepository<ProductSpecificationAttribute> _productSpecificationAttributeRepo;

        private readonly IProductAttributeService _productAttributeService;

        private readonly IAmazonProvider _amazonProvider;

        private const int _source = 2;
        private const string PRODUCTS_PATTERN_KEY = "Nop.product.";
        public AmazonService(ISettingService settingService,
            ICategoryAmazonService categoryAmazonService,
            IProductMappingService productMappingService,
            ICurrencyService currencyService,
            IProductService productService,
            IProductAmazonService productAmazonService,
            ICategoryService categoryService,

            IRepository<CategoryMapping> categoryMapRepo,
            IRepository<CategoryAmazon> categoryAmazonRepo,

            IRepository<Product> productRepo,
            IRepository<ProductMapping> productMappingRepo,
            IRepository<ProductAttribute> productAttributeRepo,
            IRepository<ProductAttributeMapping> productAttributeMappingRepo,
            IRepository<ProductAttributeValue> productAttributeValue,
            IRepository<ProductAttributeCombination> productAttributeCombinationRepo,

            IRepository<ProductSpecificationAttribute> productSpecificationAttributeRepo,

            IProductAttributeService productAttributeService,

            IPictureService pictureService,
            IAmazonProvider amazonProvider
            )
        {
            this._settingService = settingService;
            this._categoryAmazonService = categoryAmazonService;
            this._productMappingService = productMappingService;
            this._currencyService = currencyService;
            this._productService = productService;
            this._categoryService = categoryService;
            this._categoryMapRepo = categoryMapRepo;
            this._categoryAmazonRepo = categoryAmazonRepo;
            this._productMappingRepo = productMappingRepo;
            this._productRepo = productRepo;
            this._productAmazonService = productAmazonService;

            this._productAttributeRepo = productAttributeRepo;
            this._productAttributeMappingRepo = productAttributeMappingRepo;
            this._productAttributeValueRepo = productAttributeValue;
            this._productAttributeService = productAttributeService;
            this._productAttributeCombinationRepo = productAttributeCombinationRepo;

            this._productSpecificationAttributeRepo = productSpecificationAttributeRepo;


            this._amazonProvider = amazonProvider;
        }
        public BrowseNodeLookupResponse BrowseNodeLookup(AffiliateAmazonSettings amazonSettings, string browseNodeId, string responseGroup = "BrowseNodeInfo")
        {
            IDictionary<string, string> request = new Dictionary<string, string>();
            request["Operation"] = "BrowseNodeLookup";
            request["BrowseNodeId"] = browseNodeId;
            request["ResponseGroup"] = HttpUtility.UrlDecode(responseGroup);

            return Fetch<BrowseNodeLookupResponse>(amazonSettings, request);
        }

        public ItemLookupResponse ItemLookup(AffiliateAmazonSettings amazonSettings, string itemId, string responseGroup = "", params KeyValuePair<string, string>[] param)
        {
            if (responseGroup == "")
                responseGroup = responseItemLookup;
            IDictionary<string, string> request = new Dictionary<string, string>();
            request["Operation"] = "ItemLookup";
            request["ItemId"] = itemId;
            request["ResponseGroup"] = HttpUtility.UrlDecode(responseGroup);
            if (param != null)
            {
                foreach (var p in param)
                {
                    request.Add(p.Key, p.Value);
                }
            }
            return Fetch<ItemLookupResponse>(amazonSettings, request);
        }


        public ItemSearchResponse ItemSearch(AffiliateAmazonSettings amazonSettings, string searchIndex, string browseNode, string keywords, string responseGroup = "", params KeyValuePair<string, string>[] param)
        {
            if (responseGroup == "")
                responseGroup = responseItemSearch;
            IDictionary<string, string> request = new Dictionary<string, String>();
            if (!String.IsNullOrEmpty(keywords))
                request["Keywords"] = keywords;
            request["Operation"] = "ItemSearch";
            request["SearchIndex"] = searchIndex;
            request["BrowseNode"] = browseNode;
            request["ResponseGroup"] = HttpUtility.UrlDecode(responseGroup);
            if (param != null)
            {
                foreach (var p in param)
                {
                    request.Add(p.Key, p.Value);
                }
            }
            return Fetch<ItemSearchResponse>(amazonSettings, request);

        }
        public void SyncCategory(AffiliateAmazonSettings amazonSettings, string browseNodeID = "")
        {
            var query = _categoryAmazonRepo.Table;
            if (browseNodeID != "")
            {
                query = query.Where(x => x.BrowseNodeID == browseNodeID);
            }
            else
            {
                query = query.Where(x => x.IsCategoryRoot);
            }

            var roots = query.ToList();
            if (roots != null)
            {
                Parallel.For(0, roots.Count, new ParallelOptions { MaxDegreeOfParallelism = amazonSettings.ListAccounts.Count() },
                    stt =>
                    {
                        amazonSettings.Index = stt % amazonSettings.ListAccounts.Count();
                        var root = roots[stt];
                        SyncBrowseNode(amazonSettings, root.BrowseNodeID, root.ParentBrowseNodeID, root.SearchIndex, root.Level);
                    });
            }
            _amazonProvider.ClearCacheCategory();
        }

        public void SyncProducts(int storeId, int categoryId, string keywords = "", SyncProperties syncProperties = SyncProperties.All)
        {
            var category = _categoryService.GetCategoryById(categoryId);
            if (category == null)
                throw new ArgumentNullException("category");

            var categoryMaps = _categoryMapRepo.TableNoTracking.Where(x => x.CategoryId == categoryId && x.SourceId == (int)_source).ToList();
            if (categoryMaps != null)
            {
                AffiliateAmazonSettings amazonSettings = _settingService.LoadSetting<AffiliateAmazonSettings>(storeId);

                foreach (var categoryMap in categoryMaps)
                {
                    var browseNode = _categoryAmazonRepo.TableNoTracking.First(x => x.Id == categoryMap.CategorySourceId);
                    if (browseNode != null)
                    {
                        var productMappings = new List<ProductMapping>();
                        var syncBrowse = Parallel.For(0, 10, new ParallelOptions { MaxDegreeOfParallelism = amazonSettings.ListAccounts.Count },
                        stt =>
                        {
                            int pageIndex = stt + 1;
                            var index = stt % amazonSettings.ListAccounts.Count;
                            amazonSettings.Index = index;
                            while (amazonSettings.Wait > 0)
                            {
                                Thread.Sleep(amazonSettings.Wait);
                                amazonSettings = _settingService.LoadSetting<AffiliateAmazonSettings>(storeId);
                                amazonSettings.Index = index;
                            }
                            var itemSearchResponse = this.ItemSearch(amazonSettings, browseNode.SearchIndex, browseNode.BrowseNodeID, keywords, param: new[] { new KeyValuePair<string, string>("ItemPage", pageIndex.ToString()) });
                            if (itemSearchResponse != null)
                            {
                                foreach (var i in itemSearchResponse.Items)
                                {
                                    if (_productMappingService.GetProductBySourceId(i.ASIN, (int)_source) == null)
                                    {
                                        var productMapping = new ProductMapping
                                        {
                                            Id = 0,
                                            Price = 0,
                                            ProductId = 0,
                                            ProductSourceId = i.ASIN,
                                            ProductSourceLink = "",
                                            SourceId = 2
                                        };
                                        _productMappingRepo.Insert(productMapping);
                                        if (productMapping.Id > 0)
                                            productMappings.Add(productMapping);
                                    }
                                }
                            }
                        });
                        if (syncBrowse.IsCompleted)
                        {
                            if (productMappings != null)
                            {
                                var syncProduct = Parallel.For(0, productMappings.Count, new ParallelOptions { MaxDegreeOfParallelism = amazonSettings.ListAccounts.Count },
                                    stt =>
                                    {
                                        var _settingService = EngineContext.Current.Resolve<ISettingService>();
                                        var productMapping = productMappings[stt];
                                        int pageIndex = stt + 1;
                                        var index = stt % amazonSettings.ListAccounts.Count;
                                        amazonSettings.Index = index;
                                        while (amazonSettings.Wait > 0)
                                        {
                                            Thread.Sleep(amazonSettings.Wait);
                                            amazonSettings = _settingService.LoadSetting<AffiliateAmazonSettings>(storeId);
                                            amazonSettings.Index = index;
                                        }
                                        var itemLookupResponse = this.ItemLookup(amazonSettings, productMapping.ProductSourceId);
                                        if (itemLookupResponse != null)
                                        {
                                            SaveProduct(itemLookupResponse.Items.Item, category.Id, syncProperties);
                                        }
                                    });
                            }
                        }
                    }
                }
            }
        }

        public void UpdateProducts(int storeId, int categoryId, SyncProperties syncProperties = SyncProperties.All)
        {

            AffiliateAmazonSettings amazonSettings = _settingService.LoadSetting<AffiliateAmazonSettings>(storeId);
            int page = 1;
            int size = 100;
            var productMappings = _productAmazonService.GetAllProductMappingByCategoryId(categoryId, true, page, size).ToList();
            while (productMappings != null)
            {
                if (productMappings != null)
                {
                    var syncProduct = Parallel.For(0, productMappings.Count, new ParallelOptions { MaxDegreeOfParallelism = amazonSettings.ListAccounts.Count },
                        stt =>
                        {
                            var productMapping = productMappings[stt];
                            int pageIndex = stt + 1;

                            var index = stt % amazonSettings.ListAccounts.Count;
                            amazonSettings.Index = index;
                            while (amazonSettings.Wait > 0)
                            {
                                Thread.Sleep(amazonSettings.Wait);
                                var _settingService = EngineContext.Current.Resolve<ISettingService>();
                                amazonSettings = _settingService.LoadSetting<AffiliateAmazonSettings>(storeId);
                                amazonSettings.Index = index;
                            }
                            var itemLookupResponse = this.ItemLookup(amazonSettings, productMapping.ProductSourceId);
                            if (itemLookupResponse != null)
                            {
                                SaveProduct(itemLookupResponse.Items.Item, 0, syncProperties);
                            }
                            else
                            {
                                var _logger = EngineContext.Current.Resolve<ILogger>();
                                _logger.Warning("Item Lookup Response '" + productMapping.ProductSourceId + "' is Null");
                            }
                        });
                }
                page++;
                productMappings = _productAmazonService.GetAllProductMappingByCategoryId(categoryId, true, page, size).ToList();
            }
        }

        public void SyncProduct(int storeId, int id, SyncProperties properties)
        {
            var productMapping = _productMappingRepo.GetById(id);
            if (productMapping != null && productMapping.ProductId != 0)
            {
                var product = _productRepo.GetById(productMapping.ProductId);
                if (product != null)
                {
                    AffiliateAmazonSettings amazonSettings = _settingService.LoadSetting<AffiliateAmazonSettings>(storeId);
                    var itemLookupResponse = this.ItemLookup(amazonSettings, productMapping.ProductSourceId);
                    if (itemLookupResponse != null)
                    {
                        SaveProduct(itemLookupResponse.Items.Item, 0, properties);
                    }
                }
            }
        }
        private void SaveProduct(Item item, int categoryId, SyncProperties syncProperties)
        {
            try
            {
                var productMapping = _productMappingRepo.Table.FirstOrDefault(x => x.ProductSourceId == item.ASIN);
                if (productMapping != null)
                {
                    productMapping.ProductSourceLink = item.DetailPageURL;
                    var parentId = 0;
                    if (item.ParentASIN != item.ASIN)
                    {
                        var parentMapping = _productMappingRepo.Table.FirstOrDefault(x => x.ProductSourceId == item.ParentASIN);
                        if (parentMapping != null)
                            parentId = parentMapping.ProductId;
                    }
                    else
                    {
                        parentId = 0;
                    }
                    var product = _productRepo.GetById(productMapping.ProductId) ?? new Product
                    {
                        ParentGroupedProductId = parentId,

                        Sku = item.ASIN,

                        Name = item.ItemAttributes.Title,
                        VisibleIndividually = parentId != 0 ? false : true,
                        ProductTypeId = (int)ProductType.SimpleProduct,
                        AllowCustomerReviews = true,
                        UnlimitedDownloads = true,
                        MaxNumberOfDownloads = 10,
                        RecurringCycleLength = 100,
                        RecurringTotalCycles = 10,
                        RentalPriceLength = 1,

                        IsShipEnabled = true,

                        NotifyAdminForQuantityBelow = 1,

                        OrderMinimumQuantity = 1,
                        OrderMaximumQuantity = 10000,

                        CreatedOnUtc = DateTime.UtcNow,
                        UpdatedOnUtc = DateTime.UtcNow,
                        Published = false,
                    };
                    if (product.Id == 0)
                    {
                        _productRepo.Insert(product);
                        productMapping.ProductId = product.Id;
                        _productMappingRepo.Update(productMapping);
                    }
                    if (product.Id > 0)
                    {
                        if (product.Sku == null || product.Sku == "")
                        {
                            product.Sku = item.ASIN;
                        }
                        if (syncProperties.HasFlag(SyncProperties.DetailPageURL))
                            productMapping.ProductSourceLink = item.DetailPageURL;
                        if (syncProperties.HasFlag(SyncProperties.Name))
                            product.Name = item.ItemAttributes.Title;

                        if (syncProperties.HasFlag(SyncProperties.ShortDescription))
                            product.ShortDescription = item.ItemAttributes.Feature != null ? String.Join("\n", item.ItemAttributes.Feature) : "";

                        if (syncProperties.HasFlag(SyncProperties.FullDescription))
                            product.FullDescription = item.EditorialReviews != null ? item.EditorialReviews.EditorialReview.Content : "";



                        _productRepo.Update(product);

                        if (categoryId > 0)
                        {
                            SaveCategory(categoryId, product);
                        }

                        if (syncProperties.HasFlag(SyncProperties.Price))
                        {
                            SavePrice(item, product, productMapping);
                        }
                        if (syncProperties.HasFlag(SyncProperties.Images))
                            if (item.ImageSets != null)
                            {
                                var _pictureService = EngineContext.Current.Resolve<IPictureService>();
                                var pictures = _pictureService.GetPicturesByProductId(product.Id).ToList();
                                if (pictures != null)
                                {
                                    foreach (var picture in pictures)
                                    {
                                        _pictureService.DeletePicture(picture);
                                    }
                                }
                                SavePicture(item.ImageSets, product);
                            }
                        if (syncProperties.HasFlag(SyncProperties.Variations))
                            SaveVariations(item, product);

                    }

                }
                _amazonProvider.ClearCacheProduct();
                _amazonProvider.ClearCacheProductMapping();
            }
            catch (Exception ex)
            {
                var logger = EngineContext.Current.Resolve<ILogger>();
                logger.Error(ex.Message, ex);
            }
        }
        private void SaveAttribute(Item item, Product product)
        {
            try
            {
                var attributes = item.ItemAttributes;
                if (attributes != null)
                {

                }
            }

            catch (Exception ex)
            {
                var logger = EngineContext.Current.Resolve<ILogger>();
                logger.Error(ex.Message, ex);
            }

        }
        private void SaveVariations(Item item, Product product)
        {
            try
            {
                if (item.Variations != null)
                {
                    var variationDimensions = item.Variations.VariationDimensions;
                    if (variationDimensions != null)
                    {
                        foreach (var variationDimension in variationDimensions.VariationDimension)
                        {
                            var attr = _productAttributeRepo.TableNoTracking.FirstOrDefault(x => x.Name.ToLower() == variationDimension.ToLower()) ??
                            new ProductAttribute
                            {
                                Description = "",
                                Name = variationDimension,
                                Id = 0
                            };

                            if (attr.Id == 0)
                            {
                                _productAttributeRepo.Insert(attr);
                            }
                            if (attr.Id > 0)
                            {
                                var attrMapping = _productAttributeMappingRepo.Table.FirstOrDefault(x => x.ProductId == product.Id && x.ProductAttributeId == attr.Id) ?? new ProductAttributeMapping
                                {
                                    AttributeControlType = attr.Name.ToLower() == "color" ? AttributeControlType.ImageSquares : AttributeControlType.DropdownList,
                                    Id = 0,
                                    IsRequired = true,
                                    ProductId = product.Id,
                                    ProductAttributeId = attr.Id
                                };
                                if (attrMapping.Id == 0)
                                    _productAttributeMappingRepo.Insert(attrMapping);

                            }
                        }
                    }

                    var variations = item.Variations.Item;
                    if (variations != null)
                    {
                        var productMappings = _productAttributeService.GetProductAttributeMappingsByProductId(product.Id);
                        Parallel.For(0, variations.Count(), new ParallelOptions { MaxDegreeOfParallelism = 10 },
                            i =>
                            {
                                var _productAttributeService = EngineContext.Current.Resolve<IProductAttributeService>();
                                var _productAttributeRepo = EngineContext.Current.Resolve<IRepository<ProductAttribute>>();
                                var _productAttributeValueRepo = EngineContext.Current.Resolve<IRepository<ProductAttributeValue>>();
                                var _productAttributeCombinationRepo = EngineContext.Current.Resolve<IRepository<ProductAttributeCombination>>();
                                var _currencyService = EngineContext.Current.Resolve<ICurrencyService>();
                                var _productRepo = EngineContext.Current.Resolve<IRepository<Product>>();


                                var var = variations[i];
                                var productCombine = _productAttributeService.GetProductAttributeCombinationBySku(product.Sku) ?? new ProductAttributeCombination
                                {
                                    Id = 0,
                                    ProductId = product.Id,
                                    Sku = var.ASIN,
                                    StockQuantity = 1000,
                                    OverriddenPrice = 1000,
                                    Gtin = "",
                                    AllowOutOfStockOrders = true,
                                };
                                decimal price = 0;

                                if (var.Offers != null)
                                {
                                    var lowest = var.Offers.Offer.FirstOrDefault().OfferListing.Price;
                                    price = lowest.Amount / 100;

                                    var currency = _currencyService.GetCurrencyByCode(lowest.CurrencyCode);
                                    if (currency != null)
                                    {
                                        price = _currencyService.ConvertToPrimaryStoreCurrency(price, currency);
                                    }
                                }
                                var categorySettings = _settingService.LoadSetting<ProductMappingSettings>();
                                productCombine.OverriddenPrice = price * (1 + categorySettings.AdditionalCostPercent / 100);

                                var varAttrs = var.VariationAttributes;

                                XElement xmlAttributes = new XElement("Attributes");
                                foreach (var varAttr in var.VariationAttributes)
                                {
                                    var productAttr = _productAttributeRepo.TableNoTracking.FirstOrDefault(x => x.Name == varAttr.Name);
                                    if (productAttr != null)
                                    {
                                        var productMapping = productMappings.FirstOrDefault(x => x.ProductAttributeId == productAttr.Id);
                                        if (productMapping != null)
                                        {
                                            var xmlProductAttribute = new XElement("ProductAttribute");
                                            xmlProductAttribute.SetAttributeValue("ID", productMapping.Id);
                                            var xmlProductAttributeValue = new XElement("ProductAttributeValue");
                                            var productValue = _productAttributeValueRepo.TableNoTracking.FirstOrDefault(x => x.ProductAttributeMappingId == productMapping.Id && x.Name == varAttr.Value) ??
                                                new ProductAttributeValue
                                                {
                                                    ProductAttributeMappingId = productMapping.Id,
                                                    Name = varAttr.Value,
                                                    Id = 0,

                                                };


                                            if (productValue.Id == 0)
                                            {
                                                if (productMapping.AttributeControlType == AttributeControlType.ImageSquares)
                                                {
                                                    if (productValue.ImageSquaresPictureId == 0)
                                                    {
                                                        if (var.ImageSets != null && var.ImageSets.Count() > 0)
                                                        {
                                                            var image = SelectImage(var.ImageSets.OrderBy(x => x.Category).FirstOrDefault());

                                                            if (image != null)
                                                            {
                                                                var pictureId = SyncImage(image.URL, product.Id, "", 10);
                                                                productValue.ImageSquaresPictureId = pictureId;
                                                                productValue.PictureId = pictureId;
                                                            }
                                                        }
                                                    }
                                                }
                                                if (i == 0)
                                                {
                                                    productValue.IsPreSelected = true;

                                                    if (product.Price == 0)
                                                    {
                                                        product.Price = price;
                                                        _productRepo.Update(product);
                                                    }
                                                }

                                                _productAttributeValueRepo.Insert(productValue);
                                            }
                                            if (productValue.Id > 0)
                                            {
                                                var xmlValue = new XElement("Value");
                                                xmlValue.SetValue(productValue.Id);
                                                xmlProductAttributeValue.Add(xmlValue);
                                            }
                                            xmlProductAttribute.Add(xmlProductAttributeValue);
                                            xmlAttributes.Add(xmlProductAttribute);
                                        }
                                    }
                                }
                                productCombine.AttributesXml = xmlAttributes.ToString();
                                if (productCombine.Id == 0)
                                {

                                    _productAttributeCombinationRepo.Insert(productCombine);
                                }
                                else
                                {
                                    _productAttributeCombinationRepo.Update(productCombine);
                                }
                            });

                    }
                }
            }
            catch (Exception ex)
            {
                var logger = EngineContext.Current.Resolve<ILogger>();
                logger.Error(ex.Message, ex);
            }
        }
        private void SaveCategory(int categoryId, Product product)
        {
            try
            {
                var pc = new ProductCategory
                {
                    CategoryId = categoryId,
                    ProductId = product.Id,
                    DisplayOrder = 1
                };
                _categoryService.InsertProductCategory(pc);
            }
            catch (Exception ex)
            {
                var logger = EngineContext.Current.Resolve<ILogger>();
                logger.Error(ex.Message, ex);
            }
        }
        private void SavePrice(Item item, Product product, ProductMapping productMapping)
        {
            try
            {
                decimal originPrice = 0;
                decimal oldPrice = 0;
                decimal price = 0;

                if (item.OfferSummary != null)
                {

                    if (item.OfferSummary.LowestNewPrice != null)
                    {
                        var lowest = item.OfferSummary.LowestNewPrice;
                        originPrice = lowest.Amount / 100;

                        var currency = _currencyService.GetCurrencyByCode(lowest.CurrencyCode);
                        if (currency != null)
                        {
                            price = _currencyService.ConvertToPrimaryStoreCurrency(originPrice, currency);
                        }
                    }

                }
                if (item.ItemAttributes.ListPrice != null)
                {

                    if (item.ItemAttributes.ListPrice != null)
                    {
                        var oldest = item.ItemAttributes.ListPrice;
                        oldPrice = oldest.Amount / 100;
                        var currency = _currencyService.GetCurrencyByCode(oldest.CurrencyCode);
                        if (currency != null)
                        {
                            oldPrice = _currencyService.ConvertToPrimaryStoreCurrency(oldPrice, currency);
                        }
                    }

                }

                var categorySettings = _settingService.LoadSetting<ProductMappingSettings>();

                product.Price = price * (1 + categorySettings.AdditionalCostPercent / 100);
                product.OldPrice = oldPrice * (1 + categorySettings.AdditionalCostPercent / 100);

                productMapping.Price = originPrice;
                _productRepo.Update(product);
                _productMappingRepo.Update(productMapping);
            }
            catch (Exception ex)
            {
                var logger = EngineContext.Current.Resolve<ILogger>();
                logger.Error(ex.Message, ex);
            }
        }
        private void SavePicture(ImageSet[] imageSets, Product product)
        {
            try
            {
                int display = 1;
                Parallel.For(0, imageSets.Count(), new ParallelOptions { MaxDegreeOfParallelism = 10 }, stt =>
                {

                    display = stt + 1;
                    var image = imageSets[stt];
                    var amazonImage = SelectImage(image);
                    if (amazonImage != null)
                    {
                        display++;
                        if (!string.IsNullOrEmpty(amazonImage.URL))
                        {
                            SyncImage(amazonImage.URL, product.Id, image.Category, display);
                        }
                    }
                    Thread.Sleep(1000);
                });
            }
            catch (Exception ex)
            {
                var logger = EngineContext.Current.Resolve<ILogger>();
                logger.Error(ex.Message, ex);
            }
        }

        private int SyncImage(string url, int productId, string category, int display)
        {
            try
            {
                System.Net.HttpWebRequest _HttpWebRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);
                _HttpWebRequest.AllowWriteStreamBuffering = true;

                _HttpWebRequest.UserAgent = "Chrome/56.0.2924.87";
                _HttpWebRequest.Referer = "http://www.google.com/";

                _HttpWebRequest.Timeout = 20000;

                using (System.Net.WebResponse _WebResponse = _HttpWebRequest.GetResponse())
                {
                    using (System.IO.Stream _WebStream = _WebResponse.GetResponseStream())
                    {
                        using (var _tmpImage = Image.FromStream(_WebStream))
                        {
                            var contentType = "";
                            var fileExtension = Path.GetExtension(url);
                            if (!String.IsNullOrEmpty(fileExtension))
                                fileExtension = fileExtension.ToLowerInvariant();
                            //contentType is not always available 
                            //that's why we manually update it here
                            //http://www.sfsu.edu/training/mimetype.htm
                            if (String.IsNullOrEmpty(contentType))
                            {
                                switch (fileExtension)
                                {
                                    case ".bmp":
                                        contentType = MimeTypes.ImageBmp;
                                        break;
                                    case ".gif":
                                        contentType = MimeTypes.ImageGif;
                                        break;
                                    case ".jpeg":
                                    case ".jpg":
                                    case ".jpe":
                                    case ".jfif":
                                    case ".pjpeg":
                                    case ".pjp":
                                        contentType = MimeTypes.ImageJpeg;
                                        break;
                                    case ".png":
                                        contentType = MimeTypes.ImagePng;
                                        break;
                                    case ".tiff":
                                    case ".tif":
                                        contentType = MimeTypes.ImageTiff;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            ImageConverter converter = new ImageConverter();
                            var vendorPictureBinary = (byte[])converter.ConvertTo(_tmpImage, typeof(byte[]));

                            var _pictureService = EngineContext.Current.Resolve<IPictureService>();
                            var picture = _pictureService.InsertPicture(vendorPictureBinary, contentType, null);
                            if (picture != null && picture.Id > 0)
                            {
                                var _productService = EngineContext.Current.Resolve<IProductService>();
                                _productService.InsertProductPicture(new ProductPicture
                                {
                                    Id = 0,
                                    PictureId = picture.Id,
                                    ProductId = productId,
                                    DisplayOrder = category == "primary" ? 1 : display,
                                });
                                return picture.Id;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var logger = EngineContext.Current.Resolve<ILogger>();
                logger.Error(ex.Message, ex);
            }
            return 0;
        }

        private AmazonImage SelectImage(ImageSet imageSet)
        {
            return imageSet.HiResImage != null ? imageSet.HiResImage :
                imageSet.LargeImage != null ? imageSet.LargeImage :
                imageSet.MediumImage != null ? imageSet.MediumImage :
                imageSet.ThumbnailImage != null ? imageSet.ThumbnailImage :
                imageSet.SmallImage != null ? imageSet.SmallImage :
                imageSet.SwatchImage != null ? imageSet.SwatchImage :
                null;
        }
        private T Fetch<T>(AffiliateAmazonSettings amazonSettings, IDictionary<string, string> request) where T : class
        {
            var account = amazonSettings.Account;
            request["Service"] = amazonSettings.Service;
            request["AssociateTag"] = account.AssociateTag;
            request["Version"] = amazonSettings.Version;
            SignedRequestHelper helper = new SignedRequestHelper(account.AccessKeyID, account.SecretKey, amazonSettings.Endpoint);
            string requestUrl = helper.Sign(request);
            string _awsNamespace = string.Format("http://webservices.amazon.com/{0}/{1}", "AWSECommerceService", "2013-08-01");
            try
            {
                HttpWebRequest webRequest = (System.Net.HttpWebRequest)HttpWebRequest.Create(requestUrl);
                webRequest.UserAgent = "Chrome/56.0.2924.87";
                webRequest.AllowWriteStreamBuffering = true;
                webRequest.Timeout = 20000;
                using (WebResponse response = webRequest.GetResponseAsync().Result)
                {
                    UpdateAccount(account);
                    using (StreamReader xmlReader = new StreamReader(response.GetResponseStream()))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(T), _awsNamespace);
                        T result = (T)serializer.Deserialize(xmlReader);
                        if (result != null)
                        {
                            return result;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var logger = EngineContext.Current.Resolve<ILogger>();
                logger.Error(ex.Message, ex);
            }
            return null;
        }
        private List<String> Images(List<XElement> imageSetXmls)
        {
            string _awsNamespace = string.Format("http://webservices.amazon.com/{0}/{1}", "AWSECommerceService", "2013-08-01");
            var lst = new List<string>();
            foreach (var imageSetXml in imageSetXmls)
            {
                var largeXml = imageSetXml.Element("{" + _awsNamespace + "}" + "LargeImage");
                if (largeXml != null)
                {
                    lst.Add(largeXml.Element("{" + _awsNamespace + "}" + "URL").Value);
                }
                else
                {
                    var mediumXml = imageSetXml.Element("{" + _awsNamespace + "}" + "MediumImage");
                    if (mediumXml != null)
                    {
                        lst.Add(mediumXml.Element("{" + _awsNamespace + "}" + "URL").Value);
                    }
                    else
                    {
                        var smallXml = imageSetXml.Element("{" + _awsNamespace + "}" + "SmallImage");
                        if (smallXml != null)
                        {
                            lst.Add(smallXml.Element("{" + _awsNamespace + "}" + "URL").Value);
                        }
                    }
                }
            }
            return lst;
        }
        private void ConvertFormatPriceToSystemPrice(string formatPrice, out decimal price)
        {
            price = 0M;
            if (!string.IsNullOrEmpty(formatPrice))
            {
                Regex rg = new Regex(@"[\d]+(.[\d][\d]*)?");
                string currencyCode = rg.Replace(formatPrice, "");
                string priceStr = formatPrice.Replace(currencyCode, "");

                Decimal.TryParse(priceStr, out price);
            }
        }
        private void SyncBrowseNode(AffiliateAmazonSettings amazonSettings, string browseNodeId, string parentBrowseNodeId, string searchIndex, int level)
        {
            var browseNodeLookup = this.BrowseNodeLookup(amazonSettings, browseNodeId);
            if (browseNodeLookup != null && browseNodeLookup.BrowseNodes.BrowseNode != null)
            {

                var browseNode = browseNodeLookup.BrowseNodes.BrowseNode;
                if (browseNode != null)
                {
                    var _categoryAmazonService = EngineContext.Current.Resolve<ICategoryAmazonService>();
                    var categoryAmazon = _categoryAmazonService.GetByBrowseNodeID(browseNode.BrowseNodeId) ??
                 new CategoryAmazon
                 {
                     Id = 0,
                     BrowseNodeID = browseNode.BrowseNodeId,
                     IsCategoryRoot = browseNode.IsCategoryRoot == 1,
                     ParentBrowseNodeID = parentBrowseNodeId,
                     Name = browseNode.Name,
                     SearchIndex = searchIndex,
                     Level = level
                 };
                    if (categoryAmazon.Id == 0)
                        _categoryAmazonService.Insert(categoryAmazon);
                    else
                    {
                        categoryAmazon.BrowseNodeID = browseNode.BrowseNodeId;
                        categoryAmazon.Name = browseNode.Name;
                        categoryAmazon.Level = level;
                        _categoryAmazonService.Update(categoryAmazon);
                    }
                    if (browseNode.Children != null && browseNode.Children.Count() > 0)
                    {
                        foreach (var children in browseNode.Children)
                        {
                            var chirldAmazon = _categoryAmazonService.GetByBrowseNodeID(children.BrowseNodeId);
                            if (chirldAmazon == null)
                            {
                                _categoryAmazonService.Insert(new CategoryAmazon
                                {
                                    BrowseNodeID = children.BrowseNodeId,
                                    Id = 0,
                                    IsCategoryRoot = false,
                                    Name = children.Name,
                                    SearchIndex = categoryAmazon.SearchIndex,
                                    Level = level + 1,
                                    ParentBrowseNodeID = categoryAmazon.BrowseNodeID
                                });
                            }
                            SyncBrowseNode(amazonSettings, children.BrowseNodeId, browseNode.BrowseNodeId, categoryAmazon.SearchIndex, level + 1);
                        }
                    }
                }

            }
        }
        private void UpdateAccount(AffiliateAmazonAccount account)
        {
            var amazonSettings = _settingService.LoadSetting<AffiliateAmazonSettings>();

            var accounts = amazonSettings.ListAccounts;

            accounts.ForEach(x =>
            {
                if (x.AccessKeyID == account.AccessKeyID)
                {
                    x.UsedTime = DateTime.Now;
                }
            });

            amazonSettings.Accounts = JsonConvert.SerializeObject(accounts);
            _settingService.SaveSetting<AffiliateAmazonSettings>(amazonSettings);
            _settingService.ClearCache();
        }
    }

}
