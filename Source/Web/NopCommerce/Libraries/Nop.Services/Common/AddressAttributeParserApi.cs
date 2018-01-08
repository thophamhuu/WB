using Nop.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Common
{
    public partial class AddressAttributeParserApi : IAddressAttributeParser
    {
        /// <summary>
        /// Gets selected address attribute identifiers
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <returns>Selected address attribute identifiers</returns>
        protected virtual IList<int> ParseAddressAttributeIds(string attributesXml)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("attributesXml", attributesXml);
            return APIHelper.Instance.GetListAsync<int>("Common", "ParseAddressAttributeIds", parameters);
        }

        /// <summary>
        /// Gets selected address attributes
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <returns>Selected address attributes</returns>
        public virtual IList<AddressAttribute> ParseAddressAttributes(string attributesXml)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("attributesXml", attributesXml);
            return APIHelper.Instance.GetListAsync<AddressAttribute>("Common", "ParseAddressAttributes", parameters);
        }

        /// <summary>
        /// Get address attribute values
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <returns>Address attribute values</returns>
        public virtual IList<AddressAttributeValue> ParseAddressAttributeValues(string attributesXml)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("attributesXml", attributesXml);
            return APIHelper.Instance.GetListAsync<AddressAttributeValue>("Common", "ParseAddressAttributeValues", parameters);
        }

        /// <summary>
        /// Gets selected address attribute value
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <param name="addressAttributeId">Address attribute identifier</param>
        /// <returns>Address attribute value</returns>
        public virtual IList<string> ParseValues(string attributesXml, int addressAttributeId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("attributesXml", attributesXml);
            parameters.Add("addressAttributeId", addressAttributeId);
            return APIHelper.Instance.GetListAsync<string>("Common", "ParseValues", parameters);
        }

        /// <summary>
        /// Adds an attribute
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <param name="attribute">Address attribute</param>
        /// <param name="value">Value</param>
        /// <returns>Attributes</returns>
        public virtual string AddAddressAttribute(string attributesXml, AddressAttribute attribute, string value)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("attributesXml", attributesXml);
            parameters.Add("attribute", attribute);
            parameters.Add("value", value);
            return APIHelper.Instance.GetAsync<string>("Common", "AddAddressAttribute", parameters);
        }

        /// <summary>
        /// Validates address attributes
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <returns>Warnings</returns>
        public virtual IList<string> GetAttributeWarnings(string attributesXml)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("attributesXml", attributesXml);
            return APIHelper.Instance.GetListAsync<string>("Common", "GetAttributeWarnings", parameters);
        }
    }
}
