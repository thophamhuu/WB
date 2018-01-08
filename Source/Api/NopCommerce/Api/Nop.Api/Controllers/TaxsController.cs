using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Tax;
using Nop.Services.Tax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace Nop.Api.Controllers
{
    public class TaxsController : ApiController
    {
        #region Fields

        private readonly ITaxService _taxService;
        private readonly ITaxCategoryService _taxCategoryService;
        private readonly ITaxProvider _taxProvider;

        #endregion

        #region Ctor

        public TaxsController(ITaxService taxService, ITaxCategoryService taxCategoryService, ITaxProvider taxProvider)
        {
            this._taxService = taxService;
            this._taxCategoryService = taxCategoryService;
            this._taxProvider = taxProvider;
        }

        #endregion

        #region Method

        #region Tax

        #region Tax providers

        /// <summary>
        /// Load active tax provider
        /// </summary>
        /// <param name="customer">Load records allowed only to a specified customer; pass null to ignore ACL permissions</param>
        /// <returns>Active tax provider</returns>
        public ITaxProvider LoadActiveTaxProvider([FromBody]Customer customer = null)
        {
            return _taxService.LoadActiveTaxProvider(customer);
        }

        /// <summary>
        /// Load tax provider by system name
        /// </summary>
        /// <param name="systemName">System name</param>
        /// <returns>Found tax provider</returns>
        public ITaxProvider LoadTaxProviderBySystemName(string systemName)
        {
            return _taxService.LoadTaxProviderBySystemName(systemName);
        }

        /// <summary>
        /// Load all tax providers
        /// </summary>
        /// <param name="customer">Load records allowed only to a specified customer; pass null to ignore ACL permissions</param>
        /// <returns>Tax providers</returns>
        public IList<ITaxProvider> LoadAllTaxProviders([FromBody]Customer customer = null)
        {
            return _taxService.LoadAllTaxProviders(customer);
        }

        #endregion

        #region Product price

        /// <summary>
        /// Gets price
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="price">Price</param>
        /// <param name="taxRate">Tax rate</param>
        /// <returns>Price</returns>
        public decimal GetProductPrice(Product product, decimal price,
            out decimal taxRate)
        {
            return _taxService.GetProductPrice(product, price, out taxRate);
        }

        /// <summary>
        /// Gets price
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="price">Price</param>
        /// <param name="customer">Customer</param>
        /// <param name="taxRate">Tax rate</param>
        /// <returns>Price</returns>
        public decimal GetProductPrice(Product product, decimal price,
            Customer customer, out decimal taxRate)
        {
            return _taxService.GetProductPrice(product, price, customer, out taxRate);
        }

        /// <summary>
        /// Gets price
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="price">Price</param>
        /// <param name="includingTax">A value indicating whether calculated price should include tax</param>
        /// <param name="customer">Customer</param>
        /// <param name="taxRate">Tax rate</param>
        /// <returns>Price</returns>
        public decimal GetProductPrice(Product product, decimal price,
            bool includingTax, Customer customer, out decimal taxRate)
        {
            return _taxService.GetProductPrice(product, price, includingTax, customer, out taxRate);
        }

        /// <summary>
        /// Gets price
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="taxCategoryId">Tax category identifier</param>
        /// <param name="price">Price</param>
        /// <param name="includingTax">A value indicating whether calculated price should include tax</param>
        /// <param name="customer">Customer</param>
        /// <param name="priceIncludesTax">A value indicating whether price already includes tax</param>
        /// <param name="taxRate">Tax rate</param>
        /// <returns>Price</returns>
        public decimal GetProductPrice(Product product, int taxCategoryId, decimal price,
            bool includingTax, Customer customer,
            bool priceIncludesTax, out decimal taxRate)
        {
            return _taxService.GetProductPrice(product, taxCategoryId, price, includingTax, customer, priceIncludesTax, out taxRate);
        }

        #endregion

        #region Shipping price

        /// <summary>
        /// Gets shipping price
        /// </summary>
        /// <param name="price">Price</param>
        /// <param name="customer">Customer</param>
        /// <returns>Price</returns>
        public decimal GetShippingPrice(decimal price, Customer customer)
        {
            return _taxService.GetShippingPrice(price, customer);
        }

        /// <summary>
        /// Gets shipping price
        /// </summary>
        /// <param name="price">Price</param>
        /// <param name="includingTax">A value indicating whether calculated price should include tax</param>
        /// <param name="customer">Customer</param>
        /// <returns>Price</returns>
        public decimal GetShippingPrice(decimal price, bool includingTax, Customer customer)
        {
            return _taxService.GetShippingPrice(price, includingTax, customer);
        }

        /// <summary>
        /// Gets shipping price
        /// </summary>
        /// <param name="price">Price</param>
        /// <param name="includingTax">A value indicating whether calculated price should include tax</param>
        /// <param name="customer">Customer</param>
        /// <param name="taxRate">Tax rate</param>
        /// <returns>Price</returns>
        public decimal GetShippingPrice(decimal price, bool includingTax, Customer customer, out decimal taxRate)
        {
            return _taxService.GetShippingPrice(price, includingTax, customer, out taxRate);
        }

        #endregion

        #region Payment additional fee

        /// <summary>
        /// Gets payment method additional handling fee
        /// </summary>
        /// <param name="price">Price</param>
        /// <param name="customer">Customer</param>
        /// <returns>Price</returns>
        public decimal GetPaymentMethodAdditionalFee(decimal price, Customer customer)
        {
            return _taxService.GetPaymentMethodAdditionalFee(price, customer);
        }

        /// <summary>
        /// Gets payment method additional handling fee
        /// </summary>
        /// <param name="price">Price</param>
        /// <param name="includingTax">A value indicating whether calculated price should include tax</param>
        /// <param name="customer">Customer</param>
        /// <returns>Price</returns>
        public decimal GetPaymentMethodAdditionalFee(decimal price, bool includingTax, Customer customer)
        {
            return _taxService.GetPaymentMethodAdditionalFee(price, includingTax, customer);
        }

        /// <summary>
        /// Gets payment method additional handling fee
        /// </summary>
        /// <param name="price">Price</param>
        /// <param name="includingTax">A value indicating whether calculated price should include tax</param>
        /// <param name="customer">Customer</param>
        /// <param name="taxRate">Tax rate</param>
        /// <returns>Price</returns>
        public decimal GetPaymentMethodAdditionalFee(decimal price, bool includingTax, Customer customer, out decimal taxRate)
        {
            return _taxService.GetPaymentMethodAdditionalFee(price, includingTax, customer, out taxRate);
        }

        #endregion

        #region Checkout attribute price

        /// <summary>
        /// Gets checkout attribute value price
        /// </summary>
        /// <param name="cav">Checkout attribute value</param>
        /// <returns>Price</returns>
        public decimal GetCheckoutAttributePrice([FromBody]CheckoutAttributeValue cav)
        {
            return _taxService.GetCheckoutAttributePrice(cav);
        }

        /// <summary>
        /// Gets checkout attribute value price
        /// </summary>
        /// <param name="cav">Checkout attribute value</param>
        /// <param name="customer">Customer</param>
        /// <returns>Price</returns>
        public decimal GetCheckoutAttributePrice(CheckoutAttributeValue cav, Customer customer)
        {
            return _taxService.GetCheckoutAttributePrice(cav, customer);
        }

        /// <summary>
        /// Gets checkout attribute value price
        /// </summary>
        /// <param name="cav">Checkout attribute value</param>
        /// <param name="includingTax">A value indicating whether calculated price should include tax</param>
        /// <param name="customer">Customer</param>
        /// <returns>Price</returns>
        public decimal GetCheckoutAttributePrice(CheckoutAttributeValue cav,
            bool includingTax, Customer customer)
        {
            return _taxService.GetCheckoutAttributePrice(cav, includingTax, customer);
        }

        /// <summary>
        /// Gets checkout attribute value price
        /// </summary>
        /// <param name="cav">Checkout attribute value</param>
        /// <param name="includingTax">A value indicating whether calculated price should include tax</param>
        /// <param name="customer">Customer</param>
        /// <param name="taxRate">Tax rate</param>
        /// <returns>Price</returns>
        public decimal GetCheckoutAttributePrice(CheckoutAttributeValue cav,
            bool includingTax, Customer customer, out decimal taxRate)
        {
            return _taxService.GetCheckoutAttributePrice(cav, includingTax, customer, out taxRate);
        }

        #endregion

        #region VAT

        /// <summary>
        /// Gets VAT Number status
        /// </summary>
        /// <param name="fullVatNumber">Two letter ISO code of a country and VAT number (e.g. GB 111 1111 111)</param>
        /// <returns>VAT Number status</returns>
        public VatNumberStatus GetVatNumberStatus(string fullVatNumber)
        {
            return _taxService.GetVatNumberStatus(fullVatNumber);
        }

        /// <summary>
        /// Gets VAT Number status
        /// </summary>
        /// <param name="fullVatNumber">Two letter ISO code of a country and VAT number (e.g. GB 111 1111 111)</param>
        /// <param name="name">Name (if received)</param>
        /// <param name="address">Address (if received)</param>
        /// <returns>VAT Number status</returns>
        public VatNumberStatus GetVatNumberStatus(string fullVatNumber,
            out string name, out string address)
        {
            return _taxService.GetVatNumberStatus(fullVatNumber, out name, out address);
        }
        /// <summary>
        /// Gets VAT Number status
        /// </summary>
        /// <param name="twoLetterIsoCode">Two letter ISO code of a country</param>
        /// <param name="vatNumber">VAT number</param>
        /// <returns>VAT Number status</returns>
        public VatNumberStatus GetVatNumberStatus(string twoLetterIsoCode, string vatNumber)
        {
            return _taxService.GetVatNumberStatus(twoLetterIsoCode, vatNumber);
        }

        /// <summary>
        /// Gets VAT Number status
        /// </summary>
        /// <param name="twoLetterIsoCode">Two letter ISO code of a country</param>
        /// <param name="vatNumber">VAT number</param>
        /// <param name="name">Name (if received)</param>
        /// <param name="address">Address (if received)</param>
        /// <returns>VAT Number status</returns>
        public VatNumberStatus GetVatNumberStatus(string twoLetterIsoCode, string vatNumber,
            out string name, out string address)
        {
            return _taxService.GetVatNumberStatus(twoLetterIsoCode, vatNumber, out name, out address);
        }

        /// <summary>
        /// Performs a basic check of a VAT number for validity
        /// </summary>
        /// <param name="twoLetterIsoCode">Two letter ISO code of a country</param>
        /// <param name="vatNumber">VAT number</param>
        /// <param name="name">Company name</param>
        /// <param name="address">Address</param>
        /// <param name="exception">Exception</param>
        /// <returns>VAT number status</returns>
        public VatNumberStatus DoVatCheck(string twoLetterIsoCode, string vatNumber,
            out string name, out string address, out Exception exception)
        {
            return _taxService.DoVatCheck(twoLetterIsoCode, vatNumber, out name, out address, out exception);
        }

        #endregion

        #region Exempts

        /// <summary>
        /// Gets a value indicating whether a product is tax exempt
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="customer">Customer</param>
        /// <returns>A value indicating whether a product is tax exempt</returns>
        public bool IsTaxExempt(Product product, Customer customer)
        {
            return _taxService.IsTaxExempt(product, customer);
        }

        /// <summary>
        /// Gets a value indicating whether EU VAT exempt (the European Union Value Added Tax)
        /// </summary>
        /// <param name="address">Address</param>
        /// <param name="customer">Customer</param>
        /// <returns>Result</returns>
        public bool IsVatExempt(Address address, Customer customer)
        {
            return _taxService.IsVatExempt(address, customer);
        }

        #endregion

        #endregion

        #region TaxCategory

        /// <summary>
        /// Deletes a tax category
        /// </summary>
        /// <param name="taxCategory">Tax category</param>
        public void DeleteTaxCategory([FromBody]TaxCategory taxCategory)
        {
            _taxCategoryService.DeleteTaxCategory(taxCategory);
        }

        /// <summary>
        /// Gets all tax categories
        /// </summary>
        /// <returns>Tax categories</returns>
        public IList<TaxCategory> GetAllTaxCategories()
        {
            return _taxCategoryService.GetAllTaxCategories();
        }

        /// <summary>
        /// Gets a tax category
        /// </summary>
        /// <param name="taxCategoryId">Tax category identifier</param>
        /// <returns>Tax category</returns>
        public TaxCategory GetTaxCategoryById(int taxCategoryId)
        {
            return _taxCategoryService.GetTaxCategoryById(taxCategoryId);
        }

        /// <summary>
        /// Inserts a tax category
        /// </summary>
        /// <param name="taxCategory">Tax category</param>
        public void InsertTaxCategory([FromBody]TaxCategory taxCategory)
        {
            _taxCategoryService.InsertTaxCategory(taxCategory);
        }

        /// <summary>
        /// Updates the tax category
        /// </summary>
        /// <param name="taxCategory">Tax category</param>
        public void UpdateTaxCategory([FromBody]TaxCategory taxCategory)
        {
            _taxCategoryService.UpdateTaxCategory(taxCategory);
        }

        #endregion

        #region TaxProvider

        /// <summary>
        /// Gets tax rate
        /// </summary>
        /// <param name="calculateTaxRequest">Tax calculation request</param>
        /// <returns>Tax</returns>
        public CalculateTaxResult GetTaxRate(CalculateTaxRequest calculateTaxRequest)
        {
            return _taxProvider.GetTaxRate(calculateTaxRequest);
        }

        /// <summary>
        /// Gets a route for provider configuration
        /// </summary>
        /// <param name="actionName">Action name</param>
        /// <param name="controllerName">Controller name</param>
        /// <param name="routeValues">Route values</param>
        public void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            _taxProvider.GetConfigurationRoute(out actionName, out controllerName, out routeValues);   
        }

        #endregion

        #endregion
    }
}
