using Nop.Core.Domain.Topics;
using Nop.Services.Topics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nop.Api.Controllers
{
    [Authorize]
    public class TopicsController : ApiController
    {
        #region Fields

        private readonly ITopicService _topicService;
        private readonly ITopicTemplateService _topicTemplateService;

        #endregion

        #region Ctor

        public TopicsController(ITopicService topicService, ITopicTemplateService topicTemplateService)
        {
            this._topicService = topicService;
            this._topicTemplateService = topicTemplateService;
        }

        #endregion

        #region Method

        #region Topic

        /// <summary>
        /// Deletes a topic
        /// </summary>
        /// <param name="topic">Topic</param>
        public void DeleteTopic([FromBody]Topic topic)
        {
            _topicService.DeleteTopic(topic);
        }

        /// <summary>
        /// Gets a topic
        /// </summary>
        /// <param name="topicId">The topic identifier</param>
        /// <returns>Topic</returns>
        public Topic GetTopicById(int topicId)
        {
            return _topicService.GetTopicById(topicId);
        }

        /// <summary>
        /// Gets a topic
        /// </summary>
        /// <param name="systemName">The topic system name</param>
        /// <param name="storeId">Store identifier; pass 0 to ignore filtering by store and load the first one</param>
        /// <returns>Topic</returns>
        public Topic GetTopicBySystemName(string systemName, int storeId = 0)
        {
            return _topicService.GetTopicBySystemName(systemName, storeId);
        }

        /// <summary>
        /// Gets all topics
        /// </summary>
        /// <param name="storeId">Store identifier; pass 0 to load all records</param>
        /// <param name="ignorAcl">A value indicating whether to ignore ACL rules</param>
        /// <param name="showHidden">A value indicating whether to show hidden topics</param>
        /// <returns>Topics</returns>
        public IList<Topic> GetAllTopics(int storeId, bool ignorAcl = false, bool showHidden = false)
        {
            return _topicService.GetAllTopics(storeId, ignorAcl, showHidden);
        }

        /// <summary>
        /// Inserts a topic
        /// </summary>
        /// <param name="topic">Topic</param>
        public void InsertTopic([FromBody]Topic topic)
        {
            _topicService.InsertTopic(topic);
        }

        /// <summary>
        /// Updates the topic
        /// </summary>
        /// <param name="topic">Topic</param>
        public void UpdateTopic([FromBody]Topic topic)
        {
            _topicService.UpdateTopic(topic);
        }

        #endregion

        #region Topic template

        /// <summary>
        /// Delete topic template
        /// </summary>
        /// <param name="topicTemplate">Topic template</param>
        public void DeleteTopicTemplate([FromBody]TopicTemplate topicTemplate)
        {
            _topicTemplateService.DeleteTopicTemplate(topicTemplate);
        }

        /// <summary>
        /// Gets all topic templates
        /// </summary>
        /// <returns>Topic templates</returns>
        public IList<TopicTemplate> GetAllTopicTemplates()
        {
            return _topicTemplateService.GetAllTopicTemplates();
        }

        /// <summary>
        /// Gets a topic template
        /// </summary>
        /// <param name="topicTemplateId">Topic template identifier</param>
        /// <returns>Topic template</returns>
        public TopicTemplate GetTopicTemplateById(int topicTemplateId)
        {
            return _topicTemplateService.GetTopicTemplateById(topicTemplateId);
        }

        /// <summary>
        /// Inserts topic template
        /// </summary>
        /// <param name="topicTemplate">Topic template</param>
        public void InsertTopicTemplate([FromBody]TopicTemplate topicTemplate)
        {
            _topicTemplateService.InsertTopicTemplate(topicTemplate);
        }

        /// <summary>
        /// Updates the topic template
        /// </summary>
        /// <param name="topicTemplate">Topic template</param>
        public void UpdateTopicTemplate([FromBody]TopicTemplate topicTemplate)
        {
            _topicTemplateService.UpdateTopicTemplate(topicTemplate);
        }

        #endregion

        #endregion
    }
}
