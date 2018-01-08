using Nop.Core.Domain.Directory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Directory
{
    public partial class CountryApiService : ICountryService
    {
        #region Methods

        /// <summary>
        /// Deletes a country
        /// </summary>
        /// <param name="country">Country</param>
        public virtual void DeleteCountry(Country country)
        {
            APIHelper.Instance.PostAsync("Directory", "DeleteCountry", country);
        }

        /// <summary>
        /// Gets all countries
        /// </summary>
        /// <param name="languageId">Language identifier. It's used to sort countries by localized names (if specified); pass 0 to skip it</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Countries</returns>
        public virtual IList<Country> GetAllCountries(int languageId = 0, bool showHidden = false)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("languageId", languageId);
            parameters.Add("showHidden", showHidden);
            return APIHelper.Instance.GetListAsync<Country>("Directory", "GetAllCountries", parameters);
        }

        /// <summary>
        /// Gets all countries that allow billing
        /// </summary>
        /// <param name="languageId">Language identifier. It's used to sort countries by localized names (if specified); pass 0 to skip it</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Countries</returns>
        public virtual IList<Country> GetAllCountriesForBilling(int languageId = 0, bool showHidden = false)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("languageId", languageId);
            parameters.Add("showHidden", showHidden);
            return APIHelper.Instance.GetListAsync<Country>("Directory", "GetAllCountriesForBilling", parameters);
        }

        /// <summary>
        /// Gets all countries that allow shipping
        /// </summary>
        /// <param name="languageId">Language identifier. It's used to sort countries by localized names (if specified); pass 0 to skip it</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Countries</returns>
        public virtual IList<Country> GetAllCountriesForShipping(int languageId = 0, bool showHidden = false)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("languageId", languageId);
            parameters.Add("showHidden", showHidden);
            return APIHelper.Instance.GetListAsync<Country>("Directory", "GetAllCountriesForShipping", parameters);
        }

        /// <summary>
        /// Gets a country 
        /// </summary>
        /// <param name="countryId">Country identifier</param>
        /// <returns>Country</returns>
        public virtual Country GetCountryById(int countryId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("countryId", countryId);
            return APIHelper.Instance.GetAsync<Country>("Directory", "GetCountryById", parameters);
        }

        /// <summary>
        /// Get countries by identifiers
        /// </summary>
        /// <param name="countryIds">Country identifiers</param>
        /// <returns>Countries</returns>
        public virtual IList<Country> GetCountriesByIds(int[] countryIds)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("countryIds", string.Join(",", countryIds));
            return APIHelper.Instance.GetListAsync<Country>("Directory", "GetCountriesByIds", parameters);
        }

        /// <summary>
        /// Gets a country by two letter ISO code
        /// </summary>
        /// <param name="twoLetterIsoCode">Country two letter ISO code</param>
        /// <returns>Country</returns>
        public virtual Country GetCountryByTwoLetterIsoCode(string twoLetterIsoCode)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("twoLetterIsoCode", twoLetterIsoCode);
            return APIHelper.Instance.GetAsync<Country>("Directory", "GetCountryByTwoLetterIsoCode", parameters);
        }

        /// <summary>
        /// Gets a country by three letter ISO code
        /// </summary>
        /// <param name="threeLetterIsoCode">Country three letter ISO code</param>
        /// <returns>Country</returns>
        public virtual Country GetCountryByThreeLetterIsoCode(string threeLetterIsoCode)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("threeLetterIsoCode", threeLetterIsoCode);
            return APIHelper.Instance.GetAsync<Country>("Directory", "GetCountryByThreeLetterIsoCode", parameters);
        }

        /// <summary>
        /// Inserts a country
        /// </summary>
        /// <param name="country">Country</param>
        public virtual void InsertCountry(Country country)
        {
            APIHelper.Instance.PostAsync("Directory", "InsertCountry", country);
        }

        /// <summary>
        /// Updates the country
        /// </summary>
        /// <param name="country">Country</param>
        public virtual void UpdateCountry(Country country)
        {
            APIHelper.Instance.PostAsync("Directory", "UpdateCountry", country);
        }

        #endregion
    }
}
