using Nop.Core.Domain.Customers;
using Nop.Services.Authentication;
using Nop.Services.Authentication.External;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nop.Api.Controllers
{
    public class AuthenticationController : ApiController
    {
        #region Fields

        private readonly IAuthenticationService _authenticationService;
        private readonly IOpenAuthenticationService _openAuthenticationService;

        #endregion

        #region Ctor

        public AuthenticationController(IAuthenticationService authenticationService, IOpenAuthenticationService openAuthenticationService)
        {
            this._authenticationService = authenticationService;
            this._openAuthenticationService = openAuthenticationService;
        }

        #endregion

        #region Method

        #region Authentication

        /// <summary>
        /// Sign in
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="createPersistentCookie">A value indicating whether to create a persistent cookie</param>
        public void SignIn(Customer customer, bool createPersistentCookie)
        {
            _authenticationService.SignIn(customer, createPersistentCookie);
        }

        /// <summary>
        /// Sign out
        /// </summary>
        public void SignOut()
        {
            _authenticationService.SignOut();
        }

        /// <summary>
        /// Get authenticated customer
        /// </summary>
        /// <returns>Customer</returns>
        public Customer GetAuthenticatedCustomer()
        {
            return _authenticationService.GetAuthenticatedCustomer();
        }

        #endregion

        #region Open authentication

        #region External authentication methods

        /// <summary>
        /// Load active external authentication methods
        /// </summary>
        /// <param name="customer">Load records allowed only to a specified customer; pass null to ignore ACL permissions</param>
        /// <param name="storeId">Load records allowed only in a specified store; pass 0 to load all records</param>
        /// <returns>Payment methods</returns>
        public IList<IExternalAuthenticationMethod> LoadActiveExternalAuthenticationMethods(Customer customer = null, int storeId = 0)
        {
            return _openAuthenticationService.LoadActiveExternalAuthenticationMethods(customer, storeId);
        }

        /// <summary>
        /// Load external authentication method by system name
        /// </summary>
        /// <param name="systemName">System name</param>
        /// <returns>Found external authentication method</returns>
        public IExternalAuthenticationMethod LoadExternalAuthenticationMethodBySystemName(string systemName)
        {
            return _openAuthenticationService.LoadExternalAuthenticationMethodBySystemName(systemName);
        }

        /// <summary>
        /// Load all external authentication methods
        /// </summary>
        /// <param name="customer">Load records allowed only to a specified customer; pass null to ignore ACL permissions</param>
        /// <param name="storeId">Load records allowed only in a specified store; pass 0 to load all records</param>
        /// <returns>External authentication methods</returns>
        public IList<IExternalAuthenticationMethod> LoadAllExternalAuthenticationMethods(Customer customer = null, int storeId = 0)
        {
            return _openAuthenticationService.LoadAllExternalAuthenticationMethods(customer, storeId);
        }

        #endregion

        /// <summary>
        /// Accociate external account with customer
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="parameters">Open authentication parameters</param>
        public void AssociateExternalAccountWithUser(Customer customer, OpenAuthenticationParameters parameters)
        {
            _openAuthenticationService.AssociateExternalAccountWithUser(customer, parameters);
        }

        /// <summary>
        /// Check that account exists
        /// </summary>
        /// <param name="parameters">Open authentication parameters</param>
        /// <returns>True if it exists; otherwise false</returns>
        public bool AccountExists(OpenAuthenticationParameters parameters)
        {
            return _openAuthenticationService.AccountExists(parameters);
        }

        /// <summary>
        /// Get the particular user with specified parameters
        /// </summary>
        /// <param name="parameters">Open authentication parameters</param>
        /// <returns>Customer</returns>
        public Customer GetUser(OpenAuthenticationParameters parameters)
        {
            return _openAuthenticationService.GetUser(parameters);
        }

        /// <summary>
        /// Get external authentication records for the specified customer
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <returns>List of external authentication records</returns>
        public IList<ExternalAuthenticationRecord> GetExternalIdentifiersFor(Customer customer)
        {
            return _openAuthenticationService.GetExternalIdentifiersFor(customer);
        }

        /// <summary>
        /// Delete the external authentication record
        /// </summary>
        /// <param name="externalAuthenticationRecord">External authentication record</param>
        public void DeleteExternalAuthenticationRecord(ExternalAuthenticationRecord externalAuthenticationRecord)
        {
            _openAuthenticationService.DeleteExternalAuthenticationRecord(externalAuthenticationRecord);
        }

        /// <summary>
        /// Remove the association
        /// </summary>
        /// <param name="parameters">Open authentication parameters</param>
        public void RemoveAssociation(OpenAuthenticationParameters parameters)
        {
            _openAuthenticationService.RemoveAssociation(parameters);
        }

        #endregion

        #endregion
    }
}
