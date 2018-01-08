using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Directory;
using Nop.Services.Directory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nop.Api.Controllers
{
    [Authorize]
    public class DirectoryController : ApiController
    {
        #region Fields

        private readonly ICountryService _countryService;
        private readonly ICurrencyService _currencyService;
        private readonly IGeoLookupService _geoLookupService;
        private readonly IMeasureService _measureService;
        private readonly IStateProvinceService _stateProvinceService;

        #endregion

        #region Ctor

        public DirectoryController(ICountryService countryService, ICurrencyService currencyService, IGeoLookupService geoLookupService, IMeasureService measureService, IStateProvinceService stateProvinceService)
        {
            this._countryService = countryService;
            this._currencyService = currencyService;
            this._geoLookupService = geoLookupService;
            this._measureService = measureService;
            this._stateProvinceService = stateProvinceService;
        }

        #endregion

        #region Method

        #region Country

        /// <summary>
        /// Deletes a country
        /// </summary>
        /// <param name="country">Country</param>
        public void DeleteCountry(Country country)
        {
            _countryService.DeleteCountry(country);
        }

        /// <summary>
        /// Gets all countries
        /// </summary>
        /// <param name="languageId">Language identifier. It's used to sort countries by localized names (if specified); pass 0 to skip it</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Countries</returns>
        public IList<Country> GetAllCountries(int languageId = 0, bool showHidden = false)
        {
            return _countryService.GetAllCountries(languageId, showHidden);
        }

        /// <summary>
        /// Gets all countries that allow billing
        /// </summary>
        /// <param name="languageId">Language identifier. It's used to sort countries by localized names (if specified); pass 0 to skip it</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Countries</returns>
        public IList<Country> GetAllCountriesForBilling(int languageId = 0, bool showHidden = false)
        {
            return _countryService.GetAllCountriesForBilling(languageId, showHidden);
        }

        /// <summary>
        /// Gets all countries that allow shipping
        /// </summary>
        /// <param name="languageId">Language identifier. It's used to sort countries by localized names (if specified); pass 0 to skip it</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Countries</returns>
        public IList<Country> GetAllCountriesForShipping(int languageId = 0, bool showHidden = false)
        {
            return _countryService.GetAllCountriesForShipping(languageId, showHidden);
        }

        /// <summary>
        /// Gets a country 
        /// </summary>
        /// <param name="countryId">Country identifier</param>
        /// <returns>Country</returns>
        public Country GetCountryById(int countryId)
        {
            return _countryService.GetCountryById(countryId);
        }

        /// <summary>
        /// Get countries by identifiers
        /// </summary>
        /// <param name="countryIds">Country identifiers</param>
        /// <returns>Countries</returns>
        public IList<Country> GetCountriesByIds(int[] countryIds)
        {
            return _countryService.GetCountriesByIds(countryIds);
        }

        /// <summary>
        /// Gets a country by two letter ISO code
        /// </summary>
        /// <param name="twoLetterIsoCode">Country two letter ISO code</param>
        /// <returns>Country</returns>
        public Country GetCountryByTwoLetterIsoCode(string twoLetterIsoCode)
        {
            return _countryService.GetCountryByTwoLetterIsoCode(twoLetterIsoCode);
        }

        /// <summary>
        /// Gets a country by three letter ISO code
        /// </summary>
        /// <param name="threeLetterIsoCode">Country three letter ISO code</param>
        /// <returns>Country</returns>
        public Country GetCountryByThreeLetterIsoCode(string threeLetterIsoCode)
        {
            return _countryService.GetCountryByThreeLetterIsoCode(threeLetterIsoCode);
        }

        /// <summary>
        /// Inserts a country
        /// </summary>
        /// <param name="country">Country</param>
        public void InsertCountry(Country country)
        {
            _countryService.InsertCountry(country);
        }

        /// <summary>
        /// Updates the country
        /// </summary>
        /// <param name="country">Country</param>
        public void UpdateCountry(Country country)
        {
            _countryService.UpdateCountry(country);
        }

        #endregion

        #region Currency

        #region Currency

        /// <summary>
        /// Gets currency live rates
        /// </summary>
        /// <param name="exchangeRateCurrencyCode">Exchange rate currency code</param>
        /// <param name="customer">Load records allowed only to a specified customer; pass null to ignore ACL permissions</param>
        /// <returns>Exchange rates</returns>
        public IList<ExchangeRate> GetCurrencyLiveRates(string exchangeRateCurrencyCode, Customer customer = null)
        {
            return _currencyService.GetCurrencyLiveRates(exchangeRateCurrencyCode, customer);
        }

        /// <summary>
        /// Deletes currency
        /// </summary>
        /// <param name="currency">Currency</param>
        public void DeleteCurrency(Currency currency)
        {
            _currencyService.DeleteCurrency(currency);
        }

        /// <summary>
        /// Gets a currency
        /// </summary>
        /// <param name="currencyId">Currency identifier</param>
        /// <returns>Currency</returns>
        public Currency GetCurrencyById(int currencyId)
        {
            return _currencyService.GetCurrencyById(currencyId);
        }

        /// <summary>
        /// Gets a currency by code
        /// </summary>
        /// <param name="currencyCode">Currency code</param>
        /// <returns>Currency</returns>
        public Currency GetCurrencyByCode(string currencyCode)
        {
            return _currencyService.GetCurrencyByCode(currencyCode);
        }

        /// <summary>
        /// Gets all currencies
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <param name="storeId">Load records allowed only in a specified store; pass 0 to load all records</param>
        /// <returns>Currencies</returns>
        public IList<Currency> GetAllCurrencies(bool showHidden = false, int storeId = 0)
        {
            return _currencyService.GetAllCurrencies(showHidden, storeId);
        }

        /// <summary>
        /// Inserts a currency
        /// </summary>
        /// <param name="currency">Currency</param>
        public void InsertCurrency(Currency currency)
        {
            _currencyService.InsertCurrency(currency);
        }

        /// <summary>
        /// Updates the currency
        /// </summary>
        /// <param name="currency">Currency</param>
        public void UpdateCurrency(Currency currency)
        {
            _currencyService.UpdateCurrency(currency);
        }

        #endregion

        #region Conversions

        /// <summary>
        /// Converts currency
        /// </summary>
        /// <param name="amount">Amount</param>
        /// <param name="exchangeRate">Currency exchange rate</param>
        /// <returns>Converted value</returns>
        public decimal ConvertCurrency(decimal amount, decimal exchangeRate)
        {
            return _currencyService.ConvertCurrency(amount, exchangeRate);
        }

        /// <summary>
        /// Converts currency
        /// </summary>
        /// <param name="amount">Amount</param>
        /// <param name="sourceCurrencyCode">Source currency code</param>
        /// <param name="targetCurrencyCode">Target currency code</param>
        /// <returns>Converted value</returns>
        public decimal ConvertCurrency(decimal amount, Currency sourceCurrencyCode, Currency targetCurrencyCode)
        {
            return _currencyService.ConvertCurrency(amount, sourceCurrencyCode, targetCurrencyCode);
        }

        /// <summary>
        /// Converts to primary exchange rate currency 
        /// </summary>
        /// <param name="amount">Amount</param>
        /// <param name="sourceCurrencyCode">Source currency code</param>
        /// <returns>Converted value</returns>
        public decimal ConvertToPrimaryExchangeRateCurrency(decimal amount, Currency sourceCurrencyCode)
        {
            return _currencyService.ConvertToPrimaryExchangeRateCurrency(amount, sourceCurrencyCode);
        }

        /// <summary>
        /// Converts from primary exchange rate currency
        /// </summary>
        /// <param name="amount">Amount</param>
        /// <param name="targetCurrencyCode">Target currency code</param>
        /// <returns>Converted value</returns>
        public decimal ConvertFromPrimaryExchangeRateCurrency(decimal amount, Currency targetCurrencyCode)
        {
            return _currencyService.ConvertFromPrimaryExchangeRateCurrency(amount, targetCurrencyCode);
        }

        /// <summary>
        /// Converts to primary store currency 
        /// </summary>
        /// <param name="amount">Amount</param>
        /// <param name="sourceCurrencyCode">Source currency code</param>
        /// <returns>Converted value</returns>
        public decimal ConvertToPrimaryStoreCurrency(decimal amount, Currency sourceCurrencyCode)
        {
            return _currencyService.ConvertToPrimaryStoreCurrency(amount, sourceCurrencyCode);
        }

        /// <summary>
        /// Converts from primary store currency
        /// </summary>
        /// <param name="amount">Amount</param>
        /// <param name="targetCurrencyCode">Target currency code</param>
        /// <returns>Converted value</returns>
        public decimal ConvertFromPrimaryStoreCurrency(decimal amount, Currency targetCurrencyCode)
        {
            return _currencyService.ConvertFromPrimaryStoreCurrency(amount, targetCurrencyCode);
        }

        #endregion

        #region Exchange rate providers

        /// <summary>
        /// Load active exchange rate provider
        /// </summary>
        /// <param name="customer">Load records allowed only to a specified customer; pass null to ignore ACL permissions</param>
        /// <returns>Active exchange rate provider</returns>
        public IExchangeRateProvider LoadActiveExchangeRateProvider(Customer customer = null)
        {
            return _currencyService.LoadActiveExchangeRateProvider(customer);
        }

        /// <summary>
        /// Load exchange rate provider by system name
        /// </summary>
        /// <param name="systemName">System name</param>
        /// <returns>Found exchange rate provider</returns>
        public IExchangeRateProvider LoadExchangeRateProviderBySystemName(string systemName)
        {
            return _currencyService.LoadExchangeRateProviderBySystemName(systemName);
        }

        /// <summary>
        /// Load all exchange rate providers
        /// </summary>
        /// <param name="customer">Load records allowed only to a specified customer; pass null to ignore ACL permissions</param>
        /// <returns>Exchange rate providers</returns>
        public IList<IExchangeRateProvider> LoadAllExchangeRateProviders(Customer customer = null)
        {
            return _currencyService.LoadAllExchangeRateProviders(customer);
        }

        #endregion

        #endregion

        #region GEO lookup

        /// <summary>
        /// Get country name
        /// </summary>
        /// <param name="ipAddress">IP address</param>
        /// <returns>Country name</returns>
        public string LookupCountryIsoCode(string ipAddress)
        {
            return _geoLookupService.LookupCountryIsoCode(ipAddress);
        }

        /// <summary>
        /// Get country name
        /// </summary>
        /// <param name="ipAddress">IP address</param>
        /// <returns>Country name</returns>
        public string LookupCountryName(string ipAddress)
        {
            return _geoLookupService.LookupCountryName(ipAddress);
        }

        #endregion

        #region Measure

        /// <summary>
        /// Deletes measure dimension
        /// </summary>
        /// <param name="measureDimension">Measure dimension</param>
        public void DeleteMeasureDimension(MeasureDimension measureDimension)
        {
            _measureService.DeleteMeasureDimension(measureDimension);
        }

        /// <summary>
        /// Gets a measure dimension by identifier
        /// </summary>
        /// <param name="measureDimensionId">Measure dimension identifier</param>
        /// <returns>Measure dimension</returns>
        public MeasureDimension GetMeasureDimensionById(int measureDimensionId)
        {
            return _measureService.GetMeasureDimensionById(measureDimensionId);
        }

        /// <summary>
        /// Gets a measure dimension by system keyword
        /// </summary>
        /// <param name="systemKeyword">The system keyword</param>
        /// <returns>Measure dimension</returns>
        public MeasureDimension GetMeasureDimensionBySystemKeyword(string systemKeyword)
        {
            return _measureService.GetMeasureDimensionBySystemKeyword(systemKeyword);
        }

        /// <summary>
        /// Gets all measure dimensions
        /// </summary>
        /// <returns>Measure dimensions</returns>
        public IList<MeasureDimension> GetAllMeasureDimensions()
        {
            return _measureService.GetAllMeasureDimensions();
        }

        /// <summary>
        /// Inserts a measure dimension
        /// </summary>
        /// <param name="measure">Measure dimension</param>
        public void InsertMeasureDimension(MeasureDimension measure)
        {
            _measureService.InsertMeasureDimension(measure);
        }

        /// <summary>
        /// Updates the measure dimension
        /// </summary>
        /// <param name="measure">Measure dimension</param>
        public void UpdateMeasureDimension(MeasureDimension measure)
        {
            _measureService.UpdateMeasureDimension(measure);
        }

        /// <summary>
        /// Converts dimension
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="sourceMeasureDimension">Source dimension</param>
        /// <param name="targetMeasureDimension">Target dimension</param>
        /// <param name="round">A value indicating whether a result should be rounded</param>
        /// <returns>Converted value</returns>
        public decimal ConvertDimension(decimal value,
            MeasureDimension sourceMeasureDimension, MeasureDimension targetMeasureDimension, bool round = true)
        {
            return _measureService.ConvertDimension(value, sourceMeasureDimension, targetMeasureDimension, round);
        }

        /// <summary>
        /// Converts to primary measure dimension
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="sourceMeasureDimension">Source dimension</param>
        /// <returns>Converted value</returns>
        public decimal ConvertToPrimaryMeasureDimension(decimal value,
            MeasureDimension sourceMeasureDimension)
        {
            return _measureService.ConvertToPrimaryMeasureDimension(value, sourceMeasureDimension);
        }

        /// <summary>
        /// Converts from primary dimension
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="targetMeasureDimension">Target dimension</param>
        /// <returns>Converted value</returns>
        public decimal ConvertFromPrimaryMeasureDimension(decimal value,
            MeasureDimension targetMeasureDimension)
        {
            return _measureService.ConvertFromPrimaryMeasureDimension(value, targetMeasureDimension);
        }


        /// <summary>
        /// Deletes measure weight
        /// </summary>
        /// <param name="measureWeight">Measure weight</param>
        public void DeleteMeasureWeight(MeasureWeight measureWeight)
        {
            _measureService.DeleteMeasureWeight(measureWeight);
        }

        /// <summary>
        /// Gets a measure weight by identifier
        /// </summary>
        /// <param name="measureWeightId">Measure weight identifier</param>
        /// <returns>Measure weight</returns>
        public MeasureWeight GetMeasureWeightById(int measureWeightId)
        {
            return _measureService.GetMeasureWeightById(measureWeightId);
        }

        /// <summary>
        /// Gets a measure weight by system keyword
        /// </summary>
        /// <param name="systemKeyword">The system keyword</param>
        /// <returns>Measure weight</returns>
        public MeasureWeight GetMeasureWeightBySystemKeyword(string systemKeyword)
        {
            return _measureService.GetMeasureWeightBySystemKeyword(systemKeyword);
        }

        /// <summary>
        /// Gets all measure weights
        /// </summary>
        /// <returns>Measure weights</returns>
        public IList<MeasureWeight> GetAllMeasureWeights()
        {
            return _measureService.GetAllMeasureWeights();
        }

        /// <summary>
        /// Inserts a measure weight
        /// </summary>
        /// <param name="measure">Measure weight</param>
        public void InsertMeasureWeight(MeasureWeight measure)
        {
            _measureService.InsertMeasureWeight(measure);
        }

        /// <summary>
        /// Updates the measure weight
        /// </summary>
        /// <param name="measure">Measure weight</param>
        public void UpdateMeasureWeight(MeasureWeight measure)
        {
            _measureService.UpdateMeasureWeight(measure);
        }

        /// <summary>
        /// Converts weight
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="sourceMeasureWeight">Source weight</param>
        /// <param name="targetMeasureWeight">Target weight</param>
        /// <param name="round">A value indicating whether a result should be rounded</param>
        /// <returns>Converted value</returns>
        public decimal ConvertWeight(decimal value,
            MeasureWeight sourceMeasureWeight, MeasureWeight targetMeasureWeight, bool round = true)
        {
            return _measureService.ConvertWeight(value, sourceMeasureWeight, targetMeasureWeight, round);
        }

        /// <summary>
        /// Converts to primary measure weight
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="sourceMeasureWeight">Source weight</param>
        /// <returns>Converted value</returns>
        public decimal ConvertToPrimaryMeasureWeight(decimal value, MeasureWeight sourceMeasureWeight)
        {
            return _measureService.ConvertToPrimaryMeasureWeight(value, sourceMeasureWeight);
        }

        /// <summary>
        /// Converts from primary weight
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="targetMeasureWeight">Target weight</param>
        /// <returns>Converted value</returns>
        public decimal ConvertFromPrimaryMeasureWeight(decimal value,
            MeasureWeight targetMeasureWeight)
        {
            return _measureService.ConvertFromPrimaryMeasureWeight(value, targetMeasureWeight);
        }

        #endregion

        #region State province

        /// <summary>
        /// Deletes a state/province
        /// </summary>
        /// <param name="stateProvince">The state/province</param>
        void DeleteStateProvince(StateProvince stateProvince)
        {
            _stateProvinceService.DeleteStateProvince(stateProvince);
        }

        /// <summary>
        /// Gets a state/province
        /// </summary>
        /// <param name="stateProvinceId">The state/province identifier</param>
        /// <returns>State/province</returns>
        StateProvince GetStateProvinceById(int stateProvinceId)
        {
            return _stateProvinceService.GetStateProvinceById(stateProvinceId);
        }

        /// <summary>
        /// Gets a state/province 
        /// </summary>
        /// <param name="abbreviation">The state/province abbreviation</param>
        /// <returns>State/province</returns>
        StateProvince GetStateProvinceByAbbreviation(string abbreviation)
        {
            return _stateProvinceService.GetStateProvinceByAbbreviation(abbreviation);
        }

        /// <summary>
        /// Gets a state/province collection by country identifier
        /// </summary>
        /// <param name="countryId">Country identifier</param>
        /// <param name="languageId">Language identifier. It's used to sort states by localized names (if specified); pass 0 to skip it</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>States</returns>
        IList<StateProvince> GetStateProvincesByCountryId(int countryId, int languageId = 0, bool showHidden = false)
        {
            return _stateProvinceService.GetStateProvincesByCountryId(countryId, languageId, showHidden);
        }

        /// <summary>
        /// Gets all states/provinces
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>States</returns>
        IList<StateProvince> GetStateProvinces(bool showHidden = false)
        {
            return _stateProvinceService.GetStateProvinces(showHidden);
        }

        /// <summary>
        /// Inserts a state/province
        /// </summary>
        /// <param name="stateProvince">State/province</param>
        void InsertStateProvince(StateProvince stateProvince)
        {
            _stateProvinceService.InsertStateProvince(stateProvince);
        }

        /// <summary>
        /// Updates a state/province
        /// </summary>
        /// <param name="stateProvince">State/province</param>
        void UpdateStateProvince(StateProvince stateProvince)
        {
            _stateProvinceService.UpdateStateProvince(stateProvince);
        }

        #endregion

        #endregion
    }
}
