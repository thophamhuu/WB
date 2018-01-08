using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Shipping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Catalog
{
    public partial class ProductApiService
    {
        #region Methods

        #region Products

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="product">Product</param>
        public virtual void DeleteProduct(Product product)
        {
            APIHelper.Instance.PostAsync("Catalogs", "DeleteProduct", product);
        }

        /// <summary>
        /// Delete products
        /// </summary>
        /// <param name="products">Products</param>
        public virtual void DeleteProducts(IList<Product> products)
        {
            APIHelper.Instance.PostAsync("Catalogs", "DeleteProducts", products);
        }

        /// <summary>
        /// Gets all products displayed on the home page
        /// </summary>
        /// <returns>Products</returns>
        public virtual IList<Product> GetAllProductsDisplayedOnHomePage()
        {
            return APIHelper.Instance.GetListAsync<Product>("Catalogs", "GetAllProductsDisplayedOnHomePage", null);
        }

        /// <summary>
        /// Gets product
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <returns>Product</returns>
        public virtual Product GetProductById(int productId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("productId", productId);
            return APIHelper.Instance.GetAsync<Product>("Catalogs", "GetProductById", parameters);
        }

        /// <summary>
        /// Get products by identifiers
        /// </summary>
        /// <param name="productIds">Product identifiers</param>
        /// <returns>Products</returns>
        public virtual IList<Product> GetProductsByIds(int[] productIds)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("productIds", string.Join(",", productIds));
            return APIHelper.Instance.GetListAsync<Product>("Catalogs", "GetProductsByIds", parameters);
        }

        /// <summary>
        /// Inserts a product
        /// </summary>
        /// <param name="product">Product</param>
        public virtual void InsertProduct(Product product)
        {
            APIHelper.Instance.PostAsync("Catalogs", "InsertProduct", product);
        }

        /// <summary>
        /// Updates the product
        /// </summary>
        /// <param name="product">Product</param>
        public virtual void UpdateProduct(Product product)
        {
            APIHelper.Instance.PostAsync("Catalogs", "UpdateProduct", product);
        }

        public virtual void UpdateProducts(IList<Product> products)
        {
            APIHelper.Instance.PostAsync("Catalogs", "UpdateProducts", products);
        }

        /// <summary>
        /// Get number of product (published and visible) in certain category
        /// </summary>
        /// <param name="categoryIds">Category identifiers</param>
        /// <param name="storeId">Store identifier; 0 to load all records</param>
        /// <returns>Number of products</returns>
        public virtual int GetNumberOfProductsInCategory(IList<int> categoryIds = null, int storeId = 0)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("categoryIds", categoryIds);
            parameters.Add("storeId", storeId);
            return APIHelper.Instance.GetAsync<int>("Catalogs", "GetNumberOfProductsInCategory", parameters);
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
        public virtual IPagedList<Product> SearchProducts(
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
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("pageIndex", pageIndex);           
            parameters.Add("pageSize", pageSize);
            parameters.Add("categoryIds", categoryIds);
            parameters.Add("manufacturerId", manufacturerId);
            parameters.Add("storeId", storeId);
            parameters.Add("vendorId", vendorId);
            parameters.Add("warehouseId", warehouseId);
            parameters.Add("productType", productType);
            parameters.Add("visibleIndividuallyOnly", visibleIndividuallyOnly);
            parameters.Add("markedAsNewOnly", markedAsNewOnly);
            parameters.Add("featuredProducts", featuredProducts);
            parameters.Add("priceMin", priceMin);
            parameters.Add("priceMax", priceMax);
            parameters.Add("productTagId", productTagId);
            parameters.Add("keywords", keywords);
            parameters.Add("searchDescriptions", searchDescriptions);
            parameters.Add("searchManufacturerPartNumber", searchManufacturerPartNumber);
            parameters.Add("searchSku", searchSku);
            parameters.Add("searchProductTags", searchProductTags);
            parameters.Add("languageId", languageId);
            parameters.Add("filteredSpecs", filteredSpecs);
            parameters.Add("orderBy", orderBy);
            parameters.Add("showHidden", showHidden);
            parameters.Add("overridePublished", overridePublished);
            return APIHelper.Instance.GetPagedListAsync<Product>("Catalogs", "SearchProducts", parameters);
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
        //public virtual IPagedList<Product> SearchProducts(
        //    out IList<int> filterableSpecificationAttributeOptionIds,
        //    bool loadFilterableSpecificationAttributeOptionIds = false,
        //    int pageIndex = 0,
        //    int pageSize = int.MaxValue,
        //    IList<int> categoryIds = null,
        //    int manufacturerId = 0,
        //    int storeId = 0,
        //    int vendorId = 0,
        //    int warehouseId = 0,
        //    ProductType? productType = null,
        //    bool visibleIndividuallyOnly = false,
        //    bool markedAsNewOnly = false,
        //    bool? featuredProducts = null,
        //    decimal? priceMin = null,
        //    decimal? priceMax = null,
        //    int productTagId = 0,
        //    string keywords = null,
        //    bool searchDescriptions = false,
        //    bool searchManufacturerPartNumber = true,
        //    bool searchSku = true,
        //    bool searchProductTags = false,
        //    int languageId = 0,
        //    IList<int> filteredSpecs = null,
        //    ProductSortingEnum orderBy = ProductSortingEnum.Position,
        //    bool showHidden = false,
        //    bool? overridePublished = null)
        //{
        //    var parameters = new Dictionary<string, dynamic>();
        //    parameters.Add("pageIndex", pageIndex);
        //    parameters.Add("pageSize", pageSize);
        //    parameters.Add("categoryIds", categoryIds);
        //    parameters.Add("manufacturerId", manufacturerId);
        //    parameters.Add("storeId", storeId);
        //    parameters.Add("vendorId", vendorId);
        //    parameters.Add("warehouseId", warehouseId);
        //    parameters.Add("productType", productType);
        //    parameters.Add("visibleIndividuallyOnly", visibleIndividuallyOnly);
        //    parameters.Add("markedAsNewOnly", markedAsNewOnly);
        //    parameters.Add("featuredProducts", featuredProducts);
        //    parameters.Add("priceMin", priceMin);
        //    parameters.Add("priceMax", priceMax);
        //    parameters.Add("productTagId", productTagId);
        //    parameters.Add("keywords", keywords);
        //    parameters.Add("searchDescriptions", searchDescriptions);
        //    parameters.Add("searchManufacturerPartNumber", searchManufacturerPartNumber);
        //    parameters.Add("searchSku", searchSku);
        //    parameters.Add("searchProductTags", searchProductTags);
        //    parameters.Add("languageId", languageId);
        //    parameters.Add("filteredSpecs", filteredSpecs);
        //    parameters.Add("orderBy", orderBy);
        //    parameters.Add("showHidden", showHidden);
        //    parameters.Add("overridePublished", overridePublished);
        //    return APIHelper.Instance.GetPagedListAsync<Product>("Catalogs", "SearchProducts", parameters);
        //}

        /// <summary>
        /// Gets products by product attribute
        /// </summary>
        /// <param name="productAttributeId">Product attribute identifier</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Products</returns>
        public virtual IPagedList<Product> GetProductsByProductAtributeId(int productAttributeId,
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("productAttributeId", productAttributeId);
            parameters.Add("pageIndex", pageIndex);
            parameters.Add("pageSize", pageSize);
            return APIHelper.Instance.GetPagedListAsync<Product>("Catalogs", "GetProductsByProductAtributeId", parameters);
        }

        /// <summary>
        /// Gets associated products
        /// </summary>
        /// <param name="parentGroupedProductId">Parent product identifier (used with grouped products)</param>
        /// <param name="storeId">Store identifier; 0 to load all records</param>
        /// <param name="vendorId">Vendor identifier; 0 to load all records</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Products</returns>
        public virtual IList<Product> GetAssociatedProducts(int parentGroupedProductId,
            int storeId = 0, int vendorId = 0, bool showHidden = false)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("parentGroupedProductId", parentGroupedProductId);
            parameters.Add("storeId", storeId);
            parameters.Add("vendorId", vendorId);
            parameters.Add("showHidden", showHidden);
            return APIHelper.Instance.GetListAsync<Product>("Catalogs", "GetAssociatedProducts", parameters);
        }

        /// <summary>
        /// Update product review totals
        /// </summary>
        /// <param name="product">Product</param>
        public virtual void UpdateProductReviewTotals(Product product)
        {
            APIHelper.Instance.PostAsync("Catalogs", "UpdateProductReviewTotals", product);
        }

        /// <summary>
        /// Get low stock products
        /// </summary>
        /// <param name="vendorId">Vendor identifier; 0 to load all records</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Products</returns>
        public virtual IPagedList<Product> GetLowStockProducts(int vendorId = 0,
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("vendorId", vendorId);
            parameters.Add("pageIndex", pageIndex);
            parameters.Add("pageSize", pageSize);
            return APIHelper.Instance.GetPagedListAsync<Product>("Catalogs", "GetLowStockProducts", parameters);
        }

        /// <summary>
        /// Get low stock product combinations
        /// </summary>
        /// <param name="vendorId">Vendor identifier; 0 to load all records</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Product combinations</returns>
        public virtual IPagedList<ProductAttributeCombination> GetLowStockProductCombinations(int vendorId = 0,
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("vendorId", vendorId);
            parameters.Add("pageIndex", pageIndex);
            parameters.Add("pageSize", pageSize);
            return APIHelper.Instance.GetPagedListAsync<ProductAttributeCombination>("Catalogs", "GetLowStockProductCombinations", parameters);
        }

        /// <summary>
        /// Gets a product by SKU
        /// </summary>
        /// <param name="sku">SKU</param>
        /// <returns>Product</returns>
        public virtual Product GetProductBySku(string sku)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("sku", sku);
            return APIHelper.Instance.GetAsync<Product>("Catalogs", "GetProductBySku", parameters);
        }

        /// <summary>
        /// Gets a products by SKU array
        /// </summary>
        /// <param name="skuArray">SKU array</param>
        /// <param name="vendorId">Vendor ID; 0 to load all records</param>
        /// <returns>Products</returns>
        public IList<Product> GetProductsBySku(string[] skuArray, int vendorId = 0)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("skuArray", skuArray);
            parameters.Add("vendorId", vendorId);
            return APIHelper.Instance.GetListAsync<Product>("Catalogs", "GetProductsBySku", parameters);
        }

        /// <summary>
        /// Update HasTierPrices property (used for performance optimization)
        /// </summary>
        /// <param name="product">Product</param>
        public virtual void UpdateHasTierPricesProperty(Product product)
        {
            APIHelper.Instance.PostAsync("Catalogs", "UpdateHasTierPricesProperty", product);
        }

        /// <summary>
        /// Update HasDiscountsApplied property (used for performance optimization)
        /// </summary>
        /// <param name="product">Product</param>
        public virtual void UpdateHasDiscountsApplied(Product product)
        {
            APIHelper.Instance.PostAsync("Catalogs", "UpdateHasDiscountsApplied", product);
        }


        /// <summary>
        /// Gets number of products by vendor identifier
        /// </summary>
        /// <param name="vendorId">Vendor identifier</param>
        /// <returns>Number of products</returns>
        public int GetNumberOfProductsByVendorId(int vendorId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("vendorId", vendorId);
            return APIHelper.Instance.GetAsync<int>("Catalogs", "GetNumberOfProductsByVendorId", parameters);
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
        public virtual void AdjustInventory(Product product, int quantityToChange, string attributesXml = "", string message = "")
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("quantityToChange", quantityToChange);
            parameters.Add("attributesXml", attributesXml);
            parameters.Add("message", message);
            APIHelper.Instance.PostAsync("Catalogs", "AdjustInventory", product, parameters);
        }

        /// <summary>
        /// Reserve the given quantity in the warehouses.
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="quantity">Quantity, must be negative</param>
        public virtual void ReserveInventory(Product product, int quantity)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("quantity", quantity);
            APIHelper.Instance.PostAsync("Catalogs", "ReserveInventory", product, parameters);
        }

        /// <summary>
        /// Unblocks the given quantity reserved items in the warehouses
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="quantity">Quantity, must be positive</param>
        public virtual void UnblockReservedInventory(Product product, int quantity)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("quantity", quantity);
            APIHelper.Instance.PostAsync("Catalogs", "UnblockReservedInventory", product, parameters);
        }

        /// <summary>
        /// Book the reserved quantity
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="warehouseId">Warehouse identifier</param>
        /// <param name="quantity">Quantity, must be negative</param>
        /// <param name="message">Message for the stock quantity history</param>
        public virtual void BookReservedInventory(Product product, int warehouseId, int quantity, string message = "")
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("product", product);
            parameters.Add("warehouseId", warehouseId);
            parameters.Add("quantity", quantity);
            parameters.Add("message", message);
            APIHelper.Instance.PostAsync("Catalogs", "BookReservedInventory", parameters);
        }

        /// <summary>
        /// Reverse booked inventory (if acceptable)
        /// </summary>
        /// <param name="product">product</param>
        /// <param name="shipmentItem">Shipment item</param>
        /// <param name="message">Message for the stock quantity history</param>
        /// <returns>Quantity reversed</returns>
        public virtual int ReverseBookedInventory(Product product, ShipmentItem shipmentItem, string message = "")
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("product", product);
            parameters.Add("shipmentItem", shipmentItem);
            parameters.Add("message", message);
            return APIHelper.Instance.GetAsync<int>("Catalogs", "ReverseBookedInventory", parameters);
        }

        #endregion

        #region Related products

        /// <summary>
        /// Deletes a related product
        /// </summary>
        /// <param name="relatedProduct">Related product</param>
        public virtual void DeleteRelatedProduct(RelatedProduct relatedProduct)
        {
            APIHelper.Instance.PostAsync("Catalogs", "DeleteRelatedProduct", relatedProduct);
        }

        /// <summary>
        /// Gets related products by product identifier
        /// </summary>
        /// <param name="productId1">The first product identifier</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Related products</returns>
        public virtual IList<RelatedProduct> GetRelatedProductsByProductId1(int productId1, bool showHidden = false)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("productId1", productId1);
            parameters.Add("showHidden", showHidden);
            return APIHelper.Instance.GetListAsync<RelatedProduct>("Catalogs", "GetRelatedProductsByProductId1", parameters);
        }

        /// <summary>
        /// Gets a related product
        /// </summary>
        /// <param name="relatedProductId">Related product identifier</param>
        /// <returns>Related product</returns>
        public virtual RelatedProduct GetRelatedProductById(int relatedProductId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("relatedProductId", relatedProductId);
            return APIHelper.Instance.GetAsync<RelatedProduct>("Catalogs", "GetRelatedProductById", parameters);
        }

        /// <summary>
        /// Inserts a related product
        /// </summary>
        /// <param name="relatedProduct">Related product</param>
        public virtual void InsertRelatedProduct(RelatedProduct relatedProduct)
        {
            APIHelper.Instance.PostAsync("Catalogs", "InsertRelatedProduct", relatedProduct);
        }

        /// <summary>
        /// Updates a related product
        /// </summary>
        /// <param name="relatedProduct">Related product</param>
        public virtual void UpdateRelatedProduct(RelatedProduct relatedProduct)
        {
            APIHelper.Instance.PostAsync("Catalogs", "UpdateRelatedProduct", relatedProduct);
        }

        #endregion

        #region Cross-sell products

        /// <summary>
        /// Deletes a cross-sell product
        /// </summary>
        /// <param name="crossSellProduct">Cross-sell identifier</param>
        public virtual void DeleteCrossSellProduct(CrossSellProduct crossSellProduct)
        {
            APIHelper.Instance.PostAsync("Catalogs", "DeleteCrossSellProduct", crossSellProduct);
        }

        /// <summary>
        /// Gets cross-sell products by product identifier
        /// </summary>
        /// <param name="productId1">The first product identifier</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Cross-sell products</returns>
        public virtual IList<CrossSellProduct> GetCrossSellProductsByProductId1(int productId1, bool showHidden = false)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("productId1", productId1);
            parameters.Add("showHidden", showHidden);
            return APIHelper.Instance.GetListAsync<CrossSellProduct>("Catalogs", "GetCrossSellProductsByProductId1", parameters);
        }

        /// <summary>
        /// Gets a cross-sell product
        /// </summary>
        /// <param name="crossSellProductId">Cross-sell product identifier</param>
        /// <returns>Cross-sell product</returns>
        public virtual CrossSellProduct GetCrossSellProductById(int crossSellProductId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("crossSellProductId", crossSellProductId);
            return APIHelper.Instance.GetAsync<CrossSellProduct>("Catalogs", "GetCrossSellProductById", parameters);
        }

        /// <summary>
        /// Inserts a cross-sell product
        /// </summary>
        /// <param name="crossSellProduct">Cross-sell product</param>
        public virtual void InsertCrossSellProduct(CrossSellProduct crossSellProduct)
        {
            APIHelper.Instance.PostAsync("Catalogs", "InsertCrossSellProduct", crossSellProduct);
        }

        /// <summary>
        /// Updates a cross-sell product
        /// </summary>
        /// <param name="crossSellProduct">Cross-sell product</param>
        public virtual void UpdateCrossSellProduct(CrossSellProduct crossSellProduct)
        {
            APIHelper.Instance.PostAsync("Catalogs", "UpdateCrossSellProduct", crossSellProduct);
        }

        /// <summary>
        /// Gets a cross-sells
        /// </summary>
        /// <param name="cart">Shopping cart</param>
        /// <param name="numberOfProducts">Number of products to return</param>
        /// <returns>Cross-sells</returns>
        public virtual IList<Product> GetCrosssellProductsByShoppingCart(IList<ShoppingCartItem> cart, int numberOfProducts)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("cart", cart);
            parameters.Add("numberOfProducts", numberOfProducts);
            return APIHelper.Instance.GetListAsync<Product>("Catalogs", "GetCrosssellProductsByShoppingCart", parameters);
        }
        #endregion

        #region Tier prices

        /// <summary>
        /// Deletes a tier price
        /// </summary>
        /// <param name="tierPrice">Tier price</param>
        public virtual void DeleteTierPrice(TierPrice tierPrice)
        {
            APIHelper.Instance.PostAsync("Catalogs", "DeleteTierPrice", tierPrice);
        }

        /// <summary>
        /// Gets a tier price
        /// </summary>
        /// <param name="tierPriceId">Tier price identifier</param>
        /// <returns>Tier price</returns>
        public virtual TierPrice GetTierPriceById(int tierPriceId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("tierPriceId", tierPriceId);
            return APIHelper.Instance.GetAsync<TierPrice>("Catalogs", "GetTierPriceById", parameters);
        }

        /// <summary>
        /// Inserts a tier price
        /// </summary>
        /// <param name="tierPrice">Tier price</param>
        public virtual void InsertTierPrice(TierPrice tierPrice)
        {
            APIHelper.Instance.PostAsync("Catalogs", "InsertTierPrice", tierPrice);
        }

        /// <summary>
        /// Updates the tier price
        /// </summary>
        /// <param name="tierPrice">Tier price</param>
        public virtual void UpdateTierPrice(TierPrice tierPrice)
        {
            APIHelper.Instance.PostAsync("Catalogs", "UpdateTierPrice", tierPrice);
        }

        #endregion

        #region Product pictures

        /// <summary>
        /// Deletes a product picture
        /// </summary>
        /// <param name="productPicture">Product picture</param>
        public virtual void DeleteProductPicture(ProductPicture productPicture)
        {
            APIHelper.Instance.PostAsync("Catalogs", "DeleteProductPicture", productPicture);
        }

        /// <summary>
        /// Gets a product pictures by product identifier
        /// </summary>
        /// <param name="productId">The product identifier</param>
        /// <returns>Product pictures</returns>
        public virtual IList<ProductPicture> GetProductPicturesByProductId(int productId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("productId", productId);
            return APIHelper.Instance.GetListAsync<ProductPicture>("Catalogs", "GetProductPicturesByProductId", parameters);
        }

        /// <summary>
        /// Gets a product picture
        /// </summary>
        /// <param name="productPictureId">Product picture identifier</param>
        /// <returns>Product picture</returns>
        public virtual ProductPicture GetProductPictureById(int productPictureId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("productPictureId", productPictureId);
            return APIHelper.Instance.GetAsync<ProductPicture>("Catalogs", "GetProductPictureById", parameters);
        }

        /// <summary>
        /// Inserts a product picture
        /// </summary>
        /// <param name="productPicture">Product picture</param>
        public virtual void InsertProductPicture(ProductPicture productPicture)
        {
            APIHelper.Instance.PostAsync("Catalogs", "InsertProductPicture", productPicture);
        }

        /// <summary>
        /// Updates a product picture
        /// </summary>
        /// <param name="productPicture">Product picture</param>
        public virtual void UpdateProductPicture(ProductPicture productPicture)
        {
            APIHelper.Instance.PostAsync("Catalogs", "UpdateProductPicture", productPicture);
        }

        /// <summary>
        /// Get the IDs of all product images 
        /// </summary>
        /// <param name="productsIds">Products IDs</param>
        /// <returns>All picture identifiers grouped by product ID</returns>
        public IDictionary<int, int[]> GetProductsImagesIds(int[] productsIds)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("productsIds", string.Join(",", productsIds));
            return APIHelper.Instance.GetAsync<IDictionary<int, int[]>>("Catalogs", "GetProductsImagesIds", parameters);
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
        public virtual IPagedList<ProductReview> GetAllProductReviews(int customerId, bool? approved,
            DateTime? fromUtc = null, DateTime? toUtc = null,
            string message = null, int storeId = 0, int productId = 0, int vendorId = 0,
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customerId", customerId);
            parameters.Add("approved", approved);
            if (fromUtc.HasValue)
                parameters.Add("fromUtc", CommonHelper.DateTimeUtcToStringAPI(fromUtc.Value));
            if (toUtc.HasValue)
                parameters.Add("toUtc", CommonHelper.DateTimeUtcToStringAPI(toUtc.Value));
            parameters.Add("message", message);
            parameters.Add("storeId", storeId);
            parameters.Add("productId", productId);
            parameters.Add("vendorId", vendorId);
            parameters.Add("pageIndex", pageIndex);
            parameters.Add("pageSize", pageSize);
            return APIHelper.Instance.GetPagedListAsync<ProductReview>("Catalogs", "GetAllProductReviews", parameters);
        }

        /// <summary>
        /// Gets product review
        /// </summary>
        /// <param name="productReviewId">Product review identifier</param>
        /// <returns>Product review</returns>
        public virtual ProductReview GetProductReviewById(int productReviewId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("productReviewId", productReviewId);
            return APIHelper.Instance.GetAsync<ProductReview>("Catalogs", "GetProductReviewById", parameters);
        }

        /// <summary>
        /// Get product reviews by identifiers
        /// </summary>
        /// <param name="productReviewIds">Product review identifiers</param>
        /// <returns>Product reviews</returns>
        public virtual IList<ProductReview> GetProducReviewsByIds(int[] productReviewIds)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("productReviewIds", string.Join(",", productReviewIds));
            return APIHelper.Instance.GetListAsync<ProductReview>("Catalogs", "GetProducReviewsByIds", parameters);
        }

        /// <summary>
        /// Deletes a product review
        /// </summary>
        /// <param name="productReview">Product review</param>
        public virtual void DeleteProductReview(ProductReview productReview)
        {
            APIHelper.Instance.PostAsync("Catalogs", "DeleteProductReview", productReview);
        }

        /// <summary>
        /// Deletes product reviews
        /// </summary>
        /// <param name="productReviews">Product reviews</param>
        public virtual void DeleteProductReviews(IList<ProductReview> productReviews)
        {
            APIHelper.Instance.PostAsync("Catalogs", "DeleteProductReviews", productReviews);
        }

        #endregion

        #region Product warehouse inventory

        /// <summary>
        /// Deletes a ProductWarehouseInventory
        /// </summary>
        /// <param name="pwi">ProductWarehouseInventory</param>
        public virtual void DeleteProductWarehouseInventory(ProductWarehouseInventory pwi)
        {
            APIHelper.Instance.PostAsync("Catalogs", "DeleteProductWarehouseInventory", pwi);
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
        public virtual void AddStockQuantityHistoryEntry(Product product, int quantityAdjustment, int stockQuantity,
            int warehouseId = 0, string message = "", int? combinationId = null)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("product", product);
            parameters.Add("quantityAdjustment", quantityAdjustment);
            parameters.Add("stockQuantity", stockQuantity);
            parameters.Add("warehouseId", warehouseId);
            parameters.Add("message", message);
            parameters.Add("combinationId", combinationId);
            APIHelper.Instance.PostAsync("Catalogs", "AddStockQuantityHistoryEntry", parameters);
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
        public virtual IPagedList<StockQuantityHistory> GetStockQuantityHistory(Product product, int warehouseId = 0, int combinationId = 0,
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var parameters = new Dictionary<string, dynamic>();       
            parameters.Add("product", product);
            parameters.Add("warehouseId", warehouseId);
            parameters.Add("combinationId", combinationId);
            parameters.Add("pageIndex", pageIndex);
            parameters.Add("pageSize", pageSize);
            return APIHelper.Instance.GetPagedListAsync<StockQuantityHistory>("Catalogs", "GetStockQuantityHistory", parameters);
        }

        #endregion

        #endregion
    }
}
