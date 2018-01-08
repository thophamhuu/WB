using Nop.Core;
using Nop.Core.Domain.Stores;
using Nop.Services.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nop.Api.Controllers
{
    [Authorize]
    public class StoresController : ApiController
    {
        #region Fields

        private readonly IStoreService _storeService;
        private readonly IStoreMappingService _storeMappingService;

        #endregion

        #region Ctor

        public StoresController(IStoreService storeService, IStoreMappingService storeMappingService)
        {
            this._storeService = storeService;
            this._storeMappingService = storeMappingService;
        }

        #endregion

        #region Method

        #region Store

        /// <summary>
        /// Deletes a store
        /// </summary>
        /// <param name="store">Store</param>
        public void DeleteStore([FromBody]Store store)
        {
            _storeService.DeleteStore(store);
        }

        /// <summary>
        /// Gets all stores
        /// </summary>
        /// <returns>Stores</returns>
        public IList<Store> GetAllStores()
        {
            return _storeService.GetAllStores();
        }

        /// <summary>
        /// Gets a store 
        /// </summary>
        /// <param name="storeId">Store identifier</param>
        /// <returns>Store</returns>
        public Store GetStoreById(int storeId)
        {
            return _storeService.GetStoreById(storeId);
        }

        /// <summary>
        /// Inserts a store
        /// </summary>
        /// <param name="store">Store</param>
        public void InsertStore([FromBody]Store store)
        {
            _storeService.InsertStore(store);
        }

        /// <summary>
        /// Updates the store
        /// </summary>
        /// <param name="store">Store</param>
        public void UpdateStore([FromBody]Store store)
        {
            _storeService.UpdateStore(store);
        }

        #endregion

        #region StoreMapping

        /// <summary>
        /// Deletes a store mapping record
        /// </summary>
        /// <param name="storeMapping">Store mapping record</param>
        public void DeleteStoreMapping([FromBody]StoreMapping storeMapping)
        {
            _storeMappingService.DeleteStoreMapping(storeMapping);
        }

        /// <summary>
        /// Gets a store mapping record
        /// </summary>
        /// <param name="storeMappingId">Store mapping record identifier</param>
        /// <returns>Store mapping record</returns>
        public StoreMapping GetStoreMappingById(int storeMappingId)
        {
            return _storeMappingService.GetStoreMappingById(storeMappingId);
        }

        /// <summary>
        /// Gets store mapping records
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="entity">Entity</param>
        /// <returns>Store mapping records</returns>
        public IList<StoreMapping> GetStoreMappings<T>(T entity) where T : BaseEntity, IStoreMappingSupported
        {
            return _storeMappingService.GetStoreMappings(entity);
        }

        /// <summary>
        /// Inserts a store mapping record
        /// </summary>
        /// <param name="storeMapping">Store mapping</param>
        public void InsertStoreMapping([FromBody]StoreMapping storeMapping)
        {
            _storeMappingService.InsertStoreMapping(storeMapping);
        }

        /// <summary>
        /// Inserts a store mapping record
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="storeId">Store id</param>
        /// <param name="entity">Entity</param>
        public void InsertStoreMapping<T>(T entity, int storeId) where T : BaseEntity, IStoreMappingSupported
        {
            _storeMappingService.InsertStoreMapping(entity, storeId);
        }

        /// <summary>
        /// Updates the store mapping record
        /// </summary>
        /// <param name="storeMapping">Store mapping</param>
        public void UpdateStoreMapping([FromBody]StoreMapping storeMapping)
        {
            _storeMappingService.UpdateStoreMapping(storeMapping);
        }

        /// <summary>
        /// Find store identifiers with granted access (mapped to the entity)
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="entity">Wntity</param>
        /// <returns>Store identifiers</returns>
        public int[] GetStoresIdsWithAccess<T>(T entity) where T : BaseEntity, IStoreMappingSupported
        {
            return _storeMappingService.GetStoresIdsWithAccess(entity);
        }

        /// <summary>
        /// Authorize whether entity could be accessed in the current store (mapped to this store)
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="entity">Wntity</param>
        /// <returns>true - authorized; otherwise, false</returns>
        public bool Authorize<T>(T entity) where T : BaseEntity, IStoreMappingSupported
        {
            return _storeMappingService.Authorize(entity);
        }

        /// <summary>
        /// Authorize whether entity could be accessed in a store (mapped to this store)
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="entity">Entity</param>
        /// <param name="storeId">Store identifier</param>
        /// <returns>true - authorized; otherwise, false</returns>
        public bool Authorize<T>(T entity, int storeId) where T : BaseEntity, IStoreMappingSupported
        {
            return _storeMappingService.Authorize(entity, storeId);
        }

        #endregion

        #endregion
    }
}
