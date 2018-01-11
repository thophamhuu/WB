using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Data;
using Nop.Core.Domain.Blogs;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Forums;
using Nop.Core.Domain.News;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Polls;
using Nop.Core.Domain.Shipping;
using Nop.Data;
using Nop.Services.Common;
using Nop.Services.Events;

namespace Nop.Services.Customers
{
    /// <summary>
    /// Customer service
    /// </summary>
    public partial class CustomerApiService : ICustomerService
    {
        #region Constants

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : show hidden records?
        /// </remarks>
        private const string CUSTOMERROLES_ALL_KEY = "Nop.customerrole.all-{0}";
        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : system name
        /// </remarks>
        private const string CUSTOMERROLES_BY_SYSTEMNAME_KEY = "Nop.customerrole.systemname-{0}";
        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        private const string CUSTOMERROLES_PATTERN_KEY = "Nop.customerrole.";

        #endregion

        #region Fields

        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<CustomerPassword> _customerPasswordRepository;
        private readonly IRepository<CustomerRole> _customerRoleRepository;
        private readonly IRepository<GenericAttribute> _gaRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<ForumPost> _forumPostRepository;
        private readonly IRepository<ForumTopic> _forumTopicRepository;
        private readonly IRepository<BlogComment> _blogCommentRepository;
        private readonly IRepository<NewsComment> _newsCommentRepository;
        private readonly IRepository<PollVotingRecord> _pollVotingRecordRepository;
        private readonly IRepository<ProductReview> _productReviewRepository;
        private readonly IRepository<ProductReviewHelpfulness> _productReviewHelpfulnessRepository;
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly ICacheManager _cacheManager;
        private readonly IEventPublisher _eventPublisher;
        private readonly CustomerSettings _customerSettings;
        private readonly CommonSettings _commonSettings;
        #endregion

        #region Ctor

        public CustomerApiService(ICacheManager cacheManager,
            IRepository<Customer> customerRepository,
            IRepository<CustomerPassword> customerPasswordRepository,
            IRepository<CustomerRole> customerRoleRepository,
            IRepository<GenericAttribute> gaRepository,
            IRepository<Order> orderRepository,
            IRepository<ForumPost> forumPostRepository,
            IRepository<ForumTopic> forumTopicRepository,
            IRepository<BlogComment> blogCommentRepository,
            IRepository<NewsComment> newsCommentRepository,
            IRepository<PollVotingRecord> pollVotingRecordRepository,
            IRepository<ProductReview> productReviewRepository,
            IRepository<ProductReviewHelpfulness> productReviewHelpfulnessRepository,
            IGenericAttributeService genericAttributeService,
            IDataProvider dataProvider,
            IDbContext dbContext,
            IEventPublisher eventPublisher,
            CustomerSettings customerSettings,
            CommonSettings commonSettings)
        {
            this._cacheManager = cacheManager;
            this._customerRepository = customerRepository;
            this._customerPasswordRepository = customerPasswordRepository;
            this._customerRoleRepository = customerRoleRepository;
            this._gaRepository = gaRepository;
            this._orderRepository = orderRepository;
            this._forumPostRepository = forumPostRepository;
            this._forumTopicRepository = forumTopicRepository;
            this._blogCommentRepository = blogCommentRepository;
            this._newsCommentRepository = newsCommentRepository;
            this._pollVotingRecordRepository = pollVotingRecordRepository;
            this._productReviewRepository = productReviewRepository;
            this._productReviewHelpfulnessRepository = productReviewHelpfulnessRepository;
            this._genericAttributeService = genericAttributeService;
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._eventPublisher = eventPublisher;
            this._customerSettings = customerSettings;
            this._commonSettings = commonSettings;
        }

        #endregion

        #region Methods

        #region Customers

