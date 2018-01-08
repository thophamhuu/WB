using Nop.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Common
{
    public partial class AddressAttributeApiService : IAddressAttributeService
    {
        #region Methods

        /// <summary>
        /// Deletes an address attribute
        /// </summary>
        /// <param name="addressAttribute">Address attribute</param>
        public virtual void DeleteAddressAttribute(AddressAttribute addressAttribute)
        {
            APIHelper.Instance.PostAsync("Common", "DeleteAddressAttribute", addressAttribute);
        }

        /// <summary>
        /// Gets all address attributes
        /// </summary>
        /// <returns>Address attributes</returns>
        public virtual IList<AddressAttribute> GetAllAddressAttributes()
        {
            return APIHelper.Instance.GetListAsync<AddressAttribute>("Common", "GetAllAddressAttributes", null);
        }

        /// <summary>
        /// Gets an address attribute 
        /// </summary>
        /// <param name="addressAttributeId">Address attribute identifier</param>
        /// <returns>Address attribute</returns>
        public virtual AddressAttribute GetAddressAttributeById(int addressAttributeId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("addressAttributeId", addressAttributeId);
            return APIHelper.Instance.GetAsync<AddressAttribute>("Common", "GetAddressAttributeById", parameters);
        }

        /// <summary>
        /// Inserts an address attribute
        /// </summary>
        /// <param name="addressAttribute">Address attribute</param>
        public virtual void InsertAddressAttribute(AddressAttribute addressAttribute)
        {
            APIHelper.Instance.PostAsync("Common", "InsertAddressAttribute", addressAttribute);
        }

        /// <summary>
        /// Updates the address attribute
        /// </summary>
        /// <param name="addressAttribute">Address attribute</param>
        public virtual void UpdateAddressAttribute(AddressAttribute addressAttribute)
        {
            APIHelper.Instance.PostAsync("Common", "UpdateAddressAttribute", addressAttribute);
        }

        /// <summary>
        /// Deletes an address attribute value
        /// </summary>
        /// <param name="addressAttributeValue">Address attribute value</param>
        public virtual void DeleteAddressAttributeValue(AddressAttributeValue addressAttributeValue)
        {
            APIHelper.Instance.PostAsync("Common", "DeleteAddressAttributeValue", addressAttributeValue);
        }

        /// <summary>
        /// Gets address attribute values by address attribute identifier
        /// </summary>
        /// <param name="addressAttributeId">The address attribute identifier</param>
        /// <returns>Address attribute values</returns>
        public virtual IList<AddressAttributeValue> GetAddressAttributeValues(int addressAttributeId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("addressAttributeId", addressAttributeId);
            return APIHelper.Instance.GetListAsync<AddressAttributeValue>("Common", "GetAddressAttributeValues", parameters);
        }

        /// <summary>
        /// Gets an address attribute value
        /// </summary>
        /// <param name="addressAttributeValueId">Address attribute value identifier</param>
        /// <returns>Address attribute value</returns>
        public virtual AddressAttributeValue GetAddressAttributeValueById(int addressAttributeValueId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("addressAttributeValueId", addressAttributeValueId);
            return APIHelper.Instance.GetAsync<AddressAttributeValue>("Common", "GetAddressAttributeValueById", parameters);
        }

        /// <summary>
        /// Inserts an address attribute value
        /// </summary>
        /// <param name="addressAttributeValue">Address attribute value</param>
        public virtual void InsertAddressAttributeValue(AddressAttributeValue addressAttributeValue)
        {
            APIHelper.Instance.PostAsync("Common", "InsertAddressAttributeValue", addressAttributeValue);
        }

        /// <summary>
        /// Updates the address attribute value
        /// </summary>
        /// <param name="addressAttributeValue">Address attribute value</param>
        public virtual void UpdateAddressAttributeValue(AddressAttributeValue addressAttributeValue)
        {
            APIHelper.Instance.PostAsync("Common", "UpdateAddressAttributeValue", addressAttributeValue);
        }

        #endregion
    }
}
