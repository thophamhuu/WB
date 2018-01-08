using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Catalog
{
    public partial class RecentlyViewedProductsApiService : IRecentlyViewedProductsService
    {
        #region Methods


        /// <summary>
        /// Gets a "recently viewed products" list
        /// </summary>
        /// <param name="number">Number of products to load</param>
        /// <returns>"recently viewed products" list</returns>
        public virtual IList<Product> GetRecentlyViewedProducts(int number)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("number", number);
            return APIHelper.Instance.GetListAsync<Product>("Catalogs", "GetRecentlyViewedProducts", parameters);
        }

        /// <summary>
        /// Adds a product to a recently viewed products list
        /// </summary>
        /// <param name="productId">Product identifier</param>
        public virtual void AddProductToRecentlyViewedList(int productId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("productId", productId);
            APIHelper.Instance.PostAsync("Catalogs", "AddProductToRecentlyViewedList", null, parameters);
        }

        #endregion
    }
}
