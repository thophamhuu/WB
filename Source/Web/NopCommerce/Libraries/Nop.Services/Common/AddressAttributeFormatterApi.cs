using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Common
{
    public partial class AddressAttributeFormatterApi : IAddressAttributeFormatter
    {
        /// <summary>
        /// Formats attributes
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <param name="serapator">Serapator</param>
        /// <param name="htmlEncode">A value indicating whether to encode (HTML) values</param>
        /// <returns>Attributes</returns>
        public virtual string FormatAttributes(string attributesXml,
            string serapator = "<br />",
            bool htmlEncode = true)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("attributesXml", attributesXml);
            parameters.Add("serapator", serapator);
            parameters.Add("htmlEncode", htmlEncode);
            return APIHelper.Instance.GetAsync<string>("Common", "FormatAttributes", parameters);
        }
    }
}
