using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Catalog
{
    public partial class CompareProductsApiService : ICompareProductsService
    {
        #region Methods

        /// <summary>
        /// Clears a "compare products" list
        /// </summary>
        public virtual void ClearCompareProducts()
        {
            APIHelper.Instance.PostAsync("Catalogs", "ClearCompareProducts", null);
        }

        /// <summary>
        /// Gets a "compare products" list
        /// </summary>
        /// <returns>"Compare products" list</returns>
        public virtual IList<Product> GetComparedProducts()
        {
            return APIHelper.Instance.GetListAsync<Product>("Catalogs", "GetComparedProducts", null);
        }

        /// <summary>
        /// Removes a product from a "compare products" list
        /// </summary>
        /// <param name="productId">Product identifier</param>
        public virtual void RemoveProductFromCompareList(int productId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("productId", productId);
            APIHelper.Instance.PostAsync("Catalogs", "RemoveProductFromCompareList", null, parameters);
        }

        /// <summary>
        /// Adds a product to a "compare products" list
        /// </summary>
        /// <param name="productId">Product identifier</param>
        public virtual void AddProductToCompareList(int productId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("productId", productId);
            APIHelper.Instance.PostAsync("Catalogs", "AddProductToCompareList", null, parameters);
        }

        #endregion
    }
}
