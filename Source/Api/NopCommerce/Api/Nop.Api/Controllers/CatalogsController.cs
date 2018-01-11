using Nop.Api.Models.Requests;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Shipping;
using Nop.Services.Catalog;
using Nop.Services.Discounts;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nop.Api.Controllers
{
    [Authorize]
    public class CatalogsController : ApiController
    {
        #region Fields

        private readonly IBackInStockSubscriptionService _backInStockSubscriptionService;
        private readonly ICategoryService _categoryService;
        private readonly ICategoryTemplateService _categoryTemplateService;
        private readonly ICompareProductsService _compareProductsService;
        private readonly ICopyProductService _copyProductService;
        private readonly IManufacturerService _manufacturerService;
        private readonly IManufacturerTemplateService _manufacturerTemplateService;
        private readonly IPriceCalculationService _priceCalculationService;
        private readonly IProductAttributeService _productAttributeService;
        private readonly IProductService _productService;
        private readonly IProductTagService _productTagService;
        private readonly IProductTemplateService _productTemplateService;
        private readonly IRecentlyViewedProductsService _recentlyViewedProductsService;
        private readonly ISpecificationAttributeService _specificationAttributeService;

        #endregion

        #region Ctor

        public CatalogsController(IBackInStockSubscriptionService backInStockSubscriptionService, ICategoryService categoryService, ICategoryTemplateService categoryTemplateService,
            ICompareProductsService compareProductsService, ICopyProductService copyProductService, IManufacturerService manufacturerService, IManufacturerTemplateService manufacturerTemplateService, IPriceCalculationService priceCalculationService, IProductAttributeService productAttributeService, IProductService productService,
            IProductTagService productTagService, IProductTemplateService productTemplateService, IRecentlyViewedProductsService recentlyViewedProductsService,
            ISpecificationAttributeService specificationAttributeService)
        {
            this._backInStockSubscriptionService = backInStockSubscriptionService;
            this._categoryService = categoryService;
            this._categoryTemplateService = categoryTemplateService;
            this._compareProductsService = compareProductsService;
            this._copyProductService = copyProductService;
            this._manufacturerService = manufacturerService;
            this._manufacturerTemplateService = manufacturerTemplateService;
            this._priceCalculationService = priceCalculationService;
            this._productAttributeService = productAttributeService;
            this._productService = productService;
            this._productTagService = productTagService;
            this._productTemplateService = productTemplateService;
            this._recentlyViewedProductsService = recentlyViewedProductsService;
            this._specificationAttributeService = specificationAttributeService;
        }

        #endregion

        #region Method

        #region BackInStockSubscription

        /// <summary>
        /// Delete a back in stock subscription
        /// </summary>
        /// <param name="subscription">Subscription</param>
        [HttpDelete]
        public void DeleteSubscription(BackInStockSubscription subscription)
        {
            _backInStockSubscriptionService.DeleteSubscription(subscription);
        }

        /// <summary>
        /// Gets all subscriptions
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="storeId">Store identifier; pass 0 to load all records</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Subscriptions</returns>
        [HttpGet]
        public IAPIPagedList<BackInStockSubscription> GetAllSubscriptionsByCustomerId(int customerId,
            int storeId = 0, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return _backInStockSubscriptionService.GetAllSubscriptionsByCustomerId(customerId, storeId, pageIndex, pageSize).ConvertPagedListToAPIPagedList();
        }

        /// <summary>
        /// Gets all subscriptions
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <param name="storeId">Store identifier; pass 0 to load all records</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Subscriptions</returns>
        [HttpGet]
        public IAPIPagedList<BackInStockSubscription> GetAllSubscriptionsByProductId(int productId,
            int storeId = 0, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return _backInStockSubscriptionService.GetAllSubscriptionsByProductId(productId, storeId, pageIndex, pageSize).ConvertPagedListToAPIPagedList();
        }

        /// <summary>
        /// Gets all subscriptions
        /// </summary>
        /// <param name="customerId">Customer id</param>
        /// <param name="productId">Product identifier</param>
        /// <param name="storeId">Store identifier</param>
        /// <returns>Subscriptions</returns>
        [HttpGet]
        public BackInStockSubscription FindSubscription(int customerId, int productId, int storeId)
        {
            return _backInStockSubscriptionService.FindSubscription(customerId, productId, storeId);
        }

        /// <summary>
        /// Gets a subscription
        /// </summary>
        /// <param name="subscriptionId">Subscription identifier</param>
        /// <returns>Subscription</returns>
        [HttpGet]
        public BackInStockSubscription GetSubscriptionById(int subscriptionId)
        {
            return _backInStockSubscriptionService.GetSubscriptionById(subscriptionId);
        }

        /// <summary>
        /// Inserts subscription
        /// </summary>
        /// <param name="subscription">Subscription</param>
        [HttpPost]
        public void InsertSubscription(BackInStockSubscription subscription)
        {
            _backInStockSubscriptionService.InsertSubscription(subscription);
        }

        /// <summary>
        /// Updates subscription
        /// </summary>
        /// <param name="subscription">Subscription</param>
        [HttpPut]
        public void UpdateSubscription(BackInStockSubscription subscription)
        {
            _backInStockSubscriptionService.UpdateSubscription(subscription);
        }

        /// <summary>
        /// Send notification to subscribers
        /// </summary>
        /// <param name="product">Product</param>
        /// <returns>Number of sent email</returns>
        [HttpGet]
        public int SendNotificationsToSubscribers(Product product)
        {
            return _backInStockSubscriptionService.SendNotificationsToSubscribers(product);
        }

        #endregion

        #region Category

        /// <summary>
        /// Delete category
        /// </summary>
        /// <param name="category">Category</param>
        [HttpPost]
        public void DeleteCategory([FromBody]Category category)
        {
            _categoryService.DeleteCategory(category);
        }

        /// <summary>
        /// Gets all categories
        /// </summary>
        /// <param name="categoryName">Category name</param>
        /// <param name="storeId">Store identifier; 0 if you want to get all records</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Categories</returns>
        [HttpGet]
        public IAPIPagedList<Category> GetAllCategories(string categoryName = "", int storeId = 0,
            int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            return _categoryService.GetAllCategories(categoryName, storeId, pageIndex, pageSize, showHidden).ConvertPagedListToAPIPagedList();
        }

        /// <summary>
        /// Gets all categories filtered by parent category identifier
        /// </summary>
        /// <param name="parentCategoryId">Parent category identifier</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <param name="includeAllLevels">A value indicating whether we should load all child levels</param>
        /// <returns>Categories</returns>
        [HttpGet]
        public IList<Category> GetAllCategoriesByParentCategoryId(int parentCategoryId, bool showHidden = false, bool includeAllLevels = false)
        {
            return _categoryService.GetAllCategoriesByParentCategoryId(parentCategoryId, showHidden, includeAllLevels);
        }

        /// <summary>
        /// Gets all categories displayed on the home page
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Categories</returns>
        [HttpGet]
        public IList<Category> GetAllCategoriesDisplayedOnHomePage(bool showHidden = false)
        {
            return _categoryService.GetAllCategoriesDisplayedOnHomePage(showHidden);
        }

        /// <summary>
        /// Gets a category
        /// </summary>
        /// <param name="categoryId">Category identifier</param>
        /// <returns>Category</returns>
        [HttpGet]
        public Category GetCategoryById(int categoryId)
        {
            return _categoryService.GetCategoryById(categoryId);
        }

        /// <summary>
        /// Inserts category
        /// </summary>
        /// <param name="category">Category</param>
        [HttpPost]
        public void InsertCategory([FromBody]Category category)
        {
            _categoryService.InsertCategory(category);
        }

        /// <summary>
        /// Updates the category
        /// </summary>
        /// <param name="category">Category</param>
        [HttpPut]
        public void UpdateCategory([FromBody]Category category)
        {
            _categoryService.UpdateCategory(category);
        }

        /// <summary>
        /// Deletes a product category mapping
        /// </summary>
        /// <param name="productCategory">Product category</param>
        [HttpDelete]
        public void DeleteProductCategory([FromBody]ProductCategory productCategory)
        {
            _categoryService.DeleteProductCategory(productCategory);
        }

        /// <summary>
        /// Gets product category mapping collection
        /// </summary>
        /// <param name="categoryId">Category identifier</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Product a category mapping collection</returns>
        [HttpGet]
        public IAPIPagedList<ProductCategory> GetProductCategoriesByCategoryId(int categoryId,
            int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            return _categoryService.GetProductCategoriesByCategoryId(categoryId, pageIndex, pageSize, showHidden).ConvertPagedListToAPIPagedList();
        }

        /// <summary>
        /// Gets a product category mapping collection
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Product category mapping collection</returns>
        [HttpGet]
        public IList<ProductCategory> GetProductCategoriesByProductId(int productId, bool showHidden = false)
        {
            return _categoryService.GetProductCategoriesByProductId(productId, showHidden);
        }

        /// <summary>
        /// Gets a product category mapping collection
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <param name="storeId">Store identifier (used in multi-store environment). "showHidden" parameter should also be "true"</param>
        /// <param name="showHidden"> A value indicating whether to show hidden records</param>
        /// <returns> Product category mapping collection</returns>
        [HttpGet]
        public IList<ProductCategory> GetProductCategoriesByProductId(int productId, int storeId, bool showHidden = false)
        {
            return _categoryService.GetProductCategoriesByProductId(productId, storeId, showHidden);
        }

        /// <summary>
        /// Gets a product category mapping 
        /// </summary>
        /// <param name="productCategoryId">Product category mapping identifier</param>
        /// <returns>Product category mapping</returns>
        [HttpGet]
        public ProductCategory GetProductCategoryById(int productCategoryId)
        {
            return _categoryService.GetProductCategoryById(productCategoryId);
        }

        /// <summary>
        /// Inserts a product category mapping
        /// </summary>
        /// <param name="productCategory">>Product category mapping</param>
        [HttpPost]
        public void InsertProductCategory([FromBody]ProductCategory productCategory)
        {
            _categoryService.InsertProductCategory(productCategory);
        }

        /// <summary>
        /// Updates the product category mapping 
        /// </summary>
        /// <param name="productCategory">>Product category mapping</param>
        [HttpPut]
        public void UpdateProductCategory([FromBody]ProductCategory productCategory)
        {
            _categoryService.UpdateProductCategory(productCategory);
        }

        /// <summary>
        /// Returns a list of names of not existing categories
        /// </summary>
        /// <param name="categoryNames">The nemes of the categories to check</param>
        /// <returns>List of names not existing categories</returns>
        [HttpGet]
        public string[] GetNotExistingCategories(string[] categoryNames)
        {
            return _categoryService.GetNotExistingCategories(categoryNames);
        }

        /// <summary>
        /// Get category IDs for products
        /// </summary>
        /// <param name="productIds">Products IDs</param>
        /// <returns>Category IDs for products</returns>
        [HttpGet]
        public IDictionary<int, int[]> GetProductCategoryIds(int[] productIds)
        {
            return _categoryService.GetProductCategoryIds(productIds);
        }

        #endregion

        #region CategoryTemplate

        /// <summary>
        /// Delete category template
        /// </summary>
        /// <param name="categoryTemplate">Category template</param>
        [HttpDelete]
        public void DeleteCategoryTemplate(CategoryTemplate categoryTemplate)
        {
            _categoryTemplateService.DeleteCategoryTemplate(categoryTemplate);
        }

        /// <summary>
        /// Gets all category templates
        /// </summary>
        /// <returns>Category templates</returns>
        [HttpGet]
        public IList<CategoryTemplate> GetAllCategoryTemplates()
        {
            return _categoryTemplateService.GetAllCategoryTemplates();
        }

        /// <summary>
        /// Gets a category template
        /// </summary>
        /// <param name="categoryTemplateId">Category template identifier</param>
        /// <returns>Category template</returns>
        [HttpGet]
        public CategoryTemplate GetCategoryTemplateById(int categoryTemplateId)
        {
            return _categoryTemplateService.GetCategoryTemplateById(categoryTemplateId);
        }

        /// <summary>
        /// Inserts category template
        /// </summary>
        /// <param name="categoryTemplate">Category template</param>
        [HttpPost]
        public void InsertCategoryTemplate(CategoryTemplate categoryTemplate)
        {
            _categoryTemplateService.InsertCategoryTemplate(categoryTemplate);
        }

        /// <summary>
        /// Updates the category template
        /// </summary>
        /// <param name="categoryTemplate">Category template</param>
        [HttpPut]
        public void UpdateCategoryTemplate(CategoryTemplate categoryTemplate)
        {
            _categoryTemplateService.UpdateCategoryTemplate(categoryTemplate);
        }

        #endregion

        #region  CompareProducts

        /// <summary>
        /// Clears a "compare products" list
        /// </summary>
        [HttpGet]
        public void ClearCompareProducts()
        {
            _compareProductsService.ClearCompareProducts();
        }

        /// <summary>
        /// Gets a "compare products" list
        /// </summary>
        /// <returns>"Compare products" list</returns>
        [HttpGet]
        public IList<Product> GetComparedProducts()
        {
            return _compareProductsService.GetComparedProducts();
        }

        /// <summary>
        /// Removes a product from a "compare products" list
        /// </summary>
        /// <param name="productId">Product identifier</param>
        [HttpGet]
        public void RemoveProductFromCompareList(int productId)
        {
            _compareProductsService.RemoveProductFromCompareList(productId);
        }

        /// <summary>
        /// Adds a product to a "compare products" list
        /// </summary>
        /// <param name="productId">Product identifier</param>
        [HttpGet]
        public void AddProductToCompareList(int productId)
        {
            _compareProductsService.AddProductToCompareList(productId);
        }

        #endregion

        #region CopyProduct

        /// <summary>
        /// Create a copy of product with all depended data
        /// </summary>
        /// <param name="product">The product to copy</param>
        /// <param name="newName">The name of product duplicate</param>
        /// <param name="isPublished">A value indicating whether the product duplicate should be published</param>
        /// <param name="copyImages">A value indicating whether the product images should be copied</param>
        /// <param name="copyAssociatedProducts">A value indicating whether the copy associated products</param>
        /// <returns>Product copy</returns>
        public Product CopyProduct(Product product, string newName,
            bool isPublished = true, bool copyImages = true, bool copyAssociatedProducts = true)
        {
            return _copyProductService.CopyProduct(product, newName, isPublished, copyImages, copyAssociatedProducts);
        }

        #endregion

        #region Manufacturers

        /// <summary>
        /// Deletes a manufacturer
        /// </summary>
        /// <param name="manufacturer">Manufacturer</param>
        public void DeleteManufacturer(Manufacturer manufacturer)
        {
            _manufacturerService.DeleteManufacturer(manufacturer);
        }

        /// <summary>
        /// Gets all manufacturers
        /// </summary>
        /// <param name="manufacturerName">Manufacturer name</param>
        /// <param name="storeId">Store identifier; 0 if you want to get all records</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Manufacturers</returns>
        public IAPIPagedList<Manufacturer> GetAllManufacturers(string manufacturerName = "", int storeId = 0, int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            return _manufacturerService.GetAllManufacturers(manufacturerName, storeId, pageIndex, pageSize, showHidden).ConvertPagedListToAPIPagedList();
        }

        /// <summary>
        /// Gets a manufacturer
        /// </summary>
        /// <param name="manufacturerId">Manufacturer identifier</param>
        /// <returns>Manufacturer</returns>
        public Manufacturer GetManufacturerById(int manufacturerId)
        {
            return _manufacturerService.GetManufacturerById(manufacturerId);
        }

        /// <summary>
        /// Inserts a manufacturer
        /// </summary>
        /// <param name="manufacturer">Manufacturer</param>
        public void InsertManufacturer(Manufacturer manufacturer)
        {
            _manufacturerService.InsertManufacturer(manufacturer);
        }

        /// <summary>
        /// Updates the manufacturer
        /// </summary>
        /// <param name="manufacturer">Manufacturer</param>
        public void UpdateManufacturer(Manufacturer manufacturer)
        {
            _manufacturerService.UpdateManufacturer(manufacturer);
        }

        /// <summary>
        /// Deletes a product manufacturer mapping
        /// </summary>
        /// <param name="productManufacturer">Product manufacturer mapping</param>
        public void DeleteProductManufacturer(ProductManufacturer productManufacturer)
        {
            _manufacturerService.DeleteProductManufacturer(productManufacturer);
        }

        /// <summary>
        /// Gets product manufacturer collection
        /// </summary>
        /// <param name="manufacturerId">Manufacturer identifier</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Product manufacturer collection</returns>
        public IAPIPagedList<ProductManufacturer> GetProductManufacturersByManufacturerId(int manufacturerId,
            int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            return _manufacturerService.GetProductManufacturersByManufacturerId(manufacturerId, pageIndex, pageSize, showHidden).ConvertPagedListToAPIPagedList();
        }

        /// <summary>
        /// Gets a product manufacturer mapping collection
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Product manufacturer mapping collection</returns>
        public IList<ProductManufacturer> GetProductManufacturersByProductId(int productId, bool showHidden = false)
        {
            return _manufacturerService.GetProductManufacturersByProductId(productId, showHidden);
        }

        /// <summary>
        /// Gets a product manufacturer mapping 
        /// </summary>
        /// <param name="productManufacturerId">Product manufacturer mapping identifier</param>
        /// <returns>Product manufacturer mapping</returns>
        public ProductManufacturer GetProductManufacturerById(int productManufacturerId)
        {
            return _manufacturerService.GetProductManufacturerById(productManufacturerId);
        }

        /// <summary>
        /// Inserts a product manufacturer mapping
        /// </summary>
        /// <param name="productManufacturer">Product manufacturer mapping</param>
        public void InsertProductManufacturer(ProductManufacturer productManufacturer)
        {
            _manufacturerService.InsertProductManufacturer(productManufacturer);
        }

        /// <summary>
        /// Updates the product manufacturer mapping
        /// </summary>
        /// <param name="productManufacturer">Product manufacturer mapping</param>
        public void UpdateProductManufacturer(ProductManufacturer productManufacturer)
        {
            _manufacturerService.UpdateProductManufacturer(productManufacturer);
        }

        /// <summary>
        /// Get manufacturer IDs for products
        /// </summary>
        /// <param name="productIds">Products IDs</param>
        /// <returns>Manufacturer IDs for products</returns>
        public IDictionary<int, int[]> GetProductManufacturerIds(int[] productIds)
        {
            return _manufacturerService.GetProductManufacturerIds(productIds);
        }

        /// <summary>
        /// Returns a list of names of not existing manufacturers
        /// </summary>
        /// <param name="manufacturerNames">The names of the manufacturers to check</param>
        /// <returns>List of names not existing manufacturers</returns>
        public string[] GetNotExistingManufacturers(string[] manufacturerNames)
        {
            return _manufacturerService.GetNotExistingManufacturers(manufacturerNames);
        }

        #endregion

        #region ManufacturerTemplates

        /// <summary>
        /// Delete manufacturer template
        /// </summary>
        /// <param name="manufacturerTemplate">Manufacturer template</param>
        public void DeleteManufacturerTemplate(ManufacturerTemplate manufacturerTemplate)
        {
            _manufacturerTemplateService.DeleteManufacturerTemplate(manufacturerTemplate);
        }

        /// <summary>
        /// Gets all manufacturer templates
        /// </summary>
        /// <returns>Manufacturer templates</returns>
        public IList<ManufacturerTemplate> GetAllManufacturerTemplates()
        {
            return _manufacturerTemplateService.GetAllManufacturerTemplates();
        }

        /// <summary>
        /// Gets a manufacturer template
        /// </summary>
        /// <param name="manufacturerTemplateId">Manufacturer template identifier</param>
        /// <returns>Manufacturer template</returns>
        public ManufacturerTemplate GetManufacturerTemplateById(int manufacturerTemplateId)
        {
            return _manufacturerTemplateService.GetManufacturerTemplateById(manufacturerTemplateId);
        }

        /// <summary>
        /// Inserts manufacturer template
        /// </summary>
        /// <param name="manufacturerTemplate">Manufacturer template</param>
        void InsertManufacturerTemplate(ManufacturerTemplate manufacturerTemplate)
        {
            _manufacturerTemplateService.InsertManufacturerTemplate(manufacturerTemplate);
        }

        /// <summary>
        /// Updates the manufacturer template
        /// </summary>
        /// <param name="manufacturerTemplate">Manufacturer template</param>
        public void UpdateManufacturerTemplate(ManufacturerTemplate manufacturerTemplate)
        {
            _manufacturerTemplateService.UpdateManufacturerTemplate(manufacturerTemplate);
        }

        #endregion

        #region PriceCalculations

        /// <summary>
        /// Gets the final price
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="customer">The customer</param>
        /// <param name="additionalCharge">Additional charge</param>
        /// <param name="includeDiscounts">A value indicating whether include discounts or not for final price computation</param>
        /// <param name="quantity">Shopping cart item quantity</param>
        /// <param name="rentalStartDate">Rental period start date (for rental products)</param>
        /// <param name="rentalEndDate">Rental period end date (for rental products)</param>
        /// <param name="discountAmount">Applied discount amount</param>
        /// <param name="appliedDiscounts">Applied discounts</param>
        /// <returns>Final price</returns>
        public object GetFinalPrice([FromBody]GetFinalPriceModel model)
        {
            decimal discountAmount = model.discountAmount;
            List<DiscountForCaching> appliedDiscounts = model.appliedDiscounts;

            var result =  _priceCalculationService.GetFinalPrice(model.product, model.customer, model.additionalCharge, model.includeDiscounts, model.quantity, model.rentalStartDate, model.rentalEndDate, out discountAmount, out appliedDiscounts);

            dynamic expando = new ExpandoObject();
            expando.result = result;
            expando.discountAmount = discountAmount;
            expando.appliedDiscounts = appliedDiscounts;

            return expando;
        }

        /// <summary>
        /// Gets the shopping cart unit price (one item)
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="customer">Customer</param>
        /// <param name="shoppingCartType">Shopping cart type</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="attributesXml">Product atrributes (XML format)</param>
        /// <param name="customerEnteredPrice">Customer entered price (if specified)</param>
        /// <param name="rentalStartDate">Rental start date (null for not rental products)</param>
        /// <param name="rentalEndDate">Rental end date (null for not rental products)</param>
        /// <param name="includeDiscounts">A value indicating whether include discounts or not for price computation</param>
        /// <param name="discountAmount">Applied discount amount</param>
        /// <param name="appliedDiscounts">Applied discounts</param>
        /// <returns>Shopping cart unit price (one item)</returns>
        public object GetUnitPrice([FromBody]GetUnitPriceModel model)
        {
            decimal discountAmount = model.discountAmount;
            List<DiscountForCaching> appliedDiscounts = model.appliedDiscounts;
            var result = _priceCalculationService.GetUnitPrice(model.product, model.customer, model.shoppingCartType, model.quantity, model.attributesXml, model.customerEnteredPrice, model.rentalStartDate, model.rentalEndDate, model.includeDiscounts, out discountAmount, out appliedDiscounts);

            dynamic expando = new ExpandoObject();
            expando.result = result;
            expando.discountAmount = discountAmount;
            expando.appliedDiscounts = appliedDiscounts;

            return expando;
        }

        /// <summary>
        /// Gets the product cost (one item)
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="attributesXml">Shopping cart item attributes in XML</param>
        /// <returns>Product cost (one item)</returns>
        public decimal GetProductCost(Product product, string attributesXml)
        {
            return _priceCalculationService.GetProductCost(product, attributesXml);
        }

        /// <summary>
        /// Get a price adjustment of a product attribute value
        /// </summary>
        /// <param name="value">Product attribute value</param>
        /// <returns>Price adjustment</returns>
        public decimal GetProductAttributeValuePriceAdjustment(ProductAttributeValue value)
        {
            return _priceCalculationService.GetProductAttributeValuePriceAdjustment(value);
        }

        #endregion

        #region ProductAttributes

        #region Product attributes

        /// <summary>
        /// Deletes a product attribute
        /// </summary>
        /// <param name="productAttribute">Product attribute</param>
        public void DeleteProductAttribute([FromBody]ProductAttribute productAttribute)
        {
            _productAttributeService.DeleteProductAttribute(productAttribute);
        }

        /// <summary>
        /// Gets all product attributes
        /// </summary>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Product attributes</returns>
        public IAPIPagedList<ProductAttribute> GetAllProductAttributes(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return _productAttributeService.GetAllProductAttributes(pageIndex, pageSize).ConvertPagedListToAPIPagedList();
        }

        /// <summary>
        /// Gets a product attribute 
        /// </summary>
        /// <param name="productAttributeId">Product attribute identifier</param>
        /// <returns>Product attribute </returns>
        public ProductAttribute GetProductAttributeById(int productAttributeId)
        {
            return _productAttributeService.GetProductAttributeById(productAttributeId);
        }

        /// <summary>
        /// Inserts a product attribute
        /// </summary>
        /// <param name="productAttribute">Product attribute</param>
        public void InsertProductAttribute([FromBody]ProductAttribute productAttribute)
        {
            _productAttributeService.InsertProductAttribute(productAttribute);
        }

        /// <summary>
        /// Updates the product attribute
        /// </summary>
        /// <param name="productAttribute">Product attribute</param>
        public void UpdateProductAttribute([FromBody]ProductAttribute productAttribute)
        {
            _productAttributeService.UpdateProductAttribute(productAttribute);
        }

        /// <summary>
        /// Returns a list of IDs of not existing attributes
        /// </summary>
        /// <param name="attributeId">The IDs of the attributes to check</param>
        /// <returns>List of IDs not existing attributes</returns>
        public int[] GetNotExistingAttributes(int[] attributeId)
        {
            return _productAttributeService.GetNotExistingAttributes(attributeId);
        }

        #endregion

        #region Product attributes mappings

        /// <summary>
        /// Deletes a product attribute mapping
        /// </summary>
        /// <param name="productAttributeMapping">Product attribute mapping</param>
        public void DeleteProductAttributeMapping([FromBody]ProductAttributeMapping productAttributeMapping)
        {
            _productAttributeService.DeleteProductAttributeMapping(productAttributeMapping);
        }

        /// <summary>
        /// Gets product attribute mappings by product identifier
        /// </summary>
        /// <param name="productId">The product identifier</param>
        /// <returns>Product attribute mapping collection</returns>
        public IList<ProductAttributeMapping> GetProductAttributeMappingsByProductId(int productId)
        {
            return _productAttributeService.GetProductAttributeMappingsByProductId(productId);
        }

        /// <summary>
        /// Gets a product attribute mapping
        /// </summary>
        /// <param name="productAttributeMappingId">Product attribute mapping identifier</param>
        /// <returns>Product attribute mapping</returns>
        public ProductAttributeMapping GetProductAttributeMappingById(int productAttributeMappingId)
        {
            return _productAttributeService.GetProductAttributeMappingById(productAttributeMappingId);
        }

        /// <summary>
        /// Inserts a product attribute mapping
        /// </summary>
        /// <param name="productAttributeMapping">The product attribute mapping</param>
        public void InsertProductAttributeMapping([FromBody]ProductAttributeMapping productAttributeMapping)
        {
            _productAttributeService.InsertProductAttributeMapping(productAttributeMapping);
        }

        /// <summary>
        /// Updates the product attribute mapping
        /// </summary>
        /// <param name="productAttributeMapping">The product attribute mapping</param>
        public void UpdateProductAttributeMapping([FromBody]ProductAttributeMapping productAttributeMapping)
        {
            _productAttributeService.UpdateProductAttributeMapping(productAttributeMapping);
        }

        #endregion

        #region Product attribute values

        /// <summary>
        /// Deletes a product attribute value
        /// </summary>
        /// <param name="productAttributeValue">Product attribute value</param>
        public void DeleteProductAttributeValue([FromBody]ProductAttributeValue productAttributeValue)
        {
            _productAttributeService.DeleteProductAttributeValue(productAttributeValue);
        }

        /// <summary>
        /// Gets product attribute values by product attribute mapping identifier
        /// </summary>
        /// <param name="productAttributeMappingId">The product attribute mapping identifier</param>
        /// <returns>Product attribute values</returns>
        public IList<ProductAttributeValue> GetProductAttributeValues(int productAttributeMappingId)
        {
            return _productAttributeService.GetProductAttributeValues(productAttributeMappingId);
        }

        /// <summary>
        /// Gets a product attribute value
        /// </summary>
        /// <param name="productAttributeValueId">Product attribute value identifier</param>
        /// <returns>Product attribute value</returns>
        public ProductAttributeValue GetProductAttributeValueById(int productAttributeValueId)
        {
            return _productAttributeService.GetProductAttributeValueById(productAttributeValueId);
        }

        /// <summary>
        /// Inserts a product attribute value
        /// </summary>
        /// <param name="productAttributeValue">The product attribute value</param>
        public void InsertProductAttributeValue([FromBody]ProductAttributeValue productAttributeValue)
        {
            _productAttributeService.InsertProductAttributeValue(productAttributeValue);
        }

        /// <summary>
        /// Updates the product attribute value
        /// </summary>
        /// <param name="productAttributeValue">The product attribute value</param>
        public void UpdateProductAttributeValue([FromBody]ProductAttributeValue productAttributeValue)
        {
            _productAttributeService.UpdateProductAttributeValue(productAttributeValue);
        }

        #endregion

        #region Predefined product attribute values

        /// <summary>
        /// Deletes a predefined product attribute value
        /// </summary>
        /// <param name="ppav">Predefined product attribute value</param>
        public void DeletePredefinedProductAttributeValue([FromBody]PredefinedProductAttributeValue ppav)
        {
            _productAttributeService.DeletePredefinedProductAttributeValue(ppav);
        }

        /// <summary>
        /// Gets predefined product attribute values by product attribute identifier
        /// </summary>
        /// <param name="productAttributeId">The product attribute identifier</param>
        /// <returns>Product attribute mapping collection</returns>
        public IList<PredefinedProductAttributeValue> GetPredefinedProductAttributeValues(int productAttributeId)
        {
            return _productAttributeService.GetPredefinedProductAttributeValues(productAttributeId);
        }

        /// <summary>
        /// Gets a predefined product attribute value
        /// </summary>
        /// <param name="id">Predefined product attribute value identifier</param>
        /// <returns>Predefined product attribute value</returns>
        public PredefinedProductAttributeValue GetPredefinedProductAttributeValueById(int id)
        {
            return _productAttributeService.GetPredefinedProductAttributeValueById(id);
        }

        /// <summary>
        /// Inserts a predefined product attribute value
        /// </summary>
        /// <param name="ppav">The predefined product attribute value</param>
        public void InsertPredefinedProductAttributeValue([FromBody]PredefinedProductAttributeValue ppav)
        {
            _productAttributeService.InsertPredefinedProductAttributeValue(ppav);
        }

        /// <summary>
        /// Updates the predefined product attribute value
        /// </summary>
        /// <param name="ppav">The predefined product attribute value</param>
        public void UpdatePredefinedProductAttributeValue([FromBody]PredefinedProductAttributeValue ppav)
        {
            _productAttributeService.UpdatePredefinedProductAttributeValue(ppav);
        }

        #endregion

        #region Product attribute combinations

        /// <summary>
        /// Deletes a product attribute combination
        /// </summary>
        /// <param name="combination">Product attribute combination</param>
        public void DeleteProductAttributeCombination([FromBody]ProductAttributeCombination combination)
        {
            _productAttributeService.DeleteProductAttributeCombination(combination);
        }

        /// <summary>
        /// Gets all product attribute combinations
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <returns>Product attribute combinations</returns>
        public IList<ProductAttributeCombination> GetAllProductAttributeCombinations(int productId)
        {
            return _productAttributeService.GetAllProductAttributeCombinations(productId);
        }

        /// <summary>
        /// Gets a product attribute combination
        /// </summary>
        /// <param name="productAttributeCombinationId">Product attribute combination identifier</param>
        /// <returns>Product attribute combination</returns>
        public ProductAttributeCombination GetProductAttributeCombinationById(int productAttributeCombinationId)
        {
            return _productAttributeService.GetProductAttributeCombinationById(productAttributeCombinationId);
        }

        /// <summary>
        /// Gets a product attribute combination by SKU
        /// </summary>
        /// <param name="sku">SKU</param>
        /// <returns>Product attribute combination</returns>
        public ProductAttributeCombination GetProductAttributeCombinationBySku(string sku)
        {
            return _productAttributeService.GetProductAttributeCombinationBySku(sku);
        }

        /// <summary>
        /// Inserts a product attribute combination
        /// </summary>
        /// <param name="combination">Product attribute combination</param>
        public void InsertProductAttributeCombination([FromBody]ProductAttributeCombination combination)
        {
            _productAttributeService.InsertProductAttributeCombination(combination);
        }

        /// <summary>
        /// Updates a product attribute combination
        /// </summary>
        /// <param name="combination">Product attribute combination</param>
        public void UpdateProductAttributeCombination([FromBody]ProductAttributeCombination combination)
        {
            _productAttributeService.UpdateProductAttributeCombination(combination);
        }

        #endregion

        #endregion

        #region Products

        #region Products

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="product">Product</param>
        public void DeleteProduct([FromBody]Product product)
        {
            _productService.DeleteProduct(product);
        }

        /// <summary>
        /// Delete products
        /// </summary>
        /// <param name="products">Products</param>
        public void DeleteProducts([FromBody]IList<Product> products)
        {
            _productService.DeleteProducts(products);
        }

        /// <summary>
        /// Gets all products displayed on the home page
        /// </summary>
        /// <returns>Products</returns>
        public IList<Product> GetAllProductsDisplayedOnHomePage()
        {
            return _productService.GetAllProductsDisplayedOnHomePage();
        }

        /// <summary>
        /// Gets product
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <returns>Product</returns>
        public Product GetProductById(int productId)
        {
            return _productService.GetProductById(productId);
        }

        /// <summary>
        /// Gets products by identifier
        /// </summary>
        /// <param name="productIds">Product identifiers</param>
        /// <returns>Products</returns>
        public IList<Product> GetProductsByIds(int[] productIds)
        {
            return _productService.GetProductsByIds(productIds);
        }

        /// <summary>
        /// Inserts a product
        /// </summary>
        /// <param name="product">Product</param>
        public void InsertProduct([FromBody]Product product)
        {
            _productService.InsertProduct(product);
        }

        /// <summary>
        /// Updates the product
        /// </summary>
        /// <param name="product">Product</param>
        public void UpdateProduct([FromBody]Product product)
        {
            _productService.UpdateProduct(product);
        }

        /// <summary>
        /// Updates the products
        /// </summary>
        /// <param name="products">Product</param>
        public void UpdateProducts([FromBody]IList<Product> products)
        {
            _productService.UpdateProducts(products);
        }

        /// <summary>
        /// Get number of product (published and visible) in certain category
        /// </summary>
        /// <param name="categoryIds">Category identifiers</param>
        /// <param name="storeId">Store identifier; 0 to load all records</param>
        /// <returns>Number of products</returns>
        public int GetNumberOfProductsInCategory(IList<int> categoryIds = null, int storeId = 0)
        {
            return _productService.GetNumberOfProductsInCategory(categoryIds, storeId);
        }

        /// <summary>
        /// Search products
        /// </summary>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="categoryIds">Category identifiers</param>
        /// <param name="manufacturerId">Manufacturer identifier; 0 to load all records</param>
        /// <param name="storeId">Store identifier; 0 to load all records</param>
        /// <param name="vendorId">Vendor identifier; 0 to load all records</param>
        /// <param name="warehouseId">Warehouse identifier; 0 to load all records</param>
        /// <param name="productType">Product type; 0 to load all records</param>
        /// <param name="visibleIndividuallyOnly">A values indicating whether to load only products marked as "visible individually"; "false" to load all records; "true" to load "visible individually" only</param>
        /// <param name="markedAsNewOnly">A values indicating whether to load only products marked as "new"; "false" to load all records; "true" to load "marked as new" only</param>
        /// <param name="featuredProducts">A value indicating whether loaded products are marked as featured (relates only to categories and manufacturers). 0 to load featured products only, 1 to load not featured products only, null to load all products</param>
        /// <param name="priceMin">Minimum price; null to load all records</param>
        /// <param name="priceMax">Maximum price; null to load all records</param>
        /// <param name="productTagId">Product tag identifier; 0 to load all records</param>
        /// <param name="keywords">Keywords</param>
        /// <param name="searchDescriptions">A value indicating whether to search by a specified "keyword" in product descriptions</param>
        /// <param name="searchManufacturerPartNumber">A value indicating whether to search by a specified "keyword" in manufacturer part number</param>
        /// <param name="searchSku">A value indicating whether to search by a specified "keyword" in product SKU</param>
        /// <param name="searchProductTags">A value indicating whether to search by a specified "keyword" in product tags</param>
        /// <param name="languageId">Language identifier (search for text searching)</param>
        /// <param name="filteredSpecs">Filtered product specification identifiers</param>
        /// <param name="orderBy">Order by</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <param name="overridePublished">
        /// null - process "Published" property according to "showHidden" parameter
        /// true - load only "Published" products
        /// false - load only "Unpublished" products
        /// </param>
        /// <returns>Products</returns>
        public IAPIPagedList<Product> SearchProducts(int pageIndex = 0, int pageSize = int.MaxValue, IList<int> categoryIds = null, int manufacturerId = 0,
            int storeId = 0, int vendorId = 0, int warehouseId = 0, ProductType? productType = null, bool visibleIndividuallyOnly = false, bool markedAsNewOnly = false,
            bool? featuredProducts = null, decimal? priceMin = null, decimal? priceMax = null, int productTagId = 0, string keywords = null, bool searchDescriptions = false,
            bool searchManufacturerPartNumber = true, bool searchSku = true, bool searchProductTags = false, int languageId = 0, IList<int> filteredSpecs = null,
            ProductSortingEnum orderBy = ProductSortingEnum.Position, bool showHidden = false, bool? overridePublished = null)
        {
            return _productService.SearchProducts(pageIndex, pageSize, categoryIds, manufacturerId, storeId, vendorId, warehouseId, productType, visibleIndividuallyOnly, markedAsNewOnly,
                featuredProducts, priceMin, priceMax, productTagId, keywords, searchDescriptions, searchManufacturerPartNumber, searchSku, searchProductTags, languageId, filteredSpecs,
                orderBy, showHidden, overridePublished).ConvertPagedListToAPIPagedList();
        }

        /// <summary>
        /// Search products
        /// </summary>
        /// <param name="filterableSpecificationAttributeOptionIds">The specification attribute option identifiers applied to loaded products (all pages)</param>
        /// <param name="loadFilterableSpecificationAttributeOptionIds">A value indicating whether we should load the specification attribute option identifiers applied to loaded products (all pages)</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="categoryIds">Category identifiers</param>
        /// <param name="manufacturerId">Manufacturer identifier; 0 to load all records</param>
        /// <param name="storeId">Store identifier; 0 to load all records</param>
        /// <param name="vendorId">Vendor identifier; 0 to load all records</param>
        /// <param name="warehouseId">Warehouse identifier; 0 to load all records</param>
        /// <param name="productType">Product type; 0 to load all records</param>
        /// <param name="visibleIndividuallyOnly">A values indicating whether to load only products marked as "visible individually"; "false" to load all records; "true" to load "visible individually" only</param>
        /// <param name="markedAsNewOnly">A values indicating whether to load only products marked as "new"; "false" to load all records; "true" to load "marked as new" only</param>
        /// <param name="featuredProducts">A value indicating whether loaded products are marked as featured (relates only to categories and manufacturers). 0 to load featured products only, 1 to load not featured products only, null to load all products</param>
        /// <param name="priceMin">Minimum price; null to load all records</param>
        /// <param name="priceMax">Maximum price; null to load all records</param>
        /// <param name="productTagId">Product tag identifier; 0 to load all records</param>
        /// <param name="keywords">Keywords</param>
        /// <param name="searchDescriptions">A value indicating whether to search by a specified "keyword" in product descriptions</param>
        /// <param name="searchManufacturerPartNumber">A value indicating whether to search by a specified "keyword" in manufacturer part number</param>
        /// <param name="searchSku">A value indicating whether to search by a specified "keyword" in product SKU</param>
        /// <param name="searchProductTags">A value indicating whether to search by a specified "keyword" in product tags</param>
        /// <param name="languageId">Language identifier (search for text searching)</param>
        /// <param name="filteredSpecs">Filtered product specification identifiers</param>
        /// <param name="orderBy">Order by</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <param name="overridePublished">
        /// null - process "Published" property according to "showHidden" parameter
        /// true - load only "Published" products
        /// false - load only "Unpublished" products
        /// </param>
        /// <returns>Products</returns>
        public IAPIPagedList<Product> SearchProducts(
            out IList<int> filterableSpecificationAttributeOptionIds,
            bool loadFilterableSpecificationAttributeOptionIds = false,
            int pageIndex = 0,
            int pageSize = int.MaxValue,
            IList<int> categoryIds = null,
            int manufacturerId = 0,
            int storeId = 0,
            int vendorId = 0,
            int warehouseId = 0,
            ProductType? productType = null,
            bool visibleIndividuallyOnly = false,
            bool markedAsNewOnly = false,
            bool? featuredProducts = null,
            decimal? priceMin = null,
            decimal? priceMax = null,
            int productTagId = 0,
            string keywords = null,
            bool searchDescriptions = false,
            bool searchManufacturerPartNumber = true,
            bool searchSku = true,
            bool searchProductTags = false,
            int languageId = 0,
            IList<int> filteredSpecs = null,
            ProductSortingEnum orderBy = ProductSortingEnum.Position,
            bool showHidden = false,
            bool? overridePublished = null)
        {
            return _productService.SearchProducts(out filterableSpecificationAttributeOptionIds, loadFilterableSpecificationAttributeOptionIds, pageIndex, pageSize, categoryIds, manufacturerId, storeId, vendorId, warehouseId, productType, visibleIndividuallyOnly, markedAsNewOnly,
                featuredProducts, priceMin, priceMax, productTagId, keywords, searchDescriptions, searchManufacturerPartNumber, searchSku, searchProductTags, languageId, filteredSpecs,
                orderBy, showHidden, overridePublished).ConvertPagedListToAPIPagedList();
        }

        /// <summary>
        /// Gets products by product attribute
        /// </summary>
        /// <param name="productAttributeId">Product attribute identifier</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Products</returns>
        public IAPIPagedList<Product> GetProductsByProductAtributeId(int productAttributeId,
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return _productService.GetProductsByProductAtributeId(productAttributeId, pageIndex, pageSize).ConvertPagedListToAPIPagedList();
        }

        /// <summary>
        /// Gets associated products
        /// </summary>
        /// <param name="parentGroupedProductId">Parent product identifier (used with grouped products)</param>
        /// <param name="storeId">Store identifier; 0 to load all records</param>
        /// <param name="vendorId">Vendor identifier; 0 to load all records</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Products</returns>
        IList<Product> GetAssociatedProducts(int parentGroupedProductId,
            int storeId = 0, int vendorId = 0, bool showHidden = false)
        {
            return _productService.GetAssociatedProducts(parentGroupedProductId, storeId, vendorId, showHidden);
        }

        /// <summary>
        /// Update product review totals
        /// </summary>
        /// <param name="product">Product</param>
        public void UpdateProductReviewTotals([FromBody]Product product)
        {
            _productService.UpdateProductReviewTotals(product);
        }

        /// <summary>
        /// Get low stock products
        /// </summary>
        /// <param name="vendorId">Vendor identifier; 0 to load all records</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Products</returns>
        public IAPIPagedList<Product> GetLowStockProducts(int vendorId = 0,
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return _productService.GetLowStockProducts(vendorId, pageIndex, pageSize).ConvertPagedListToAPIPagedList();
        }

        /// <summary>
        /// Get low stock product combinations
        /// </summary>
        /// <param name="vendorId">Vendor identifier; 0 to load all records</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Product combinations</returns>
        public IAPIPagedList<ProductAttributeCombination> GetLowStockProductCombinations(int vendorId = 0,
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return _productService.GetLowStockProductCombinations(vendorId, pageIndex, pageSize).ConvertPagedListToAPIPagedList();
        }

        /// <summary>
        /// Gets a product by SKU
        /// </summary>
        /// <param name="sku">SKU</param>
        /// <returns>Product</returns>
        public Product GetProductBySku(string sku)
        {
            return _productService.GetProductBySku(sku);
        }

        /// <summary>
        /// Gets a products by SKU array
        /// </summary>
        /// <param name="skuArray">SKU array</param>
        /// <param name="vendorId">Vendor ID; 0 to load all records</param>
        /// <returns>Products</returns>
        public IList<Product> GetProductsBySku(string[] skuArray, int vendorId = 0)
        {
            return _productService.GetProductsBySku(skuArray, vendorId);
        }

        /// <summary>
        /// Update HasTierPrices property (used for performance optimization)
        /// </summary>
        /// <param name="product">Product</param>
        public void UpdateHasTierPricesProperty([FromBody]Product product)
        {
            _productService.UpdateHasTierPricesProperty(product);
        }

        /// <summary>
        /// Update HasDiscountsApplied property (used for performance optimization)
        /// </summary>
        /// <param name="product">Product</param>
        public void UpdateHasDiscountsApplied([FromBody]Product product)
        {
            _productService.UpdateHasDiscountsApplied(product);
        }

        /// <summary>
        /// Gets number of products by vendor identifier
        /// </summary>
        /// <param name="vendorId">Vendor identifier</param>
        /// <returns>Number of products</returns>
        public int GetNumberOfProductsByVendorId(int vendorId)
        {
            return _productService.GetNumberOfProductsByVendorId(vendorId);
        }

        #endregion

        #region Inventory management methods

        /// <summary>
        /// Adjust inventory
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="quantityToChange">Quantity to increase or descrease</param>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <param name="message">Message for the stock quantity history</param>
        public void AdjustInventory(Product product, int quantityToChange, string attributesXml = "", string message = "")
        {
            _productService.AdjustInventory(product, quantityToChange, attributesXml, message);
        }

        /// <summary>
        /// Reserve the given quantity in the warehouses.
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="quantity">Quantity, must be negative</param>
        public void ReserveInventory(Product product, int quantity)
        {
            _productService.ReserveInventory(product, quantity);
        }

        /// <summary>
        /// Unblocks the given quantity reserved items in the warehouses
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="quantity">Quantity, must be positive</param>
        public void UnblockReservedInventory(Product product, int quantity)
        {
            _productService.UnblockReservedInventory(product, quantity);
        }

        /// <summary>
        /// Book the reserved quantity
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="warehouseId">Warehouse identifier</param>
        /// <param name="quantity">Quantity, must be negative</param>
        /// <param name="message">Message for the stock quantity history</param>
        public void BookReservedInventory(Product product, int warehouseId, int quantity, string message = "")
        {
            _productService.BookReservedInventory(product, warehouseId, quantity, message);
        }

        /// <summary>
        /// Reverse booked inventory (if acceptable)
        /// </summary>
        /// <param name="product">product</param>
        /// <param name="shipmentItem">Shipment item</param>
        /// <returns>Quantity reversed</returns>
        /// <param name="message">Message for the stock quantity history</param>
        public int ReverseBookedInventory(Product product, ShipmentItem shipmentItem, string message = "")
        {
            return _productService.ReverseBookedInventory(product, shipmentItem, message);
        }

        #endregion

        #region Related products

        /// <summary>
        /// Deletes a related product
        /// </summary>
        /// <param name="relatedProduct">Related product</param>
        public void DeleteRelatedProduct([FromBody]RelatedProduct relatedProduct)
        {
            _productService.DeleteRelatedProduct(relatedProduct);
        }

        /// <summary>
        /// Gets related products by product identifier
        /// </summary>
        /// <param name="productId1">The first product identifier</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Related products</returns>
        public IList<RelatedProduct> GetRelatedProductsByProductId1(int productId1, bool showHidden = false)
        {
            return _productService.GetRelatedProductsByProductId1(productId1, showHidden);
        }

        /// <summary>
        /// Gets a related product
        /// </summary>
        /// <param name="relatedProductId">Related product identifier</param>
        /// <returns>Related product</returns>
        public RelatedProduct GetRelatedProductById(int relatedProductId)
        {
            return _productService.GetRelatedProductById(relatedProductId);
        }

        /// <summary>
        /// Inserts a related product
        /// </summary>
        /// <param name="relatedProduct">Related product</param>
        public void InsertRelatedProduct([FromBody]RelatedProduct relatedProduct)
        {
            _productService.InsertRelatedProduct(relatedProduct);
        }

        /// <summary>
        /// Updates a related product
        /// </summary>
        /// <param name="relatedProduct">Related product</param>
        public void UpdateRelatedProduct([FromBody]RelatedProduct relatedProduct)
        {
            _productService.UpdateRelatedProduct(relatedProduct);
        }

        #endregion

        #region Cross-sell products

        /// <summary>
        /// Deletes a cross-sell product
        /// </summary>
        /// <param name="crossSellProduct">Cross-sell</param>
        public void DeleteCrossSellProduct([FromBody]CrossSellProduct crossSellProduct)
        {
            _productService.DeleteCrossSellProduct(crossSellProduct);
        }

        /// <summary>
        /// Gets cross-sell products by product identifier
        /// </summary>
        /// <param name="productId1">The first product identifier</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Cross-sell products</returns>
        public IList<CrossSellProduct> GetCrossSellProductsByProductId1(int productId1, bool showHidden = false)
        {
            return _productService.GetCrossSellProductsByProductId1(productId1, showHidden);
        }

        /// <summary>
        /// Gets a cross-sell product
        /// </summary>
        /// <param name="crossSellProductId">Cross-sell product identifier</param>
        /// <returns>Cross-sell product</returns>
        public CrossSellProduct GetCrossSellProductById(int crossSellProductId)
        {
            return _productService.GetCrossSellProductById(crossSellProductId);
        }

        /// <summary>
        /// Inserts a cross-sell product
        /// </summary>
        /// <param name="crossSellProduct">Cross-sell product</param>
        public void InsertCrossSellProduct([FromBody]CrossSellProduct crossSellProduct)
        {
            _productService.InsertCrossSellProduct(crossSellProduct);
        }

        /// <summary>
        /// Updates a cross-sell product
        /// </summary>
        /// <param name="crossSellProduct">Cross-sell product</param>
        public void UpdateCrossSellProduct([FromBody]CrossSellProduct crossSellProduct)
        {
            _productService.UpdateCrossSellProduct(crossSellProduct);
        }

        /// <summary>
        /// Gets a cross-sells
        /// </summary>
        /// <param name="cart">Shopping cart</param>
        /// <param name="numberOfProducts">Number of products to return</param>
        /// <returns>Cross-sells</returns>
        public IList<Product> GetCrosssellProductsByShoppingCart(IList<ShoppingCartItem> cart, int numberOfProducts)
        {
            return _productService.GetCrosssellProductsByShoppingCart(cart, numberOfProducts);
        }

        #endregion

        #region Tier prices

        /// <summary>
        /// Deletes a tier price
        /// </summary>
        /// <param name="tierPrice">Tier price</param>
        public void DeleteTierPrice([FromBody]TierPrice tierPrice)
        {
            _productService.DeleteTierPrice(tierPrice);
        }

        /// <summary>
        /// Gets a tier price
        /// </summary>
        /// <param name="tierPriceId">Tier price identifier</param>
        /// <returns>Tier price</returns>
        public TierPrice GetTierPriceById(int tierPriceId)
        {
            return _productService.GetTierPriceById(tierPriceId);
        }

        /// <summary>
        /// Inserts a tier price
        /// </summary>
        /// <param name="tierPrice">Tier price</param>
        public void InsertTierPrice([FromBody]TierPrice tierPrice)
        {
            _productService.InsertTierPrice(tierPrice);
        }

        /// <summary>
        /// Updates the tier price
        /// </summary>
        /// <param name="tierPrice">Tier price</param>
        public void UpdateTierPrice([FromBody]TierPrice tierPrice)
        {
            _productService.UpdateTierPrice(tierPrice);
        }

        #endregion

        #region Product pictures

        /// <summary>
        /// Deletes a product picture
        /// </summary>
        /// <param name="productPicture">Product picture</param>
        public void DeleteProductPicture([FromBody]ProductPicture productPicture)
        {
            _productService.DeleteProductPicture(productPicture);
        }

        /// <summary>
        /// Gets a product pictures by product identifier
        /// </summary>
        /// <param name="productId">The product identifier</param>
        /// <returns>Product pictures</returns>
        public IList<ProductPicture> GetProductPicturesByProductId(int productId)
        {
            return _productService.GetProductPicturesByProductId(productId);
        }

        /// <summary>
        /// Gets a product picture
        /// </summary>
        /// <param name="productPictureId">Product picture identifier</param>
        /// <returns>Product picture</returns>
        public ProductPicture GetProductPictureById(int productPictureId)
        {
            return _productService.GetProductPictureById(productPictureId);
        }

        /// <summary>
        /// Inserts a product picture
        /// </summary>
        /// <param name="productPicture">Product picture</param>
        public void InsertProductPicture([FromBody]ProductPicture productPicture)
        {
            _productService.InsertProductPicture(productPicture);
        }

        /// <summary>
        /// Updates a product picture
        /// </summary>
        /// <param name="productPicture">Product picture</param>
        public void UpdateProductPicture([FromBody]ProductPicture productPicture)
        {
            _productService.UpdateProductPicture(productPicture);
        }

        /// <summary>
        /// Get the IDs of all product images 
        /// </summary>
        /// <param name="productsIds">Products IDs</param>
        /// <returns>All picture identifiers grouped by product ID</returns>
        public IDictionary<int, int[]> GetProductsImagesIds(int[] productsIds)
        {
            return _productService.GetProductsImagesIds(productsIds);
        }

        #endregion

        #region Product reviews

        /// <summary>
        /// Gets all product reviews
        /// </summary>
        /// <param name="customerId">Customer identifier (who wrote a review); 0 to load all records</param>
        /// <param name="approved">A value indicating whether to content is approved; null to load all records</param> 
        /// <param name="fromUtc">Item creation from; null to load all records</param>
        /// <param name="toUtc">Item item creation to; null to load all records</param>
        /// <param name="message">Search title or review text; null to load all records</param>
        /// <param name="storeId">The store identifier; pass 0 to load all records</param>
        /// <param name="productId">The product identifier; pass 0 to load all records</param>
        /// <param name="vendorId">The vendor identifier (limit to products of this vendor); pass 0 to load all records</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Reviews</returns>
        public IAPIPagedList<ProductReview> GetAllProductReviews(int customerId, bool? approved,
            DateTime? fromUtc = null, DateTime? toUtc = null,
            string message = null, int storeId = 0, int productId = 0, int vendorId = 0,
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return _productService.GetAllProductReviews(customerId, approved, fromUtc, toUtc, message, storeId, productId, vendorId, pageIndex, pageSize).ConvertPagedListToAPIPagedList();
        }

        /// <summary>
        /// Gets product review
        /// </summary>
        /// <param name="productReviewId">Product review identifier</param>
        /// <returns>Product review</returns>
        public ProductReview GetProductReviewById(int productReviewId)
        {
            return _productService.GetProductReviewById(productReviewId);
        }

        /// <summary>
        /// Get product reviews by identifiers
        /// </summary>
        /// <param name="productReviewIds">Product review identifiers</param>
        /// <returns>Product reviews</returns>
        public IList<ProductReview> GetProducReviewsByIds(int[] productReviewIds)
        {
            return _productService.GetProducReviewsByIds(productReviewIds);
        }

        /// <summary>
        /// Deletes a product review
        /// </summary>
        /// <param name="productReview">Product review</param>
        public void DeleteProductReview([FromBody]ProductReview productReview)
        {
            _productService.DeleteProductReview(productReview);
        }

        /// <summary>
        /// Deletes product reviews
        /// </summary>
        /// <param name="productReviews">Product reviews</param>
        public void DeleteProductReviews([FromBody]IList<ProductReview> productReviews)
        {
            _productService.DeleteProductReviews(productReviews);
        }

        #endregion

        #region Product warehouse inventory

        /// <summary>
        /// Deletes a ProductWarehouseInventory
        /// </summary>
        /// <param name="pwi">ProductWarehouseInventory</param>
        public void DeleteProductWarehouseInventory([FromBody]ProductWarehouseInventory pwi)
        {
            _productService.DeleteProductWarehouseInventory(pwi);
        }

        #endregion

        #region Stock quantity history

        /// <summary>
        /// Add stock quantity change entry
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="quantityAdjustment">Quantity adjustment</param>
        /// <param name="stockQuantity">Current stock quantity</param>
        /// <param name="warehouseId">Warehouse identifier</param>
        /// <param name="message">Message</param>
        /// <param name="combinationId">Product attribute combination identifier</param>
        public void AddStockQuantityHistoryEntry(Product product, int quantityAdjustment, int stockQuantity,
            int warehouseId = 0, string message = "", int? combinationId = null)
        {
            _productService.AddStockQuantityHistoryEntry(product, quantityAdjustment, stockQuantity, warehouseId, message, combinationId);
        }

        /// <summary>
        /// Get the history of the product stock quantity changes
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="warehouseId">Warehouse identifier; pass 0 to load all entries</param>
        /// <param name="combinationId">Product attribute combination identifier; pass 0 to load all entries</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>List of stock quantity change entries</returns>
        IAPIPagedList<StockQuantityHistory> GetStockQuantityHistory(Product product, int warehouseId = 0, int combinationId = 0,
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return _productService.GetStockQuantityHistory(product, warehouseId, combinationId, pageIndex, pageSize).ConvertPagedListToAPIPagedList();
        }

        #endregion

        #endregion

        #region ProductTemplates

        /// <summary>
        /// Delete product template
        /// </summary>
        /// <param name="productTemplate">Product template</param>
        public void DeleteProductTemplate([FromBody]ProductTemplate productTemplate)
        {
            _productTemplateService.DeleteProductTemplate(productTemplate);
        }

        /// <summary>
        /// Gets all product templates
        /// </summary>
        /// <returns>Product templates</returns>
        public IList<ProductTemplate> GetAllProductTemplates()
        {
            return _productTemplateService.GetAllProductTemplates();
        }

        /// <summary>
        /// Gets a product template
        /// </summary>
        /// <param name="productTemplateId">Product template identifier</param>
        /// <returns>Product template</returns>
        public ProductTemplate GetProductTemplateById(int productTemplateId)
        {
            return _productTemplateService.GetProductTemplateById(productTemplateId);
        }

        /// <summary>
        /// Inserts product template
        /// </summary>
        /// <param name="productTemplate">Product template</param>
        public void InsertProductTemplate([FromBody]ProductTemplate productTemplate)
        {
            _productTemplateService.InsertProductTemplate(productTemplate);
        }

        /// <summary>
        /// Updates the product template
        /// </summary>
        /// <param name="productTemplate">Product template</param>
        public void UpdateProductTemplate([FromBody]ProductTemplate productTemplate)
        {
            _productTemplateService.UpdateProductTemplate(productTemplate);
        }

        #endregion

        #region ProductTags

        /// <summary>
        /// Delete a product tag
        /// </summary>
        /// <param name="productTag">Product tag</param>
        public void DeleteProductTag([FromBody]ProductTag productTag)
        {
            _productTagService.DeleteProductTag(productTag);
        }

        /// <summary>
        /// Gets all product tags
        /// </summary>
        /// <returns>Product tags</returns>
        public IList<ProductTag> GetAllProductTags()
        {
            return _productTagService.GetAllProductTags();
        }

        /// <summary>
        /// Gets product tag
        /// </summary>
        /// <param name="productTagId">Product tag identifier</param>
        /// <returns>Product tag</returns>
        public ProductTag GetProductTagById(int productTagId)
        {
            return _productTagService.GetProductTagById(productTagId);
        }

        /// <summary>
        /// Gets product tag by name
        /// </summary>
        /// <param name="name">Product tag name</param>
        /// <returns>Product tag</returns>
        public ProductTag GetProductTagByName(string name)
        {
            return _productTagService.GetProductTagByName(name);
        }

        /// <summary>
        /// Inserts a product tag
        /// </summary>
        /// <param name="productTag">Product tag</param>
        public void InsertProductTag([FromBody]ProductTag productTag)
        {
            _productTagService.InsertProductTag(productTag);
        }

        /// <summary>
        /// Updates the product tag
        /// </summary>
        /// <param name="productTag">Product tag</param>
        public void UpdateProductTag([FromBody]ProductTag productTag)
        {
            _productTagService.UpdateProductTag(productTag);
        }

        /// <summary>
        /// Get number of products
        /// </summary>
        /// <param name="productTagId">Product tag identifier</param>
        /// <param name="storeId">Store identifier</param>
        /// <returns>Number of products</returns>
        public int GetProductCount(int productTagId, int storeId)
        {
            return _productTagService.GetProductCount(productTagId, storeId);
        }

        /// <summary>
        /// Update product tags
        /// </summary>
        /// <param name="product">Product for update</param>
        /// <param name="productTags">Product tags</param>
        public void UpdateProductTags([FromBody]Product product, [FromBody]string[] productTags)
        {
            _productTagService.UpdateProductTags(product, productTags);
        }

        #endregion

        #region RecentlyViewedProducts

        /// <summary>
        /// Gets a "recently viewed products" list
        /// </summary>
        /// <param name="number">Number of products to load</param>
        /// <returns>"recently viewed products" list</returns>
        public IList<Product> GetRecentlyViewedProducts(int number)
        {
            return _recentlyViewedProductsService.GetRecentlyViewedProducts(number);
        }

        /// <summary>
        /// Adds a product to a recently viewed products list
        /// </summary>
        /// <param name="productId">Product identifier</param>
        public void AddProductToRecentlyViewedList([FromBody]int productId)
        {
            _recentlyViewedProductsService.AddProductToRecentlyViewedList(productId);
        }

        #endregion

        #region SpecificationAttributes

        #region Specification attribute

        /// <summary>
        /// Gets a specification attribute
        /// </summary>
        /// <param name="specificationAttributeId">The specification attribute identifier</param>
        /// <returns>Specification attribute</returns>
        public SpecificationAttribute GetSpecificationAttributeById(int specificationAttributeId)
        {
            return _specificationAttributeService.GetSpecificationAttributeById(specificationAttributeId);
        }

        /// <summary>
        /// Gets specification attributes
        /// </summary>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Specification attributes</returns>
        public IAPIPagedList<SpecificationAttribute> GetSpecificationAttributes(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return _specificationAttributeService.GetSpecificationAttributes(pageIndex, pageSize).ConvertPagedListToAPIPagedList();
        }

        /// <summary>
        /// Deletes a specification attribute
        /// </summary>
        /// <param name="specificationAttribute">The specification attribute</param>
        public void DeleteSpecificationAttribute([FromBody]SpecificationAttribute specificationAttribute)
        {
            _specificationAttributeService.DeleteSpecificationAttribute(specificationAttribute);
        }

        /// <summary>
        /// Inserts a specification attribute
        /// </summary>
        /// <param name="specificationAttribute">The specification attribute</param>
        public void InsertSpecificationAttribute([FromBody]SpecificationAttribute specificationAttribute)
        {
            _specificationAttributeService.InsertSpecificationAttribute(specificationAttribute);
        }

        /// <summary>
        /// Updates the specification attribute
        /// </summary>
        /// <param name="specificationAttribute">The specification attribute</param>
        public void UpdateSpecificationAttribute([FromBody]SpecificationAttribute specificationAttribute)
        {
            _specificationAttributeService.UpdateSpecificationAttribute(specificationAttribute);
        }

        #endregion

        #region Specification attribute option

        /// <summary>
        /// Gets a specification attribute option
        /// </summary>
        /// <param name="specificationAttributeOption">The specification attribute option</param>
        /// <returns>Specification attribute option</returns>
        public SpecificationAttributeOption GetSpecificationAttributeOptionById(int specificationAttributeOption)
        {
            return _specificationAttributeService.GetSpecificationAttributeOptionById(specificationAttributeOption);
        }

        /// <summary>
        /// Get specification attribute options by identifiers
        /// </summary>
        /// <param name="specificationAttributeOptionIds">Identifiers</param>
        /// <returns>Specification attribute options</returns>
        public IList<SpecificationAttributeOption> GetSpecificationAttributeOptionsByIds(int[] specificationAttributeOptionIds)
        {
            return _specificationAttributeService.GetSpecificationAttributeOptionsByIds(specificationAttributeOptionIds);
        }

        /// <summary>
        /// Gets a specification attribute option by specification attribute id
        /// </summary>
        /// <param name="specificationAttributeId">The specification attribute identifier</param>
        /// <returns>Specification attribute option</returns>
        public IList<SpecificationAttributeOption> GetSpecificationAttributeOptionsBySpecificationAttribute(int specificationAttributeId)
        {
            return _specificationAttributeService.GetSpecificationAttributeOptionsBySpecificationAttribute(specificationAttributeId);
        }

        /// <summary>
        /// Deletes a specification attribute option
        /// </summary>
        /// <param name="specificationAttributeOption">The specification attribute option</param>
        public void DeleteSpecificationAttributeOption([FromBody]SpecificationAttributeOption specificationAttributeOption)
        {
            _specificationAttributeService.DeleteSpecificationAttributeOption(specificationAttributeOption);
        }

        /// <summary>
        /// Inserts a specification attribute option
        /// </summary>
        /// <param name="specificationAttributeOption">The specification attribute option</param>
        public void InsertSpecificationAttributeOption([FromBody]SpecificationAttributeOption specificationAttributeOption)
        {
            _specificationAttributeService.InsertSpecificationAttributeOption(specificationAttributeOption);
        }

        /// <summary>
        /// Updates the specification attribute
        /// </summary>
        /// <param name="specificationAttributeOption">The specification attribute option</param>
        public void UpdateSpecificationAttributeOption([FromBody]SpecificationAttributeOption specificationAttributeOption)
        {
            _specificationAttributeService.UpdateSpecificationAttributeOption(specificationAttributeOption);
        }

        #endregion

        #region Product specification attribute

        /// <summary>
        /// Deletes a product specification attribute mapping
        /// </summary>
        /// <param name="productSpecificationAttribute">Product specification attribute</param>
        public void DeleteProductSpecificationAttribute([FromBody]ProductSpecificationAttribute productSpecificationAttribute)
        {
            _specificationAttributeService.DeleteProductSpecificationAttribute(productSpecificationAttribute);
        }

        /// <summary>
        /// Gets a product specification attribute mapping collection
        /// </summary>
        /// <param name="productId">Product identifier; 0 to load all records</param>
        /// <param name="specificationAttributeOptionId">Specification attribute option identifier; 0 to load all records</param>
        /// <param name="allowFiltering">0 to load attributes with AllowFiltering set to false, 1 to load attributes with AllowFiltering set to true, null to load all attributes</param>
        /// <param name="showOnProductPage">0 to load attributes with ShowOnProductPage set to false, 1 to load attributes with ShowOnProductPage set to true, null to load all attributes</param>
        /// <returns>Product specification attribute mapping collection</returns>
        public IList<ProductSpecificationAttribute> GetProductSpecificationAttributes(int productId = 0,
            int specificationAttributeOptionId = 0, bool? allowFiltering = null, bool? showOnProductPage = null)
        {
            return _specificationAttributeService.GetProductSpecificationAttributes(productId, specificationAttributeOptionId, allowFiltering, showOnProductPage);
        }

        /// <summary>
        /// Gets a product specification attribute mapping 
        /// </summary>
        /// <param name="productSpecificationAttributeId">Product specification attribute mapping identifier</param>
        /// <returns>Product specification attribute mapping</returns>
        public ProductSpecificationAttribute GetProductSpecificationAttributeById(int productSpecificationAttributeId)
        {
            return _specificationAttributeService.GetProductSpecificationAttributeById(productSpecificationAttributeId);
        }

        /// <summary>
        /// Inserts a product specification attribute mapping
        /// </summary>
        /// <param name="productSpecificationAttribute">Product specification attribute mapping</param>
        public void InsertProductSpecificationAttribute([FromBody]ProductSpecificationAttribute productSpecificationAttribute)
        {
            _specificationAttributeService.InsertProductSpecificationAttribute(productSpecificationAttribute);
        }

        /// <summary>
        /// Updates the product specification attribute mapping
        /// </summary>
        /// <param name="productSpecificationAttribute">Product specification attribute mapping</param>
        public void UpdateProductSpecificationAttribute([FromBody]ProductSpecificationAttribute productSpecificationAttribute)
        {
            _specificationAttributeService.UpdateProductSpecificationAttribute(productSpecificationAttribute);
        }

        /// <summary>
        /// Gets a count of product specification attribute mapping records
        /// </summary>
        /// <param name="productId">Product identifier; 0 to load all records</param>
        /// <param name="specificationAttributeOptionId">The specification attribute option identifier; 0 to load all records</param>
        /// <returns>Count</returns>
        public int GetProductSpecificationAttributeCount(int productId = 0, int specificationAttributeOptionId = 0)
        {
            return _specificationAttributeService.GetProductSpecificationAttributeCount(productId, specificationAttributeOptionId);
        }

        #endregion

        #endregion

        #endregion
    }
}
