using System;
using System.Collections.Generic;
using System.Linq;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Data;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Logging;
using Nop.Data;

namespace Nop.Services.Logging
{
    /// <summary>
    /// Customer activity service
    /// </summary>
    public class CustomerActivityApiService : ICustomerActivityService
    {     
        #region Methods

        /// <summary>
        /// Inserts an activity log type item
        /// </summary>
        /// <param name="activityLogType">Activity log type item</param>
        public virtual void InsertActivityType(ActivityLogType activityLogType)
        {
            APIHelper.Instance.PostAsync("Logging", "InsertActivityType", activityLogType);
        }

        /// <summary>
        /// Updates an activity log type item
        /// </summary>
        /// <param name="activityLogType">Activity log type item</param>
        public virtual void UpdateActivityType(ActivityLogType activityLogType)
        {
            APIHelper.Instance.PostAsync("Logging", "UpdateActivityType", activityLogType);
        }

        /// <summary>
        /// Deletes an activity log type item
        /// </summary>
        /// <param name="activityLogType">Activity log type</param>
        public virtual void DeleteActivityType(ActivityLogType activityLogType)
        {
            APIHelper.Instance.PostAsync("Logging", "DeleteActivityType", activityLogType);
        }

        /// <summary>
        /// Gets all activity log type items
        /// </summary>
        /// <returns>Activity log type items</returns>
        public virtual IList<ActivityLogType> GetAllActivityTypes()
        {
            return APIHelper.Instance.GetListAsync<ActivityLogType>("Logging", "GetAllActivityTypes", null);
        }

        /// <summary>
        /// Gets an activity log type item
        /// </summary>
        /// <param name="activityLogTypeId">Activity log type identifier</param>
        /// <returns>Activity log type item</returns>
        public virtual ActivityLogType GetActivityTypeById(int activityLogTypeId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("activityLogTypeId", activityLogTypeId);
            return APIHelper.Instance.GetAsync<ActivityLogType>("Logging", "GetActivityTypeById", parameters);
        }

        /// <summary>
        /// Inserts an activity log item
        /// </summary>
        /// <param name="systemKeyword">The system keyword</param>
        /// <param name="comment">The activity comment</param>
        /// <param name="commentParams">The activity comment parameters for string.Format() function.</param>
        /// <returns>Activity log item</returns>
        public virtual ActivityLog InsertActivity(string systemKeyword, string comment, params object[] commentParams)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("systemKeyword", systemKeyword);
            parameters.Add("comment", comment);
            parameters.Add("commentParams", commentParams);
            return APIHelper.Instance.GetAsync<ActivityLog>("Logging", "InsertActivity", parameters);
        }


        /// <summary>
        /// Inserts an activity log item
        /// </summary>
        /// <param name="customer">The customer</param>
        /// <param name="systemKeyword">The system keyword</param>
        /// <param name="comment">The activity comment</param>
        /// <param name="commentParams">The activity comment parameters for string.Format() function.</param>
        /// <returns>Activity log item</returns>
        public virtual ActivityLog InsertActivity(Customer customer, string systemKeyword, string comment, params object[] commentParams)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("systemKeyword", systemKeyword);
            parameters.Add("comment", comment);
            parameters.Add("commentParams", commentParams);
            return APIHelper.Instance.PostAsync<ActivityLog>("Logging", "InsertActivity", customer, parameters);
        }

        /// <summary>
        /// Deletes an activity log item
        /// </summary>
        /// <param name="activityLog">Activity log type</param>
        public virtual void DeleteActivity(ActivityLog activityLog)
        {
            APIHelper.Instance.PostAsync("Logging", "DeleteActivity", activityLog);
        }

        /// <summary>
        /// Gets all activity log items
        /// </summary>
        /// <param name="createdOnFrom">Log item creation from; null to load all activities</param>
        /// <param name="createdOnTo">Log item creation to; null to load all activities</param>
        /// <param name="customerId">Customer identifier; null to load all activities</param>
        /// <param name="activityLogTypeId">Activity log type identifier</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="ipAddress">IP address; null or empty to load all activities</param>
        /// <returns>Activity log items</returns>
        public virtual IPagedList<ActivityLog> GetAllActivities(DateTime? createdOnFrom = null,
            DateTime? createdOnTo = null, int? customerId = null, int activityLogTypeId = 0,
            int pageIndex = 0, int pageSize = int.MaxValue, string ipAddress = null)
        {
            var parameters = new Dictionary<string, dynamic>();
            if(createdOnFrom.HasValue)
                parameters.Add("createdOnFrom", CommonHelper.DateTimeUtcToStringAPI(createdOnFrom.Value));
            if (createdOnTo.HasValue)
                parameters.Add("createdOnTo", CommonHelper.DateTimeUtcToStringAPI(createdOnTo.Value));
            parameters.Add("customerId", customerId);
            parameters.Add("activityLogTypeId", activityLogTypeId);
            parameters.Add("pageIndex", pageIndex);
            parameters.Add("pageSize", pageSize);
            parameters.Add("ipAddress", ipAddress);
            return APIHelper.Instance.GetPagedListAsync<ActivityLog>("Logging", "GetAllActivities", parameters);
        }

        /// <summary>
        /// Gets an activity log item
        /// </summary>
        /// <param name="activityLogId">Activity log identifier</param>
        /// <returns>Activity log item</returns>
        public virtual ActivityLog GetActivityById(int activityLogId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("activityLogId", activityLogId);
            return APIHelper.Instance.GetAsync<ActivityLog>("Logging", "GetActivityById", parameters);
        }

        /// <summary>
        /// Clears activity log
        /// </summary>
        public virtual void ClearAllActivities()
        {
            APIHelper.Instance.PostAsync("Logging", "ClearAllActivities", null);
        }
        #endregion

    }
}
