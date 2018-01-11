using Nop.Api.Models.Requests;
using Nop.Core;
using Nop.Core.Domain.Seo;
using Nop.Services.Seo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nop.Api.Controllers
{
    [Authorize]
    public class SeoController : ApiController
    {
        #region Fields

        private readonly IUrlRecordService _urlRecordService;

        #endregion

        #region Ctor

        public SeoController(IUrlRecordService urlRecordService)
        {
            this._urlRecordService = urlRecordService;
        }

        #endregion

        #region Method

        #region URL record

        /// <summary>
        /// Deletes an URL record
        /// </summary>
        /// <param name="urlRecord">URL record</param>
        public void DeleteUrlRecord([FromBody]UrlRecord urlRecord)
        {
            _urlRecordService.DeleteUrlRecord(urlRecord);
        }

        /// <summary>
        /// Deletes an URL records
        /// </summary>
        /// <param name="urlRecords">URL records</param>
        public void DeleteUrlRecords(IList<UrlRecord> urlRecords)
        {
            _urlRecordService.DeleteUrlRecords(urlRecords);
        }

        /// <summary>
        /// Gets an URL record
        /// </summary>
        /// <param name="urlRecordId">URL record identifier</param>
        /// <returns>URL record</returns>
        public UrlRecord GetUrlRecordById(int urlRecordId)
        {
            return _urlRecordService.GetUrlRecordById(urlRecordId);
        }

        /// <summary>
        /// Gets an URL records
        /// </summary>
        /// <param name="urlRecordIds">URL record identifiers</param>
        /// <returns>URL record</returns>
        public IList<UrlRecord> GetUrlRecordsByIds(int[] urlRecordIds)
        {
            return _urlRecordService.GetUrlRecordsByIds(urlRecordIds);
        }

        /// <summary>
        /// Inserts an URL record
        /// </summary>
        /// <param name="urlRecord">URL record</param>
        public void InsertUrlRecord([FromBody]UrlRecord urlRecord)
        {
            _urlRecordService.InsertUrlRecord(urlRecord);
        }

        /// <summary>
        /// Updates the URL record
        /// </summary>
        /// <param name="urlRecord">URL record</param>
        public void UpdateUrlRecord([FromBody]UrlRecord urlRecord)
        {
            _urlRecordService.UpdateUrlRecord(urlRecord);
        }

        /// <summary>
        /// Find URL record
        /// </summary>
        /// <param name="slug">Slug</param>
        /// <returns>Found URL record</returns>
        public UrlRecord GetBySlug(string slug)
        {
            return _urlRecordService.GetBySlug(slug);
        }

        /// <summary>
        /// Find URL record (cached version).
        /// This method works absolutely the same way as "GetBySlug" one but caches the results.
        /// Hence, it's used only for performance optimization in public store
        /// </summary>
        /// <param name="slug">Slug</param>
        /// <returns>Found URL record</returns>
        public UrlRecordService.UrlRecordForCaching GetBySlugCached(string slug)
        {
            return _urlRecordService.GetBySlugCached(slug);
        }

        /// <summary>
        /// Gets all URL records
        /// </summary>
        /// <param name="slug">Slug</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>URL records</returns>
        public IAPIPagedList<UrlRecord> GetAllUrlRecords(string slug = "", int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return _urlRecordService.GetAllUrlRecords(slug, pageIndex, pageSize).ConvertPagedListToAPIPagedList();
        }

        /// <summary>
        /// Find slug
        /// </summary>
        /// <param name="entityId">Entity identifier</param>
        /// <param name="entityName">Entity name</param>
        /// <param name="languageId">Language identifier</param>
        /// <returns>Found slug</returns>
        public string GetActiveSlug(int entityId, string entityName, int languageId)
        {
            return _urlRecordService.GetActiveSlug(entityId, entityName, languageId);
        }

        /// <summary>
        /// Save slug
        /// </summary>
        /// <param name="entityName">Type Name</typeparam>
        /// <param name="entity">Entity</param>
        /// <param name="slug">Slug</param>
        /// <param name="languageId">Language ID</param>
        public void SaveSlug([FromBody]SaveSlugModel model)
        {
            _urlRecordService.SaveSlug(model.entityName, model.entity, model.slug, model.languageId);
        }

        #endregion

        #endregion
    }
}
