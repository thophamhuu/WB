using Nop.Core.Domain.Customers;
using Nop.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nop.Api.Controllers
{
    [Authorize]
    public class HelpersController : ApiController
    {
        #region Fields

        private readonly IDateTimeHelper _dateTimeHelper;

        #endregion

        #region Ctor

        public HelpersController(IDateTimeHelper dateTimeHelper)
        {
            this._dateTimeHelper = dateTimeHelper;
        }

        #endregion

        #region Method

        #region DateTimeHelper

        /// <summary>
        /// Gets a customer time zone
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <returns>Customer time zone; if customer is null, then default store time zone</returns>
        public TimeZoneInfo GetCustomerTimeZone(Customer customer)
        {
            return _dateTimeHelper.GetCustomerTimeZone(customer);
        }

        /// <summary>
        /// Gets or sets a default store time zone
        /// </summary>
        public TimeZoneInfo DefaultStoreTimeZone()
        {
            return _dateTimeHelper.DefaultStoreTimeZone;
        }

        /// <summary>
        /// Gets or sets the current user time zone
        /// </summary>
        public TimeZoneInfo CurrentTimeZone()
        {
            return _dateTimeHelper.CurrentTimeZone;
        }

        #endregion

        #endregion
    }
}
