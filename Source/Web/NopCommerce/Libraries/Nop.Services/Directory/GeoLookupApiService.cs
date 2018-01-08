using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Directory
{
    public partial class GeoLookupApiService : IGeoLookupService
    {
        #region Methods
        /// <summary>
        /// Get country name
        /// </summary>
        /// <param name="ipAddress">IP address</param>
        /// <returns>Country name</returns>
        public virtual string LookupCountryIsoCode(string ipAddress)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("ipAddress", ipAddress);
            return APIHelper.Instance.GetAsync<string>("Directory", "LookupCountryIsoCode", parameters);
        }

        /// <summary>
        /// Get country name
        /// </summary>
        /// <param name="ipAddress">IP address</param>
        /// <returns>Country name</returns>
        public virtual string LookupCountryName(string ipAddress)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("ipAddress", ipAddress);
            return APIHelper.Instance.GetAsync<string>("Directory", "LookupCountryName", parameters);
        }

        #endregion
    }
}
