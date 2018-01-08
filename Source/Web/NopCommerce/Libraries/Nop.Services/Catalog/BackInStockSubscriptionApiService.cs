using Nop.Core;
using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Catalog
{
    public partial class BackInStockSubscriptionApiService : IBackInStockSubscriptionService
    {
        #region Methods

        /// <summary>
        /// Delete a back in stock subscription
        /// </summary>
        /// <param name="subscription">Subscription</param>
        public virtual void DeleteSubscription(BackInStockSubscription subscription)
        {
            APIHelper.Instance.PostAsync("Catalogs", "DeleteSubscription", subscription);
        }

        /// <summary>
        /// Gets all subscriptions
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="storeId">Store identifier; pass 0 to load all records</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Subscriptions</returns>
        public virtual IPagedList<BackInStockSubscription> GetAllSubscriptionsByCustomerId(int customerId,
            int storeId = 0, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customerId", customerId);
            parameters.Add("storeId", storeId);
            parameters.Add("pageIndex", pageIndex);
            parameters.Add("pageSize", pageSize);
            return APIHelper.Instance.GetPagedListAsync<BackInStockSubscription>("Catalogs", "GetAllSubscriptionsByCustomerId", parameters);
        }

        /// <summary>
        /// Gets all subscriptions
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <param name="storeId">Store identifier; pass 0 to load all records</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Subscriptions</returns>
        public virtual IPagedList<BackInStockSubscription> GetAllSubscriptionsByProductId(int productId,
            int storeId = 0, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("productId", productId);
            parameters.Add("storeId", storeId);
            parameters.Add("pageIndex", pageIndex);
            parameters.Add("pageSize", pageSize);
            return APIHelper.Instance.GetPagedListAsync<BackInStockSubscription>("Catalogs", "GetAllSubscriptionsByProductId", parameters);
        }

        /// <summary>
        /// Gets all subscriptions
        /// </summary>
        /// <param name="customerId">Customer id</param>
        /// <param name="productId">Product identifier</param>
        /// <param name="storeId">Store identifier</param>
        /// <returns>Subscriptions</returns>
        public virtual BackInStockSubscription FindSubscription(int customerId, int productId, int storeId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customerId", customerId);
            parameters.Add("productId", productId);
            parameters.Add("storeId", storeId);
            return APIHelper.Instance.GetAsync<BackInStockSubscription>("Catalogs", "FindSubscription", parameters);
        }

        /// <summary>
        /// Gets a subscription
        /// </summary>
        /// <param name="subscriptionId">Subscription identifier</param>
        /// <returns>Subscription</returns>
        public virtual BackInStockSubscription GetSubscriptionById(int subscriptionId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("subscriptionId", subscriptionId);
            return APIHelper.Instance.GetAsync<BackInStockSubscription>("Catalogs", "GetSubscriptionById", parameters);
        }

        /// <summary>
        /// Inserts subscription
        /// </summary>
        /// <param name="subscription">Subscription</param>
        public virtual void InsertSubscription(BackInStockSubscription subscription)
        {
            APIHelper.Instance.PostAsync("Catalogs", "InsertSubscription", subscription);
        }

        /// <summary>
        /// Updates subscription
        /// </summary>
        /// <param name="subscription">Subscription</param>
        public virtual void UpdateSubscription(BackInStockSubscription subscription)
        {
            APIHelper.Instance.PostAsync("Catalogs", "UpdateSubscription", subscription);
        }

        /// <summary>
        /// Send notification to subscribers
        /// </summary>
        /// <param name="product">Product</param>
        /// <returns>Number of sent email</returns>
        public virtual int SendNotificationsToSubscribers(Product product)
        {
            return APIHelper.Instance.PostAsync<int>("Catalogs", "SendNotificationsToSubscribers", product);
        }

        #endregion
    }
}
