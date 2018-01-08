using Nop.Core;
using Nop.Core.Domain.News;
using Nop.Services.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nop.Api.Controllers
{
    [Authorize]
    public class NewsController : ApiController
    {
        #region Fields

        private readonly INewsService _newsService;

        #endregion

        #region Ctor

        public NewsController(INewsService newsService)
        {
            this._newsService = newsService;
        }

        #endregion

        #region Method

        #region News

        /// <summary>
        /// Deletes a news
        /// </summary>
        /// <param name="newsItem">News item</param>
        public void DeleteNews(NewsItem newsItem)
        {
            _newsService.DeleteNews(newsItem);
        }

        /// <summary>
        /// Gets a news
        /// </summary>
        /// <param name="newsId">The news identifier</param>
        /// <returns>News</returns>
        public NewsItem GetNewsById(int newsId)
        {
            return _newsService.GetNewsById(newsId);
        }

        /// <summary>
        /// Gets news
        /// </summary>
        /// <param name="newsIds">The news identifiers</param>
        /// <returns>News</returns>
        public IList<NewsItem> GetNewsByIds(int[] newsIds)
        {
            return _newsService.GetNewsByIds(newsIds);
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
        public IAPIPagedList<NewsItem> GetAllNews(int languageId = 0, int storeId = 0,
            int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            return _newsService.GetAllNews(languageId, storeId, pageIndex, pageSize, showHidden).ConvertPagedListToAPIPagedList();
        }

        /// <summary>
        /// Inserts a news item
        /// </summary>
        /// <param name="news">News item</param>
        public void InsertNews(NewsItem news)
        {
            _newsService.InsertNews(news);
        }

        /// <summary>
        /// Updates the news item
        /// </summary>
        /// <param name="news">News item</param>
        public void UpdateNews(NewsItem news)
        {
            _newsService.UpdateNews(news);
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
        public IList<NewsComment> GetAllComments(int customerId = 0, int storeId = 0, int? newsItemId = null,
            bool? approved = null, DateTime? fromUtc = null, DateTime? toUtc = null, string commentText = null)
        {
            return _newsService.GetAllComments(customerId, storeId, newsItemId, approved, fromUtc, toUtc, commentText);
        }

        /// <summary>
        /// Gets a news comment
        /// </summary>
        /// <param name="newsCommentId">News comment identifier</param>
        /// <returns>News comment</returns>
        public NewsComment GetNewsCommentById(int newsCommentId)
        {
            return _newsService.GetNewsCommentById(newsCommentId);
        }

        /// <summary>
        /// Get news comments by identifiers
        /// </summary>
        /// <param name="commentIds">News comment identifiers</param>
        /// <returns>News comments</returns>
        public IList<NewsComment> GetNewsCommentsByIds(int[] commentIds)
        {
            return _newsService.GetNewsCommentsByIds(commentIds);
        }

        /// <summary>
        /// Get the count of news comments
        /// </summary>
        /// <param name="newsItem">News item</param>
        /// <param name="storeId">Store identifier; pass 0 to load all records</param>
        /// <param name="isApproved">A value indicating whether to count only approved or not approved comments; pass null to get number of all comments</param>
        /// <returns>Number of news comments</returns>
        public int GetNewsCommentsCount(NewsItem newsItem, int storeId = 0, bool? isApproved = null)
        {
            return _newsService.GetNewsCommentsCount(newsItem, storeId, isApproved);
        }

        /// <summary>
        /// Deletes a news comment
        /// </summary>
        /// <param name="newsComment">News comment</param>
        public void DeleteNewsComment(NewsComment newsComment)
        {
            _newsService.DeleteNewsComment(newsComment);
        }

        /// <summary>
        /// Deletes a news comments
        /// </summary>
        /// <param name="newsComments">News comments</param>
        public void DeleteNewsComments(IList<NewsComment> newsComments)
        {
            _newsService.DeleteNewsComments(newsComments);
        }

        #endregion

        #endregion
    }
}
