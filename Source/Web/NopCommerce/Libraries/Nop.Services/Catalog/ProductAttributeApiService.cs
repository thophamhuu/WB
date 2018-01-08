using Nop.Core;
using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Catalog
{
    public partial class ProductAttributeApiService : IProductAttributeService
    {
        #region Methods

        #region Product attributes

        /// <summary>
        /// Deletes a product attribute
        /// </summary>
        /// <param name="productAttribute">Product attribute</param>
        public virtual void DeleteProductAttribute(ProductAttribute productAttribute)
        {
            APIHelper.Instance.PostAsync("Catalogs", "DeleteProductAttribute", productAttribute);
        }

        /// <summary>
        /// Gets all product attributes
        /// </summary>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Product attributes</returns>
        public virtual IPagedList<ProductAttribute> GetAllProductAttributes(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("pageIndex", pageIndex);
            parameters.Add("pageSize", pageSize);
            return APIHelper.Instance.GetPagedListAsync<ProductAttribute>("Catalogs", "GetAllProductAttributes", parameters);
        }

        /// <summary>
        /// Gets a product attribute 
        /// </summary>
        /// <param name="productAttributeId">Product attribute identifier</param>
        /// <returns>Product attribute </returns>
        public virtual ProductAttribute GetProductAttributeById(int productAttributeId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("productAttributeId", productAttributeId);
            return APIHelper.Instance.GetAsync<ProductAttribute>("Catalogs", "GetProductAttributeById", parameters);
        }

        /// <summary>
        /// Inserts a product attribute
        /// </summary>
        /// <param name="productAttribute">Product attribute</param>
        public virtual void InsertProductAttribute(ProductAttribute productAttribute)
        {
            APIHelper.Instance.PostAsync("Catalogs", "InsertProductAttribute", productAttribute);
        }

        /// <summary>
        /// Updates the product attribute
        /// </summary>
        /// <param name="productAttribute">Product attribute</param>
        public virtual void UpdateProductAttribute(ProductAttribute productAttribute)
        {
            APIHelper.Instance.PostAsync("Catalogs", "UpdateProductAttribute", productAttribute);
        }

        /// <summary>
        /// Returns a list of IDs of not existing attributes
        /// </summary>
        /// <param name="attributeId">The IDs of the attributes to check</param>
        /// <returns>List of IDs not existing attributes</returns>
        public virtual int[] GetNotExistingAttributes(int[] attributeId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("attributeId", string.Join(",", attributeId));
            return APIHelper.Instance.GetAsync<int[]>("Catalogs", "GetNotExistingAttributes", parameters);
        }

        #endregion

        #region Product attributes mappings

        /// <summary>
        /// Deletes a product attribute mapping
        /// </summary>
        /// <param name="productAttributeMapping">Product attribute mapping</param>
        public virtual void DeleteProductAttributeMapping(ProductAttributeMapping productAttributeMapping)
        {
            APIHelper.Instance.PostAsync("Catalogs", "DeleteProductAttributeMapping", productAttributeMapping);
        }

        /// <summary>
        /// Gets product attribute mappings by product identifier
        /// </summary>
        /// <param name="productId">The product identifier</param>
        /// <returns>Product attribute mapping collection</returns>
        public virtual IList<ProductAttributeMapping> GetProductAttributeMappingsByProductId(int productId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("productId", productId);
            return APIHelper.Instance.GetListAsync<ProductAttributeMapping>("Catalogs", "GetProductAttributeMappingsByProductId", parameters);
        }

        /// <summary>
        /// Gets a product attribute mapping
        /// </summary>
        /// <param name="productAttributeMappingId">Product attribute mapping identifier</param>
        /// <returns>Product attribute mapping</returns>
        public virtual ProductAttributeMapping GetProductAttributeMappingById(int productAttributeMappingId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("productAttributeMappingId", productAttributeMappingId);
            return APIHelper.Instance.GetAsync<ProductAttributeMapping>("Catalogs", "GetProductAttributeMappingById", parameters);
        }

        /// <summary>
        /// Inserts a product attribute mapping
        /// </summary>
        /// <param name="productAttributeMapping">The product attribute mapping</param>
        public virtual void InsertProductAttributeMapping(ProductAttributeMapping productAttributeMapping)
        {
            APIHelper.Instance.PostAsync("Catalogs", "InsertProductAttributeMapping", productAttributeMapping);
        }

        /// <summary>
        /// Updates the product attribute mapping
        /// </summary>
        /// <param name="productAttributeMapping">The product attribute mapping</param>
        public virtual void UpdateProductAttributeMapping(ProductAttributeMapping productAttributeMapping)
        {
            APIHelper.Instance.PostAsync("Catalogs", "UpdateProductAttributeMapping", productAttributeMapping);
        }

        #endregion

        #region Product attribute values

        /// <summary>
        /// Deletes a product attribute value
        /// </summary>
        /// <param name="productAttributeValue">Product attribute value</param>
        public virtual void DeleteProductAttributeValue(ProductAttributeValue productAttributeValue)
        {
            APIHelper.Instance.PostAsync("Catalogs", "DeleteProductAttributeValue", productAttributeValue);
        }

        /// <summary>
        /// Gets product attribute values by product attribute mapping identifier
        /// </summary>
        /// <param name="productAttributeMappingId">The product attribute mapping identifier</param>
        /// <returns>Product attribute mapping collection</returns>
        public virtual IList<ProductAttributeValue> GetProductAttributeValues(int productAttributeMappingId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("productAttributeMappingId", productAttributeMappingId);
            return APIHelper.Instance.GetListAsync<ProductAttributeValue>("Catalogs", "GetProductAttributeValues", parameters);
        }

        /// <summary>
        /// Gets a product attribute value
        /// </summary>
        /// <param name="productAttributeValueId">Product attribute value identifier</param>
        /// <returns>Product attribute value</returns>
        public virtual ProductAttributeValue GetProductAttributeValueById(int productAttributeValueId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("productAttributeValueId", productAttributeValueId);
            return APIHelper.Instance.GetAsync<ProductAttributeValue>("Catalogs", "GetProductAttributeValueById", parameters);
        }

        /// <summary>
        /// Inserts a product attribute value
        /// </summary>
        /// <param name="productAttributeValue">The product attribute value</param>
        public virtual void InsertProductAttributeValue(ProductAttributeValue productAttributeValue)
        {
            APIHelper.Instance.PostAsync("Catalogs", "InsertProductAttributeValue", productAttributeValue);
        }

        /// <summary>
        /// Updates the product attribute value
        /// </summary>
        /// <param name="productAttributeValue">The product attribute value</param>
        public virtual void UpdateProductAttributeValue(ProductAttributeValue productAttributeValue)
        {
            APIHelper.Instance.PostAsync("Catalogs", "UpdateProductAttributeValue", productAttributeValue);
        }

        #endregion

        #region Predefined product attribute values

        /// <summary>
        /// Deletes a predefined product attribute value
        /// </summary>
        /// <param name="ppav">Predefined product attribute value</param>
        public virtual void DeletePredefinedProductAttributeValue(PredefinedProductAttributeValue ppav)
        {
            APIHelper.Instance.PostAsync("Catalogs", "DeletePredefinedProductAttributeValue", ppav);
        }

        /// <summary>
        /// Gets predefined product attribute values by product attribute identifier
        /// </summary>
        /// <param name="productAttributeId">The product attribute identifier</param>
        /// <returns>Product attribute mapping collection</returns>
        public virtual IList<PredefinedProductAttributeValue> GetPredefinedProductAttributeValues(int productAttributeId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("productAttributeId", productAttributeId);
            return APIHelper.Instance.GetListAsync<PredefinedProductAttributeValue>("Catalogs", "GetPredefinedProductAttributeValues", parameters);
        }

        /// <summary>
        /// Gets a predefined product attribute value
        /// </summary>
        /// <param name="id">Predefined product attribute value identifier</param>
        /// <returns>Predefined product attribute value</returns>
        public virtual PredefinedProductAttributeValue GetPredefinedProductAttributeValueById(int id)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("id", id);
            return APIHelper.Instance.GetAsync<PredefinedProductAttributeValue>("Catalogs", "GetPredefinedProductAttributeValueById", parameters);
        }

        /// <summary>
        /// Inserts a predefined product attribute value
        /// </summary>
        /// <param name="ppav">The predefined product attribute value</param>
        public virtual void InsertPredefinedProductAttributeValue(PredefinedProductAttributeValue ppav)
        {
            APIHelper.Instance.PostAsync("Catalogs", "InsertPredefinedProductAttributeValue", ppav);
        }

        /// <summary>
        /// Updates the predefined product attribute value
        /// </summary>
        /// <param name="ppav">The predefined product attribute value</param>
        public virtual void UpdatePredefinedProductAttributeValue(PredefinedProductAttributeValue ppav)
        {
            APIHelper.Instance.PostAsync("Catalogs", "UpdatePredefinedProductAttributeValue", ppav);
        }

        #endregion

        #region Product attribute combinations

        /// <summary>
        /// Deletes a product attribute combination
        /// </summary>
        /// <param name="combination">Product attribute combination</param>
        public virtual void DeleteProductAttributeCombination(ProductAttributeCombination combination)
        {
            APIHelper.Instance.PostAsync("Catalogs", "DeleteProductAttributeCombination", combination);
        }

        /// <summary>
        /// Gets all product attribute combinations
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <returns>Product attribute combinations</returns>
        public virtual IList<ProductAttributeCombination> GetAllProductAttributeCombinations(int productId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("productId", productId);
            return APIHelper.Instance.GetListAsync<ProductAttributeCombination>("Catalogs", "GetAllProductAttributeCombinations", parameters);
        }

        /// <summary>
        /// Gets a product attribute combination
        /// </summary>
        /// <param name="productAttributeCombinationId">Product attribute combination identifier</param>
        /// <returns>Product attribute combination</returns>
        public virtual ProductAttributeCombination GetProductAttributeCombinationById(int productAttributeCombinationId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("productAttributeCombinationId", productAttributeCombinationId);
            return APIHelper.Instance.GetAsync<ProductAttributeCombination>("Catalogs", "GetProductAttributeCombinationById", parameters);
        }

        /// <summary>
        /// Gets a product attribute combination by SKU
        /// </summary>
        /// <param name="sku">SKU</param>
        /// <returns>Product attribute combination</returns>
        public virtual ProductAttributeCombination GetProductAttributeCombinationBySku(string sku)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("sku", sku);
            return APIHelper.Instance.GetAsync<ProductAttributeCombination>("Catalogs", "GetProductAttributeCombinationBySku", parameters);
        }

        /// <summary>
        /// Inserts a product attribute combination
        /// </summary>
        /// <param name="combination">Product attribute combination</param>
        public virtual void InsertProductAttributeCombination(ProductAttributeCombination combination)
        {
            APIHelper.Instance.PostAsync("Catalogs", "InsertProductAttributeCombination", combination);
        }

        /// <summary>
        /// Updates a product attribute combination
        /// </summary>
        /// <param name="combination">Product attribute combination</param>
        public virtual void UpdateProductAttributeCombination(ProductAttributeCombination combination)
        {
            APIHelper.Instance.PostAsync("Catalogs", "UpdateProductAttributeCombination", combination);
        }

        #endregion

        #endregion
    }
}
