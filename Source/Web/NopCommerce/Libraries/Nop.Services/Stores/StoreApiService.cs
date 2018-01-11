using Nop.Core.Domain.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Stores
{
    public partial class StoreApiService : IStoreService
    {
        #region Methods

        /// <summary>
        /// Deletes a store
        /// </summary>
        /// <param name="store">Store</param>
        public virtual void DeleteStore(Store store)
        {
            APIHelper.Instance.PostAsync("Stores", "DeleteStore", store);
        }

        /// <summary>
        /// Gets all stores
        /// </summary>
        /// <returns>Stores</returns>
        public virtual IList<Store> GetAllStores()
        {
            return APIHelper.Instance.GetListAsync<Store>("Stores", "GetAllStores", new Dictionary<string, dynamic>());
        }

        /// <summary>
        /// Gets a store 
        /// </summary>
        /// <param name="storeId">Store identifier</param>
        /// <returns>Store</returns>
        public virtual Store GetStoreById(int storeId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("storeId", storeId);
            return APIHelper.Instance.GetAsync<Store>("Stores", "GetStoreById", parameters);
        }

        /// <summary>
        /// Inserts a store
        /// </summary>
        /// <param name="store">Store</param>
        public virtual void InsertStore(Store store)
        {
            APIHelper.Instance.PostAsync("Stores", "InsertStore", store);
        }

        /// <summary>
        /// Updates the store
        /// </summary>
        /// <param name="store">Store</param>
        public virtual void UpdateStore(Store store)
        {
            APIHelper.Instance.PostAsync("Stores", "UpdateStore", store);
        }

        #endregion
    }
}