        /// <summary>
        /// Gets all customers
        /// </summary>
        /// <param name="createdFromUtc">Created date from (UTC); null to load all records</param>
        /// <param name="createdToUtc">Created date to (UTC); null to load all records</param>
        /// <param name="affiliateId">Affiliate identifier</param>
        /// <param name="vendorId">Vendor identifier</param>
        /// <param name="customerRoleIds">A list of customer role identifiers to filter by (at least one match); pass null or empty list in order to load all customers; </param>
        /// <param name="email">Email; null to load all customers</param>
        /// <param name="username">Username; null to load all customers</param>
        /// <param name="firstName">First name; null to load all customers</param>
        /// <param name="lastName">Last name; null to load all customers</param>
        /// <param name="dayOfBirth">Day of birth; 0 to load all customers</param>
        /// <param name="monthOfBirth">Month of birth; 0 to load all customers</param>
        /// <param name="company">Company; null to load all customers</param>
        /// <param name="phone">Phone; null to load all customers</param>
        /// <param name="zipPostalCode">Phone; null to load all customers</param>
        /// <param name="ipAddress">IP address; null to load all customers</param>
        /// <param name="loadOnlyWithShoppingCart">Value indicating whether to load customers only with shopping cart</param>
        /// <param name="sct">Value indicating what shopping cart type to filter; userd when 'loadOnlyWithShoppingCart' param is 'true'</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Customers</returns>
        public virtual IPagedList<Customer> GetAllCustomers(DateTime? createdFromUtc = null, DateTime? createdToUtc = null,
            int affiliateId = 0, int vendorId = 0,
            int[] customerRoleIds = null, string email = null, string username = null,
            string firstName = null, string lastName = null,
            int dayOfBirth = 0, int monthOfBirth = 0,
            string company = null, string phone = null, string zipPostalCode = null,
            string ipAddress = null, bool loadOnlyWithShoppingCart = false, ShoppingCartType? sct = null,
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var parameters = new Dictionary<string, dynamic>();
            if (createdFromUtc.HasValue)
                parameters.Add("createdFromUtcStr", CommonHelper.DateTimeUtcToStringAPI(createdFromUtc.Value));

            if (createdToUtc.HasValue)
                parameters.Add("createdToUtcStr", CommonHelper.DateTimeUtcToStringAPI(createdToUtc.Value));

            parameters.Add("affiliateId", affiliateId.ToString());
            parameters.Add("vendorId", vendorId.ToString());

            if (customerRoleIds != null)
            {
                parameters.Add("customerRoleIds", string.Join(",", customerRoleIds));
            }
            if (email != null)
                parameters.Add("email", email);
            if (username != null)
                parameters.Add("username", username);

            if (firstName != null)
                parameters.Add("firstName", firstName);
            if (lastName != null)
                parameters.Add("lastName", lastName);


            parameters.Add("dayOfBirth", dayOfBirth);
            parameters.Add("monthOfBirth", monthOfBirth);

            if (company != null)
                parameters.Add("company", company);
            if (phone != null)
                parameters.Add("phone", phone);
            if (zipPostalCode != null)
                parameters.Add("zipPostalCode", zipPostalCode);

            if (ipAddress != null)
                parameters.Add("ipAddress", ipAddress);
            parameters.Add("loadOnlyWithShoppingCart", loadOnlyWithShoppingCart);
            if (sct.HasValue)
                parameters.Add("sct", sct.Value);

            parameters.Add("pageIndex", pageIndex);
            parameters.Add("pageSize", pageSize);



            return APIHelper.Instance.GetPagedListAsync<Customer>("Customers", "GetAllCustomers", parameters);
        }

        /// <summary>
        /// Gets online customers
        /// </summary>
        /// <param name="lastActivityFromUtc">Customer last activity date (from)</param>
        /// <param name="customerRoleIds">A list of customer role identifiers to filter by (at least one match); pass null or empty list in order to load all customers; </param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Customers</returns>
        public virtual IPagedList<Customer> GetOnlineCustomers(DateTime lastActivityFromUtc,
            int[] customerRoleIds, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("lastActivityFromUtcStr", CommonHelper.DateTimeUtcToStringAPI(lastActivityFromUtc));
            if (customerRoleIds != null)
            {
                parameters.Add("customerRoleId", string.Join(",", customerRoleIds));
            }
            else
            {
                parameters.Add("customerRoleId", "");
            }
            parameters.Add("pageIndex", pageIndex);
            parameters.Add("pageSize", pageSize);
            return APIHelper.Instance.GetPagedListAsync<Customer>("Customers", "GetOnlineCustomers", parameters);
        }

        /// <summary>
        /// Delete a customer
        /// </summary>
        /// <param name="customer">Customer</param>
        public virtual void DeleteCustomer(Customer customer)
        {
            APIHelper.Instance.PostAsync("Customers", "DeleteCustomer", customer);
        }

        /// <summary>
        /// Gets a customer
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <returns>A customer</returns>
        public virtual Customer GetCustomerById(int customerId)
        {
            if (customerId == 0)
                return null;
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customerId", customerId);
            return APIHelper.Instance.GetAsync<Customer>("Customers", "GetCustomerById", parameters);
        }

