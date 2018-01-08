using Nop.Core.Domain.Customers;
using Nop.Services.Cms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nop.Api.Controllers
{
    [Authorize]
    public class CmsController : ApiController
    {
        #region Fields

        private readonly IWidgetService _widgetService;

        #endregion

        #region Ctor

        public CmsController(IWidgetService widgetService)
        {
            this._widgetService = widgetService;
        }

        #endregion

        #region Method

        /// <summary>
        /// Load active widgets
        /// </summary>
        /// <param name="customer">Load records allowed only to a specified customer; pass null to ignore ACL permissions</param>
        /// <param name="storeId">Load records allowed only in a specified store; pass 0 to load all records</param>
        /// <returns>Widgets</returns>
        public IList<IWidgetPlugin> LoadActiveWidgets(Customer customer = null, int storeId = 0)
        {
            return _widgetService.LoadActiveWidgets(customer, storeId);
        }

        /// <summary>
        /// Load active widgets
        /// </summary>
        /// <param name="widgetZone">Widget zone</param>
        /// <param name="customer">Load records allowed only to a specified customer; pass null to ignore ACL permissions</param>
        /// <param name="storeId">Load records allowed only in a specified store; pass 0 to load all records</param>
        /// <returns>Widgets</returns>
        public IList<IWidgetPlugin> LoadActiveWidgetsByWidgetZone([FromBody]Customer customer,string widgetZone, int storeId = 0)
        {
            return _widgetService.LoadActiveWidgetsByWidgetZone(widgetZone, customer, storeId);
        }

        /// <summary>
        /// Load widget by system name
        /// </summary>
        /// <param name="systemName">System name</param>
        /// <returns>Found widget</returns>
        public IWidgetPlugin LoadWidgetBySystemName(string systemName)
        {
            return _widgetService.LoadWidgetBySystemName(systemName);
        }

        /// <summary>
        /// Load all widgets
        /// </summary>
        /// <param name="customer">Load records allowed only to a specified customer; pass null to ignore ACL permissions</param>
        /// <param name="storeId">Load records allowed only in a specified store; pass 0 to load all records</param>
        /// <returns>Widgets</returns>
        public IList<IWidgetPlugin> LoadAllWidgets(Customer customer = null, int storeId = 0)
        {
            return _widgetService.LoadAllWidgets(customer, storeId);
        }

        #endregion
    }
}
