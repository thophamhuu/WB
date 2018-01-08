using Nop.Core;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Logging;
using Nop.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nop.Api.Controllers
{
    [Authorize]
    public class LoggingController : ApiController
    {
        #region Fields

        private readonly ICustomerActivityService _customerActivityService;

        #endregion

        #region Ctor

        public LoggingController(ICustomerActivityService customerActivityService)
        {
            this._customerActivityService = customerActivityService;
        }

        #endregion

        #region Method

        #region Customer activity

        /// <summary>
        /// Inserts an activity log type item
        /// </summary>
        /// <param name="activityLogType">Activity log type item</param>
        public void InsertActivityType(ActivityLogType activityLogType)
        {
            _customerActivityService.InsertActivityType(activityLogType);
        }

        /// <summary>
        /// Updates an activity log type item
        /// </summary>
        /// <param name="activityLogType">Activity log type item</param>
        public void UpdateActivityType(ActivityLogType activityLogType)
        {
            _customerActivityService.UpdateActivityType(activityLogType);
        }

        /// <summary>
        /// Deletes an activity log type item
        /// </summary>
        /// <param name="activityLogType">Activity log type</param>
        public void DeleteActivityType(ActivityLogType activityLogType)
        {
            _customerActivityService.DeleteActivityType(activityLogType);
        }

        /// <summary>
        /// Gets all activity log type items
        /// </summary>
        /// <returns>Activity log type items</returns>
        public IList<ActivityLogType> GetAllActivityTypes()
        {
            return _customerActivityService.GetAllActivityTypes();
        }

        /// <summary>
        /// Gets an activity log type item
        /// </summary>
        /// <param name="activityLogTypeId">Activity log type identifier</param>
        /// <returns>Activity log type item</returns>
        public ActivityLogType GetActivityTypeById(int activityLogTypeId)
        {
            return _customerActivityService.GetActivityTypeById(activityLogTypeId);
        }

        /// <summary>
        /// Inserts an activity log item
        /// </summary>
        /// <param name="systemKeyword">The system keyword</param>
        /// <param name="comment">The activity comment</param>
        /// <param name="commentParams">The activity comment parameters for string.Format() function.</param>
        /// <returns>Activity log item</returns>
        public ActivityLog InsertActivity(string systemKeyword, string comment, params object[] commentParams)
        {
            return _customerActivityService.InsertActivity(systemKeyword, comment, commentParams);
        }

        /// <summary>
        /// Inserts an activity log item
        /// </summary>
        /// <param name="customer">The customer</param>
        /// <param name="systemKeyword">The system keyword</param>
        /// <param name="comment">The activity comment</param>
        /// <param name="commentParams">The activity comment parameters for string.Format() function.</param>
        /// <returns>Activity log item</returns>
        public ActivityLog InsertActivity(Customer customer, string systemKeyword, string comment, params object[] commentParams)
        {
            return _customerActivityService.InsertActivity(customer, systemKeyword, comment, commentParams);
        }

        /// <summary>
        /// Deletes an activity log item
        /// </summary>
        /// <param name="activityLog">Activity log</param>
        public void DeleteActivity(ActivityLog activityLog)
        {
            _customerActivityService.DeleteActivity(activityLog);
        }

        /// <summary>
        /// Gets all activity log items
        /// </summary>
        /// <param name="createdOnFrom">Log item creation from; null to load all customers</param>
        /// <param name="createdOnTo">Log item creation to; null to load all customers</param>
        /// <param name="customerId">Customer identifier; null to load all customers</param>
        /// <param name="activityLogTypeId">Activity log type identifier</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="ipAddress">IP address; null or empty to load all customers</param>
        /// <returns>Activity log items</returns>
        public IAPIPagedList<ActivityLog> GetAllActivities(DateTime? createdOnFrom = null,
            DateTime? createdOnTo = null, int? customerId = null, int activityLogTypeId = 0,
            int pageIndex = 0, int pageSize = int.MaxValue, string ipAddress = null)
        {
            return _customerActivityService.GetAllActivities(createdOnFrom, createdOnTo, customerId, activityLogTypeId, pageIndex, pageSize, ipAddress).ConvertPagedListToAPIPagedList();
        }

        /// <summary>
        /// Gets an activity log item
        /// </summary>
        /// <param name="activityLogId">Activity log identifier</param>
        /// <returns>Activity log item</returns>
        public ActivityLog GetActivityById(int activityLogId)
        {
            return _customerActivityService.GetActivityById(activityLogId);
        }

        /// <summary>
        /// Clears activity log
        /// </summary>
        public void ClearAllActivities()
        {
            _customerActivityService.ClearAllActivities();
        }

        #endregion

        #endregion
    }
}