        /// <summary>
        /// Get customers by identifiers
        /// </summary>
        /// <param name="customerIds">Customer identifiers</param>
        /// <returns>Customers</returns>
        public virtual IList<Customer> GetCustomersByIds(int[] customerIds)
        {
            var parameters = new Dictionary<string, dynamic>();
            if (customerIds != null)
                parameters.Add("customerId", string.Join(",", customerIds));
            else
                parameters.Add("customerId", "");

            var customer = APIHelper.Instance.GetListAsync<Customer>("Customers", "GetCustomersByIds", parameters);
            return customer;
        }

        /// <summary>
        /// Gets a customer by GUID
        /// </summary>
        /// <param name="customerGuid">Customer GUID</param>
        /// <returns>A customer</returns>
        public virtual Customer GetCustomerByGuid(Guid customerGuid)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customerGuid", customerGuid);
            var customer = APIHelper.Instance.GetAsync<Customer>("Customers", "GetCustomerByGuid", parameters);
            return customer;
        }

        /// <summary>
        /// Get customer by email
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns>Customer</returns>
        public virtual Customer GetCustomerByEmail(string email)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("email", email);
            var customer = APIHelper.Instance.GetAsync<Customer>("Customers", "GetCustomerByEmail", parameters);
            return customer;
        }

        /// <summary>
        /// Get customer by system name
        /// </summary>
        /// <param name="systemName">System name</param>
        /// <returns>Customer</returns>
        public virtual Customer GetCustomerBySystemName(string systemName)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("systemName", systemName);
            var customer = APIHelper.Instance.GetAsync<Customer>("Customers", "GetCustomerBySystemName", parameters);
            return customer;
        }

        /// <summary>
        /// Get customer by username
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>Customer</returns>
        public virtual Customer GetCustomerByUsername(string username)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("username", username);
            var customer = APIHelper.Instance.GetAsync<Customer>("Customers", "GetCustomerByUsername", parameters);
            return customer;
        }

        /// <summary>
        /// Insert a guest customer
        /// </summary>
        /// <returns>Customer</returns>
        public virtual Customer InsertGuestCustomer()
        {
            return APIHelper.Instance.PostAsync<Customer>("Customers", "InsertGuestCustomer", null,null);
        }

        /// <summary>
        /// Insert a customer
        /// </summary>
        /// <param name="customer">Customer</param>
        public virtual void InsertCustomer(Customer customer)
        {
            APIHelper.Instance.PostAsync("Customers", "InsertCustomer", customer);
        }

        /// <summary>
        /// Updates the customer
        /// </summary>
        /// <param name="customer">Customer</param>
        public virtual void UpdateCustomer(Customer customer)
        {
            APIHelper.Instance.PostAsync("Customers", "UpdateCustomer", customer);
        }

        /// <summary>
        /// Reset data required for checkout
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="storeId">Store identifier</param>
        /// <param name="clearCouponCodes">A value indicating whether to clear coupon code</param>
        /// <param name="clearCheckoutAttributes">A value indicating whether to clear selected checkout attributes</param>
        /// <param name="clearRewardPoints">A value indicating whether to clear "Use reward points" flag</param>
        /// <param name="clearShippingMethod">A value indicating whether to clear selected shipping method</param>
        /// <param name="clearPaymentMethod">A value indicating whether to clear selected payment method</param>
        public virtual void ResetCheckoutData(Customer customer, int storeId,
            bool clearCouponCodes = false, bool clearCheckoutAttributes = false,
            bool clearRewardPoints = true, bool clearShippingMethod = true,
            bool clearPaymentMethod = true)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("storeId", storeId);
            parameters.Add("clearCouponCodes", clearCouponCodes);
            parameters.Add("clearCheckoutAttributes", clearCheckoutAttributes);
            parameters.Add("clearRewardPoints", clearRewardPoints);
            parameters.Add("clearShippingMethod", clearShippingMethod);
            parameters.Add("clearPaymentMethod", clearPaymentMethod);

            APIHelper.Instance.PostAsync("Customers", "ResetCheckoutData", customer, parameters);
        }

        /// <summary>
        /// Delete guest customer records
        /// </summary>
        /// <param name="createdFromUtc">Created date from (UTC); null to load all records</param>
        /// <param name="createdToUtc">Created date to (UTC); null to load all records</param>
        /// <param name="onlyWithoutShoppingCart">A value indicating whether to delete customers only without shopping cart</param>
        /// <returns>Number of deleted customers</returns>
        public virtual int DeleteGuestCustomers(DateTime? createdFromUtc, DateTime? createdToUtc, bool onlyWithoutShoppingCart)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("createdFromUtc", createdFromUtc);
            parameters.Add("createdToUtc", createdToUtc);

            return APIHelper.Instance.PostAsync<int>("Customers", "DeleteGuestCustomers", null , parameters);
        }

        #endregion

        #region Customer roles

        /// <summary>
        /// Delete a customer role
        /// </summary>
        /// <param name="customerRole">Customer role</param>
        public virtual void DeleteCustomerRole(CustomerRole customerRole)
        {
            APIHelper.Instance.PostAsync("Customers", "DeleteCustomerRole", customerRole);
        }

        /// <summary>
        /// Gets a customer role
        /// </summary>
        /// <param name="customerRoleId">Customer role identifier</param>
        /// <returns>Customer role</returns>
        public virtual CustomerRole GetCustomerRoleById(int customerRoleId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customerRoleId", customerRoleId);

            return APIHelper.Instance.GetAsync<CustomerRole>("Customers", "GetCustomerRoleById", parameters);
        }

        /// <summary>
        /// Gets a customer role
        /// </summary>
        /// <param name="systemName">Customer role system name</param>
        /// <returns>Customer role</returns>
        public virtual CustomerRole GetCustomerRoleBySystemName(string systemName)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("systemName", systemName);

            return APIHelper.Instance.GetAsync<CustomerRole>("Customers", "GetCustomerRoleBySystemName", parameters);
        }

        /// <summary>
        /// Gets all customer roles
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Customer roles</returns>
        public virtual IList<CustomerRole> GetAllCustomerRoles(bool showHidden = false)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("showHidden", showHidden);
            var customerRoles = APIHelper.Instance.GetListAsync<CustomerRole>("Customers", "GetAllCustomerRoles", parameters);
            return customerRoles;
        }

        /// <summary>
        /// Inserts a customer role
        /// </summary>
        /// <param name="customerRole">Customer role</param>
        public virtual void InsertCustomerRole(CustomerRole customerRole)
        {
            APIHelper.Instance.PostAsync("Customers", "InsertCustomerRole", customerRole);
        }

        /// <summary>
        /// Updates the customer role
        /// </summary>
        /// <param name="customerRole">Customer role</param>
        public virtual void UpdateCustomerRole(CustomerRole customerRole)
        {
            APIHelper.Instance.PostAsync("Customers", "UpdateCustomerRole", customerRole);
        }

        #endregion

        #region Customer passwords

        /// <summary>
        /// Gets customer passwords
        /// </summary>
        /// <param name="customerId">Customer identifier; pass null to load all records</param>
        /// <param name="passwordFormat">Password format; pass null to load all records</param>
        /// <param name="passwordsToReturn">Number of returning passwords; pass null to load all records</param>
        /// <returns>List of customer passwords</returns>
        public virtual IList<CustomerPassword> GetCustomerPasswords(int? customerId = null,
            PasswordFormat? passwordFormat = null, int? passwordsToReturn = null)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customerId", customerId);
            parameters.Add("passwordFormat", passwordFormat);
            parameters.Add("passwordsToReturn", passwordsToReturn);
            return APIHelper.Instance.GetListAsync<CustomerPassword>("Customers", "GetCustomerPasswords", parameters);
        }

        /// <summary>
        /// Get current customer password
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <returns>Customer password</returns>
        public virtual CustomerPassword GetCurrentPassword(int customerId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customerId", customerId);
            return APIHelper.Instance.GetAsync<CustomerPassword>("Customers", "GetCurrentPassword", parameters);
        }

        /// <summary>
        /// Insert a customer password
        /// </summary>
        /// <param name="customerPassword">Customer password</param>
        public virtual void InsertCustomerPassword(CustomerPassword customerPassword)
        {
            APIHelper.Instance.PostAsync("Customers", "InsertCustomerPassword", customerPassword);
        }

        /// <summary>
        /// Update a customer password
        /// </summary>
        /// <param name="customerPassword">Customer password</param>
        public virtual void UpdateCustomerPassword(CustomerPassword customerPassword)
        {
            APIHelper.Instance.PostAsync("Customers", "UpdateCustomerPassword", customerPassword);
        }

        public ICollection<CustomerRole> GetCustomerRolesByCustomerId(int customerId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customerId", customerId);
            return APIHelper.Instance.GetListAsync<CustomerRole>("Customers", "GetCustomerRolesByCustomerId", parameters);
        }

        #endregion

        #endregion
    }
}