using Nop.Core;
using Nop.Core.Domain.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.News
{
    public partial class NewsApiService : INewsService
    {
        #region Methods

        #region News

        /// <summary>
        /// Deletes a news
        /// </summary>
        /// <param name="newsItem">News item</param>
        public virtual void DeleteNews(NewsItem newsItem)
        {
            APIHelper.Instance.PostAsync("News", "DeleteNews", newsItem);
        }

        /// <summary>
        /// Gets a news
        /// </summary>
        /// <param name="newsId">The news identifier</param>
        /// <returns>News</returns>
        public virtual NewsItem GetNewsById(int newsId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("newsId", newsId);
            return APIHelper.Instance.GetAsync<NewsItem>("News", "GetNewsById", parameters);
        }

        /// <summary>
        /// Gets news
        /// </summary>
        /// <param name="newsIds">The news identifiers</param>
        /// <returns>News</returns>
        public virtual IList<NewsItem> GetNewsByIds(int[] newsIds)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("newsId", string.Join(",", newsIds));
            return APIHelper.Instance.GetListAsync<NewsItem>("News", "GetNewsByIds", parameters);
        }

        /// <summary>
        /// Gets all news
        /// </summary>
        /// <param name="languageId">Language identifier; 0 if you want to get all records</param>
        /// <param name="storeId">Store identifier; 0 if you want to get all records</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>News items</returns>
        public virtual IPagedList<NewsItem> GetAllNews(int languageId = 0, int storeId = 0,
            int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("languageId", languageId);
            parameters.Add("storeId", storeId);
            parameters.Add("pageIndex", pageIndex);
            parameters.Add("pageSize", pageSize);
            parameters.Add("showHidden", showHidden);
            return APIHelper.Instance.GetPagedListAsync<NewsItem>("News", "GetAllNews", parameters);
        }

        /// <summary>
        /// Inserts a news item
        /// </summary>
        /// <param name="news">News item</param>
        public virtual void InsertNews(NewsItem news)
        {
            APIHelper.Instance.PostAsync("News", "InsertNews", news);
        }

        /// <summary>
        /// Updates the news item
        /// </summary>
        /// <param name="news">News item</param>
        public virtual void UpdateNews(NewsItem news)
        {
            APIHelper.Instance.PostAsync("News", "UpdateNews", news);
        }

        #endregion

        #region News comments

        /// <summary>
        /// Gets all comments
        /// </summary>
        /// <param name="customerId">Customer identifier; 0 to load all records</param>
        /// <param name="storeId">Store identifier; pass 0 to load all records</param>
        /// <param name="newsItemId">News item ID; 0 or null to load all records</param>
        /// <param name="approved">A value indicating whether to content is approved; null to load all records</param> 
        /// <param name="fromUtc">Item creation from; null to load all records</param>
        /// <param name="toUtc">Item creation to; null to load all records</param>
        /// <param name="commentText">Search comment text; null to load all records</param>
        /// <returns>Comments</returns>
        public virtual IList<NewsComment> GetAllComments(int customerId = 0, int storeId = 0, int? newsItemId = null,
            bool? approved = null, DateTime? fromUtc = null, DateTime? toUtc = null, string commentText = null)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customerId", customerId);
            parameters.Add("storeId", storeId);
            parameters.Add("newsItemId", newsItemId);
            parameters.Add("approved", approved);
            if (fromUtc.HasValue)
                parameters.Add("fromUtc", CommonHelper.DateTimeUtcToStringAPI(fromUtc.Value));
            if (toUtc.HasValue)
                parameters.Add("toUtc", CommonHelper.DateTimeUtcToStringAPI(toUtc.Value));
            parameters.Add("commentText", commentText);
            return APIHelper.Instance.GetListAsync<NewsComment>("News", "GetAllComments", parameters);
        }

        /// <summary>
        /// Gets a news comment
        /// </summary>
        /// <param name="newsCommentId">News comment identifier</param>
        /// <returns>News comment</returns>
        public virtual NewsComment GetNewsCommentById(int newsCommentId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("newsCommentId", newsCommentId);
            return APIHelper.Instance.GetAsync<NewsComment>("News", "GetNewsCommentById", parameters);
        }

        /// <summary>
        /// Get news comments by identifiers
        /// </summary>
        /// <param name="commentIds">News comment identifiers</param>
        /// <returns>News comments</returns>
        public virtual IList<NewsComment> GetNewsCommentsByIds(int[] commentIds)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("commentIds", string.Join(",", commentIds));
            return APIHelper.Instance.GetListAsync<NewsComment>("News", "GetNewsCommentsByIds", parameters);
        }

        /// <summary>
        /// Get the count of news comments
        /// </summary>
        /// <param name="newsItem">News item</param>
        /// <param name="storeId">Store identifier; pass 0 to load all records</param>
        /// <param name="isApproved">A value indicating whether to count only approved or not approved comments; pass null to get number of all comments</param>
        /// <returns>Number of news comments</returns>
        public virtual int GetNewsCommentsCount(NewsItem newsItem, int storeId = 0, bool? isApproved = null)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("storeId", storeId);
            parameters.Add("isApproved", isApproved);
            return APIHelper.Instance.PostAsync<int>("News", "GetNewsCommentsCount", newsItem, parameters);
        }

        /// <summary>
        /// Deletes a news comment
        /// </summary>
        /// <param name="newsComment">News comment</param>
        public virtual void DeleteNewsComment(NewsComment newsComment)
        {
            APIHelper.Instance.PostAsync("News", "DeleteNewsComment", newsComment);
        }

        /// <summary>
        /// Deletes a news comments
        /// </summary>
        /// <param name="newsComments">News comments</param>
        public virtual void DeleteNewsComments(IList<NewsComment> newsComments)
        {
            APIHelper.Instance.PostAsync("News", "DeleteNewsComments", newsComments);
        }

        #endregion

        #endregion
    }
}
