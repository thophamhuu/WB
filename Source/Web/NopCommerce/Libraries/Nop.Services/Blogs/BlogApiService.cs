using Nop.Core;
using Nop.Core.Domain.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Blogs
{
    public partial class BlogApiService : IBlogService
    {
        #region Methods

        #region Blog posts

        /// <summary>
        /// Deletes a blog post
        /// </summary>
        /// <param name="blogPost">Blog post</param>
        public virtual void DeleteBlogPost(BlogPost blogPost)
        {
            APIHelper.Instance.PostAsync("Blogs", "DeleteBlogPost", blogPost);
        }

        /// <summary>
        /// Gets a blog post
        /// </summary>
        /// <param name="blogPostId">Blog post identifier</param>
        /// <returns>Blog post</returns>
        public virtual BlogPost GetBlogPostById(int blogPostId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("blogPostId", blogPostId);
            return APIHelper.Instance.GetAsync<BlogPost>("Blogs", "GetBlogPostById", parameters);
        }

        /// <summary>
        /// Gets blog posts
        /// </summary>
        /// <param name="blogPostIds">Blog post identifiers</param>
        /// <returns>Blog posts</returns>
        public virtual IList<BlogPost> GetBlogPostsByIds(int[] blogPostIds)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("blogPostIds", string.Join(",", blogPostIds));
            return APIHelper.Instance.GetListAsync<BlogPost>("Blogs", "GetBlogPostsByIds", parameters);
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
        public virtual IPagedList<BlogPost> GetAllBlogPosts(int storeId = 0, int languageId = 0,
            DateTime? dateFrom = null, DateTime? dateTo = null,
            int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("storeId", storeId);
            parameters.Add("languageId", languageId);
            if (dateFrom.HasValue)
                parameters.Add("dateFrom", CommonHelper.DateTimeUtcToStringAPI(dateFrom.Value));
            if (dateTo.HasValue)
                parameters.Add("dateTo", CommonHelper.DateTimeUtcToStringAPI(dateTo.Value));
            parameters.Add("pageIndex", pageIndex);
            parameters.Add("pageSize", pageSize);
            parameters.Add("showHidden", showHidden);
            return APIHelper.Instance.GetPagedListAsync<BlogPost>("Blogs", "GetAllBlogPosts", parameters);
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
        public virtual IPagedList<BlogPost> GetAllBlogPostsByTag(int storeId = 0,
            int languageId = 0, string tag = "",
            int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("storeId", storeId);
            parameters.Add("languageId", languageId);
            parameters.Add("tag", tag);
            parameters.Add("pageIndex", pageIndex);
            parameters.Add("pageSize", pageSize);
            parameters.Add("showHidden", showHidden);
            return APIHelper.Instance.GetPagedListAsync<BlogPost>("Blogs", "GetAllBlogPostsByTag", parameters);
        }

        /// <summary>
        /// Gets all blog post tags
        /// </summary>
        /// <param name="storeId">The store identifier; pass 0 to load all records</param>
        /// <param name="languageId">Language identifier. 0 if you want to get all blog posts</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Blog post tags</returns>
        public virtual IList<BlogPostTag> GetAllBlogPostTags(int storeId, int languageId, bool showHidden = false)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("storeId", storeId);
            parameters.Add("languageId", languageId);
            parameters.Add("showHidden", showHidden);
            return APIHelper.Instance.GetListAsync<BlogPostTag>("Blogs", "GetAllBlogPostTags", parameters);
        }

        /// <summary>
        /// Inserts an blog post
        /// </summary>
        /// <param name="blogPost">Blog post</param>
        public virtual void InsertBlogPost(BlogPost blogPost)
        {
            APIHelper.Instance.PostAsync("Blogs", "InsertBlogPost", blogPost);
        }

        /// <summary>
        /// Updates the blog post
        /// </summary>
        /// <param name="blogPost">Blog post</param>
        public virtual void UpdateBlogPost(BlogPost blogPost)
        {
            APIHelper.Instance.PostAsync("Blogs", "UpdateBlogPost", blogPost);
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
        public virtual IList<BlogComment> GetAllComments(int customerId = 0, int storeId = 0, int? blogPostId = null,
            bool? approved = null, DateTime? fromUtc = null, DateTime? toUtc = null, string commentText = null)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customerId", customerId);
            parameters.Add("storeId", storeId);
            parameters.Add("blogPostId", blogPostId);
            parameters.Add("approved", approved);
            if (fromUtc.HasValue)
                parameters.Add("fromUtc", CommonHelper.DateTimeUtcToStringAPI(fromUtc.Value));
            if (toUtc.HasValue)
                parameters.Add("toUtc", CommonHelper.DateTimeUtcToStringAPI(toUtc.Value));
            parameters.Add("commentText", commentText);
            return APIHelper.Instance.GetListAsync<BlogComment>("Blogs", "GetAllComments", parameters);
        }

        /// <summary>
        /// Gets a blog comment
        /// </summary>
        /// <param name="blogCommentId">Blog comment identifier</param>
        /// <returns>Blog comment</returns>
        public virtual BlogComment GetBlogCommentById(int blogCommentId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("blogCommentId", blogCommentId);
            return APIHelper.Instance.GetAsync<BlogComment>("Blogs", "GetBlogCommentById", parameters);
        }

        /// <summary>
        /// Get blog comments by identifiers
        /// </summary>
        /// <param name="commentIds">Blog comment identifiers</param>
        /// <returns>Blog comments</returns>
        public virtual IList<BlogComment> GetBlogCommentsByIds(int[] commentIds)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("commentIds", string.Join(",", commentIds));
            return APIHelper.Instance.GetListAsync<BlogComment>("Blogs", "GetBlogCommentsByIds", parameters);
        }

        /// <summary>
        /// Get the count of blog comments
        /// </summary>
        /// <param name="blogPost">Blog post</param>
        /// <param name="storeId">Store identifier; pass 0 to load all records</param>
        /// <param name="isApproved">A value indicating whether to count only approved or not approved comments; pass null to get number of all comments</param>
        /// <returns>Number of blog comments</returns>
        public virtual int GetBlogCommentsCount(BlogPost blogPost, int storeId = 0, bool? isApproved = null)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("blogPost", blogPost);
            parameters.Add("storeId", storeId);
            parameters.Add("isApproved", isApproved);
            return APIHelper.Instance.GetAsync<int>("Blogs", "GetBlogCommentsCount", parameters);
        }

        /// <summary>
        /// Deletes a blog comment
        /// </summary>
        /// <param name="blogComment">Blog comment</param>
        public virtual void DeleteBlogComment(BlogComment blogComment)
        {
            APIHelper.Instance.PostAsync("Blogs", "DeleteBlogComment", blogComment);
        }

        /// <summary>
        /// Deletes blog comments
        /// </summary>
        /// <param name="blogComments">Blog comments</param>
        public virtual void DeleteBlogComments(IList<BlogComment> blogComments)
        {
            APIHelper.Instance.PostAsync("Blogs", "DeleteBlogComments", blogComments);
        }

        #endregion

        #endregion
    }
}
