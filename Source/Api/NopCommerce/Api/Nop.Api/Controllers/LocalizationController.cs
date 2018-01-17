using Nop.Core;
using Nop.Core.Domain.Localization;
using Nop.Services.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nop.Api.Controllers
{
    [Authorize]
    public class LocalizationController : ApiController
    {
        #region Fields

        private readonly ILanguageService _languageService;
        private readonly ILocalizationService _localizationService;
        private readonly ILocalizedEntityService _localizedEntityService;

        #endregion

        #region Ctor

        public LocalizationController(ILanguageService languageService, ILocalizationService localizationService, ILocalizedEntityService localizedEntityService)
        {
            this._languageService = languageService;
            this._localizationService = localizationService;
            this._localizedEntityService = localizedEntityService;
        }

        #endregion

        #region Method

        //#region Language

        ///// <summary>
        ///// Deletes a language
        ///// </summary>
        ///// <param name="language">Language</param>
        //public void DeleteLanguage(Language language)
        //{
        //    _languageService.DeleteLanguage(language);
        //}

        ///// <summary>
        ///// Gets all languages
        ///// </summary>
        ///// <param name="storeId">Load records allowed only in a specified store; pass 0 to load all records</param>
        ///// <param name="showHidden">A value indicating whether to show hidden records</param>
        ///// <returns>Languages</returns>
        //public IList<Language> GetAllLanguages(bool showHidden = false, int storeId = 0)
        //{
        //    return _languageService.GetAllLanguages(showHidden, storeId);
        //}

        ///// <summary>
        ///// Gets a language
        ///// </summary>
        ///// <param name="languageId">Language identifier</param>
        ///// <returns>Language</returns>
        //public Language GetLanguageById(int languageId)
        //{
        //    return _languageService.GetLanguageById(languageId);
        //}

        ///// <summary>
        ///// Inserts a language
        ///// </summary>
        ///// <param name="language">Language</param>
        //public void InsertLanguage(Language language)
        //{
        //    _languageService.InsertLanguage(language);
        //}

        ///// <summary>
        ///// Updates a language
        ///// </summary>
        ///// <param name="language">Language</param>
        //public void UpdateLanguage(Language language)
        //{
        //    _languageService.UpdateLanguage(language);
        //}

        //#endregion

        #region Localization

        /// <summary>
        /// Deletes a locale string resource
        /// </summary>
        /// <param name="localeStringResource">Locale string resource</param>
        public void DeleteLocaleStringResource(LocaleStringResource localeStringResource)
        {
            _localizationService.DeleteLocaleStringResource(localeStringResource);
        }

        /// <summary>
        /// Gets a locale string resource
        /// </summary>
        /// <param name="localeStringResourceId">Locale string resource identifier</param>
        /// <returns>Locale string resource</returns>
        public LocaleStringResource GetLocaleStringResourceById(int localeStringResourceId)
        {
            return _localizationService.GetLocaleStringResourceById(localeStringResourceId);
        }

        /// <summary>
        /// Gets a locale string resource
        /// </summary>
        /// <param name="resourceName">A string representing a resource name</param>
        /// <returns>Locale string resource</returns>
        public LocaleStringResource GetLocaleStringResourceByName(string resourceName)
        {
            return _localizationService.GetLocaleStringResourceByName(resourceName);
        }

        /// <summary>
        /// Gets a locale string resource
        /// </summary>
        /// <param name="resourceName">A string representing a resource name</param>
        /// <param name="languageId">Language identifier</param>
        /// <param name="logIfNotFound">A value indicating whether to log error if locale string resource is not found</param>
        /// <returns>Locale string resource</returns>
        public LocaleStringResource GetLocaleStringResourceByName(string resourceName, int languageId,
            bool logIfNotFound = true)
        {
            return _localizationService.GetLocaleStringResourceByName(resourceName, languageId, logIfNotFound);
        }

        /// <summary>
        /// Gets all locale string resources by language identifier
        /// </summary>
        /// <param name="languageId">Language identifier</param>
        /// <returns>Locale string resources</returns>
        public IList<LocaleStringResource> GetAllResources(int languageId)
        {
            return _localizationService.GetAllResources(languageId);
        }

        /// <summary>
        /// Inserts a locale string resource
        /// </summary>
        /// <param name="localeStringResource">Locale string resource</param>
        public void InsertLocaleStringResource(LocaleStringResource localeStringResource)
        {
            _localizationService.InsertLocaleStringResource(localeStringResource);
        }

        /// <summary>
        /// Updates the locale string resource
        /// </summary>
        /// <param name="localeStringResource">Locale string resource</param>
        public void UpdateLocaleStringResource(LocaleStringResource localeStringResource)
        {
            _localizationService.UpdateLocaleStringResource(localeStringResource);
        }

        /// <summary>
        /// Gets all locale string resources by language identifier
        /// </summary>
        /// <param name="languageId">Language identifier</param>
        /// <returns>Locale string resources</returns>
        public Dictionary<string, KeyValuePair<int, string>> GetAllResourceValues(int languageId)
        {
            return _localizationService.GetAllResourceValues(languageId);
        }

        /// <summary>
        /// Gets a resource string based on the specified ResourceKey property.
        /// </summary>
        /// <param name="resourceKey">A string representing a ResourceKey.</param>
        /// <returns>A string representing the requested resource string.</returns>
        public string GetResource(string resourceKey)
        {
            return _localizationService.GetResource(resourceKey);
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
        public string GetResource(string resourceKey, int languageId,
            bool logIfNotFound = true, string defaultValue = "", bool returnEmptyIfNotFound = false)
        {
            return _localizationService.GetResource(resourceKey, languageId, logIfNotFound, defaultValue, returnEmptyIfNotFound);
        }

        /// <summary>
        /// Export language resources to xml
        /// </summary>
        /// <param name="language">Language</param>
        /// <returns>Result in XML format</returns>
        public string ExportResourcesToXml(Language language)
        {
            return _localizationService.ExportResourcesToXml(language);
        }

        /// <summary>
        /// Import language resources from XML file
        /// </summary>
        /// <param name="language">Language</param>
        /// <param name="xml">XML</param>
        /// <param name="updateExistingResources">A value indicating whether to update existing resources</param>
        public void ImportResourcesFromXml(Language language, string xml, bool updateExistingResources = true)
        {
            _localizationService.ImportResourcesFromXml(language, xml, updateExistingResources);
        }

        #endregion

        #region Localized entity

        /// <summary>
        /// Deletes a localized property
        /// </summary>
        /// <param name="localizedProperty">Localized property</param>
        public void DeleteLocalizedProperty(LocalizedProperty localizedProperty)
        {
            _localizedEntityService.DeleteLocalizedProperty(localizedProperty);
        }

        /// <summary>
        /// Gets a localized property
        /// </summary>
        /// <param name="localizedPropertyId">Localized property identifier</param>
        /// <returns>Localized property</returns>
        public LocalizedProperty GetLocalizedPropertyById(int localizedPropertyId)
        {
            return _localizedEntityService.GetLocalizedPropertyById(localizedPropertyId);
        }

        /// <summary>
        /// Find localized value
        /// </summary>
        /// <param name="languageId">Language identifier</param>
        /// <param name="entityId">Entity identifier</param>
        /// <param name="localeKeyGroup">Locale key group</param>
        /// <param name="localeKey">Locale key</param>
        /// <returns>Found localized value</returns>
        public string GetLocalizedValue(int languageId, int entityId, string localeKeyGroup, string localeKey)
        {
            return _localizedEntityService.GetLocalizedValue(languageId, entityId, localeKeyGroup, localeKey);
        }

        /// <summary>
        /// Inserts a localized property
        /// </summary>
        /// <param name="localizedProperty">Localized property</param>
        public void InsertLocalizedProperty(LocalizedProperty localizedProperty)
        {
            _localizedEntityService.InsertLocalizedProperty(localizedProperty);
        }

        /// <summary>
        /// Updates the localized property
        /// </summary>
        /// <param name="localizedProperty">Localized property</param>
        public void UpdateLocalizedProperty(LocalizedProperty localizedProperty)
        {
            _localizedEntityService.UpdateLocalizedProperty(localizedProperty);
        }

        /// <summary>
        /// Save localized value
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="entity">Entity</param>
        /// <param name="keySelector">Key selector</param>
        /// <param name="localeValue">Locale value</param>
        /// <param name="languageId">Language ID</param>
        public void SaveLocalizedValue<T>(T entity,
            Expression<Func<T, string>> keySelector,
            string localeValue,
            int languageId) where T : BaseEntity, ILocalizedEntity
        {
            _localizedEntityService.SaveLocalizedValue(entity, keySelector, localeValue, languageId);
        }

        public void SaveLocalizedValue<T, TPropType>(T entity,
           Expression<Func<T, TPropType>> keySelector,
           TPropType localeValue,
           int languageId) where T : BaseEntity, ILocalizedEntity
        {
            _localizedEntityService.SaveLocalizedValue(entity, keySelector, localeValue, languageId);
        }

        #endregion

        #endregion
    }
}
