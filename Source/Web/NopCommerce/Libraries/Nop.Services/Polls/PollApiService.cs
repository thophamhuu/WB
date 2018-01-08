using Nop.Core;
using Nop.Core.Domain.Polls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Polls
{
    public partial class PollApiService : IPollService
    {
        #region Methods

        /// <summary>
        /// Gets a poll
        /// </summary>
        /// <param name="pollId">The poll identifier</param>
        /// <returns>Poll</returns>
        public virtual Poll GetPollById(int pollId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("pollId", pollId);
            return APIHelper.Instance.GetAsync<Poll>("Polls", "GetPollById", parameters);
        }

        /// <summary>
        /// Gets polls
        /// </summary>
        /// <param name="languageId">Language identifier. 0 if you want to get all polls</param>
        /// <param name="loadShownOnHomePageOnly">Retrieve only shown on home page polls</param>
        /// <param name="systemKeyword">The poll system keyword. Pass null if you want to get all polls</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Polls</returns>
        public virtual IPagedList<Poll> GetPolls(int languageId = 0, bool loadShownOnHomePageOnly = false,
            string systemKeyword = null, int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("languageId", languageId);
            parameters.Add("loadShownOnHomePageOnly", loadShownOnHomePageOnly);
            parameters.Add("systemKeyword", systemKeyword);
            parameters.Add("pageIndex", pageIndex);
            parameters.Add("pageSize", pageSize);
            parameters.Add("showHidden", showHidden);
            return APIHelper.Instance.GetPagedListAsync<Poll>("Polls", "GetAllVendors", parameters);
        }

        /// <summary>
        /// Deletes a poll
        /// </summary>
        /// <param name="poll">The poll</param>
        public virtual void DeletePoll(Poll poll)
        {
            APIHelper.Instance.PostAsync("Polls", "DeletePoll", poll);
        }

        /// <summary>
        /// Inserts a poll
        /// </summary>
        /// <param name="poll">Poll</param>
        public virtual void InsertPoll(Poll poll)
        {
            APIHelper.Instance.PostAsync("Polls", "InsertPoll", poll);
        }

        /// <summary>
        /// Updates the poll
        /// </summary>
        /// <param name="poll">Poll</param>
        public virtual void UpdatePoll(Poll poll)
        {
            APIHelper.Instance.PostAsync("Polls", "UpdatePoll", poll);
        }

        /// <summary>
        /// Gets a poll answer
        /// </summary>
        /// <param name="pollAnswerId">Poll answer identifier</param>
        /// <returns>Poll answer</returns>
        public virtual PollAnswer GetPollAnswerById(int pollAnswerId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("pollAnswerId", pollAnswerId);
            return APIHelper.Instance.GetAsync<PollAnswer>("Polls", "GetPollAnswerById", parameters);
        }

        /// <summary>
        /// Deletes a poll answer
        /// </summary>
        /// <param name="pollAnswer">Poll answer</param>
        public virtual void DeletePollAnswer(PollAnswer pollAnswer)
        {
            APIHelper.Instance.PostAsync("Polls", "DeletePollAnswer", pollAnswer);
        }

        /// <summary>
        /// Gets a value indicating whether customer already voted for this poll
        /// </summary>
        /// <param name="pollId">Poll identifier</param>
        /// <param name="customerId">Customer identifier</param>
        /// <returns>Result</returns>
        public virtual bool AlreadyVoted(int pollId, int customerId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("pollId", pollId);
            parameters.Add("customerId", customerId);
            return APIHelper.Instance.GetAsync<bool>("Polls", "AlreadyVoted", parameters);
        }

        #endregion
    }
}
