using Nop.Core;
using Nop.Core.Domain.Blogs;
using Nop.Services.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nop.Api.Controllers
{
    [Authorize]
    public class BlogsController : ApiController
    {
        #region Fields

        private readonly IBlogService _blogService;

        #endregion

        #region Ctor

        public BlogsController(IBlogService blogService)
        {
            this._blogService = blogService;
        }

        #endregion

        #region Method

        #region Blog posts

        /// <summary>
        /// Deletes a blog post
        /// </summary>
        /// <param name="blogPost">Blog post</param>
        public void DeleteBlogPost([FromBody]BlogPost blogPost)
        {
            _blogService.DeleteBlogPost(blogPost);
        }

        /// <summary>
        /// Gets a blog post
        /// </summary>
        /// <param name="blogPostId">Blog post identifier</param>
        /// <returns>Blog post</returns>
        public BlogPost GetBlogPostById(int blogPostId)
        {
            return _blogService.GetBlogPostById(blogPostId);
        }

        /// <summary>
        /// Gets blog posts
        /// </summary>
        /// <param name="blogPostIds">Blog post identifiers</param>
        /// <returns>Blog posts</returns>
        public IList<BlogPost> GetBlogPostsByIds(int[] blogPostIds)
        {
            return _blogService.GetBlogPostsByIds(blogPostIds);
        }

        /// <summary>
        /// Gets all blog posts
        /// </summary>
        /// <param name="storeId">The store identifier; pass 0 to load all records</param>
        /// <param name="languageId">Language identifier; 0 if you want to get all records</param>
        /// <param name="dateFrom">Filter by created date; null if you want to get all records</param>
        /// <param name="dateTo">Filter by created date; null if you want to get all records</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Blog posts</returns>
        public IAPIPagedList<BlogPost> GetAllBlogPosts(int storeId = 0, int languageId = 0,
            DateTime? dateFrom = null, DateTime? dateTo = null,
            int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            return _blogService.GetAllBlogPosts(storeId, languageId, dateFrom, dateTo, pageIndex, pageSize, showHidden).ConvertPagedListToAPIPagedList();
        }

        /// <summary>
        /// Gets all blog posts
        /// </summary>
        /// <param name="storeId">The store identifier; pass 0 to load all records</param>
        /// <param name="languageId">Language identifier. 0 if you want to get all blog posts</param>
        /// <param name="tag">Tag</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Blog posts</returns>
        public IAPIPagedList<BlogPost> GetAllBlogPostsByTag(int storeId = 0,
            int languageId = 0, string tag = "",
            int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            return _blogService.GetAllBlogPostsByTag(storeId, languageId, tag, pageIndex, pageSize, showHidden).ConvertPagedListToAPIPagedList();
        }

        /// <summary>
        /// Gets all blog post tags
        /// </summary>
        /// <param name="storeId">The store identifier; pass 0 to load all records</param>
        /// <param name="languageId">Language identifier. 0 if you want to get all blog posts</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Blog post tags</returns>
        public IList<BlogPostTag> GetAllBlogPostTags(int storeId, int languageId, bool showHidden = false)
        {
            return _blogService.GetAllBlogPostTags(storeId, languageId, showHidden);
        }

        /// <summary>
        /// Inserts an blog post
        /// </summary>
        /// <param name="blogPost">Blog post</param>
        public void InsertBlogPost([FromBody]BlogPost blogPost)
        {
            _blogService.InsertBlogPost(blogPost);
        }

        /// <summary>
        /// Updates the blog post
        /// </summary>
        /// <param name="blogPost">Blog post</param>
        public void UpdateBlogPost([FromBody]BlogPost blogPost)
        {
            _blogService.UpdateBlogPost(blogPost);
        }

        #endregion

        #region Blog comments

        /// <summary>
        /// Gets all comments
        /// </summary>
        /// <param name="customerId">Customer identifier; 0 to load all records</param>
        /// <param name="storeId">Store identifier; pass 0 to load all records</param>
        /// <param name="blogPostId">Blog post ID; 0 or null to load all records</param>
        /// <param name="approved">A value indicating whether to content is approved; null to load all records</param> 
        /// <param name="fromUtc">Item creation from; null to load all records</param>
        /// <param name="toUtc">Item creation to; null to load all records</param>
        /// <param name="commentText">Search comment text; null to load all records</param>
        /// <returns>Comments</returns>
        public IList<BlogComment> GetAllComments(int customerId = 0, int storeId = 0, int? blogPostId = null,
            bool? approved = null, DateTime? fromUtc = null, DateTime? toUtc = null, string commentText = null)
        {
            return _blogService.GetAllComments(customerId, storeId, blogPostId, approved, fromUtc, toUtc, commentText);
        }

        /// <summary>
        /// Gets a blog comment
        /// </summary>
        /// <param name="blogCommentId">Blog comment identifier</param>
        /// <returns>Blog comment</returns>
        public BlogComment GetBlogCommentById(int blogCommentId)
        {
            return _blogService.GetBlogCommentById(blogCommentId);
        }

        /// <summary>
        /// Get blog comments by identifiers
        /// </summary>
        /// <param name="commentIds">Blog comment identifiers</param>
        /// <returns>Blog comments</returns>
        public IList<BlogComment> GetBlogCommentsByIds(int[] commentIds)
        {
            return _blogService.GetBlogCommentsByIds(commentIds);
        }

        /// <summary>
        /// Get the count of blog comments
        /// </summary>
        /// <param name="blogPost">Blog post</param>
        /// <param name="storeId">Store identifier; pass 0 to load all records</param>
        /// <param name="isApproved">A value indicating whether to count only approved or not approved comments; pass null to get number of all comments</param>
        /// <returns>Number of blog comments</returns>
        public int GetBlogCommentsCount(BlogPost blogPost, int storeId = 0, bool? isApproved = null)
        {
            return _blogService.GetBlogCommentsCount(blogPost, storeId, isApproved);
        }

        /// <summary>
        /// Deletes a blog comment
        /// </summary>
        /// <param name="blogComment">Blog comment</param>
        public void DeleteBlogComment([FromBody]BlogComment blogComment)
        {
            _blogService.DeleteBlogComment(blogComment);
        }

        /// <summary>
        /// Deletes blog comments
        /// </summary>
        /// <param name="blogComments">Blog comments</param>
        public void DeleteBlogComments([FromBody]IList<BlogComment> blogComments)
        {
            _blogService.DeleteBlogComments(blogComments);
        }

        #endregion

        #endregion
    }
}
