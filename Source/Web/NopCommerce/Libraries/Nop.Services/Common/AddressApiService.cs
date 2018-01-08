using Nop.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Common
{
    public partial class AddressApiService : IAddressService
    {
        #region Methods

        /// <summary>
        /// Deletes an address
        /// </summary>
        /// <param name="address">Address</param>
        public virtual void DeleteAddress(Address address)
        {
            APIHelper.Instance.PostAsync("Common", "DeleteAddress", address);
        }

        /// <summary>
        /// Gets total number of addresses by country identifier
        /// </summary>
        /// <param name="countryId">Country identifier</param>
        /// <returns>Number of addresses</returns>
        public virtual int GetAddressTotalByCountryId(int countryId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("countryId", countryId);
            return APIHelper.Instance.GetAsync<int>("Common", "GetAddressTotalByCountryId", parameters);
        }

        /// <summary>
        /// Gets total number of addresses by state/province identifier
        /// </summary>
        /// <param name="stateProvinceId">State/province identifier</param>
        /// <returns>Number of addresses</returns>
        public virtual int GetAddressTotalByStateProvinceId(int stateProvinceId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("stateProvinceId", stateProvinceId);
            return APIHelper.Instance.GetAsync<int>("Common", "GetAddressTotalByStateProvinceId", parameters);
        }

        /// <summary>
        /// Gets an address by address identifier
        /// </summary>
        /// <param name="addressId">Address identifier</param>
        /// <returns>Address</returns>
        public virtual Address GetAddressById(int addressId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("addressId", addressId);
            return APIHelper.Instance.GetAsync<Address>("Common", "GetAddressById", parameters);
        }

        /// <summary>
        /// Inserts an address
        /// </summary>
        /// <param name="address">Address</param>
        public virtual void InsertAddress(Address address)
        {
            APIHelper.Instance.PostAsync("Common", "InsertAddress", address);
        }

        /// <summary>
        /// Updates the address
        /// </summary>
        /// <param name="address">Address</param>
        public virtual void UpdateAddress(Address address)
        {
            APIHelper.Instance.PostAsync("Common", "UpdateAddress", address);
        }

        /// <summary>
        /// Gets a value indicating whether address is valid (can be saved)
        /// </summary>
        /// <param name="address">Address to validate</param>
        /// <returns>Result</returns>
        public virtual bool IsAddressValid(Address address)
        {
            return APIHelper.Instance.PostAsync<bool>("Common", "IsAddressValid", address);
        }

        #endregion
    }
}
