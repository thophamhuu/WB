using Nop.Api.Models.Requests;
using Nop.Core;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Payments;
using Nop.Core.Domain.Shipping;
using Nop.Services.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nop.Api.Controllers
{
    [Authorize]
    public class CustomersController : ApiController
    {
        #region Fields

        private readonly ICustomerService _customerService;
        private readonly ICustomerReportService _customerReportService;
        private readonly ICustomerRegistrationService _customerRegistrationService;
        private readonly ICustomerAttributeService _customerAttributeService;
        private readonly ICustomerAttributeParser _customerAttributeParser;

        #endregion

        #region Ctor

        public CustomersController(ICustomerService customerService, ICustomerReportService customerReportService, ICustomerRegistrationService customerRegistrationService,
            ICustomerAttributeService customerAttributeService, ICustomerAttributeParser customerAttributeParser)
        {
            this._customerService = customerService;
            this._customerReportService = customerReportService;
            this._customerRegistrationService = customerRegistrationService;
            this._customerAttributeService = customerAttributeService;
            this._customerAttributeParser = customerAttributeParser;
        }

        #endregion

        #region Method

        #region Customer

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
        public IAPIPagedList<Customer> GetAllCustomers(DateTime? createdFromUtc = null,
            DateTime? createdToUtc = null, int affiliateId = 0, int vendorId = 0,
            string customerRoleIds = null, string email = null, string username = null,
            string firstName = null, string lastName = null,
            int dayOfBirth = 0, int monthOfBirth = 0,
            string company = null, string phone = null, string zipPostalCode = null,
            string ipAddress = null, bool loadOnlyWithShoppingCart = false, ShoppingCartType? sct = null,
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            int[] arrCustomerRoleIds = null;
            if (customerRoleIds != null)
            {
                arrCustomerRoleIds = customerRoleIds.Split(',').Select(x => Int32.Parse(x)).ToArray();
            }
            return _customerService.GetAllCustomers(createdFromUtc, createdToUtc, affiliateId, vendorId, arrCustomerRoleIds, email, username, firstName, lastName, dayOfBirth, monthOfBirth, company, phone, zipPostalCode, ipAddress, loadOnlyWithShoppingCart, sct, pageIndex, pageSize).ConvertPagedListToAPIPagedList();
        }

        /// <summary>
        /// Gets online customers
        /// </summary>
        /// <param name="lastActivityFromUtc">Customer last activity date (from)</param>
        /// <param name="customerRoleIds">A list of customer role identifiers to filter by (at least one match); pass null or empty list in order to load all customers; </param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Customers</returns>
        public IAPIPagedList<Customer> GetOnlineCustomers(DateTime lastActivityFromUtc,
            int[] customerRoleIds, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return _customerService.GetOnlineCustomers(lastActivityFromUtc, customerRoleIds, pageIndex, pageSize).ConvertPagedListToAPIPagedList();
        }

        /// <summary>
        /// Delete a customer
        /// </summary>
        /// <param name="customer">Customer</param>
        public void DeleteCustomer(Customer customer)
        {
            _customerService.DeleteCustomer(customer);
        }

        /// <summary>
        /// Gets a customer
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <returns>A customer</returns>
        public Customer GetCustomerById(int customerId)
        {
            return _customerService.GetCustomerById(customerId);
        }

        /// <summary>
        /// Get customers by identifiers
        /// </summary>
        /// <param name="customerIds">Customer identifiers</param>
        /// <returns>Customers</returns>
        public IList<Customer> GetCustomersByIds(int[] customerIds)
        {
            return _customerService.GetCustomersByIds(customerIds);
        }

        /// <summary>
        /// Gets a customer by GUID
        /// </summary>
        /// <param name="customerGuid">Customer GUID</param>
        /// <returns>A customer</returns>
        public Customer GetCustomerByGuid(Guid customerGuid)
        {
            return _customerService.GetCustomerByGuid(customerGuid);
        }

        /// <summary>
        /// Get customer by email
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns>Customer</returns>
        public Customer GetCustomerByEmail(string email)
        {
            return _customerService.GetCustomerByEmail(email);
        }

        /// <summary>
        /// Get customer by system role
        /// </summary>
        /// <param name="systemName">System name</param>
        /// <returns>Customer</returns>
        public Customer GetCustomerBySystemName(string systemName)
        {
            return _customerService.GetCustomerBySystemName(systemName);
        }

        /// <summary>
        /// Get customer by username
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>Customer</returns>
        public Customer GetCustomerByUsername(string username)
        {
            return _customerService.GetCustomerByUsername(username);
        }

        /// <summary>
        /// Insert a guest customer
        /// </summary>
        /// <returns>Customer</returns>
        public Customer InsertGuestCustomer()
        {
            return _customerService.InsertGuestCustomer();
        }

        /// <summary>
        /// Insert a customer
        /// </summary>
        /// <param name="customer">Customer</param>
        public void InsertCustomer(Customer customer)
        {
            _customerService.InsertCustomer(customer);
        }

        /// <summary>
        /// Updates the customer
        /// </summary>
        /// <param name="customer">Customer</param>
        public void UpdateCustomer(Customer customer)
        {
            _customerService.UpdateCustomer(customer);
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
        public void ResetCheckoutData(Customer customer, int storeId,
            bool clearCouponCodes = false, bool clearCheckoutAttributes = false,
            bool clearRewardPoints = true, bool clearShippingMethod = true,
            bool clearPaymentMethod = true)
        {
            _customerService.ResetCheckoutData(customer, storeId, clearCouponCodes, clearCheckoutAttributes, clearRewardPoints, clearShippingMethod, clearPaymentMethod);
        }

        /// <summary>
        /// Delete guest customer records
        /// </summary>
        /// <param name="createdFromUtc">Created date from (UTC); null to load all records</param>
        /// <param name="createdToUtc">Created date to (UTC); null to load all records</param>
        /// <param name="onlyWithoutShoppingCart">A value indicating whether to delete customers only without shopping cart</param>
        /// <returns>Number of deleted customers</returns>
        public int DeleteGuestCustomers(DateTime? createdFromUtc, DateTime? createdToUtc, bool onlyWithoutShoppingCart)
        {
            return _customerService.DeleteGuestCustomers(createdFromUtc, createdToUtc, onlyWithoutShoppingCart);
        }

        #endregion

        #region Customer roles

        /// <summary>
        /// Delete a customer role
        /// </summary>
        /// <param name="customerRole">Customer role</param>
        public void DeleteCustomerRole(CustomerRole customerRole)
        {
            _customerService.DeleteCustomerRole(customerRole);
        }

        /// <summary>
        /// Gets a customer role
        /// </summary>
        /// <param name="customerRoleId">Customer role identifier</param>
        /// <returns>Customer role</returns>
        public CustomerRole GetCustomerRoleById(int customerRoleId)
        {
            return _customerService.GetCustomerRoleById(customerRoleId);
        }

        /// <summary>
        /// Gets a customer role
        /// </summary>
        /// <param name="systemName">Customer role system name</param>
        /// <returns>Customer role</returns>
        public CustomerRole GetCustomerRoleBySystemName(string systemName)
        {
            return _customerService.GetCustomerRoleBySystemName(systemName);
        }

        /// <summary>
        /// Gets all customer roles
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Customer roles</returns>
        public IList<CustomerRole> GetAllCustomerRoles(bool showHidden = false)
        {
            return _customerService.GetAllCustomerRoles(showHidden);
        }

        /// <summary>
        /// Inserts a customer role
        /// </summary>
        /// <param name="customerRole">Customer role</param>
        public void InsertCustomerRole(CustomerRole customerRole)
        {
            _customerService.InsertCustomerRole(customerRole);
        }

        /// <summary>
        /// Updates the customer role
        /// </summary>
        /// <param name="customerRole">Customer role</param>
        public void UpdateCustomerRole(CustomerRole customerRole)
        {
            _customerService.UpdateCustomerRole(customerRole);
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
        public IList<CustomerPassword> GetCustomerPasswords(int? customerId = null,
            PasswordFormat? passwordFormat = null, int? passwordsToReturn = null)
        {
            return _customerService.GetCustomerPasswords(customerId, passwordFormat, passwordsToReturn);
        }

        /// <summary>
        /// Get current customer password
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <returns>Customer password</returns>
        public CustomerPassword GetCurrentPassword(int customerId)
        {
            return _customerService.GetCurrentPassword(customerId);
        }

        /// <summary>
        /// Insert a customer password
        /// </summary>
        /// <param name="customerPassword">Customer password</param>
        public void InsertCustomerPassword(CustomerPassword customerPassword)
        {
            _customerService.InsertCustomerPassword(customerPassword);
        }

        /// <summary>
        /// Update a customer password
        /// </summary>
        /// <param name="customerPassword">Customer password</param>
        public void UpdateCustomerPassword(CustomerPassword customerPassword)
        {
            _customerService.UpdateCustomerPassword(customerPassword);
        }

        #endregion

        #endregion

        #region  Customer report

        /// <summary>
        /// Get best customers
        /// </summary>
        /// <param name="createdFromUtc">Order created date from (UTC); null to load all records</param>
        /// <param name="createdToUtc">Order created date to (UTC); null to load all records</param>
        /// <param name="os">Order status; null to load all records</param>
        /// <param name="ps">Order payment status; null to load all records</param>
        /// <param name="ss">Order shipment status; null to load all records</param>
        /// <param name="orderBy">1 - order by order total, 2 - order by number of orders</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Report</returns>
        public IAPIPagedList<BestCustomerReportLine> GetBestCustomersReport(DateTime? createdFromUtc,
            DateTime? createdToUtc, OrderStatus? os, PaymentStatus? ps, ShippingStatus? ss, int orderBy,
            int pageIndex = 0, int pageSize = 214748364)
        {
            return _customerReportService.GetBestCustomersReport(createdFromUtc, createdToUtc, os, ps, ss, orderBy, pageIndex, pageSize).ConvertPagedListToAPIPagedList();
        }

        /// <summary>
        /// Gets a report of customers registered in the last days
        /// </summary>
        /// <param name="days">Customers registered in the last days</param>
        /// <returns>Number of registered customers</returns>
        public int GetRegisteredCustomersReport(int days)
        {
            return _customerReportService.GetRegisteredCustomersReport(days);
        }

        #endregion

        #region Customer registration

        /// <summary>
        /// Validate customer
        /// </summary>
        /// <param name="usernameOrEmail">Username or email</param>
        /// <param name="password">Password</param>
        /// <returns>Result</returns>
        [HttpPost]
        public HttpResponseMessage ValidateCustomer([FromBody]ValidateCustomerModel model)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _customerRegistrationService.ValidateCustomer(model.usernameOrEmail, model.password));
        }
        /// <summary>
        /// Register customer
        /// </summary>
        /// <param name="request">Request</param>
        /// <returns>Result</returns>
        public CustomerRegistrationResult RegisterCustomer(CustomerRegistrationRequest request)
        {
            return _customerRegistrationService.RegisterCustomer(request);
        }

        /// <summary>
        /// Change password
        /// </summary>
        /// <param name="request">Request</param>
        /// <returns>Result</returns>
        public ChangePasswordResult ChangePassword(ChangePasswordRequest request)
        {
            return _customerRegistrationService.ChangePassword(request);
        }

        /// <summary>
        /// Sets a user email
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="newEmail">New email</param>
        /// <param name="requireValidation">Require validation of new email address</param>
        public void SetEmail(Customer customer, string newEmail, bool requireValidation)
        {
            _customerRegistrationService.SetEmail(customer, newEmail, requireValidation);
        }

        /// <summary>
        /// Sets a customer username
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="newUsername">New Username</param>
        public void SetUsername(Customer customer, string newUsername)
        {
            _customerRegistrationService.SetUsername(customer, newUsername);
        }

        #endregion

        #region Customer attribute

        /// <summary>
        /// Deletes a customer attribute
        /// </summary>
        /// <param name="customerAttribute">Customer attribute</param>
        public void DeleteCustomerAttribute(CustomerAttribute customerAttribute)
        {
            _customerAttributeService.DeleteCustomerAttribute(customerAttribute);
        }

        /// <summary>
        /// Gets all customer attributes
        /// </summary>
        /// <returns>Customer attributes</returns>
        public IList<CustomerAttribute> GetAllCustomerAttributes()
        {
            return _customerAttributeService.GetAllCustomerAttributes();
        }

        /// <summary>
        /// Gets a customer attribute 
        /// </summary>
        /// <param name="customerAttributeId">Customer attribute identifier</param>
        /// <returns>Customer attribute</returns>
        public CustomerAttribute GetCustomerAttributeById(int customerAttributeId)
        {
            return _customerAttributeService.GetCustomerAttributeById(customerAttributeId);
        }

        /// <summary>
        /// Inserts a customer attribute
        /// </summary>
        /// <param name="customerAttribute">Customer attribute</param>
        public void InsertCustomerAttribute(CustomerAttribute customerAttribute)
        {
            _customerAttributeService.InsertCustomerAttribute(customerAttribute);
        }

        /// <summary>
        /// Updates the customer attribute
        /// </summary>
        /// <param name="customerAttribute">Customer attribute</param>
        public void UpdateCustomerAttribute(CustomerAttribute customerAttribute)
        {
            _customerAttributeService.UpdateCustomerAttribute(customerAttribute);
        }

        /// <summary>
        /// Deletes a customer attribute value
        /// </summary>
        /// <param name="customerAttributeValue">Customer attribute value</param>
        public void DeleteCustomerAttributeValue(CustomerAttributeValue customerAttributeValue)
        {
            _customerAttributeService.DeleteCustomerAttributeValue(customerAttributeValue);
        }

        /// <summary>
        /// Gets customer attribute values by customer attribute identifier
        /// </summary>
        /// <param name="customerAttributeId">The customer attribute identifier</param>
        /// <returns>Customer attribute values</returns>
        public IList<CustomerAttributeValue> GetCustomerAttributeValues(int customerAttributeId)
        {
            return _customerAttributeService.GetCustomerAttributeValues(customerAttributeId);
        }

        /// <summary>
        /// Gets a customer attribute value
        /// </summary>
        /// <param name="customerAttributeValueId">Customer attribute value identifier</param>
        /// <returns>Customer attribute value</returns>
        public CustomerAttributeValue GetCustomerAttributeValueById(int customerAttributeValueId)
        {
            return _customerAttributeService.GetCustomerAttributeValueById(customerAttributeValueId);
        }

        /// <summary>
        /// Inserts a customer attribute value
        /// </summary>
        /// <param name="customerAttributeValue">Customer attribute value</param>
        public void InsertCustomerAttributeValue(CustomerAttributeValue customerAttributeValue)
        {
            _customerAttributeService.InsertCustomerAttributeValue(customerAttributeValue);
        }

        /// <summary>
        /// Updates the customer attribute value
        /// </summary>
        /// <param name="customerAttributeValue">Customer attribute value</param>
        public void UpdateCustomerAttributeValue(CustomerAttributeValue customerAttributeValue)
        {
            _customerAttributeService.UpdateCustomerAttributeValue(customerAttributeValue);
        }

        #endregion

        #region Customer attribute parser

        /// <summary>
        /// Gets selected customer attributes
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <returns>Selected customer attributes</returns>
        IList<CustomerAttribute> ParseCustomerAttributes(string attributesXml)
        {
            return _customerAttributeParser.ParseCustomerAttributes(attributesXml);
        }

        /// <summary>
        /// Get customer attribute values
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <returns>Customer attribute values</returns>
        IList<CustomerAttributeValue> ParseCustomerAttributeValues(string attributesXml)
        {
            return _customerAttributeParser.ParseCustomerAttributeValues(attributesXml);
        }

        /// <summary>
        /// Gets selected customer attribute value
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <param name="customerAttributeId">Customer attribute identifier</param>
        /// <returns>Customer attribute value</returns>
        IList<string> ParseValues(string attributesXml, int customerAttributeId)
        {
            return _customerAttributeParser.ParseValues(attributesXml, customerAttributeId);
        }

        /// <summary>
        /// Adds an attribute
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <param name="ca">Customer attribute</param>
        /// <param name="value">Value</param>
        /// <returns>Attributes</returns>
        string AddCustomerAttribute(string attributesXml, CustomerAttribute ca, string value)
        {
            return _customerAttributeParser.AddCustomerAttribute(attributesXml, ca, value);
        }

        /// <summary>
        /// Validates customer attributes
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <returns>Warnings</returns>
        IList<string> GetAttributeWarnings(string attributesXml)
        {
            return _customerAttributeParser.GetAttributeWarnings(attributesXml);
        }

        #endregion

        #endregion
    }
}
