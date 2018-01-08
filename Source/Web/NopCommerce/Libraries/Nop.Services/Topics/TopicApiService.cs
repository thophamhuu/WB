using Nop.Core.Domain.Topics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Topics
{
    public partial class TopicApiService : ITopicService
    {
        #region Methods

        /// <summary>
        /// Deletes a topic
        /// </summary>
        /// <param name="topic">Topic</param>
        public virtual void DeleteTopic(Topic topic)
        {
            APIHelper.Instance.PostAsync("Topics", "DeleteTopic", topic);
        }

        /// <summary>
        /// Gets a topic
        /// </summary>
        /// <param name="topicId">The topic identifier</param>
        /// <returns>Topic</returns>
        public virtual Topic GetTopicById(int topicId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("topicId", topicId);
            return APIHelper.Instance.GetAsync<Topic>("Topics", "GetTopicById", parameters);
        }

        /// <summary>
        /// Gets a topic
        /// </summary>
        /// <param name="systemName">The topic system name</param>
        /// <param name="storeId">Store identifier; pass 0 to ignore filtering by store and load the first one</param>
        /// <returns>Topic</returns>
        public virtual Topic GetTopicBySystemName(string systemName, int storeId = 0)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("systemName", systemName);
            parameters.Add("storeId", storeId);
            return APIHelper.Instance.GetAsync<Topic>("Topics", "GetTopicBySystemName", parameters);
        }

        /// <summary>
        /// Gets all topics
        /// </summary>
        /// <param name="storeId">Store identifier; pass 0 to load all records</param>
        /// <param name="ignorAcl">A value indicating whether to ignore ACL rules</param>
        /// <param name="showHidden">A value indicating whether to show hidden topics</param>
        /// <returns>Topics</returns>
        public virtual IList<Topic> GetAllTopics(int storeId, bool ignorAcl = false, bool showHidden = false)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("storeId", storeId);
            parameters.Add("ignorAcl", ignorAcl);
            parameters.Add("showHidden", showHidden);
            return APIHelper.Instance.GetListAsync<Topic>("Topics", "GetAllTopics", parameters);
        }

        /// <summary>
        /// Inserts a topic
        /// </summary>
        /// <param name="topic">Topic</param>
        public virtual void InsertTopic(Topic topic)
        {
            APIHelper.Instance.PostAsync("Topics", "InsertTopic", topic);
        }

        /// <summary>
        /// Updates the topic
        /// </summary>
        /// <param name="topic">Topic</param>
        public virtual void UpdateTopic(Topic topic)
        {
            APIHelper.Instance.PostAsync("Topics", "UpdateTopic", topic);
        }

        #endregion
    }
}
