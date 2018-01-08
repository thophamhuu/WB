using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Catalog
{
    public partial class ProductAttributeParserApics : IProductAttributeParser
    {
        #region Product attributes

        /// <summary>
        /// Gets selected product attribute mapping identifiers
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <returns>Selected product attribute mapping identifiers</returns>
        protected virtual IList<int> ParseProductAttributeMappingIds(string attributesXml)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("attributesXml", attributesXml);
            return APIHelper.Instance.GetListAsync<int>("Catalogs", "ParseProductAttributeMappingIds", parameters);
        }

        /// <summary>
        /// Gets selected product attribute values with the quantity entered by the customer
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <param name="productAttributeMappingId">Product attribute mapping identifier</param>
        /// <returns>Collections of pairs of product attribute values and their quantity</returns>
        protected IList<Tuple<string, string>> ParseValuesWithQuantity(string attributesXml, int productAttributeMappingId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("attributesXml", attributesXml);
            parameters.Add("productAttributeMappingId", productAttributeMappingId);
            return APIHelper.Instance.GetListAsync<Tuple<string, string>>("Catalogs", "ParseValuesWithQuantity", parameters);
        }

        /// <summary>
        /// Gets selected product attribute mappings
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <returns>Selected product attribute mappings</returns>
        public virtual IList<ProductAttributeMapping> ParseProductAttributeMappings(string attributesXml)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("attributesXml", attributesXml);
            return APIHelper.Instance.GetListAsync<ProductAttributeMapping>("Catalogs", "ParseProductAttributeMappings", parameters);
        }

        /// <summary>
        /// Get product attribute values
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <param name="productAttributeMappingId">Product attribute mapping identifier; pass 0 to load all values</param>
        /// <returns>Product attribute values</returns>
        public virtual IList<ProductAttributeValue> ParseProductAttributeValues(string attributesXml, int productAttributeMappingId = 0)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("attributesXml", attributesXml);
            parameters.Add("productAttributeMappingId", productAttributeMappingId);
            return APIHelper.Instance.GetListAsync<ProductAttributeValue>("Catalogs", "ParseProductAttributeValues", parameters);
        }

        /// <summary>
        /// Gets selected product attribute values
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <param name="productAttributeMappingId">Product attribute mapping identifier</param>
        /// <returns>Product attribute values</returns>
        public virtual IList<string> ParseValues(string attributesXml, int productAttributeMappingId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("attributesXml", attributesXml);
            parameters.Add("productAttributeMappingId", productAttributeMappingId);
            return APIHelper.Instance.GetListAsync<string>("Catalogs", "ParseValues", parameters);
        }

        /// <summary>
        /// Adds an attribute
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <param name="productAttributeMapping">Product attribute mapping</param>
        /// <param name="value">Value</param>
        /// <param name="quantity">Quantity (used with AttributeValueType.AssociatedToProduct to specify the quantity entered by the customer)</param>
        /// <returns>Updated result (XML format)</returns>
        public virtual string AddProductAttribute(string attributesXml, ProductAttributeMapping productAttributeMapping, string value, int? quantity = null)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("attributesXml", attributesXml);
            parameters.Add("productAttributeMapping", productAttributeMapping);
            parameters.Add("value", value);
            parameters.Add("quantity", quantity);
            return APIHelper.Instance.GetAsync<string>("Catalogs", "AddProductAttribute", parameters);
        }

        /// <summary>
        /// Remove an attribute
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <param name="productAttributeMapping">Product attribute mapping</param>
        /// <returns>Updated result (XML format)</returns>
        public virtual string RemoveProductAttribute(string attributesXml, ProductAttributeMapping productAttributeMapping)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("attributesXml", attributesXml);
            parameters.Add("productAttributeMapping", productAttributeMapping);
            return APIHelper.Instance.GetAsync<string>("Catalogs", "RemoveProductAttribute", parameters);
        }

        /// <summary>
        /// Are attributes equal
        /// </summary>
        /// <param name="attributesXml1">The attributes of the first product</param>
        /// <param name="attributesXml2">The attributes of the second product</param>
        /// <param name="ignoreNonCombinableAttributes">A value indicating whether we should ignore non-combinable attributes</param>
        /// <param name="ignoreQuantity">A value indicating whether we should ignore the quantity of attribute value entered by the customer</param>
        /// <returns>Result</returns>
        public virtual bool AreProductAttributesEqual(string attributesXml1, string attributesXml2, bool ignoreNonCombinableAttributes, bool ignoreQuantity = true)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("attributesXml1", attributesXml1);
            parameters.Add("attributesXml2", attributesXml2);
            parameters.Add("ignoreNonCombinableAttributes", ignoreNonCombinableAttributes);
            parameters.Add("ignoreQuantity", ignoreQuantity);
            return APIHelper.Instance.GetAsync<bool>("Catalogs", "AreProductAttributesEqual", parameters);
        }

        /// <summary>
        /// Check whether condition of some attribute is met (if specified). Return "null" if not condition is specified
        /// </summary>
        /// <param name="pam">Product attribute</param>
        /// <param name="selectedAttributesXml">Selected attributes (XML format)</param>
        /// <returns>Result</returns>
        public virtual bool? IsConditionMet(ProductAttributeMapping pam, string selectedAttributesXml)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("pam", pam);
            parameters.Add("selectedAttributesXml", selectedAttributesXml);
            return APIHelper.Instance.GetAsync<bool>("Catalogs", "IsConditionMet", parameters);
        }

        /// <summary>
        /// Finds a product attribute combination by attributes stored in XML 
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <param name="ignoreNonCombinableAttributes">A value indicating whether we should ignore non-combinable attributes</param>
        /// <returns>Found product attribute combination</returns>
        public virtual ProductAttributeCombination FindProductAttributeCombination(Product product,
            string attributesXml, bool ignoreNonCombinableAttributes = true)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("product", product);
            parameters.Add("attributesXml", attributesXml);
            parameters.Add("ignoreNonCombinableAttributes", ignoreNonCombinableAttributes);
            return APIHelper.Instance.GetAsync<ProductAttributeCombination>("Catalogs", "FindProductAttributeCombination", parameters);
        }

        /// <summary>
        /// Generate all combinations
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="ignoreNonCombinableAttributes">A value indicating whether we should ignore non-combinable attributes</param>
        /// <returns>Attribute combinations in XML format</returns>
        public virtual IList<string> GenerateAllCombinations(Product product, bool ignoreNonCombinableAttributes = false)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("product", product);
            parameters.Add("ignoreNonCombinableAttributes", ignoreNonCombinableAttributes);
            return APIHelper.Instance.GetListAsync<string>("Catalogs", "GenerateAllCombinations", parameters);
        }

        #endregion

        #region Gift card attributes

        /// <summary>
        /// Add gift card attrbibutes
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <param name="recipientName">Recipient name</param>
        /// <param name="recipientEmail">Recipient email</param>
        /// <param name="senderName">Sender name</param>
        /// <param name="senderEmail">Sender email</param>
        /// <param name="giftCardMessage">Message</param>
        /// <returns>Attributes</returns>
        public string AddGiftCardAttribute(string attributesXml, string recipientName,
            string recipientEmail, string senderName, string senderEmail, string giftCardMessage)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("attributesXml", attributesXml);
            parameters.Add("recipientName", recipientName);
            parameters.Add("recipientEmail", recipientEmail);
            parameters.Add("senderName", senderName);
            parameters.Add("senderEmail", senderEmail);
            parameters.Add("giftCardMessage", giftCardMessage);
            return APIHelper.Instance.GetAsync<string>("Catalogs", "AddGiftCardAttribute", parameters);
        }

        /// <summary>
        /// Get gift card attrbibutes
        /// </summary>
        /// <param name="attributesXml">Attributes</param>
        /// <param name="recipientName">Recipient name</param>
        /// <param name="recipientEmail">Recipient email</param>
        /// <param name="senderName">Sender name</param>
        /// <param name="senderEmail">Sender email</param>
        /// <param name="giftCardMessage">Message</param>
        public void GetGiftCardAttribute(string attributesXml, out string recipientName,
            out string recipientEmail, out string senderName,
            out string senderEmail, out string giftCardMessage)
        {
            recipientName = "";
            recipientEmail = "";
            senderName = "";
            senderEmail = "";
            giftCardMessage = "";

            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("attributesXml", attributesXml);
            parameters.Add("recipientName", recipientName);
            parameters.Add("recipientEmail", recipientEmail);
            parameters.Add("senderName", senderName);
            parameters.Add("senderEmail", senderEmail);
            parameters.Add("giftCardMessage", giftCardMessage);
            APIHelper.Instance.GetAsync<string>("Catalogs", "GetGiftCardAttribute", parameters);
        }

        #endregion
    }
}
