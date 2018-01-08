using Nop.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Nop.Services.Customers
{
    public partial class CustomerAttributeParserApi : ICustomerAttributeParser
    {
        /// <summary>
        /// Gets selected customer attribute identifiers
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <returns>Selected customer attribute identifiers</returns>
        protected virtual IList<int> ParseCustomerAttributeIds(string attributesXml)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("attributesXml", attributesXml);
            return APIHelper.Instance.GetListAsync<int>("Customers", "ParseCustomerAttributeIds", parameters);
        }

        /// <summary>
        /// Gets selected customer attributes
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <returns>Selected customer attributes</returns>
        public virtual IList<CustomerAttribute> ParseCustomerAttributes(string attributesXml)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("attributesXml", attributesXml);
            return APIHelper.Instance.GetListAsync<CustomerAttribute>("Customers", "ParseCustomerAttributes", parameters);
        }

        /// <summary>
        /// Get customer attribute values
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <returns>Customer attribute values</returns>
        public virtual IList<CustomerAttributeValue> ParseCustomerAttributeValues(string attributesXml)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("attributesXml", attributesXml);
            return APIHelper.Instance.GetListAsync<CustomerAttributeValue>("Customers", "ParseCustomerAttributeValues", parameters);
        }

        /// <summary>
        /// Gets selected customer attribute value
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <param name="customerAttributeId">Customer attribute identifier</param>
        /// <returns>Customer attribute value</returns>
        public virtual IList<string> ParseValues(string attributesXml, int customerAttributeId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("attributesXml", attributesXml);
            parameters.Add("customerAttributeId", customerAttributeId);
            return APIHelper.Instance.GetListAsync<string>("Customers", "ParseValues", parameters);
        }

        /// <summary>
        /// Adds an attribute
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <param name="ca">Customer attribute</param>
        /// <param name="value">Value</param>
        /// <returns>Attributes</returns>
        public virtual string AddCustomerAttribute(string attributesXml, CustomerAttribute ca, string value)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("attributesXml", attributesXml);
            parameters.Add("value", value);
            return APIHelper.Instance.PostAsync<string>("Customers", "AddCustomerAttribute", ca, parameters);
        }

        /// <summary>
        /// Validates customer attributes
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <returns>Warnings</returns>
        public virtual IList<string> GetAttributeWarnings(string attributesXml)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("attributesXml", attributesXml);
            return APIHelper.Instance.GetListAsync<string>("Customers", "GetAttributeWarnings", parameters);
        }
    }
}
