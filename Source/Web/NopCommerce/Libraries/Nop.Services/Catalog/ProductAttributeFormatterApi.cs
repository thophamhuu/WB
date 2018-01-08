using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Catalog
{
    public partial class ProductAttributeFormatterApi : IProductAttributeFormatter
    {
        /// <summary>
        /// Formats attributes
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <returns>Attributes</returns>
        public virtual string FormatAttributes(Product product, string attributesXml)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("product", product);
            parameters.Add("attributesXml", attributesXml);
            return APIHelper.Instance.GetAsync<string>("Catalogs", "FormatAttributes", parameters);
        }

        /// <summary>
        /// Formats attributes
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <param name="customer">Customer</param>
        /// <param name="serapator">Serapator</param>
        /// <param name="htmlEncode">A value indicating whether to encode (HTML) values</param>
        /// <param name="renderPrices">A value indicating whether to render prices</param>
        /// <param name="renderProductAttributes">A value indicating whether to render product attributes</param>
        /// <param name="renderGiftCardAttributes">A value indicating whether to render gift card attributes</param>
        /// <param name="allowHyperlinks">A value indicating whether to HTML hyperink tags could be rendered (if required)</param>
        /// <returns>Attributes</returns>
        public virtual string FormatAttributes(Product product, string attributesXml,
            Customer customer, string serapator = "<br />", bool htmlEncode = true, bool renderPrices = true,
            bool renderProductAttributes = true, bool renderGiftCardAttributes = true,
            bool allowHyperlinks = true)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("product", product);
            parameters.Add("attributesXml", attributesXml);
            parameters.Add("customer", customer);
            parameters.Add("serapator", serapator);
            parameters.Add("htmlEncode", htmlEncode);
            parameters.Add("renderPrices", renderPrices);
            parameters.Add("renderProductAttributes", renderProductAttributes);
            parameters.Add("renderGiftCardAttributes", renderGiftCardAttributes);
            parameters.Add("allowHyperlinks", allowHyperlinks);
            return APIHelper.Instance.GetAsync<string>("Catalogs", "FormatAttributes", parameters);
        }
    }
}
