using Nop.Core;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Forums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Forums
{
    public partial class ForumApiService : IForumService
    {
        #region Methods

        /// <summary>
        /// Deletes a forum group
        /// </summary>
        /// <param name="forumGroup">Forum group</param>
        public virtual void DeleteForumGroup(ForumGroup forumGroup)
        {
            APIHelper.Instance.PostAsync("Forums", "DeleteForumGroup", forumGroup);
        }

        /// <summary>
        /// Gets a forum group
        /// </summary>
        /// <param name="forumGroupId">The forum group identifier</param>
        /// <returns>Forum group</returns>
        public virtual ForumGroup GetForumGroupById(int forumGroupId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("forumGroupId", forumGroupId);
            return APIHelper.Instance.GetAsync<ForumGroup>("Forums", "GetForumGroupById", parameters);
        }

        /// <summary>
        /// Gets all forum groups
        /// </summary>
        /// <returns>Forum groups</returns>
        public virtual IList<ForumGroup> GetAllForumGroups()
        {
            return APIHelper.Instance.GetListAsync<ForumGroup>("Forums", "GetAllForumGroups", null);
        }

        /// <summary>
        /// Inserts a forum group
        /// </summary>
        /// <param name="forumGroup">Forum group</param>
        public virtual void InsertForumGroup(ForumGroup forumGroup)
        {
            APIHelper.Instance.PostAsync("Forums", "InsertForumGroup", forumGroup);
        }

        /// <summary>
        /// Updates the forum group
        /// </summary>
        /// <param name="forumGroup">Forum group</param>
        public virtual void UpdateForumGroup(ForumGroup forumGroup)
        {
            APIHelper.Instance.PostAsync("Forums", "UpdateForumGroup", forumGroup);
        }

        /// <summary>
        /// Deletes a forum
        /// </summary>
        /// <param name="forum">Forum</param>
        public virtual void DeleteForum(Forum forum)
        {
            APIHelper.Instance.PostAsync("Forums", "DeleteForum", forum);
        }

        /// <summary>
        /// Gets a forum
        /// </summary>
        /// <param name="forumId">The forum identifier</param>
        /// <returns>Forum</returns>
        public virtual Forum GetForumById(int forumId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("forumId", forumId);
            return APIHelper.Instance.GetAsync<Forum>("Forums", "GetForumById", parameters);
        }

        /// <summary>
        /// Gets forums by forum group identifier
        /// </summary>
        /// <param name="forumGroupId">The forum group identifier</param>
        /// <returns>Forums</returns>
        public virtual IList<Forum> GetAllForumsByGroupId(int forumGroupId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("forumGroupId", forumGroupId);
            return APIHelper.Instance.GetListAsync<Forum>("Forums", "GetAllForumsByGroupId", parameters);
        }

        /// <summary>
        /// Inserts a forum
        /// </summary>
        /// <param name="forum">Forum</param>
        public virtual void InsertForum(Forum forum)
        {
            APIHelper.Instance.PostAsync("Forums", "InsertForum", forum);
        }

        /// <summary>
        /// Updates the forum
        /// </summary>
        /// <param name="forum">Forum</param>
        public virtual void UpdateForum(Forum forum)
        {
            APIHelper.Instance.PostAsync("Forums", "UpdateForum", forum);
        }

        /// <summary>
        /// Deletes a forum topic
        /// </summary>
        /// <param name="forumTopic">Forum topic</param>
        public virtual void DeleteTopic(ForumTopic forumTopic)
        {
            APIHelper.Instance.PostAsync("Forums", "DeleteTopic", forumTopic);
        }

        /// <summary>
        /// Gets a forum topic
        /// </summary>
        /// <param name="forumTopicId">The forum topic identifier</param>
        /// <returns>Forum Topic</returns>
        public virtual ForumTopic GetTopicById(int forumTopicId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("forumTopicId", forumTopicId);
            return APIHelper.Instance.GetAsync<ForumTopic>("Forums", "GetTopicById", parameters);
        }

        /// <summary>
        /// Gets a forum topic
        /// </summary>
        /// <param name="forumTopicId">The forum topic identifier</param>
        /// <param name="increaseViews">The value indicating whether to increase forum topic views</param>
        /// <returns>Forum Topic</returns>
        public virtual ForumTopic GetTopicById(int forumTopicId, bool increaseViews)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("forumTopicId", forumTopicId);
            parameters.Add("increaseViews", increaseViews);
            return APIHelper.Instance.GetAsync<ForumTopic>("Forums", "GetTopicById", parameters);
        }

        /// <summary>
        /// Gets all forum topics
        /// </summary>
        /// <param name="forumId">The forum identifier</param>
        /// <param name="customerId">The customer identifier</param>
        /// <param name="keywords">Keywords</param>
        /// <param name="searchType">Search type</param>
        /// <param name="limitDays">Limit by the last number days; 0 to load all topics</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Forum Topics</returns>
        public virtual IPagedList<ForumTopic> GetAllTopics(int forumId = 0,
            int customerId = 0, string keywords = "", ForumSearchType searchType = ForumSearchType.All,
            int limitDays = 0, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("forumId", forumId);
            parameters.Add("customerId", customerId);
            parameters.Add("keywords", keywords);
            parameters.Add("searchType", searchType);
            parameters.Add("limitDays", limitDays);
            parameters.Add("pageIndex", pageIndex);
            parameters.Add("pageSize", pageSize);
            return APIHelper.Instance.GetPagedListAsync<ForumTopic>("Forums", "GetAllTopics", parameters);
        }

        /// <summary>
        /// Gets active forum topics
        /// </summary>
        /// <param name="forumId">The forum identifier</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Forum Topics</returns>
        public virtual IPagedList<ForumTopic> GetActiveTopics(int forumId = 0,
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("forumId", forumId);
            parameters.Add("pageIndex", pageIndex);
            parameters.Add("pageSize", pageSize);
            return APIHelper.Instance.GetPagedListAsync<ForumTopic>("Forums", "GetActiveTopics", parameters);
        }

        /// <summary>
        /// Inserts a forum topic
        /// </summary>
        /// <param name="forumTopic">Forum topic</param>
        /// <param name="sendNotifications">A value indicating whether to send notifications to subscribed customers</param>
        public virtual void InsertTopic(ForumTopic forumTopic, bool sendNotifications)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("sendNotifications", sendNotifications);
            APIHelper.Instance.PostAsync("Forums", "InsertTopic", forumTopic, parameters);
        }

        /// <summary>
        /// Updates the forum topic
        /// </summary>
        /// <param name="forumTopic">Forum topic</param>
        public virtual void UpdateTopic(ForumTopic forumTopic)
        {
            APIHelper.Instance.PostAsync("Forums", "UpdateTopic", forumTopic);
        }

        /// <summary>
        /// Moves the forum topic
        /// </summary>
        /// <param name="forumTopicId">The forum topic identifier</param>
        /// <param name="newForumId">New forum identifier</param>
        /// <returns>Moved forum topic</returns>
        public virtual ForumTopic MoveTopic(int forumTopicId, int newForumId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("forumTopicId", forumTopicId);
            parameters.Add("newForumId", newForumId);
            return APIHelper.Instance.GetAsync<ForumTopic>("Forums", "MoveTopic", parameters);
        }

        /// <summary>
        /// Deletes a forum post
        /// </summary>
        /// <param name="forumPost">Forum post</param>
        public virtual void DeletePost(ForumPost forumPost)
        {
            APIHelper.Instance.PostAsync("Forums", "DeletePost", forumPost);
        }

        /// <summary>
        /// Gets a forum post
        /// </summary>
        /// <param name="forumPostId">The forum post identifier</param>
        /// <returns>Forum Post</returns>
        public virtual ForumPost GetPostById(int forumPostId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("forumPostId", forumPostId);
            return APIHelper.Instance.GetAsync<ForumPost>("Forums", "GetPostById", parameters);
        }

        /// <summary>
        /// Gets all forum posts
        /// </summary>
        /// <param name="forumTopicId">The forum topic identifier</param>
        /// <param name="customerId">The customer identifier</param>
        /// <param name="keywords">Keywords</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Posts</returns>
        public virtual IPagedList<ForumPost> GetAllPosts(int forumTopicId = 0,
            int customerId = 0, string keywords = "",
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("forumId", forumTopicId);
            parameters.Add("customerId", customerId);
            parameters.Add("keywords", keywords);
            parameters.Add("pageIndex", pageIndex);
            parameters.Add("pageSize", pageSize);
            return APIHelper.Instance.GetPagedListAsync<ForumPost>("Forums", "GetAllPosts", parameters);
        }

        /// <summary>
        /// Gets all forum posts
        /// </summary>
        /// <param name="forumTopicId">The forum topic identifier</param>
        /// <param name="customerId">The customer identifier</param>
        /// <param name="keywords">Keywords</param>
        /// <param name="ascSort">Sort order</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Forum Posts</returns>
        public virtual IPagedList<ForumPost> GetAllPosts(int forumTopicId = 0, int customerId = 0,
            string keywords = "", bool ascSort = false,
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("forumId", forumTopicId);
            parameters.Add("customerId", customerId);
            parameters.Add("keywords", keywords);
            parameters.Add("ascSort", ascSort);
            parameters.Add("pageIndex", pageIndex);
            parameters.Add("pageSize", pageSize);
            return APIHelper.Instance.GetPagedListAsync<ForumPost>("Forums", "GetAllPosts", parameters);
        }

        /// <summary>
        /// Inserts a forum post
        /// </summary>
        /// <param name="forumPost">The forum post</param>
        /// <param name="sendNotifications">A value indicating whether to send notifications to subscribed customers</param>
        public virtual void InsertPost(ForumPost forumPost, bool sendNotifications)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("sendNotifications", sendNotifications);
            APIHelper.Instance.PostAsync("Forums", "InsertPost", forumPost, parameters);
        }

        /// <summary>
        /// Updates the forum post
        /// </summary>
        /// <param name="forumPost">Forum post</param>
        public virtual void UpdatePost(ForumPost forumPost)
        {
            APIHelper.Instance.PostAsync("Forums", "UpdatePost", forumPost);
        }

        /// <summary>
        /// Deletes a private message
        /// </summary>
        /// <param name="privateMessage">Private message</param>
        public virtual void DeletePrivateMessage(PrivateMessage privateMessage)
        {
            APIHelper.Instance.PostAsync("Forums", "DeletePrivateMessage", privateMessage);
        }

        /// <summary>
        /// Gets a private message
        /// </summary>
        /// <param name="privateMessageId">The private message identifier</param>
        /// <returns>Private message</returns>
        public virtual PrivateMessage GetPrivateMessageById(int privateMessageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("privateMessageId", privateMessageId);
            return APIHelper.Instance.GetAsync<PrivateMessage>("Forums", "GetPrivateMessageById", parameters);
        }

        /// <summary>
        /// Gets private messages
        /// </summary>
        /// <param name="storeId">The store identifier; pass 0 to load all messages</param>
        /// <param name="fromCustomerId">The customer identifier who sent the message</param>
        /// <param name="toCustomerId">The customer identifier who should receive the message</param>
        /// <param name="isRead">A value indicating whether loaded messages are read. false - to load not read messages only, 1 to load read messages only, null to load all messages</param>
        /// <param name="isDeletedByAuthor">A value indicating whether loaded messages are deleted by author. false - messages are not deleted by author, null to load all messages</param>
        /// <param name="isDeletedByRecipient">A value indicating whether loaded messages are deleted by recipient. false - messages are not deleted by recipient, null to load all messages</param>
        /// <param name="keywords">Keywords</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Private messages</returns>
        public virtual IPagedList<PrivateMessage> GetAllPrivateMessages(int storeId, int fromCustomerId,
            int toCustomerId, bool? isRead, bool? isDeletedByAuthor, bool? isDeletedByRecipient,
            string keywords, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("storeId", storeId);
            parameters.Add("fromCustomerId", fromCustomerId);
            parameters.Add("toCustomerId", toCustomerId);
            parameters.Add("isRead", isRead);
            parameters.Add("isDeletedByAuthor", isDeletedByAuthor);
            parameters.Add("isDeletedByRecipient", isDeletedByRecipient);
            parameters.Add("keywords", keywords);
            parameters.Add("pageIndex", pageIndex);
            parameters.Add("pageSize", pageSize);
            return APIHelper.Instance.GetPagedListAsync<PrivateMessage>("Forums", "GetAllPrivateMessages", parameters);
        }

        /// <summary>
        /// Inserts a private message
        /// </summary>
        /// <param name="privateMessage">Private message</param>
        public virtual void InsertPrivateMessage(PrivateMessage privateMessage)
        {
            APIHelper.Instance.PostAsync("Forums", "InsertPrivateMessage", privateMessage);
        }

        /// <summary>
        /// Updates the private message
        /// </summary>
        /// <param name="privateMessage">Private message</param>
        public virtual void UpdatePrivateMessage(PrivateMessage privateMessage)
        {
            APIHelper.Instance.PostAsync("Forums", "UpdatePrivateMessage", privateMessage);
        }

        /// <summary>
        /// Deletes a forum subscription
        /// </summary>
        /// <param name="forumSubscription">Forum subscription</param>
        public virtual void DeleteSubscription(ForumSubscription forumSubscription)
        {
            APIHelper.Instance.PostAsync("Forums", "DeleteSubscription", forumSubscription);
        }

        /// <summary>
        /// Gets a forum subscription
        /// </summary>
        /// <param name="forumSubscriptionId">The forum subscription identifier</param>
        /// <returns>Forum subscription</returns>
        public virtual ForumSubscription GetSubscriptionById(int forumSubscriptionId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("forumSubscriptionId", forumSubscriptionId);
            return APIHelper.Instance.GetAsync<ForumSubscription>("Forums", "GetSubscriptionById", parameters);
        }

        /// <summary>
        /// Gets forum subscriptions
        /// </summary>
        /// <param name="customerId">The customer identifier</param>
        /// <param name="forumId">The forum identifier</param>
        /// <param name="topicId">The topic identifier</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Forum subscriptions</returns>
        public virtual IPagedList<ForumSubscription> GetAllSubscriptions(int customerId = 0, int forumId = 0,
            int topicId = 0, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customerId", customerId);
            parameters.Add("forumId", forumId);
            parameters.Add("topicId", topicId);
            parameters.Add("pageIndex", pageIndex);
            parameters.Add("pageSize", pageSize);
            return APIHelper.Instance.GetPagedListAsync<ForumSubscription>("Forums", "GetAllSubscriptions", parameters);
        }

        /// <summary>
        /// Inserts a forum subscription
        /// </summary>
        /// <param name="forumSubscription">Forum subscription</param>
        public virtual void InsertSubscription(ForumSubscription forumSubscription)
        {
            APIHelper.Instance.PostAsync("Forums", "InsertSubscription", forumSubscription);
        }

        /// <summary>
        /// Updates the forum subscription
        /// </summary>
        /// <param name="forumSubscription">Forum subscription</param>
        public virtual void UpdateSubscription(ForumSubscription forumSubscription)
        {
            APIHelper.Instance.PostAsync("Forums", "UpdateSubscription", forumSubscription);
        }

        /// <summary>
        /// Check whether customer is allowed to create new topics
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="forum">Forum</param>
        /// <returns>True if allowed, otherwise false</returns>
        public virtual bool IsCustomerAllowedToCreateTopic(Customer customer, Forum forum)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customer", customer);
            parameters.Add("forum", forum);
            return APIHelper.Instance.GetAsync<bool>("Forums", "IsCustomerAllowedToCreateTopic", parameters);
        }

        /// <summary>
        /// Check whether customer is allowed to edit topic
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="topic">Topic</param>
        /// <returns>True if allowed, otherwise false</returns>
        public virtual bool IsCustomerAllowedToEditTopic(Customer customer, ForumTopic topic)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customer", customer);
            parameters.Add("topic", topic);
            return APIHelper.Instance.GetAsync<bool>("Forums", "IsCustomerAllowedToEditTopic", parameters);
        }

        /// <summary>
        /// Check whether customer is allowed to move topic
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="topic">Topic</param>
        /// <returns>True if allowed, otherwise false</returns>
        public virtual bool IsCustomerAllowedToMoveTopic(Customer customer, ForumTopic topic)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customer", customer);
            parameters.Add("topic", topic);
            return APIHelper.Instance.GetAsync<bool>("Forums", "IsCustomerAllowedToMoveTopic", parameters);
        }

        /// <summary>
        /// Check whether customer is allowed to delete topic
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="topic">Topic</param>
        /// <returns>True if allowed, otherwise false</returns>
        public virtual bool IsCustomerAllowedToDeleteTopic(Customer customer, ForumTopic topic)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customer", customer);
            parameters.Add("topic", topic);
            return APIHelper.Instance.GetAsync<bool>("Forums", "IsCustomerAllowedToDeleteTopic", parameters);
        }

        /// <summary>
        /// Check whether customer is allowed to create new post
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="topic">Topic</param>
        /// <returns>True if allowed, otherwise false</returns>
        public virtual bool IsCustomerAllowedToCreatePost(Customer customer, ForumTopic topic)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customer", customer);
            parameters.Add("topic", topic);
            return APIHelper.Instance.GetAsync<bool>("Forums", "IsCustomerAllowedToCreatePost", parameters);
        }

        /// <summary>
        /// Check whether customer is allowed to edit post
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="post">Topic</param>
        /// <returns>True if allowed, otherwise false</returns>
        public virtual bool IsCustomerAllowedToEditPost(Customer customer, ForumPost post)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customer", customer);
            parameters.Add("post", post);
            return APIHelper.Instance.GetAsync<bool>("Forums", "IsCustomerAllowedToEditPost", parameters);
        }

        /// <summary>
        /// Check whether customer is allowed to delete post
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="post">Topic</param>
        /// <returns>True if allowed, otherwise false</returns>
        public virtual bool IsCustomerAllowedToDeletePost(Customer customer, ForumPost post)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customer", customer);
            parameters.Add("post", post);
            return APIHelper.Instance.GetAsync<bool>("Forums", "IsCustomerAllowedToDeletePost", parameters);
        }

        /// <summary>
        /// Check whether customer is allowed to set topic priority
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <returns>True if allowed, otherwise false</returns>
        public virtual bool IsCustomerAllowedToSetTopicPriority(Customer customer)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customer", customer);
            return APIHelper.Instance.GetAsync<bool>("Forums", "IsCustomerAllowedToSetTopicPriority", parameters);
        }

        /// <summary>
        /// Check whether customer is allowed to watch topics
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <returns>True if allowed, otherwise false</returns>
        public virtual bool IsCustomerAllowedToSubscribe(Customer customer)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customer", customer);
            return APIHelper.Instance.GetAsync<bool>("Forums", "IsCustomerAllowedToSubscribe", parameters);
        }

        /// <summary>
        /// Calculates topic page index by post identifier
        /// </summary>
        /// <param name="forumTopicId">Forum topic identifier</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="postId">Post identifier</param>
        /// <returns>Page index</returns>
        public virtual int CalculateTopicPageIndex(int forumTopicId, int pageSize, int postId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("forumTopicId", forumTopicId);
            parameters.Add("pageSize", pageSize);
            parameters.Add("postId", postId);
            return APIHelper.Instance.GetAsync<int>("Forums", "CalculateTopicPageIndex", parameters);
        }

        /// <summary>
        /// Get a post vote 
        /// </summary>
        /// <param name="postId">Post identifier</param>
        /// <param name="customer">Customer</param>
        /// <returns>Post vote</returns>
        public virtual ForumPostVote GetPostVote(int postId, Customer customer)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("postId", postId);
            parameters.Add("customer", customer);
            return APIHelper.Instance.GetAsync<ForumPostVote>("Forums", "GetPostVote", parameters);
        }

        /// <summary>
        /// Get post vote made since the parameter date
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="сreatedFromUtc">Date</param>
        /// <returns>Post votes count</returns>
        public virtual int GetNumberOfPostVotes(Customer customer, DateTime сreatedFromUtc)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customer", customer);
            parameters.Add("сreatedFromUtc", CommonHelper.DateTimeUtcToStringAPI(сreatedFromUtc));
            return APIHelper.Instance.GetAsync<int>("Forums", "GetNumberOfPostVotes", parameters);
        }

        /// <summary>
        /// Insert a post vote
        /// </summary>
        /// <param name="postVote">Post vote</param>
        public virtual void InsertPostVote(ForumPostVote postVote)
        {
            APIHelper.Instance.PostAsync("Forums", "InsertPostVote", postVote);
        }

        /// <summary>
        /// Update a post vote
        /// </summary>
        /// <param name="postVote">Post vote</param>
        public virtual void UpdatePostVote(ForumPostVote postVote)
        {
            APIHelper.Instance.PostAsync("Forums", "UpdatePostVote", postVote);
        }

        /// <summary>
        /// Delete a post vote
        /// </summary>
        /// <param name="postVote">Post vote</param>
        public virtual void DeletePostVote(ForumPostVote postVote)
        {
            APIHelper.Instance.PostAsync("Forums", "DeletePostVote", postVote);
        }
        #endregion
    }
}
