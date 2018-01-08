using Nop.Core.Domain.Directory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Directory
{
    public partial class StateProvinceApiService : IStateProvinceService
    {
        #region Methods
        /// <summary>
        /// Deletes a state/province
        /// </summary>
        /// <param name="stateProvince">The state/province</param>
        public virtual void DeleteStateProvince(StateProvince stateProvince)
        {
            APIHelper.Instance.PostAsync("Directory", "DeleteStateProvince", stateProvince);
        }

        /// <summary>
        /// Gets a state/province
        /// </summary>
        /// <param name="stateProvinceId">The state/province identifier</param>
        /// <returns>State/province</returns>
        public virtual StateProvince GetStateProvinceById(int stateProvinceId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("stateProvinceId", stateProvinceId);
            return APIHelper.Instance.GetAsync<StateProvince>("Directory", "GetStateProvinceById", parameters);
        }

        /// <summary>
        /// Gets a state/province 
        /// </summary>
        /// <param name="abbreviation">The state/province abbreviation</param>
        /// <returns>State/province</returns>
        public virtual StateProvince GetStateProvinceByAbbreviation(string abbreviation)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("abbreviation", abbreviation);
            return APIHelper.Instance.GetAsync<StateProvince>("Directory", "GetStateProvinceByAbbreviation", parameters);
        }

        /// <summary>
        /// Gets a state/province collection by country identifier
        /// </summary>
        /// <param name="countryId">Country identifier</param>
        /// <param name="languageId">Language identifier. It's used to sort states by localized names (if specified); pass 0 to skip it</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>States</returns>
        public virtual IList<StateProvince> GetStateProvincesByCountryId(int countryId, int languageId = 0, bool showHidden = false)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("countryId", countryId);
            parameters.Add("languageId", languageId);
            parameters.Add("showHidden", showHidden);
            return APIHelper.Instance.GetListAsync<StateProvince>("Directory", "GetStateProvincesByCountryId", parameters);
        }

        /// <summary>
        /// Gets all states/provinces
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>States</returns>
        public virtual IList<StateProvince> GetStateProvinces(bool showHidden = false)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("showHidden", showHidden);
            return APIHelper.Instance.GetListAsync<StateProvince>("Directory", "GetStateProvinces", parameters);
        }

        /// <summary>
        /// Inserts a state/province
        /// </summary>
        /// <param name="stateProvince">State/province</param>
        public virtual void InsertStateProvince(StateProvince stateProvince)
        {
            APIHelper.Instance.PostAsync("Directory", "InsertStateProvince", stateProvince);
        }

        /// <summary>
        /// Updates a state/province
        /// </summary>
        /// <param name="stateProvince">State/province</param>
        public virtual void UpdateStateProvince(StateProvince stateProvince)
        {
            APIHelper.Instance.PostAsync("Directory", "UpdateStateProvince", stateProvince);
        }

        #endregion
    }
}
