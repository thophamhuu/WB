using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Directory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Directory
{
    public partial class CurrencyApiService : ICurrencyService
    {
        #region Methods

        #region Currency

        /// <summary>
        /// Gets currency live rates
        /// </summary>
        /// <param name="exchangeRateCurrencyCode">Exchange rate currency code</param>
        /// <param name="customer">Load records allowed only to a specified customer; pass null to ignore ACL permissions</param>
        /// <returns>Exchange rates</returns>
        public virtual IList<ExchangeRate> GetCurrencyLiveRates(string exchangeRateCurrencyCode, Customer customer = null)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("exchangeRateCurrencyCode", exchangeRateCurrencyCode);
            parameters.Add("customer", customer);
            return APIHelper.Instance.GetListAsync<ExchangeRate>("Directory", "GetCurrencyLiveRates", parameters);
        }

        /// <summary>
        /// Deletes currency
        /// </summary>
        /// <param name="currency">Currency</param>
        public virtual void DeleteCurrency(Currency currency)
        {
            APIHelper.Instance.PostAsync("Directory", "DeleteCurrency", currency);
        }

        /// <summary>
        /// Gets a currency
        /// </summary>
        /// <param name="currencyId">Currency identifier</param>
        /// <returns>Currency</returns>
        public virtual Currency GetCurrencyById(int currencyId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("currencyId", currencyId);
            return APIHelper.Instance.GetAsync<Currency>("Directory", "GetCurrencyById", parameters);
        }

        /// <summary>
        /// Gets a currency by code
        /// </summary>
        /// <param name="currencyCode">Currency code</param>
        /// <returns>Currency</returns>
        public virtual Currency GetCurrencyByCode(string currencyCode)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("currencyCode", currencyCode);
            return APIHelper.Instance.GetAsync<Currency>("Directory", "GetCurrencyByCode", parameters);
        }

        /// <summary>
        /// Gets all currencies
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <param name="storeId">Load records allowed only in a specified store; pass 0 to load all records</param>
        /// <returns>Currencies</returns>
        public virtual IList<Currency> GetAllCurrencies(bool showHidden = false, int storeId = 0)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("showHidden", showHidden);
            parameters.Add("storeId", storeId);
            return APIHelper.Instance.GetListAsync<Currency>("Directory", "GetAllCurrencies", parameters);
        }

        /// <summary>
        /// Inserts a currency
        /// </summary>
        /// <param name="currency">Currency</param>
        public virtual void InsertCurrency(Currency currency)
        {
            APIHelper.Instance.PostAsync("Directory", "InsertCurrency", currency);
        }

        /// <summary>
        /// Updates the currency
        /// </summary>
        /// <param name="currency">Currency</param>
        public virtual void UpdateCurrency(Currency currency)
        {
            APIHelper.Instance.PostAsync("Directory", "UpdateCurrency", currency);
        }

        #endregion

        #region Conversions

        /// <summary>
        /// Converts currency
        /// </summary>
        /// <param name="amount">Amount</param>
        /// <param name="exchangeRate">Currency exchange rate</param>
        /// <returns>Converted value</returns>
        public virtual decimal ConvertCurrency(decimal amount, decimal exchangeRate)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("amount", amount);
            parameters.Add("exchangeRate", exchangeRate);
            return APIHelper.Instance.GetAsync<decimal>("Directory", "ConvertCurrency", parameters);
        }

        /// <summary>
        /// Converts currency
        /// </summary>
        /// <param name="amount">Amount</param>
        /// <param name="sourceCurrencyCode">Source currency code</param>
        /// <param name="targetCurrencyCode">Target currency code</param>
        /// <returns>Converted value</returns>
        public virtual decimal ConvertCurrency(decimal amount, Currency sourceCurrencyCode, Currency targetCurrencyCode)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("amount", amount);
            parameters.Add("sourceCurrencyCode", sourceCurrencyCode);
            parameters.Add("targetCurrencyCode", targetCurrencyCode);
            return APIHelper.Instance.GetAsync<decimal>("Directory", "ConvertCurrency", parameters);
        }

        /// <summary>
        /// Converts to primary exchange rate currency 
        /// </summary>
        /// <param name="amount">Amount</param>
        /// <param name="sourceCurrencyCode">Source currency code</param>
        /// <returns>Converted value</returns>
        public virtual decimal ConvertToPrimaryExchangeRateCurrency(decimal amount, Currency sourceCurrencyCode)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("amount", amount);
            parameters.Add("sourceCurrencyCode", sourceCurrencyCode);
            return APIHelper.Instance.GetAsync<decimal>("Directory", "ConvertToPrimaryExchangeRateCurrency", parameters);
        }

        /// <summary>
        /// Converts from primary exchange rate currency
        /// </summary>
        /// <param name="amount">Amount</param>
        /// <param name="targetCurrencyCode">Target currency code</param>
        /// <returns>Converted value</returns>
        public virtual decimal ConvertFromPrimaryExchangeRateCurrency(decimal amount, Currency targetCurrencyCode)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("amount", amount);
            parameters.Add("targetCurrencyCode", targetCurrencyCode);
            return APIHelper.Instance.GetAsync<decimal>("Directory", "ConvertFromPrimaryExchangeRateCurrency", parameters);
        }

        /// <summary>
        /// Converts to primary store currency 
        /// </summary>
        /// <param name="amount">Amount</param>
        /// <param name="sourceCurrencyCode">Source currency code</param>
        /// <returns>Converted value</returns>
        public virtual decimal ConvertToPrimaryStoreCurrency(decimal amount, Currency sourceCurrencyCode)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("amount", amount);
            parameters.Add("sourceCurrencyCode", sourceCurrencyCode);
            return APIHelper.Instance.GetAsync<decimal>("Directory", "ConvertToPrimaryStoreCurrency", parameters);
        }

        /// <summary>
        /// Converts from primary store currency
        /// </summary>
        /// <param name="amount">Amount</param>
        /// <param name="targetCurrencyCode">Target currency code</param>
        /// <returns>Converted value</returns>
        public virtual decimal ConvertFromPrimaryStoreCurrency(decimal amount, Currency targetCurrencyCode)
        {
            var obj = new { amount, targetCurrencyCode };
            return APIHelper.Instance.PostAsync<decimal>("Directory", "ConvertFromPrimaryStoreCurrency", obj);
        }

        #endregion

        #region Exchange rate providers

        /// <summary>
        /// Load active exchange rate provider
        /// </summary>
        /// <param name="customer">Load records allowed only to a specified customer; pass null to ignore ACL permissions</param>
        /// <returns>Active exchange rate provider</returns>
        public virtual IExchangeRateProvider LoadActiveExchangeRateProvider(Customer customer = null)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customer", customer);
            return APIHelper.Instance.GetAsync<IExchangeRateProvider>("Directory", "LoadActiveExchangeRateProvider", parameters);
        }

        /// <summary>
        /// Load exchange rate provider by system name
        /// </summary>
        /// <param name="systemName">System name</param>
        /// <returns>Found exchange rate provider</returns>
        public virtual IExchangeRateProvider LoadExchangeRateProviderBySystemName(string systemName)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("systemName", systemName);
            return APIHelper.Instance.GetAsync<IExchangeRateProvider>("Directory", "LoadExchangeRateProviderBySystemName", parameters);
        }

        /// <summary>
        /// Load all exchange rate providers
        /// </summary>
        /// <param name="customer">Load records allowed only to a specified customer; pass null to ignore ACL permissions</param>
        /// <returns>Exchange rate providers</returns>
        public virtual IList<IExchangeRateProvider> LoadAllExchangeRateProviders(Customer customer = null)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("countryIds", customer);
            return APIHelper.Instance.GetListAsync<IExchangeRateProvider>("Directory", "LoadAllExchangeRateProviders", parameters);
        }

        #endregion

        #endregion
    }
}
