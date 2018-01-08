using Nop.Core;
using Nop.Core.Domain.Polls;
using Nop.Services.Polls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nop.Api.Controllers
{
    [Authorize]
    public class PollsController : ApiController
    {
        #region Fields

        private readonly IPollService _pollService;

        #endregion

        #region Ctor

        public PollsController(IPollService pollService)
        {
            this._pollService = pollService;
        }

        #endregion

        #region Method

        /// <summary>
        /// Gets a poll
        /// </summary>
        /// <param name="pollId">The poll identifier</param>
        /// <returns>Poll</returns>
        public Poll GetPollById(int pollId)
        {
            return _pollService.GetPollById(pollId);
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
        public IAPIPagedList<Poll> GetPolls(int languageId = 0, bool loadShownOnHomePageOnly = false,
            string systemKeyword = null, int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            return _pollService.GetPolls(languageId, loadShownOnHomePageOnly, systemKeyword, pageIndex, pageSize, showHidden).ConvertPagedListToAPIPagedList();
        }

        /// <summary>
        /// Deletes a poll
        /// </summary>
        /// <param name="poll">The poll</param>
        public void DeletePoll(Poll poll)
        {
            _pollService.DeletePoll(poll);
        }

        /// <summary>
        /// Inserts a poll
        /// </summary>
        /// <param name="poll">Poll</param>
        public void InsertPoll(Poll poll)
        {
            _pollService.InsertPoll(poll);
        }

        /// <summary>
        /// Updates the poll
        /// </summary>
        /// <param name="poll">Poll</param>
        public void UpdatePoll(Poll poll)
        {
            _pollService.UpdatePoll(poll);
        }

        /// <summary>
        /// Gets a poll answer
        /// </summary>
        /// <param name="pollAnswerId">Poll answer identifier</param>
        /// <returns>Poll answer</returns>
        public PollAnswer GetPollAnswerById(int pollAnswerId)
        {
            return _pollService.GetPollAnswerById(pollAnswerId);
        }

        /// <summary>
        /// Deletes a poll answer
        /// </summary>
        /// <param name="pollAnswer">Poll answer</param>
        public void DeletePollAnswer(PollAnswer pollAnswer)
        {
            _pollService.DeletePollAnswer(pollAnswer);
        }

        /// <summary>
        /// Gets a value indicating whether customer already voted for this poll
        /// </summary>
        /// <param name="pollId">Poll identifier</param>
        /// <param name="customerId">Customer identifier</param>
        /// <returns>Result</returns>
        public bool AlreadyVoted(int pollId, int customerId)
        {
            return _pollService.AlreadyVoted(pollId, customerId);
        }

        #endregion
    }
}
