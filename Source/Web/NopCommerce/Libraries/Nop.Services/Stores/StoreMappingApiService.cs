using Nop.Core;
using Nop.Core.Domain.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Stores
{
    public partial class StoreMappingApiService : IStoreMappingService
    {
        #region Methods

        /// <summary>
        /// Deletes a store mapping record
        /// </summary>
        /// <param name="storeMapping">Store mapping record</param>
        public virtual void DeleteStoreMapping(StoreMapping storeMapping)
        {
            APIHelper.Instance.PostAsync("Stores", "DeleteStoreMapping", storeMapping);
        }

        /// <summary>
        /// Gets a store mapping record
        /// </summary>
        /// <param name="storeMappingId">Store mapping record identifier</param>
        /// <returns>Store mapping record</returns>
        public virtual StoreMapping GetStoreMappingById(int storeMappingId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("storeMappingId", storeMappingId);
            return APIHelper.Instance.GetAsync<StoreMapping>("Stores", "GetStoreMappingById", parameters);
        }

        /// <summary>
        /// Gets store mapping records
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="entity">Entity</param>
        /// <returns>Store mapping records</returns>
        public virtual IList<StoreMapping> GetStoreMappings<T>(T entity) where T : BaseEntity, IStoreMappingSupported
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("entity", entity);
            return APIHelper.Instance.GetListAsync<StoreMapping>("Stores", "GetStoreMappings", parameters);
        }


        /// <summary>
        /// Inserts a store mapping record
        /// </summary>
        /// <param name="storeMapping">Store mapping</param>
        public virtual void InsertStoreMapping(StoreMapping storeMapping)
        {
            APIHelper.Instance.PostAsync("Stores", "InsertStoreMapping", storeMapping);
        }

        /// <summary>
        /// Inserts a store mapping record
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="storeId">Store id</param>
        /// <param name="entity">Entity</param>
        public virtual void InsertStoreMapping<T>(T entity, int storeId) where T : BaseEntity, IStoreMappingSupported
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("storeId", storeId);
            APIHelper.Instance.PostAsync("Stores", "InsertStoreMapping", entity, parameters);
        }

        /// <summary>
        /// Updates the store mapping record
        /// </summary>
        /// <param name="storeMapping">Store mapping</param>
        public virtual void UpdateStoreMapping(StoreMapping storeMapping)
        {
            APIHelper.Instance.PostAsync("Stores", "UpdateStoreMapping", storeMapping);
        }

        /// <summary>
        /// Find store identifiers with granted access (mapped to the entity)
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="entity">Wntity</param>
        /// <returns>Store identifiers</returns>
        public virtual int[] GetStoresIdsWithAccess<T>(T entity) where T : BaseEntity, IStoreMappingSupported
        {
            return APIHelper.Instance.PostAsync<int[]>("Stores", "GetStoresIdsWithAccess", entity);
        }

        /// <summary>
        /// Authorize whether entity could be accessed in the current store (mapped to this store)
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="entity">Wntity</param>
        /// <returns>true - authorized; otherwise, false</returns>
        public virtual bool Authorize<T>(T entity) where T : BaseEntity, IStoreMappingSupported
        {
            return APIHelper.Instance.PostAsync<bool>("Stores", "GetStoresIdsWithAccess", entity);
        }

        /// <summary>
        /// Authorize whether entity could be accessed in a store (mapped to this store)
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="entity">Entity</param>
        /// <param name="storeId">Store identifier</param>
        /// <returns>true - authorized; otherwise, false</returns>
        public virtual bool Authorize<T>(T entity, int storeId) where T : BaseEntity, IStoreMappingSupported
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("storeId", storeId);
            return APIHelper.Instance.PostAsync<bool>("Stores", "Authorize", entity, parameters);
        }

        #endregion
    }
}
