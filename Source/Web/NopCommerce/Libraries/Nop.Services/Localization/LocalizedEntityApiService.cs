using Nop.Core;
using Nop.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Localization
{
    public partial class LocalizedEntityApiService : ILocalizedEntityService
    {
        #region Methods

        /// <summary>
        /// Deletes a localized property
        /// </summary>
        /// <param name="localizedProperty">Localized property</param>
        public virtual void DeleteLocalizedProperty(LocalizedProperty localizedProperty)
        {
            APIHelper.Instance.PostAsync("Localization", "DeleteLocalizedProperty", localizedProperty);
        }

        /// <summary>
        /// Gets a localized property
        /// </summary>
        /// <param name="localizedPropertyId">Localized property identifier</param>
        /// <returns>Localized property</returns>
        public virtual LocalizedProperty GetLocalizedPropertyById(int localizedPropertyId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("localizedPropertyId", localizedPropertyId);
            return APIHelper.Instance.GetAsync<LocalizedProperty>("Localization", "GetLocalizedPropertyById", parameters);
        }

        /// <summary>
        /// Find localized value
        /// </summary>
        /// <param name="languageId">Language identifier</param>
        /// <param name="entityId">Entity identifier</param>
        /// <param name="localeKeyGroup">Locale key group</param>
        /// <param name="localeKey">Locale key</param>
        /// <returns>Found localized value</returns>
        public virtual string GetLocalizedValue(int languageId, int entityId, string localeKeyGroup, string localeKey)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("languageId", languageId);
            parameters.Add("entityId", entityId);
            parameters.Add("localeKeyGroup", localeKeyGroup);
            parameters.Add("localeKey", localeKey);
            return APIHelper.Instance.GetAsync<string>("Localization", "GetLocalizedValue", parameters);
        }

        /// <summary>
        /// Inserts a localized property
        /// </summary>
        /// <param name="localizedProperty">Localized property</param>
        public virtual void InsertLocalizedProperty(LocalizedProperty localizedProperty)
        {
            APIHelper.Instance.PostAsync("Localization", "InsertLocalizedProperty", localizedProperty);
        }

        /// <summary>
        /// Updates the localized property
        /// </summary>
        /// <param name="localizedProperty">Localized property</param>
        public virtual void UpdateLocalizedProperty(LocalizedProperty localizedProperty)
        {
            APIHelper.Instance.PostAsync("Localization", "UpdateLocalizedProperty", localizedProperty);
        }

        /// <summary>
        /// Save localized value
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="entity">Entity</param>
        /// <param name="keySelector">Key selector</param>
        /// <param name="localeValue">Locale value</param>
        /// <param name="languageId">Language ID</param>
        public virtual void SaveLocalizedValue<T>(T entity,
            Expression<Func<T, string>> keySelector,
            string localeValue,
            int languageId) where T : BaseEntity, ILocalizedEntity
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("entity", entity);
            parameters.Add("keySelector", keySelector);
            parameters.Add("localeValue", localeValue);
            parameters.Add("languageId", languageId);
            APIHelper.Instance.GetAsync<string>("Localization", "SaveLocalizedValue", parameters);
        }

        public virtual void SaveLocalizedValue<T, TPropType>(T entity,
            Expression<Func<T, TPropType>> keySelector,
            TPropType localeValue,
            int languageId) where T : BaseEntity, ILocalizedEntity
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("entity", entity);
            parameters.Add("keySelector", keySelector);
            parameters.Add("localeValue", localeValue);
            parameters.Add("languageId", languageId);
            APIHelper.Instance.GetAsync<string>("Localization", "SaveLocalizedValue", parameters);
        }

        #endregion
    }
}
