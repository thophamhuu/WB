﻿using Nop.Core;
using Nop.Core.Domain.Affiliates;
using Nop.Core.Infrastructure;
using Nop.Services.Affiliates;
using Nop.Services.Seo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nop.Api.Controllers
{
    [Authorize]
    public class AffiliatesController : ApiController
    {
        #region Fields

        private readonly IAffiliateService _affiliateService;

        #endregion

        #region Ctor

        public AffiliatesController(IAffiliateService affiliateService)
        {
            this._affiliateService = affiliateService;
        }

        #endregion

        #region Method

        #region Affiliate

        /// <summary>
        /// Gets an affiliate by affiliate identifier
        /// </summary>
        /// <param name="affiliateId">Affiliate identifier</param>
        /// <returns>Affiliate</returns>
        public Affiliate GetAffiliateById(int affiliateId)
        {
            return _affiliateService.GetAffiliateById(affiliateId);
        }

        /// <summary>
        /// Gets an affiliate by friendly url name
        /// </summary>
        /// <param name="friendlyUrlName">Friendly url name</param>
        /// <returns>Affiliate</returns>
        public Affiliate GetAffiliateByFriendlyUrlName(string friendlyUrlName)
        {
            return _affiliateService.GetAffiliateByFriendlyUrlName(friendlyUrlName);
        }

        /// <summary>
        /// Marks affiliate as deleted 
        /// </summary>
        /// <param name="affiliate">Affiliate</param>
        public void DeleteAffiliate(Affiliate affiliate)
        {
            _affiliateService.DeleteAffiliate(affiliate);
        }

        /// <summary>
        /// Gets all affiliates
        /// </summary>
        /// <param name="friendlyUrlName">Friendly URL name; null to load all records</param>
        /// <param name="firstName">First name; null to load all records</param>
        /// <param name="lastName">Last name; null to load all records</param>
        /// <param name="loadOnlyWithOrders">Value indicating whether to load affiliates only with orders placed (by affiliated customers)</param>
        /// <param name="ordersCreatedFromUtc">Orders created date from (UTC); null to load all records. It's used only with "loadOnlyWithOrders" parameter st to "true".</param>
        /// <param name="ordersCreatedToUtc">Orders created date to (UTC); null to load all records. It's used only with "loadOnlyWithOrders" parameter st to "true".</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Affiliates</returns>
        public IAPIPagedList<Affiliate> GetAllAffiliates(string friendlyUrlName = null,
            string firstName = null, string lastName = null,
            bool loadOnlyWithOrders = false,
            DateTime? ordersCreatedFromUtc = null, DateTime? ordersCreatedToUtc = null,
            int pageIndex = 0, int pageSize = int.MaxValue,
            bool showHidden = false)
        {
            return _affiliateService.GetAllAffiliates(friendlyUrlName, firstName, lastName, loadOnlyWithOrders, ordersCreatedFromUtc, ordersCreatedToUtc, pageIndex, pageSize, showHidden).ConvertPagedListToAPIPagedList();
        }

        /// <summary>
        /// Inserts an affiliate
        /// </summary>
        /// <param name="affiliate">Affiliate</param>
        public void InsertAffiliate(Affiliate affiliate)
        {
            _affiliateService.InsertAffiliate(affiliate);
        }

        /// <summary>
        /// Updates the affiliate
        /// </summary>
        /// <param name="affiliate">Affiliate</param>
        public void UpdateAffiliate(Affiliate affiliate)
        {
            _affiliateService.UpdateAffiliate(affiliate);
        }

        #endregion

        #endregion
    }
}
