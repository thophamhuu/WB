using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Catalog
{
    public partial class CopyProductApiService : ICopyProductService
    {
        #region Methods

        /// <summary>
        /// Create a copy of product with all depended data
        /// </summary>
        /// <param name="product">The product to copy</param>
        /// <param name="newName">The name of product duplicate</param>
        /// <param name="isPublished">A value indicating whether the product duplicate should be published</param>
        /// <param name="copyImages">A value indicating whether the product images should be copied</param>
        /// <param name="copyAssociatedProducts">A value indicating whether the copy associated products</param>
        /// <returns>Product copy</returns>
        public virtual Product CopyProduct(Product product, string newName,
            bool isPublished = true, bool copyImages = true, bool copyAssociatedProducts = true)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("newName", newName);
            parameters.Add("isPublished", isPublished);
            parameters.Add("copyImages", copyImages);
            parameters.Add("copyAssociatedProducts", copyAssociatedProducts);
            return APIHelper.Instance.PostAsync<Product>("Catalogs", "CopyProduct", product, parameters);
        }

        #endregion
    }
}
