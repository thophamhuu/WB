using Nop.Core;
using Nop.Core.Data;
using Nop.Core.Domain.Affiliates;
using Nop.Core.Domain.Orders;
using Nop.Services.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Affiliates
{
    public partial class AffiliateApiService : IAffiliateService
    {
        #region Fields

        private readonly IRepository<Affiliate> _affiliateRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IEventPublisher _eventPublisher;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="affiliateRepository">Affiliate repository</param>
        /// <param name="orderRepository">Order repository</param>
        /// <param name="eventPublisher">Event published</param>
        public AffiliateApiService(IRepository<Affiliate> affiliateRepository,
            IRepository<Order> orderRepository,
            IEventPublisher eventPublisher)
        {
            this._affiliateRepository = affiliateRepository;
            this._orderRepository = orderRepository;
            this._eventPublisher = eventPublisher;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets an affiliate by affiliate identifier
        /// </summary>
        /// <param name="affiliateId">Affiliate identifier</param>
        /// <returns>Affiliate</returns>
        public virtual Affiliate GetAffiliateById(int affiliateId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("affiliateId", affiliateId);
            return APIHelper.Instance.GetAsync<Affiliate>("Affiliates", "GetAffiliateById", parameters);
        }

        /// <summary>
        /// Gets an affiliate by friendly url name
        /// </summary>
        /// <param name="friendlyUrlName">Friendly url name</param>
        /// <returns>Affiliate</returns>
        public virtual Affiliate GetAffiliateByFriendlyUrlName(string friendlyUrlName)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("friendlyUrlName", friendlyUrlName);
            return APIHelper.Instance.GetAsync<Affiliate>("Affiliates", "GetAffiliateByFriendlyUrlName", parameters);
        }

        /// <summary>
        /// Marks affiliate as deleted 
        /// </summary>
        /// <param name="affiliate">Affiliate</param>
        public virtual void DeleteAffiliate(Affiliate affiliate)
        {
            APIHelper.Instance.PostAsync("Affiliates", "DeleteAffiliate", affiliate);
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
        public virtual IPagedList<Affiliate> GetAllAffiliates(string friendlyUrlName = null,
            string firstName = null, string lastName = null,
            bool loadOnlyWithOrders = false,
            DateTime? ordersCreatedFromUtc = null, DateTime? ordersCreatedToUtc = null,
            int pageIndex = 0, int pageSize = int.MaxValue,
            bool showHidden = false)
        {
            var parameters = new Dictionary<string, dynamic>();
            //parameters.Add("lastActivityFromUtcStr", CommonHelper.DateTimeUtcToStringAPI(lastActivityFromUtc));
            parameters.Add("friendlyUrlName", friendlyUrlName);
            parameters.Add("firstName", firstName);
            parameters.Add("lastName", lastName);
            parameters.Add("loadOnlyWithOrders", loadOnlyWithOrders);

            if(ordersCreatedFromUtc.HasValue )
                parameters.Add("ordersCreatedFromUtc", CommonHelper.DateTimeUtcToStringAPI(ordersCreatedFromUtc.Value));
            if (ordersCreatedToUtc.HasValue)
                parameters.Add("ordersCreatedToUtc", ordersCreatedFromUtc.HasValue ? CommonHelper.DateTimeUtcToStringAPI(ordersCreatedToUtc.Value) : null);
            
            parameters.Add("pageIndex", pageIndex);
            parameters.Add("pageSize", pageSize);
            parameters.Add("showHidden", showHidden);
            

            return APIHelper.Instance.GetPagedListAsync<Affiliate>("Affiliates", "GetAllAffiliates", parameters);
        }

        /// <summary>
        /// Inserts an affiliate
        /// </summary>
        /// <param name="affiliate">Affiliate</param>
        public virtual void InsertAffiliate(Affiliate affiliate)
        {
            APIHelper.Instance.PostAsync("Affiliates", "InsertAffiliate", affiliate);
        }

        /// <summary>
        /// Updates the affiliate
        /// </summary>
        /// <param name="affiliate">Affiliate</param>
        public virtual void UpdateAffiliate(Affiliate affiliate)
        {
            APIHelper.Instance.PostAsync("Affiliates", "UpdateAffiliate", affiliate);
        }

        #endregion
    }
}
