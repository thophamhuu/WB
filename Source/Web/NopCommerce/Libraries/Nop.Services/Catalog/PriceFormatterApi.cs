using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Catalog
{
    public partial class PriceFormatterApi : IPriceFormatter
    {
        #region Methods

        /// <summary>
        /// Formats the price
        /// </summary>
        /// <param name="price">Price</param>
        /// <returns>Price</returns>
        public virtual string FormatPrice(decimal price)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("price", price);
            return APIHelper.Instance.GetAsync<string>("Catalogs", "FormatPrice", parameters);
        }

        /// <summary>
        /// Formats the price
        /// </summary>
        /// <param name="price">Price</param>
        /// <param name="showCurrency">A value indicating whether to show a currency</param>
        /// <param name="targetCurrency">Target currency</param>
        /// <returns>Price</returns>
        public virtual string FormatPrice(decimal price, bool showCurrency, Currency targetCurrency)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("price", price);
            parameters.Add("showCurrency", showCurrency);
            parameters.Add("targetCurrency", targetCurrency);
            return APIHelper.Instance.GetAsync<string>("Catalogs", "FormatPrice", parameters);
        }

        /// <summary>
        /// Formats the price
        /// </summary>
        /// <param name="price">Price</param>
        /// <param name="showCurrency">A value indicating whether to show a currency</param>
        /// <param name="showTax">A value indicating whether to show tax suffix</param>
        /// <returns>Price</returns>
        public virtual string FormatPrice(decimal price, bool showCurrency, bool showTax)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("price", price);
            parameters.Add("showCurrency", showCurrency);
            parameters.Add("showTax", showTax);
            return APIHelper.Instance.GetAsync<string>("Catalogs", "FormatPrice", parameters);
        }

        /// <summary>
        /// Formats the price
        /// </summary>
        /// <param name="price">Price</param>
        /// <param name="showCurrency">A value indicating whether to show a currency</param>
        /// <param name="currencyCode">Currency code</param>
        /// <param name="showTax">A value indicating whether to show tax suffix</param>
        /// <param name="language">Language</param>
        /// <returns>Price</returns>
        public virtual string FormatPrice(decimal price, bool showCurrency,
            string currencyCode, bool showTax, Language language)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("price", price);
            parameters.Add("showCurrency", showCurrency);
            parameters.Add("currencyCode", currencyCode);
            parameters.Add("showTax", showTax);
            parameters.Add("language", language);
            return APIHelper.Instance.GetAsync<string>("Catalogs", "FormatPrice", parameters);
        }

        /// <summary>
        /// Formats the price
        /// </summary>
        /// <param name="price">Price</param>
        /// <param name="showCurrency">A value indicating whether to show a currency</param>
        /// <param name="currencyCode">Currency code</param>
        /// <param name="language">Language</param>
        /// <param name="priceIncludesTax">A value indicating whether price includes tax</param>
        /// <returns>Price</returns>
        public virtual string FormatPrice(decimal price, bool showCurrency,
            string currencyCode, Language language, bool priceIncludesTax)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("price", price);
            parameters.Add("showCurrency", showCurrency);
            parameters.Add("currencyCode", currencyCode);
            parameters.Add("language", language);
            parameters.Add("priceIncludesTax", priceIncludesTax);
            return APIHelper.Instance.GetAsync<string>("Catalogs", "FormatPrice", parameters);
        }

        /// <summary>
        /// Formats the price
        /// </summary>
        /// <param name="price">Price</param>
        /// <param name="showCurrency">A value indicating whether to show a currency</param>
        /// <param name="targetCurrency">Target currency</param>
        /// <param name="language">Language</param>
        /// <param name="priceIncludesTax">A value indicating whether price includes tax</param>
        /// <returns>Price</returns>
        public virtual string FormatPrice(decimal price, bool showCurrency,
            Currency targetCurrency, Language language, bool priceIncludesTax)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("price", price);
            parameters.Add("showCurrency", showCurrency);
            parameters.Add("targetCurrency", targetCurrency);
            parameters.Add("language", language);
            parameters.Add("priceIncludesTax", priceIncludesTax);
            return APIHelper.Instance.GetAsync<string>("Catalogs", "FormatPrice", parameters);
        }

        /// <summary>
        /// Formats the price
        /// </summary>
        /// <param name="price">Price</param>
        /// <param name="showCurrency">A value indicating whether to show a currency</param>
        /// <param name="targetCurrency">Target currency</param>
        /// <param name="language">Language</param>
        /// <param name="priceIncludesTax">A value indicating whether price includes tax</param>
        /// <param name="showTax">A value indicating whether to show tax suffix</param>
        /// <returns>Price</returns>
        public virtual string FormatPrice(decimal price, bool showCurrency,
            Currency targetCurrency, Language language, bool priceIncludesTax, bool showTax)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("price", price);
            parameters.Add("showCurrency", showCurrency);
            parameters.Add("targetCurrency", targetCurrency);
            parameters.Add("language", language);
            parameters.Add("priceIncludesTax", priceIncludesTax);
            parameters.Add("showTax", showTax);
            return APIHelper.Instance.GetAsync<string>("Catalogs", "FormatPrice", parameters);
        }

        /// <summary>
        /// Formats the price of rental product (with rental period)
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="price">Price</param>
        /// <returns>Rental product price with period</returns>
        public virtual string FormatRentalProductPeriod(Product product, string price)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("product", product);
            parameters.Add("price", price);
            return APIHelper.Instance.GetAsync<string>("Catalogs", "FormatRentalProductPeriod", parameters);
        }


        /// <summary>
        /// Formats the shipping price
        /// </summary>
        /// <param name="price">Price</param>
        /// <param name="showCurrency">A value indicating whether to show a currency</param>
        /// <returns>Price</returns>
        public virtual string FormatShippingPrice(decimal price, bool showCurrency)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("price", price);
            parameters.Add("showCurrency", showCurrency);
            return APIHelper.Instance.GetAsync<string>("Catalogs", "FormatShippingPrice", parameters);
        }

        /// <summary>
        /// Formats the shipping price
        /// </summary>
        /// <param name="price">Price</param>
        /// <param name="showCurrency">A value indicating whether to show a currency</param>
        /// <param name="targetCurrency">Target currency</param>
        /// <param name="language">Language</param>
        /// <param name="priceIncludesTax">A value indicating whether price includes tax</param>
        /// <returns>Price</returns>
        public virtual string FormatShippingPrice(decimal price, bool showCurrency,
            Currency targetCurrency, Language language, bool priceIncludesTax)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("price", price);
            parameters.Add("showCurrency", showCurrency);
            parameters.Add("targetCurrency", targetCurrency);
            parameters.Add("language", language);
            parameters.Add("priceIncludesTax", priceIncludesTax);
            return APIHelper.Instance.GetAsync<string>("Catalogs", "FormatShippingPrice", parameters);
        }

        /// <summary>
        /// Formats the shipping price
        /// </summary>
        /// <param name="price">Price</param>
        /// <param name="showCurrency">A value indicating whether to show a currency</param>
        /// <param name="targetCurrency">Target currency</param>
        /// <param name="language">Language</param>
        /// <param name="priceIncludesTax">A value indicating whether price includes tax</param>
        /// <param name="showTax">A value indicating whether to show tax suffix</param>
        /// <returns>Price</returns>
        public virtual string FormatShippingPrice(decimal price, bool showCurrency,
            Currency targetCurrency, Language language, bool priceIncludesTax, bool showTax)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("price", price);
            parameters.Add("showCurrency", showCurrency);
            parameters.Add("targetCurrency", targetCurrency);
            parameters.Add("language", language);
            parameters.Add("priceIncludesTax", priceIncludesTax);
            parameters.Add("showTax", showTax);
            return APIHelper.Instance.GetAsync<string>("Catalogs", "FormatShippingPrice", parameters);
        }

        /// <summary>
        /// Formats the shipping price
        /// </summary>
        /// <param name="price">Price</param>
        /// <param name="showCurrency">A value indicating whether to show a currency</param>
        /// <param name="currencyCode">Currency code</param>
        /// <param name="language">Language</param>
        /// <param name="priceIncludesTax">A value indicating whether price includes tax</param>
        /// <returns>Price</returns>
        public virtual string FormatShippingPrice(decimal price, bool showCurrency,
            string currencyCode, Language language, bool priceIncludesTax)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("price", price);
            parameters.Add("showCurrency", showCurrency);
            parameters.Add("currencyCode", currencyCode);
            parameters.Add("language", language);
            parameters.Add("priceIncludesTax", priceIncludesTax);
            return APIHelper.Instance.GetAsync<string>("Catalogs", "FormatShippingPrice", parameters);
        }



        /// <summary>
        /// Formats the payment method additional fee
        /// </summary>
        /// <param name="price">Price</param>
        /// <param name="showCurrency">A value indicating whether to show a currency</param>
        /// <returns>Price</returns>
        public virtual string FormatPaymentMethodAdditionalFee(decimal price, bool showCurrency)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("price", price);
            parameters.Add("showCurrency", showCurrency);
            return APIHelper.Instance.GetAsync<string>("Catalogs", "FormatPaymentMethodAdditionalFee", parameters);
        }

        /// <summary>
        /// Formats the payment method additional fee
        /// </summary>
        /// <param name="price">Price</param>
        /// <param name="showCurrency">A value indicating whether to show a currency</param>
        /// <param name="targetCurrency">Target currency</param>
        /// <param name="language">Language</param>
        /// <param name="priceIncludesTax">A value indicating whether price includes tax</param>
        /// <returns>Price</returns>
        public virtual string FormatPaymentMethodAdditionalFee(decimal price, bool showCurrency,
            Currency targetCurrency, Language language, bool priceIncludesTax)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("price", price);
            parameters.Add("showCurrency", showCurrency);
            parameters.Add("targetCurrency", targetCurrency);
            parameters.Add("language", language);
            parameters.Add("priceIncludesTax", priceIncludesTax);
            return APIHelper.Instance.GetAsync<string>("Catalogs", "FormatPaymentMethodAdditionalFee", parameters);
        }

        /// <summary>
        /// Formats the payment method additional fee
        /// </summary>
        /// <param name="price">Price</param>
        /// <param name="showCurrency">A value indicating whether to show a currency</param>
        /// <param name="targetCurrency">Target currency</param>
        /// <param name="language">Language</param>
        /// <param name="priceIncludesTax">A value indicating whether price includes tax</param>
        /// <param name="showTax">A value indicating whether to show tax suffix</param>
        /// <returns>Price</returns>
        public virtual string FormatPaymentMethodAdditionalFee(decimal price, bool showCurrency,
            Currency targetCurrency, Language language, bool priceIncludesTax, bool showTax)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("price", price);
            parameters.Add("showCurrency", showCurrency);
            parameters.Add("targetCurrency", targetCurrency);
            parameters.Add("language", language);
            parameters.Add("priceIncludesTax", priceIncludesTax);
            parameters.Add("showTax", showTax);
            return APIHelper.Instance.GetAsync<string>("Catalogs", "FormatPaymentMethodAdditionalFee", parameters);
        }

        /// <summary>
        /// Formats the payment method additional fee
        /// </summary>
        /// <param name="price">Price</param>
        /// <param name="showCurrency">A value indicating whether to show a currency</param>
        /// <param name="currencyCode">Currency code</param>
        /// <param name="language">Language</param>
        /// <param name="priceIncludesTax">A value indicating whether price includes tax</param>
        /// <returns>Price</returns>
        public virtual string FormatPaymentMethodAdditionalFee(decimal price, bool showCurrency,
            string currencyCode, Language language, bool priceIncludesTax)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("price", price);
            parameters.Add("showCurrency", showCurrency);
            parameters.Add("currencyCode", currencyCode);
            parameters.Add("language", language);
            parameters.Add("priceIncludesTax", priceIncludesTax);
            return APIHelper.Instance.GetAsync<string>("Catalogs", "FormatPaymentMethodAdditionalFee", parameters);
        }


        /// <summary>
        /// Formats a tax rate
        /// </summary>
        /// <param name="taxRate">Tax rate</param>
        /// <returns>Formatted tax rate</returns>
        public virtual string FormatTaxRate(decimal taxRate)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("taxRate", taxRate);
            return APIHelper.Instance.GetAsync<string>("Catalogs", "FormatTaxRate", parameters);
        }

        #endregion
    }
}
