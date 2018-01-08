using Nop.Core.Domain.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Messages
{
    public partial class CampaignApiService : ICampaignService
    {
        /// <summary>
        /// Inserts a campaign
        /// </summary>
        /// <param name="campaign">Campaign</param>        
        public virtual void InsertCampaign(Campaign campaign)
        {
            APIHelper.Instance.PostAsync("Messages", "InsertCampaign", campaign);
        }

        /// <summary>
        /// Updates a campaign
        /// </summary>
        /// <param name="campaign">Campaign</param>
        public virtual void UpdateCampaign(Campaign campaign)
        {
            APIHelper.Instance.PostAsync("Messages", "UpdateCampaign", campaign);
        }

        /// <summary>
        /// Deleted a queued email
        /// </summary>
        /// <param name="campaign">Campaign</param>
        public virtual void DeleteCampaign(Campaign campaign)
        {
            APIHelper.Instance.PostAsync("Messages", "DeleteCampaign", campaign);
        }

        /// <summary>
        /// Gets a campaign by identifier
        /// </summary>
        /// <param name="campaignId">Campaign identifier</param>
        /// <returns>Campaign</returns>
        public virtual Campaign GetCampaignById(int campaignId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("campaignId", campaignId);
            return APIHelper.Instance.GetAsync<Campaign>("Messages", "GetCampaignById", parameters);
        }

        /// <summary>
        /// Gets all campaigns
        /// </summary>
        /// <param name="storeId">Store identifier; 0 to load all records</param>
        /// <returns>Campaigns</returns>
        public virtual IList<Campaign> GetAllCampaigns(int storeId = 0)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("storeId", storeId);
            return APIHelper.Instance.GetListAsync<Campaign>("Messages", "GetAllCampaigns", parameters);
        }

        /// <summary>
        /// Sends a campaign to specified emails
        /// </summary>
        /// <param name="campaign">Campaign</param>
        /// <param name="emailAccount">Email account</param>
        /// <param name="subscriptions">Subscriptions</param>
        /// <returns>Total emails sent</returns>
        public virtual int SendCampaign(Campaign campaign, EmailAccount emailAccount,
            IEnumerable<NewsLetterSubscription> subscriptions)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("campaign", campaign);
            parameters.Add("emailAccount", emailAccount);
            parameters.Add("subscriptions", subscriptions);
            return APIHelper.Instance.GetAsync<int>("Messages", "SendCampaign", parameters);
        }

        /// <summary>
        /// Sends a campaign to specified email
        /// </summary>
        /// <param name="campaign">Campaign</param>
        /// <param name="emailAccount">Email account</param>
        /// <param name="email">Email</param>
        public virtual void SendCampaign(Campaign campaign, EmailAccount emailAccount, string email)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("campaign", campaign);
            parameters.Add("emailAccount", emailAccount);
            parameters.Add("email", email);
            APIHelper.Instance.GetAsync<int>("Messages", "SendCampaign", parameters);
        }
    }
}
