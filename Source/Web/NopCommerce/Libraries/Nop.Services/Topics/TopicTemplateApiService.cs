using Nop.Core.Domain.Topics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Topics
{
    public partial class TopicTemplateApiService : ITopicTemplateService
    {
        #region Methods

        /// <summary>
        /// Delete topic template
        /// </summary>
        /// <param name="topicTemplate">Topic template</param>
        public virtual void DeleteTopicTemplate(TopicTemplate topicTemplate)
        {
            APIHelper.Instance.PostAsync("Topics", "DeleteTopicTemplate", topicTemplate);
        }

        /// <summary>
        /// Gets all topic templates
        /// </summary>
        /// <returns>Topic templates</returns>
        public virtual IList<TopicTemplate> GetAllTopicTemplates()
        {
            return APIHelper.Instance.GetListAsync<TopicTemplate>("Topics", "GetAllTopicTemplates", null);
        }

        /// <summary>
        /// Gets a topic template
        /// </summary>
        /// <param name="topicTemplateId">Topic template identifier</param>
        /// <returns>Topic template</returns>
        public virtual TopicTemplate GetTopicTemplateById(int topicTemplateId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("topicTemplateId", topicTemplateId);
            return APIHelper.Instance.GetAsync<TopicTemplate>("Topics", "GetTopicTemplateById", parameters);
        }

        /// <summary>
        /// Inserts topic template
        /// </summary>
        /// <param name="topicTemplate">Topic template</param>
        public virtual void InsertTopicTemplate(TopicTemplate topicTemplate)
        {
            APIHelper.Instance.PostAsync("Topics", "InsertTopicTemplate", topicTemplate);
        }

        /// <summary>
        /// Updates the topic template
        /// </summary>
        /// <param name="topicTemplate">Topic template</param>
        public virtual void UpdateTopicTemplate(TopicTemplate topicTemplate)
        {
            APIHelper.Instance.PostAsync("Topics", "UpdateTopicTemplate", topicTemplate);
        }

        #endregion
    }
}
