using Nop.Core.Domain.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Messages
{
    public partial class EmailAccountApiService : IEmailAccountService
    {
        /// <summary>
        /// Inserts an email account
        /// </summary>
        /// <param name="emailAccount">Email account</param>
        public virtual void InsertEmailAccount(EmailAccount emailAccount)
        {
            APIHelper.Instance.PostAsync("Messages", "InsertCampaign", emailAccount);
        }

        /// <summary>
        /// Updates an email account
        /// </summary>
        /// <param name="emailAccount">Email account</param>
        public virtual void UpdateEmailAccount(EmailAccount emailAccount)
        {
            APIHelper.Instance.PostAsync("Messages", "UpdateEmailAccount", emailAccount);
        }

        /// <summary>
        /// Deletes an email account
        /// </summary>
        /// <param name="emailAccount">Email account</param>
        public virtual void DeleteEmailAccount(EmailAccount emailAccount)
        {
            APIHelper.Instance.PostAsync("Messages", "DeleteEmailAccount", emailAccount);
        }

        /// <summary>
        /// Gets an email account by identifier
        /// </summary>
        /// <param name="emailAccountId">The email account identifier</param>
        /// <returns>Email account</returns>
        public virtual EmailAccount GetEmailAccountById(int emailAccountId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("emailAccountId", emailAccountId);
            return APIHelper.Instance.GetAsync<EmailAccount>("Messages", "GetEmailAccountById", parameters);
        }

        /// <summary>
        /// Gets all email accounts
        /// </summary>
        /// <returns>Email accounts list</returns>
        public virtual IList<EmailAccount> GetAllEmailAccounts()
        {
            return APIHelper.Instance.GetListAsync<EmailAccount>("Messages", "GetAllEmailAccounts", null);
        }
    }
}
