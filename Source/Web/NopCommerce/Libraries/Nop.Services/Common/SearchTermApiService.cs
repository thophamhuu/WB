using Nop.Core;
using Nop.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Common
{
    public partial class SearchTermApiService :ISearchTermService
    {
        #region Methods

        /// <summary>
        /// Deletes a search term record
        /// </summary>
        /// <param name="searchTerm">Search term</param>
        public virtual void DeleteSearchTerm(SearchTerm searchTerm)
        {
            APIHelper.Instance.PostAsync("Common", "DeleteSearchTerm", searchTerm);
        }

        /// <summary>
        /// Gets a search term record by identifier
        /// </summary>
        /// <param name="searchTermId">Search term identifier</param>
        /// <returns>Search term</returns>
        public virtual SearchTerm GetSearchTermById(int searchTermId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("searchTermId", searchTermId);
            return APIHelper.Instance.GetAsync<SearchTerm>("Common", "GetSearchTermById", parameters);
        }

        /// <summary>
        /// Gets a search term record by keyword
        /// </summary>
        /// <param name="keyword">Search term keyword</param>
        /// <param name="storeId">Store identifier</param>
        /// <returns>Search term</returns>
        public virtual SearchTerm GetSearchTermByKeyword(string keyword, int storeId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("keyword", keyword);
            parameters.Add("storeId", storeId);
            return APIHelper.Instance.GetAsync<SearchTerm>("Common", "GetSearchTermByKeyword", parameters);
        }

        /// <summary>
        /// Gets a search term statistics
        /// </summary>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>A list search term report lines</returns>
        public virtual IPagedList<SearchTermReportLine> GetStats(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("pageIndex", pageIndex);
            parameters.Add("pageSize", pageSize);
            return APIHelper.Instance.GetPagedListAsync<SearchTermReportLine>("Common", "GetStats", parameters);
        }

        /// <summary>
        /// Inserts a search term record
        /// </summary>
        /// <param name="searchTerm">Search term</param>
        public virtual void InsertSearchTerm(SearchTerm searchTerm)
        {
            APIHelper.Instance.PostAsync("Common", "InsertSearchTerm", searchTerm);
        }

        /// <summary>
        /// Updates the search term record
        /// </summary>
        /// <param name="searchTerm">Search term</param>
        public virtual void UpdateSearchTerm(SearchTerm searchTerm)
        {
            APIHelper.Instance.PostAsync("Common", "UpdateSearchTerm", searchTerm);
        }

        #endregion
    }
}
