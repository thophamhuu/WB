using Nop.Core;
using Nop.Core.Domain.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Messages
{
    public partial class QueuedEmailApiService : IQueuedEmailService
    {
        /// <summary>
        /// Inserts a queued email
        /// </summary>
        /// <param name="queuedEmail">Queued email</param>        
        public virtual void InsertQueuedEmail(QueuedEmail queuedEmail)
        {
            APIHelper.Instance.PostAsync("Messages", "InsertQueuedEmail", queuedEmail);
        }

        /// <summary>
        /// Updates a queued email
        /// </summary>
        /// <param name="queuedEmail">Queued email</param>
        public virtual void UpdateQueuedEmail(QueuedEmail queuedEmail)
        {
            APIHelper.Instance.PostAsync("Messages", "UpdateQueuedEmail", queuedEmail);
        }

        /// <summary>
        /// Deleted a queued email
        /// </summary>
        /// <param name="queuedEmail">Queued email</param>
        public virtual void DeleteQueuedEmail(QueuedEmail queuedEmail)
        {
            APIHelper.Instance.PostAsync("Messages", "DeleteQueuedEmail", queuedEmail);
        }

        /// <summary>
        /// Deleted a queued emails
        /// </summary>
        /// <param name="queuedEmails">Queued emails</param>
        public virtual void DeleteQueuedEmails(IList<QueuedEmail> queuedEmails)
        {
            APIHelper.Instance.PostAsync("Messages", "DeleteQueuedEmails", queuedEmails);
        }

        /// <summary>
        /// Gets a queued email by identifier
        /// </summary>
        /// <param name="queuedEmailId">Queued email identifier</param>
        /// <returns>Queued email</returns>
        public virtual QueuedEmail GetQueuedEmailById(int queuedEmailId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("queuedEmailId", queuedEmailId);
            return APIHelper.Instance.GetAsync<QueuedEmail>("Messages", "GetQueuedEmailById", parameters);
        }

        /// <summary>
        /// Get queued emails by identifiers
        /// </summary>
        /// <param name="queuedEmailIds">queued email identifiers</param>
        /// <returns>Queued emails</returns>
        public virtual IList<QueuedEmail> GetQueuedEmailsByIds(int[] queuedEmailIds)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("queuedEmailIds", string.Join(",", queuedEmailIds));
            return APIHelper.Instance.GetListAsync<QueuedEmail>("Messages", "GetQueuedEmailsByIds", parameters);
        }

        /// <summary>
        /// Gets all queued emails
        /// </summary>
        /// <param name="fromEmail">From Email</param>
        /// <param name="toEmail">To Email</param>
        /// <param name="createdFromUtc">Created date from (UTC); null to load all records</param>
        /// <param name="createdToUtc">Created date to (UTC); null to load all records</param>
        /// <param name="loadNotSentItemsOnly">A value indicating whether to load only not sent emails</param>
        /// <param name="loadOnlyItemsToBeSent">A value indicating whether to load only emails for ready to be sent</param>
        /// <param name="maxSendTries">Maximum send tries</param>
        /// <param name="loadNewest">A value indicating whether we should sort queued email descending; otherwise, ascending.</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Email item list</returns>
        public virtual IPagedList<QueuedEmail> SearchEmails(string fromEmail,
            string toEmail, DateTime? createdFromUtc, DateTime? createdToUtc,
            bool loadNotSentItemsOnly, bool loadOnlyItemsToBeSent, int maxSendTries,
            bool loadNewest, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("fromEmail", fromEmail);
            parameters.Add("toEmail", toEmail);
            if (createdFromUtc.HasValue)
                parameters.Add("createdFromUtc", CommonHelper.DateTimeUtcToStringAPI(createdFromUtc.Value));
            if (createdToUtc.HasValue)
                parameters.Add("createdToUtc", CommonHelper.DateTimeUtcToStringAPI(createdToUtc.Value));
            parameters.Add("loadNotSentItemsOnly", loadNotSentItemsOnly);
            parameters.Add("loadOnlyItemsToBeSent", loadOnlyItemsToBeSent);
            parameters.Add("maxSendTries", maxSendTries);
            parameters.Add("loadNewest", loadNewest);
            parameters.Add("pageIndex", pageIndex);
            parameters.Add("pageSize", pageSize);
            return APIHelper.Instance.GetPagedListAsync<QueuedEmail>("Messages", "SearchEmails", parameters);
        }

        /// <summary>
        /// Delete all queued emails
        /// </summary>
        public virtual void DeleteAllEmails()
        {
            APIHelper.Instance.PostAsync("Messages", "DeleteAllEmails", null);
        }
    }
}
