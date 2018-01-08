using Nop.Core;
using Nop.Core.Domain.Seo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Nop.Services.Seo.UrlRecordService;

namespace Nop.Services.Seo
{
    public partial class UrlRecordApiService : IUrlRecordService
    {
        #region Methods

        /// <summary>
        /// Deletes an URL record
        /// </summary>
        /// <param name="urlRecord">URL record</param>
        public virtual void DeleteUrlRecord(UrlRecord urlRecord)
        {
            APIHelper.Instance.PostAsync("Seo", "DeleteUrlRecord", urlRecord);
        }

        /// <summary>
        /// Deletes an URL records
        /// </summary>
        /// <param name="urlRecords">URL records</param>
        public virtual void DeleteUrlRecords(IList<UrlRecord> urlRecords)
        {
            APIHelper.Instance.PostAsync("Seo", "DeleteUrlRecords", urlRecords);
        }

        /// <summary>
        /// Gets an URL records
        /// </summary>
        /// <param name="urlRecordIds">URL record identifiers</param>
        /// <returns>URL record</returns>
        public virtual IList<UrlRecord> GetUrlRecordsByIds(int[] urlRecordIds)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("urlRecordIds", string.Join(",", urlRecordIds));
            return APIHelper.Instance.GetListAsync<UrlRecord>("Seo", "GetUrlRecordsByIds", parameters);
        }

        /// <summary>
        /// Gets an URL record
        /// </summary>
        /// <param name="urlRecordId">URL record identifier</param>
        /// <returns>URL record</returns>
        public virtual UrlRecord GetUrlRecordById(int urlRecordId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("urlRecordId", urlRecordId);
            return APIHelper.Instance.GetAsync<UrlRecord>("Seo", "GetUrlRecordById", parameters);
        }

        /// <summary>
        /// Inserts an URL record
        /// </summary>
        /// <param name="urlRecord">URL record</param>
        public virtual void InsertUrlRecord(UrlRecord urlRecord)
        {
            APIHelper.Instance.PostAsync("Seo", "InsertUrlRecord", urlRecord);
        }

        /// <summary>
        /// Updates the URL record
        /// </summary>
        /// <param name="urlRecord">URL record</param>
        public virtual void UpdateUrlRecord(UrlRecord urlRecord)
        {
            APIHelper.Instance.PostAsync("Seo", "UpdateUrlRecord", urlRecord);
        }

        /// <summary>
        /// Find URL record
        /// </summary>
        /// <param name="slug">Slug</param>
        /// <returns>Found URL record</returns>
        public virtual UrlRecord GetBySlug(string slug)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("slug", slug);
            return APIHelper.Instance.GetAsync<UrlRecord>("Seo", "GetBySlug", parameters);
        }

        /// <summary>
        /// Find URL record (cached version).
        /// This method works absolutely the same way as "GetBySlug" one but caches the results.
        /// Hence, it's used only for performance optimization in public store
        /// </summary>
        /// <param name="slug">Slug</param>
        /// <returns>Found URL record</returns>
        public virtual UrlRecordForCaching GetBySlugCached(string slug)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("slug", slug);
            return APIHelper.Instance.GetAsync<UrlRecordForCaching>("Seo", "GetBySlugCached", parameters);
        }

        /// <summary>
        /// Gets all URL records
        /// </summary>
        /// <param name="slug">Slug</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>URL records</returns>
        public virtual IPagedList<UrlRecord> GetAllUrlRecords(string slug = "", int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("slug", slug);
            parameters.Add("pageIndex", pageIndex);
            parameters.Add("pageSize", pageSize);
            return APIHelper.Instance.GetPagedListAsync<UrlRecord>("Seo", "GetAllUrlRecords", parameters);
        }

        /// <summary>
        /// Find slug
        /// </summary>
        /// <param name="entityId">Entity identifier</param>
        /// <param name="entityName">Entity name</param>
        /// <param name="languageId">Language identifier</param>
        /// <returns>Found slug</returns>
        public virtual string GetActiveSlug(int entityId, string entityName, int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("entityId", entityId);
            parameters.Add("entityName", entityName);
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.GetAsync<string>("Seo", "GetActiveSlug", parameters);
        }

        /// <summary>
        /// Save slug
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="entity">Entity</param>
        /// <param name="slug">Slug</param>
        /// <param name="languageId">Language ID</param>
        public virtual void SaveSlug<T>(T entity, string slug, int languageId) where T : BaseEntity, ISlugSupported
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("slug", slug);
            parameters.Add("languageId", languageId);
            APIHelper.Instance.PostAsync("Seo", "SaveSlug", entity, parameters);
        }

        #endregion
    }
}
