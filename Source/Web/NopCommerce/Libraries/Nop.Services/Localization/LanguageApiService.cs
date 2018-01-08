using Nop.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Localization
{
    public partial class LanguageApiService : ILanguageService
    {
        #region Methods

        /// <summary>
        /// Deletes a language
        /// </summary>
        /// <param name="language">Language</param>
        public virtual void DeleteLanguage(Language language)
        {
            APIHelper.Instance.PostAsync("Localization", "DeleteLanguage", language);
        }

        /// <summary>
        /// Gets all languages
        /// </summary>
        /// <param name="storeId">Load records allowed only in a specified store; pass 0 to load all records</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Languages</returns>
        public virtual IList<Language> GetAllLanguages(bool showHidden = false, int storeId = 0)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("showHidden", showHidden);
            parameters.Add("storeId", storeId);
            return APIHelper.Instance.GetListAsync<Language>("Localization", "GetAllLanguages", parameters);
        }

        /// <summary>
        /// Gets a language
        /// </summary>
        /// <param name="languageId">Language identifier</param>
        /// <returns>Language</returns>
        public virtual Language GetLanguageById(int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.GetAsync<Language>("Localization", "GetLanguageById", parameters);
        }

        /// <summary>
        /// Inserts a language
        /// </summary>
        /// <param name="language">Language</param>
        public virtual void InsertLanguage(Language language)
        {
            APIHelper.Instance.PostAsync("Localization", "InsertLanguage", language);
        }

        /// <summary>
        /// Updates a language
        /// </summary>
        /// <param name="language">Language</param>
        public virtual void UpdateLanguage(Language language)
        {
            APIHelper.Instance.PostAsync("Localization", "UpdateLanguage", language);
        }

        #endregion
    }
}
