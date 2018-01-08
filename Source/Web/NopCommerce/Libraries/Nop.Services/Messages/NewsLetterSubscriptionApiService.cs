using Nop.Core;
using Nop.Core.Domain.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Messages
{
    public partial class NewsLetterSubscriptionApiService : INewsLetterSubscriptionService
    {
        #region Methods

        /// <summary>
        /// Inserts a newsletter subscription
        /// </summary>
        /// <param name="newsLetterSubscription">NewsLetter subscription</param>
        /// <param name="publishSubscriptionEvents">if set to <c>true</c> [publish subscription events].</param>
        public virtual void InsertNewsLetterSubscription(NewsLetterSubscription newsLetterSubscription, bool publishSubscriptionEvents = true)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("publishSubscriptionEvents", publishSubscriptionEvents);
            APIHelper.Instance.PostAsync("Messages", "InsertNewsLetterSubscription", newsLetterSubscription, parameters);
        }

        /// <summary>
        /// Updates a newsletter subscription
        /// </summary>
        /// <param name="newsLetterSubscription">NewsLetter subscription</param>
        /// <param name="publishSubscriptionEvents">if set to <c>true</c> [publish subscription events].</param>
        public virtual void UpdateNewsLetterSubscription(NewsLetterSubscription newsLetterSubscription, bool publishSubscriptionEvents = true)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("publishSubscriptionEvents", publishSubscriptionEvents);
            APIHelper.Instance.PostAsync("Messages", "UpdateNewsLetterSubscription", newsLetterSubscription, parameters);
        }

        /// <summary>
        /// Deletes a newsletter subscription
        /// </summary>
        /// <param name="newsLetterSubscription">NewsLetter subscription</param>
        /// <param name="publishSubscriptionEvents">if set to <c>true</c> [publish subscription events].</param>
        public virtual void DeleteNewsLetterSubscription(NewsLetterSubscription newsLetterSubscription, bool publishSubscriptionEvents = true)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("publishSubscriptionEvents", publishSubscriptionEvents);
            APIHelper.Instance.PostAsync("Messages", "DeleteNewsLetterSubscription", newsLetterSubscription, parameters);
        }

        /// <summary>
        /// Gets a newsletter subscription by newsletter subscription identifier
        /// </summary>
        /// <param name="newsLetterSubscriptionId">The newsletter subscription identifier</param>
        /// <returns>NewsLetter subscription</returns>
        public virtual NewsLetterSubscription GetNewsLetterSubscriptionById(int newsLetterSubscriptionId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("newsLetterSubscriptionId", newsLetterSubscriptionId);
            return APIHelper.Instance.GetAsync<NewsLetterSubscription>("Messages", "GetNewsLetterSubscriptionById", parameters);
        }

        /// <summary>
        /// Gets a newsletter subscription by newsletter subscription GUID
        /// </summary>
        /// <param name="newsLetterSubscriptionGuid">The newsletter subscription GUID</param>
        /// <returns>NewsLetter subscription</returns>
        public virtual NewsLetterSubscription GetNewsLetterSubscriptionByGuid(Guid newsLetterSubscriptionGuid)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("newsLetterSubscriptionGuid", newsLetterSubscriptionGuid);
            return APIHelper.Instance.GetAsync<NewsLetterSubscription>("Messages", "GetNewsLetterSubscriptionByGuid", parameters);
        }

        /// <summary>
        /// Gets a newsletter subscription by email and store ID
        /// </summary>
        /// <param name="email">The newsletter subscription email</param>
        /// <param name="storeId">Store identifier</param>
        /// <returns>NewsLetter subscription</returns>
        public virtual NewsLetterSubscription GetNewsLetterSubscriptionByEmailAndStoreId(string email, int storeId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("email", email);
            parameters.Add("storeId", storeId);
            return APIHelper.Instance.GetAsync<NewsLetterSubscription>("Messages", "GetNewsLetterSubscriptionByEmailAndStoreId", parameters);
        }

        /// <summary>
        /// Gets the newsletter subscription list
        /// </summary>
        /// <param name="email">Email to search or string. Empty to load all records.</param>
        /// <param name="createdFromUtc">Created date from (UTC); null to load all records</param>
        /// <param name="createdToUtc">Created date to (UTC); null to load all records</param>
        /// <param name="storeId">Store identifier. 0 to load all records.</param>
        /// <param name="customerRoleId">Customer role identifier. Used to filter subscribers by customer role. 0 to load all records.</param>
        /// <param name="isActive">Value indicating whether subscriber record should be active or not; null to load all records</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>NewsLetterSubscription entities</returns>
        public virtual IPagedList<NewsLetterSubscription> GetAllNewsLetterSubscriptions(string email = null,
            DateTime? createdFromUtc = null, DateTime? createdToUtc = null,
            int storeId = 0, bool? isActive = null, int customerRoleId = 0,
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("email", email);
            if(createdFromUtc.HasValue)
                parameters.Add("createdFromUtc", CommonHelper.DateTimeUtcToStringAPI(createdFromUtc.Value));
            if (createdToUtc.HasValue)
                parameters.Add("createdToUtc", CommonHelper.DateTimeUtcToStringAPI(createdToUtc.Value));
            parameters.Add("storeId", storeId);
            parameters.Add("isActive", isActive);
            parameters.Add("customerRoleId", customerRoleId);
            parameters.Add("pageIndex", pageIndex);
            parameters.Add("pageSize", pageSize);
            return APIHelper.Instance.GetPagedListAsync<NewsLetterSubscription>("Messages", "GetAllNewsLetterSubscriptions", parameters);
        }

        #endregion
    }
}
