using Nop.Core.Domain.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Messages
{
    public partial class MessageTemplateApiService : IMessageTemplateService
    {
        #region Methods

        /// <summary>
        /// Delete a message template
        /// </summary>
        /// <param name="messageTemplate">Message template</param>
        public virtual void DeleteMessageTemplate(MessageTemplate messageTemplate)
        {
            APIHelper.Instance.PostAsync("Messages", "DeleteMessageTemplate", messageTemplate);
        }

        /// <summary>
        /// Inserts a message template
        /// </summary>
        /// <param name="messageTemplate">Message template</param>
        public virtual void InsertMessageTemplate(MessageTemplate messageTemplate)
        {
            APIHelper.Instance.PostAsync("Messages", "InsertMessageTemplate", messageTemplate);
        }

        /// <summary>
        /// Updates a message template
        /// </summary>
        /// <param name="messageTemplate">Message template</param>
        public virtual void UpdateMessageTemplate(MessageTemplate messageTemplate)
        {
            APIHelper.Instance.PostAsync("Messages", "UpdateMessageTemplate", messageTemplate);
        }

        /// <summary>
        /// Gets a message template
        /// </summary>
        /// <param name="messageTemplateId">Message template identifier</param>
        /// <returns>Message template</returns>
        public virtual MessageTemplate GetMessageTemplateById(int messageTemplateId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("messageTemplateId", messageTemplateId);
            return APIHelper.Instance.GetAsync<MessageTemplate>("Messages", "GetMessageTemplateById", parameters);
        }

        /// <summary>
        /// Gets a message template
        /// </summary>
        /// <param name="messageTemplateName">Message template name</param>
        /// <param name="storeId">Store identifier</param>
        /// <returns>Message template</returns>
        public virtual MessageTemplate GetMessageTemplateByName(string messageTemplateName, int storeId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("messageTemplateName", messageTemplateName);
            parameters.Add("storeId", storeId);
            return APIHelper.Instance.GetAsync<MessageTemplate>("Messages", "GetMessageTemplateByName", parameters);
        }

        /// <summary>
        /// Gets all message templates
        /// </summary>
        /// <param name="storeId">Store identifier; pass 0 to load all records</param>
        /// <returns>Message template list</returns>
        public virtual IList<MessageTemplate> GetAllMessageTemplates(int storeId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("storeId", storeId);
            return APIHelper.Instance.GetListAsync<MessageTemplate>("Messages", "GetAllMessageTemplates", parameters);
        }

        /// <summary>
        /// Create a copy of message template with all depended data
        /// </summary>
        /// <param name="messageTemplate">Message template</param>
        /// <returns>Message template copy</returns>
        public virtual MessageTemplate CopyMessageTemplate(MessageTemplate messageTemplate)
        {
            return APIHelper.Instance.PostAsync<MessageTemplate>("Messages", "CopyMessageTemplate", messageTemplate);
        }

        #endregion

    }
}
