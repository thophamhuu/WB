using Nop.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Localization
{
    public partial class LocalizationApiService : ILocalizationService
    {
        #region Methods

        /// <summary>
        /// Deletes a locale string resource
        /// </summary>
        /// <param name="localeStringResource">Locale string resource</param>
        public virtual void DeleteLocaleStringResource(LocaleStringResource localeStringResource)
        {
            APIHelper.Instance.PostAsync("Localization", "DeleteLocaleStringResource", localeStringResource);
        }

        /// <summary>
        /// Gets a locale string resource
        /// </summary>
        /// <param name="localeStringResourceId">Locale string resource identifier</param>
        /// <returns>Locale string resource</returns>
        public virtual LocaleStringResource GetLocaleStringResourceById(int localeStringResourceId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("localeStringResourceId", localeStringResourceId);
            return APIHelper.Instance.GetAsync<LocaleStringResource>("Localization", "GetLocaleStringResourceById", parameters);
        }

        /// <summary>
        /// Gets a locale string resource
        /// </summary>
        /// <param name="resourceName">A string representing a resource name</param>
        /// <returns>Locale string resource</returns>
        public virtual LocaleStringResource GetLocaleStringResourceByName(string resourceName)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("resourceName", resourceName);
            return APIHelper.Instance.GetAsync<LocaleStringResource>("Localization", "GetLocaleStringResourceByName", parameters);
        }

        /// <summary>
        /// Gets a locale string resource
        /// </summary>
        /// <param name="resourceName">A string representing a resource name</param>
        /// <param name="languageId">Language identifier</param>
        /// <param name="logIfNotFound">A value indicating whether to log error if locale string resource is not found</param>
        /// <returns>Locale string resource</returns>
        public virtual LocaleStringResource GetLocaleStringResourceByName(string resourceName, int languageId,
            bool logIfNotFound = true)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("resourceName", resourceName);
            parameters.Add("languageId", languageId);
            parameters.Add("logIfNotFound", logIfNotFound);
            return APIHelper.Instance.GetAsync<LocaleStringResource>("Localization", "GetLocaleStringResourceByName", parameters);
        }

        /// <summary>
        /// Gets all locale string resources by language identifier
        /// </summary>
        /// <param name="languageId">Language identifier</param>
        /// <returns>Locale string resources</returns>
        public virtual IList<LocaleStringResource> GetAllResources(int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.GetListAsync<LocaleStringResource>("Localization", "GetAllResources", parameters);
        }

        /// <summary>
        /// Inserts a locale string resource
        /// </summary>
        /// <param name="localeStringResource">Locale string resource</param>
        public virtual void InsertLocaleStringResource(LocaleStringResource localeStringResource)
        {
            APIHelper.Instance.PostAsync("Localization", "InsertLocaleStringResource", localeStringResource);
        }

        /// <summary>
        /// Updates the locale string resource
        /// </summary>
        /// <param name="localeStringResource">Locale string resource</param>
        public virtual void UpdateLocaleStringResource(LocaleStringResource localeStringResource)
        {
            APIHelper.Instance.PostAsync("Localization", "UpdateLocaleStringResource", localeStringResource);
        }

        /// <summary>
        /// Gets all locale string resources by language identifier
        /// </summary>
        /// <param name="languageId">Language identifier</param>
        /// <returns>Locale string resources</returns>
        public virtual Dictionary<string, KeyValuePair<int, string>> GetAllResourceValues(int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.GetAsync<Dictionary<string, KeyValuePair<int, string>>>("Localization", "GetAllResources", parameters);
        }

        /// <summary>
        /// Gets a resource string based on the specified ResourceKey property.
        /// </summary>
        /// <param name="resourceKey">A string representing a ResourceKey.</param>
        /// <returns>A string representing the requested resource string.</returns>
        public virtual string GetResource(string resourceKey)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("resourceKey", resourceKey);
            return APIHelper.Instance.GetAsync<string>("Localization", "GetResource", parameters);
        }

        /// <summary>
        /// Gets a resource string based on the specified ResourceKey property.
        /// </summary>
        /// <param name="resourceKey">A string representing a ResourceKey.</param>
        /// <param name="languageId">Language identifier</param>
        /// <param name="logIfNotFound">A value indicating whether to log error if locale string resource is not found</param>
        /// <param name="defaultValue">Default value</param>
        /// <param name="returnEmptyIfNotFound">A value indicating whether an empty string will be returned if a resource is not found and default value is set to empty string</param>
        /// <returns>A string representing the requested resource string.</returns>
        public virtual string GetResource(string resourceKey, int languageId,
            bool logIfNotFound = true, string defaultValue = "", bool returnEmptyIfNotFound = false)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("resourceKey", resourceKey);
            parameters.Add("languageId", languageId);
            parameters.Add("logIfNotFound", logIfNotFound);
            parameters.Add("defaultValue", defaultValue);
            parameters.Add("returnEmptyIfNotFound", returnEmptyIfNotFound);
            return APIHelper.Instance.GetAsync<string>("Localization", "GetResource", parameters);
        }

        /// <summary>
        /// Export language resources to xml
        /// </summary>
        /// <param name="language">Language</param>
        /// <returns>Result in XML format</returns>
        public virtual string ExportResourcesToXml(Language language)
        {
            return APIHelper.Instance.PostAsync<string>("Localization", "ExportResourcesToXml", language);
        }

        /// <summary>
        /// Import language resources from XML file
        /// </summary>
        /// <param name="language">Language</param>
        /// <param name="xml">XML</param>
        /// <param name="updateExistingResources">A value indicating whether to update existing resources</param>
        public virtual void ImportResourcesFromXml(Language language, string xml, bool updateExistingResources = true)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("xml", xml);
            parameters.Add("updateExistingResources", updateExistingResources);
            APIHelper.Instance.PostAsync("Localization", "ImportResourcesFromXml", language, parameters);
        }

        #endregion
    }
}
