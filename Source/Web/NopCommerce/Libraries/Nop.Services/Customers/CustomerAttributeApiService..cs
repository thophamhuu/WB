using System;
using System.Collections.Generic;
using System.Linq;
using Nop.Core.Caching;
using Nop.Core.Data;
using Nop.Core.Domain.Customers;
using Nop.Services.Events;

namespace Nop.Services.Customers
{
    /// <summary>
    /// Customer attribute service
    /// </summary>
    public partial class CustomerAttributeApiService : ICustomerAttributeService
    {       
        #region Methods

        /// <summary>
        /// Deletes a customer attribute
        /// </summary>
        /// <param name="customerAttribute">Customer attribute</param>
        public virtual void DeleteCustomerAttribute(CustomerAttribute customerAttribute)
        {
            APIHelper.Instance.PostAsync("Customers", "DeleteCustomerAttribute", customerAttribute);
        }

        /// <summary>
        /// Gets all customer attributes
        /// </summary>
        /// <returns>Customer attributes</returns>
        public virtual IList<CustomerAttribute> GetAllCustomerAttributes()
        {
            return APIHelper.Instance.GetListAsync<CustomerAttribute>("Customers", "GetAllCustomerAttributes", null);
        }

        /// <summary>
        /// Gets a customer attribute 
        /// </summary>
        /// <param name="customerAttributeId">Customer attribute identifier</param>
        /// <returns>Customer attribute</returns>
        public virtual CustomerAttribute GetCustomerAttributeById(int customerAttributeId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customerAttributeId", customerAttributeId);
            return APIHelper.Instance.GetAsync<CustomerAttribute>("Customers", "GetCustomerAttributeById", parameters);
        }

        /// <summary>
        /// Inserts a customer attribute
        /// </summary>
        /// <param name="customerAttribute">Customer attribute</param>
        public virtual void InsertCustomerAttribute(CustomerAttribute customerAttribute)
        {
            APIHelper.Instance.PostAsync("Customers", "InsertCustomerAttribute", customerAttribute);
        }

        /// <summary>
        /// Updates the customer attribute
        /// </summary>
        /// <param name="customerAttribute">Customer attribute</param>
        public virtual void UpdateCustomerAttribute(CustomerAttribute customerAttribute)
        {
            APIHelper.Instance.PostAsync("Customers", "UpdateCustomerAttribute", customerAttribute);
        }

        /// <summary>
        /// Deletes a customer attribute value
        /// </summary>
        /// <param name="customerAttributeValue">Customer attribute value</param>
        public virtual void DeleteCustomerAttributeValue(CustomerAttributeValue customerAttributeValue)
        {
            APIHelper.Instance.PostAsync("Customers", "DeleteCustomerAttributeValue", customerAttributeValue);
        }

        /// <summary>
        /// Gets customer attribute values by customer attribute identifier
        /// </summary>
        /// <param name="customerAttributeId">The customer attribute identifier</param>
        /// <returns>Customer attribute values</returns>
        public virtual IList<CustomerAttributeValue> GetCustomerAttributeValues(int customerAttributeId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customerAttributeId", customerAttributeId);
            return APIHelper.Instance.GetListAsync<CustomerAttributeValue>("Customers", "GetCustomerAttributeValues", parameters);
        }
        
        /// <summary>
        /// Gets a customer attribute value
        /// </summary>
        /// <param name="customerAttributeValueId">Customer attribute value identifier</param>
        /// <returns>Customer attribute value</returns>
        public virtual CustomerAttributeValue GetCustomerAttributeValueById(int customerAttributeValueId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customerAttributeValueId", customerAttributeValueId);
            return APIHelper.Instance.GetAsync<CustomerAttributeValue>("Customers", "GetCustomerAttributeValueById", parameters);
        }

        /// <summary>
        /// Inserts a customer attribute value
        /// </summary>
        /// <param name="customerAttributeValue">Customer attribute value</param>
        public virtual void InsertCustomerAttributeValue(CustomerAttributeValue customerAttributeValue)
        {
            APIHelper.Instance.PostAsync("Customers", "InsertCustomerAttributeValue", customerAttributeValue);
        }

        /// <summary>
        /// Updates the customer attribute value
        /// </summary>
        /// <param name="customerAttributeValue">Customer attribute value</param>
        public virtual void UpdateCustomerAttributeValue(CustomerAttributeValue customerAttributeValue)
        {
            APIHelper.Instance.PostAsync("Customers", "UpdateCustomerAttributeValue", customerAttributeValue);
        }
        
        #endregion
    }
}
