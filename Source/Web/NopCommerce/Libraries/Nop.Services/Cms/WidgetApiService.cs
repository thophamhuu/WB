using Nop.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Cms
{
    public partial class WidgetApiService : IWidgetService
    {
        #region Methods

        /// <summary>
        /// Load active widgets
        /// </summary>
        /// <param name="customer">Load records allowed only to a specified customer; pass null to ignore ACL permissions</param>
        /// <param name="storeId">Load records allowed only in a specified store; pass 0 to load all records</param>
        /// <returns>Widgets</returns>
        public virtual IList<IWidgetPlugin> LoadActiveWidgets(Customer customer = null, int storeId = 0)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customer", customer);
            parameters.Add("storeId", storeId);
            return APIHelper.Instance.GetListAsync<IWidgetPlugin>("Cms", "LoadActiveWidgets", parameters);
        }

        /// <summary>
        /// Load active widgets
        /// </summary>
        /// <param name="widgetZone">Widget zone</param>
        /// <param name="customer">Load records allowed only to a specified customer; pass null to ignore ACL permissions</param>
        /// <param name="storeId">Load records allowed only in a specified store; pass 0 to load all records</param>
        /// <returns>Widgets</returns>
        public virtual IList<IWidgetPlugin> LoadActiveWidgetsByWidgetZone(string widgetZone, Customer customer = null, int storeId = 0)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("widgetZone", widgetZone);
            parameters.Add("storeId", storeId);
            var body = new
            {
                customer
            };
            
            return APIHelper.Instance.PostListAsync<IWidgetPlugin>("Cms", "LoadActiveWidgetsByWidgetZone", body, parameters);
        }

        /// <summary>
        /// Load widget by system name
        /// </summary>
        /// <param name="systemName">System name</param>
        /// <returns>Found widget</returns>
        public virtual IWidgetPlugin LoadWidgetBySystemName(string systemName)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("systemName", systemName);
            return APIHelper.Instance.GetAsync<IWidgetPlugin>("Cms", "LoadWidgetBySystemName", parameters);
        }

        /// <summary>
        /// Load all widgets
        /// </summary>
        /// <param name="customer">Load records allowed only to a specified customer; pass null to ignore ACL permissions</param>
        /// <param name="storeId">Load records allowed only in a specified store; pass 0 to load all records</param>
        /// <returns>Widgets</returns>
        public virtual IList<IWidgetPlugin> LoadAllWidgets(Customer customer = null, int storeId = 0)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customer", customer);
            parameters.Add("storeId", storeId);
            return APIHelper.Instance.GetListAsync<IWidgetPlugin>("Cms", "LoadAllWidgets", parameters);
        }

        #endregion
    }
}
