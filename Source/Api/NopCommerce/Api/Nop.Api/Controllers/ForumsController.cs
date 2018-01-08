using Nop.Core;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Forums;
using Nop.Services.Forums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nop.Api.Controllers
{
    [Authorize]
    public class ForumsController : ApiController
    {
        #region Fields

        private readonly IForumService _forumService;

        #endregion

        #region Ctor

        public ForumsController(IForumService forumService)
        {
            this._forumService = forumService;
        }

        #endregion

        #region Method

        /// <summary>
        /// Deletes a forum group
        /// </summary>
        /// <param name="forumGroup">Forum group</param>
        public void DeleteForumGroup(ForumGroup forumGroup)
        {
            _forumService.DeleteForumGroup(forumGroup);
        }

        /// <summary>
        /// Gets a forum group
        /// </summary>
        /// <param name="forumGroupId">The forum group identifier</param>
        /// <returns>Forum group</returns>
        public ForumGroup GetForumGroupById(int forumGroupId)
        {
            return _forumService.GetForumGroupById(forumGroupId);
        }

        /// <summary>
        /// Gets all forum groups
        /// </summary>
        /// <returns>Forum groups</returns>
        public IList<ForumGroup> GetAllForumGroups()
        {
            return _forumService.GetAllForumGroups();
        }

        /// <summary>
        /// Inserts a forum group
        /// </summary>
        /// <param name="forumGroup">Forum group</param>
        public void InsertForumGroup(ForumGroup forumGroup)
        {
            _forumService.InsertForumGroup(forumGroup);
        }

        /// <summary>
        /// Updates the forum group
        /// </summary>
        /// <param name="forumGroup">Forum group</param>
        public void UpdateForumGroup(ForumGroup forumGroup)
        {
            _forumService.UpdateForumGroup(forumGroup);
        }

        /// <summary>
        /// Deletes a forum
        /// </summary>
        /// <param name="forum">Forum</param>
        public void DeleteForum(Forum forum)
        {
            _forumService.DeleteForum(forum);
        }

        /// <summary>
        /// Gets a forum
        /// </summary>
        /// <param name="forumId">The forum identifier</param>
        /// <returns>Forum</returns>
        public Forum GetForumById(int forumId)
        {
            return _forumService.GetForumById(forumId);
        }

        /// <summary>
        /// Gets forums by group identifier
        /// </summary>
        /// <param name="forumGroupId">The forum group identifier</param>
        /// <returns>Forums</returns>
        public IList<Forum> GetAllForumsByGroupId(int forumGroupId)
        {
            return _forumService.GetAllForumsByGroupId(forumGroupId);
        }

        /// <summary>
        /// Inserts a forum
        /// </summary>
        /// <param name="forum">Forum</param>
        public void InsertForum(Forum forum)
        {
            _forumService.InsertForum(forum);
        }

        /// <summary>
        /// Updates the forum
        /// </summary>
        /// <param name="forum">Forum</param>
        public void UpdateForum(Forum forum)
        {
            _forumService.UpdateForum(forum);
        }

        /// <summary>
        /// Deletes a forum topic
        /// </summary>
        /// <param name="forumTopic">Forum topic</param>
        public void DeleteTopic(ForumTopic forumTopic)
        {
            _forumService.DeleteTopic(forumTopic);
        }

        /// <summary>
        /// Gets a forum topic
        /// </summary>
        /// <param name="forumTopicId">The forum topic identifier</param>
        /// <returns>Forum Topic</returns>
        public ForumTopic GetTopicById(int forumTopicId)
        {
            return _forumService.GetTopicById(forumTopicId);
        }

        /// <summary>
        /// Gets a forum topic
        /// </summary>
        /// <param name="forumTopicId">The forum topic identifier</param>
        /// <param name="increaseViews">The value indicating whether to increase forum topic views</param>
        /// <returns>Forum Topic</returns>
        public ForumTopic GetTopicById(int forumTopicId, bool increaseViews)
        {
            return _forumService.GetTopicById(forumTopicId, increaseViews);
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
        public IAPIPagedList<ForumTopic> GetAllTopics(int forumId = 0,
            int customerId = 0, string keywords = "", ForumSearchType searchType = ForumSearchType.All,
            int limitDays = 0, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return _forumService.GetAllTopics(forumId, customerId, keywords, searchType, limitDays, pageIndex, pageSize).ConvertPagedListToAPIPagedList();
        }

        /// <summary>
        /// Gets active forum topics
        /// </summary>
        /// <param name="forumId">The forum identifier</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Forum Topics</returns>
        public IAPIPagedList<ForumTopic> GetActiveTopics(int forumId = 0,
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return _forumService.GetActiveTopics(forumId, pageIndex, pageSize).ConvertPagedListToAPIPagedList();
        }

        /// <summary>
        /// Inserts a forum topic
        /// </summary>
        /// <param name="forumTopic">Forum topic</param>
        /// <param name="sendNotifications">A value indicating whether to send notifications to subscribed customers</param>
        public void InsertTopic(ForumTopic forumTopic, bool sendNotifications)
        {
            _forumService.InsertTopic(forumTopic, sendNotifications);
        }

        /// <summary>
        /// Updates the forum topic
        /// </summary>
        /// <param name="forumTopic">Forum topic</param>
        public void UpdateTopic(ForumTopic forumTopic)
        {
            _forumService.UpdateTopic(forumTopic);
        }

        /// <summary>
        /// Moves the forum topic
        /// </summary>
        /// <param name="forumTopicId">The forum topic identifier</param>
        /// <param name="newForumId">New forum identifier</param>
        /// <returns>Moved forum topic</returns>
        public ForumTopic MoveTopic(int forumTopicId, int newForumId)
        {
            return _forumService.MoveTopic(forumTopicId, newForumId);
        }

        /// <summary>
        /// Deletes a forum post
        /// </summary>
        /// <param name="forumPost">Forum post</param>
        public void DeletePost(ForumPost forumPost)
        {
            _forumService.DeletePost(forumPost);
        }

        /// <summary>
        /// Gets a forum post
        /// </summary>
        /// <param name="forumPostId">The forum post identifier</param>
        /// <returns>Forum Post</returns>
        public ForumPost GetPostById(int forumPostId)
        {
            return _forumService.GetPostById(forumPostId);
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
        public IAPIPagedList<ForumPost> GetAllPosts(int forumTopicId = 0,
            int customerId = 0, string keywords = "",
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return _forumService.GetAllPosts(forumTopicId, customerId, keywords, pageIndex, pageSize).ConvertPagedListToAPIPagedList();
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
        public IAPIPagedList<ForumPost> GetAllPosts(int forumTopicId = 0, int customerId = 0,
            string keywords = "", bool ascSort = false,
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return _forumService.GetAllPosts(forumTopicId, customerId, keywords, pageIndex, pageSize).ConvertPagedListToAPIPagedList();
        }

        /// <summary>
        /// Inserts a forum post
        /// </summary>
        /// <param name="forumPost">The forum post</param>
        /// <param name="sendNotifications">A value indicating whether to send notifications to subscribed customers</param>
        public void InsertPost(ForumPost forumPost, bool sendNotifications)
        {
            _forumService.InsertPost(forumPost, sendNotifications);
        }

        /// <summary>
        /// Updates the forum post
        /// </summary>
        /// <param name="forumPost">Forum post</param>
        public void UpdatePost(ForumPost forumPost)
        {
            _forumService.UpdatePost(forumPost);
        }

        /// <summary>
        /// Deletes a private message
        /// </summary>
        /// <param name="privateMessage">Private message</param>
        public void DeletePrivateMessage(PrivateMessage privateMessage)
        {
            _forumService.DeletePrivateMessage(privateMessage);
        }

        /// <summary>
        /// Gets a private message
        /// </summary>
        /// <param name="privateMessageId">The private message identifier</param>
        /// <returns>Private message</returns>
        public PrivateMessage GetPrivateMessageById(int privateMessageId)
        {
            return _forumService.GetPrivateMessageById(privateMessageId);
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
        public IAPIPagedList<PrivateMessage> GetAllPrivateMessages(int storeId, int fromCustomerId,
            int toCustomerId, bool? isRead, bool? isDeletedByAuthor, bool? isDeletedByRecipient,
            string keywords, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return _forumService.GetAllPrivateMessages(storeId, fromCustomerId, toCustomerId, isRead, isDeletedByAuthor, isDeletedByRecipient, keywords, pageIndex, pageSize).ConvertPagedListToAPIPagedList();
        }

        /// <summary>
        /// Inserts a private message
        /// </summary>
        /// <param name="privateMessage">Private message</param>
        public void InsertPrivateMessage(PrivateMessage privateMessage)
        {
            _forumService.InsertPrivateMessage(privateMessage);
        }

        /// <summary>
        /// Updates the private message
        /// </summary>
        /// <param name="privateMessage">Private message</param>
        public void UpdatePrivateMessage(PrivateMessage privateMessage)
        {
            _forumService.UpdatePrivateMessage(privateMessage);
        }

        /// <summary>
        /// Deletes a forum subscription
        /// </summary>
        /// <param name="forumSubscription">Forum subscription</param>
        public void DeleteSubscription(ForumSubscription forumSubscription)
        {
            _forumService.DeleteSubscription(forumSubscription);
        }

        /// <summary>
        /// Gets a forum subscription
        /// </summary>
        /// <param name="forumSubscriptionId">The forum subscription identifier</param>
        /// <returns>Forum subscription</returns>
        public ForumSubscription GetSubscriptionById(int forumSubscriptionId)
        {
            return _forumService.GetSubscriptionById(forumSubscriptionId);
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
        public IAPIPagedList<ForumSubscription> GetAllSubscriptions(int customerId = 0, int forumId = 0,
            int topicId = 0, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return _forumService.GetAllSubscriptions(customerId, forumId, topicId, pageIndex, pageSize).ConvertPagedListToAPIPagedList();
        }

        /// <summary>
        /// Inserts a forum subscription
        /// </summary>
        /// <param name="forumSubscription">Forum subscription</param>
        public void InsertSubscription(ForumSubscription forumSubscription)
        {
            _forumService.InsertSubscription(forumSubscription);
        }

        /// <summary>
        /// Updates the forum subscription
        /// </summary>
        /// <param name="forumSubscription">Forum subscription</param>
        public void UpdateSubscription(ForumSubscription forumSubscription)
        {
            _forumService.UpdateSubscription(forumSubscription);
        }

        /// <summary>
        /// Check whether customer is allowed to create new topics
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="forum">Forum</param>
        /// <returns>True if allowed, otherwise false</returns>
        public bool IsCustomerAllowedToCreateTopic(Customer customer, Forum forum)
        {
            return _forumService.IsCustomerAllowedToCreateTopic(customer, forum);
        }

        /// <summary>
        /// Check whether customer is allowed to edit topic
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="topic">Topic</param>
        /// <returns>True if allowed, otherwise false</returns>
        public bool IsCustomerAllowedToEditTopic(Customer customer, ForumTopic topic)
        {
            return _forumService.IsCustomerAllowedToEditTopic(customer, topic);
        }

        /// <summary>
        /// Check whether customer is allowed to move topic
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="topic">Topic</param>
        /// <returns>True if allowed, otherwise false</returns>
        public bool IsCustomerAllowedToMoveTopic(Customer customer, ForumTopic topic)
        {
            return _forumService.IsCustomerAllowedToMoveTopic(customer, topic);
        }

        /// <summary>
        /// Check whether customer is allowed to delete topic
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="topic">Topic</param>
        /// <returns>True if allowed, otherwise false</returns>
        public bool IsCustomerAllowedToDeleteTopic(Customer customer, ForumTopic topic)
        {
            return _forumService.IsCustomerAllowedToDeleteTopic(customer, topic);
        }

        /// <summary>
        /// Check whether customer is allowed to create new post
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="topic">Topic</param>
        /// <returns>True if allowed, otherwise false</returns>
        public bool IsCustomerAllowedToCreatePost(Customer customer, ForumTopic topic)
        {
            return _forumService.IsCustomerAllowedToCreatePost(customer, topic);
        }

        /// <summary>
        /// Check whether customer is allowed to edit post
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="post">Topic</param>
        /// <returns>True if allowed, otherwise false</returns>
        public bool IsCustomerAllowedToEditPost(Customer customer, ForumPost post)
        {
            return _forumService.IsCustomerAllowedToEditPost(customer, post);
        }

        /// <summary>
        /// Check whether customer is allowed to delete post
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="post">Topic</param>
        /// <returns>True if allowed, otherwise false</returns>
        public bool IsCustomerAllowedToDeletePost(Customer customer, ForumPost post)
        {
            return _forumService.IsCustomerAllowedToDeletePost(customer, post);
        }

        /// <summary>
        /// Check whether customer is allowed to set topic priority
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <returns>True if allowed, otherwise false</returns>
        public bool IsCustomerAllowedToSetTopicPriority(Customer customer)
        {
            return _forumService.IsCustomerAllowedToSetTopicPriority(customer);
        }

        /// <summary>
        /// Check whether customer is allowed to watch topics
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <returns>True if allowed, otherwise false</returns>
        public bool IsCustomerAllowedToSubscribe(Customer customer)
        {
            return _forumService.IsCustomerAllowedToSubscribe(customer);
        }

        /// <summary>
        /// Calculates topic page index by post identifier
        /// </summary>
        /// <param name="forumTopicId">Topic identifier</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="postId">Post identifier</param>
        /// <returns>Page index</returns>
        public int CalculateTopicPageIndex(int forumTopicId, int pageSize, int postId)
        {
            return _forumService.CalculateTopicPageIndex(forumTopicId, pageSize, postId);
        }

        /// <summary>
        /// Get a post vote 
        /// </summary>
        /// <param name="postId">Post identifier</param>
        /// <param name="customer">Customer</param>
        /// <returns>Post vote</returns>
        public ForumPostVote GetPostVote(int postId, Customer customer)
        {
            return _forumService.GetPostVote(postId, customer);
        }

        /// <summary>
        /// Get post vote made since the parameter date
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="сreatedFromUtc">Date</param>
        /// <returns>Post votes count</returns>
        public int GetNumberOfPostVotes(Customer customer, DateTime сreatedFromUtc)
        {
            return _forumService.GetNumberOfPostVotes(customer, сreatedFromUtc);
        }

        /// <summary>
        /// Insert a post vote
        /// </summary>
        /// <param name="postVote">Post vote</param>
        public void InsertPostVote(ForumPostVote postVote)
        {
            _forumService.InsertPostVote(postVote);
        }

        /// <summary>
        /// Update a post vote
        /// </summary>
        /// <param name="postVote">Post vote</param>
        public void UpdatePostVote(ForumPostVote postVote)
        {
            _forumService.UpdatePostVote(postVote);
        }

        /// <summary>
        /// Delete a post vote
        /// </summary>
        /// <param name="postVote">Post vote</param>
        public void DeletePostVote(ForumPostVote postVote)
        {
            _forumService.DeletePostVote(postVote);
        }

        #endregion
    }
}
