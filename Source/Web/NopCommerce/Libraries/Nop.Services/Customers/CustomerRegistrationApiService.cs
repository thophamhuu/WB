using System;
using System.Linq;
using Nop.Core;
using Nop.Core.Domain.Customers;
using Nop.Services.Common;
using Nop.Services.Events;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Orders;
using Nop.Services.Security;
using Nop.Services.Stores;
using System.Collections.Generic;

namespace Nop.Services.Customers
{
    /// <summary>
    /// Customer registration service
    /// </summary>
    public partial class CustomerRegistrationApiService : ICustomerRegistrationService
    {     

        #region Methods

        /// <summary>
        /// Validate customer
        /// </summary>
        /// <param name="usernameOrEmail">Username or email</param>
        /// <param name="password">Password</param>
        /// <returns>Result</returns>
        public virtual CustomerLoginResults ValidateCustomer(string usernameOrEmail, string password)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("usernameOrEmail", usernameOrEmail);
            parameters.Add("password", password);
            return APIHelper.Instance.GetAsync<CustomerLoginResults>("Customers", "ValidateCustomer", parameters);
        }

        /// <summary>
        /// Register customer
        /// </summary>
        /// <param name="request">Request</param>
        /// <returns>Result</returns>
        public virtual CustomerRegistrationResult RegisterCustomer(CustomerRegistrationRequest request)
        {
            return APIHelper.Instance.PostAsync<CustomerRegistrationResult>("Customers", "RegisterCustomer", request);
        }
        
        /// <summary>
        /// Change password
        /// </summary>
        /// <param name="request">Request</param>
        /// <returns>Result</returns>
        public virtual ChangePasswordResult ChangePassword(ChangePasswordRequest request)
        {
            return APIHelper.Instance.PostAsync<ChangePasswordResult>("Customers", "ChangePassword", request);
        }

        /// <summary>
        /// Sets a user email
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="newEmail">New email</param>
        /// <param name="requireValidation">Require validation of new email address</param>
        public virtual void SetEmail(Customer customer, string newEmail, bool requireValidation)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("newEmail", newEmail);
            parameters.Add("requireValidation", requireValidation);
            APIHelper.Instance.PostAsync("Customers", "SetEmail", customer, parameters);
        }

        /// <summary>
        /// Sets a customer username
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="newUsername">New Username</param>
        public virtual void SetUsername(Customer customer, string newUsername)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("newUsername", newUsername);
            APIHelper.Instance.PostAsync("Customers", "SetUsername", customer, parameters);
        }

        #endregion
    }
}