using Nop.Core;
using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Catalog
{
    public partial class SpecificationAttributeApiService : ISpecificationAttributeService
    {
        #region Methods

        #region Specification attribute

        /// <summary>
        /// Gets a specification attribute
        /// </summary>
        /// <param name="specificationAttributeId">The specification attribute identifier</param>
        /// <returns>Specification attribute</returns>
        public virtual SpecificationAttribute GetSpecificationAttributeById(int specificationAttributeId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("specificationAttributeId", specificationAttributeId);
            return APIHelper.Instance.GetAsync<SpecificationAttribute>("Catalogs", "GetSpecificationAttributeById", parameters);
        }

        /// <summary>
        /// Gets specification attributes
        /// </summary>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Specification attributes</returns>
        public virtual IPagedList<SpecificationAttribute> GetSpecificationAttributes(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("pageIndex", pageIndex);
            parameters.Add("pageSize", pageSize);
            return APIHelper.Instance.GetPagedListAsync<SpecificationAttribute>("Catalogs", "GetSpecificationAttributes", parameters);
        }

        /// <summary>
        /// Deletes a specification attribute
        /// </summary>
        /// <param name="specificationAttribute">The specification attribute</param>
        public virtual void DeleteSpecificationAttribute(SpecificationAttribute specificationAttribute)
        {
            APIHelper.Instance.PostAsync("Catalogs", "DeleteSpecificationAttribute", specificationAttribute);
        }

        /// <summary>
        /// Inserts a specification attribute
        /// </summary>
        /// <param name="specificationAttribute">The specification attribute</param>
        public virtual void InsertSpecificationAttribute(SpecificationAttribute specificationAttribute)
        {
            APIHelper.Instance.PostAsync("Catalogs", "InsertSpecificationAttribute", specificationAttribute);
        }

        /// <summary>
        /// Updates the specification attribute
        /// </summary>
        /// <param name="specificationAttribute">The specification attribute</param>
        public virtual void UpdateSpecificationAttribute(SpecificationAttribute specificationAttribute)
        {
            APIHelper.Instance.PostAsync("Catalogs", "UpdateSpecificationAttribute", specificationAttribute);
        }

        #endregion

        #region Specification attribute option

        /// <summary>
        /// Gets a specification attribute option
        /// </summary>
        /// <param name="specificationAttributeOptionId">The specification attribute option identifier</param>
        /// <returns>Specification attribute option</returns>
        public virtual SpecificationAttributeOption GetSpecificationAttributeOptionById(int specificationAttributeOptionId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("specificationAttributeOptionId", specificationAttributeOptionId);
            return APIHelper.Instance.GetAsync<SpecificationAttributeOption>("Catalogs", "GetSpecificationAttributeOptionById", parameters);
        }


        /// <summary>
        /// Get specification attribute options by identifiers
        /// </summary>
        /// <param name="specificationAttributeOptionIds">Identifiers</param>
        /// <returns>Specification attribute options</returns>
        public virtual IList<SpecificationAttributeOption> GetSpecificationAttributeOptionsByIds(int[] specificationAttributeOptionIds)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("specificationAttributeOptionIds", string.Join(",", specificationAttributeOptionIds));
            return APIHelper.Instance.GetListAsync<SpecificationAttributeOption>("Catalogs", "GetSpecificationAttributeOptionsByIds", parameters);
        }

        /// <summary>
        /// Gets a specification attribute option by specification attribute id
        /// </summary>
        /// <param name="specificationAttributeId">The specification attribute identifier</param>
        /// <returns>Specification attribute option</returns>
        public virtual IList<SpecificationAttributeOption> GetSpecificationAttributeOptionsBySpecificationAttribute(int specificationAttributeId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("specificationAttributeId", specificationAttributeId);
            return APIHelper.Instance.GetListAsync<SpecificationAttributeOption>("Catalogs", "GetSpecificationAttributeOptionsBySpecificationAttribute", parameters);
        }

        /// <summary>
        /// Deletes a specification attribute option
        /// </summary>
        /// <param name="specificationAttributeOption">The specification attribute option</param>
        public virtual void DeleteSpecificationAttributeOption(SpecificationAttributeOption specificationAttributeOption)
        {
            APIHelper.Instance.PostAsync("Catalogs", "DeleteSpecificationAttributeOption", specificationAttributeOption);
        }

        /// <summary>
        /// Inserts a specification attribute option
        /// </summary>
        /// <param name="specificationAttributeOption">The specification attribute option</param>
        public virtual void InsertSpecificationAttributeOption(SpecificationAttributeOption specificationAttributeOption)
        {
            APIHelper.Instance.PostAsync("Catalogs", "InsertSpecificationAttributeOption", specificationAttributeOption);
        }

        /// <summary>
        /// Updates the specification attribute
        /// </summary>
        /// <param name="specificationAttributeOption">The specification attribute option</param>
        public virtual void UpdateSpecificationAttributeOption(SpecificationAttributeOption specificationAttributeOption)
        {
            APIHelper.Instance.PostAsync("Catalogs", "UpdateSpecificationAttributeOption", specificationAttributeOption);
        }

        #endregion

        #region Product specification attribute

        /// <summary>
        /// Deletes a product specification attribute mapping
        /// </summary>
        /// <param name="productSpecificationAttribute">Product specification attribute</param>
        public virtual void DeleteProductSpecificationAttribute(ProductSpecificationAttribute productSpecificationAttribute)
        {
            APIHelper.Instance.PostAsync("Catalogs", "DeleteProductSpecificationAttribute", productSpecificationAttribute);
        }

        /// <summary>
        /// Gets a product specification attribute mapping collection
        /// </summary>
        /// <param name="productId">Product identifier; 0 to load all records</param>
        /// <param name="specificationAttributeOptionId">Specification attribute option identifier; 0 to load all records</param>
        /// <param name="allowFiltering">0 to load attributes with AllowFiltering set to false, 1 to load attributes with AllowFiltering set to true, null to load all attributes</param>
        /// <param name="showOnProductPage">0 to load attributes with ShowOnProductPage set to false, 1 to load attributes with ShowOnProductPage set to true, null to load all attributes</param>
        /// <returns>Product specification attribute mapping collection</returns>
        public virtual IList<ProductSpecificationAttribute> GetProductSpecificationAttributes(int productId = 0,
            int specificationAttributeOptionId = 0, bool? allowFiltering = null, bool? showOnProductPage = null)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("productId", productId);
            parameters.Add("specificationAttributeOptionId", specificationAttributeOptionId);
            parameters.Add("allowFiltering", allowFiltering);
            parameters.Add("showOnProductPage", showOnProductPage);
            return APIHelper.Instance.GetListAsync<ProductSpecificationAttribute>("Catalogs", "GetProductSpecificationAttributes", parameters);
        }

        /// <summary>
        /// Gets a product specification attribute mapping 
        /// </summary>
        /// <param name="productSpecificationAttributeId">Product specification attribute mapping identifier</param>
        /// <returns>Product specification attribute mapping</returns>
        public virtual ProductSpecificationAttribute GetProductSpecificationAttributeById(int productSpecificationAttributeId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("productSpecificationAttributeId", productSpecificationAttributeId);
            return APIHelper.Instance.GetAsync<ProductSpecificationAttribute>("Catalogs", "GetProductSpecificationAttributeById", parameters);
        }

        /// <summary>
        /// Inserts a product specification attribute mapping
        /// </summary>
        /// <param name="productSpecificationAttribute">Product specification attribute mapping</param>
        public virtual void InsertProductSpecificationAttribute(ProductSpecificationAttribute productSpecificationAttribute)
        {
            APIHelper.Instance.PostAsync("Catalogs", "InsertProductSpecificationAttribute", productSpecificationAttribute);
        }

        /// <summary>
        /// Updates the product specification attribute mapping
        /// </summary>
        /// <param name="productSpecificationAttribute">Product specification attribute mapping</param>
        public virtual void UpdateProductSpecificationAttribute(ProductSpecificationAttribute productSpecificationAttribute)
        {
            APIHelper.Instance.PostAsync("Catalogs", "UpdateProductSpecificationAttribute", productSpecificationAttribute);
        }

        /// <summary>
        /// Gets a count of product specification attribute mapping records
        /// </summary>
        /// <param name="productId">Product identifier; 0 to load all records</param>
        /// <param name="specificationAttributeOptionId">The specification attribute option identifier; 0 to load all records</param>
        /// <returns>Count</returns>
        public virtual int GetProductSpecificationAttributeCount(int productId = 0, int specificationAttributeOptionId = 0)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("productId", productId);
            parameters.Add("specificationAttributeOptionId", specificationAttributeOptionId);
            return APIHelper.Instance.GetAsync<int>("Catalogs", "GetProductSpecificationAttributeCount", parameters);
        }

        #endregion

        #endregion
    }
}
