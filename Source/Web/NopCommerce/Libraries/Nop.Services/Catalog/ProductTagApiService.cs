using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Catalog
{
    public partial class ProductTagApiService : IProductTagService
    {
        #region Methods

        /// <summary>
        /// Delete a product tag
        /// </summary>
        /// <param name="productTag">Product tag</param>
        public virtual void DeleteProductTag(ProductTag productTag)
        {
            APIHelper.Instance.PostAsync("Catalogs", "DeleteProductTag", productTag);
        }

        /// <summary>
        /// Gets all product tags
        /// </summary>
        /// <returns>Product tags</returns>
        public virtual IList<ProductTag> GetAllProductTags()
        {
            return APIHelper.Instance.GetListAsync<ProductTag>("Catalogs", "GetAllProductTags", null);
        }

        /// <summary>
        /// Gets product tag
        /// </summary>
        /// <param name="productTagId">Product tag identifier</param>
        /// <returns>Product tag</returns>
        public virtual ProductTag GetProductTagById(int productTagId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("productTagId", productTagId);
            return APIHelper.Instance.GetAsync<ProductTag>("Catalogs", "GetProductTagById", parameters);
        }

        /// <summary>
        /// Gets product tag by name
        /// </summary>
        /// <param name="name">Product tag name</param>
        /// <returns>Product tag</returns>
        public virtual ProductTag GetProductTagByName(string name)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("name", name);
            return APIHelper.Instance.GetAsync<ProductTag>("Catalogs", "GetProductTagByName", parameters);
        }

        /// <summary>
        /// Inserts a product tag
        /// </summary>
        /// <param name="productTag">Product tag</param>
        public virtual void InsertProductTag(ProductTag productTag)
        {
            APIHelper.Instance.PostAsync("Catalogs", "InsertProductTag", productTag);
        }

        /// <summary>
        /// Updates the product tag
        /// </summary>
        /// <param name="productTag">Product tag</param>
        public virtual void UpdateProductTag(ProductTag productTag)
        {
            APIHelper.Instance.PostAsync("Catalogs", "UpdateProductTag", productTag);
        }

        /// <summary>
        /// Get number of products
        /// </summary>
        /// <param name="productTagId">Product tag identifier</param>
        /// <param name="storeId">Store identifier</param>
        /// <returns>Number of products</returns>
        public virtual int GetProductCount(int productTagId, int storeId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("productTagId", productTagId);
            parameters.Add("storeId", storeId);
            return APIHelper.Instance.GetAsync<int>("Catalogs", "GetProductCount", parameters);
        }

        /// <summary>
        /// Update product tags
        /// </summary>
        /// <param name="product">Product for update</param>
        /// <param name="productTags">Product tags</param>
        public virtual void UpdateProductTags(Product product, string[] productTags)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("productTags", productTags);
            APIHelper.Instance.PostAsync("Catalogs", "UpdateProductTags", product, parameters);
        }
        #endregion
    }
}
