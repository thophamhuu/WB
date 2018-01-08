using Nop.Core;
using Nop.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Common
{
    public partial class GenericAttributeApiService : IGenericAttributeService
    {
        #region Methods

        /// <summary>
        /// Deletes an attribute
        /// </summary>
        /// <param name="attribute">Attribute</param>
        public virtual void DeleteAttribute(GenericAttribute attribute)
        {
            APIHelper.Instance.PostAsync("Common", "DeleteAttribute", attribute);
        }

        /// <summary>
        /// Deletes an attributes
        /// </summary>
        /// <param name="attributes">Attributes</param>
        public virtual void DeleteAttributes(IList<GenericAttribute> attributes)
        {
            APIHelper.Instance.PostAsync("Common", "DeleteAttributes", attributes);
        }

        /// <summary>
        /// Gets an attribute
        /// </summary>
        /// <param name="attributeId">Attribute identifier</param>
        /// <returns>An attribute</returns>
        public virtual GenericAttribute GetAttributeById(int attributeId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("attributeId", attributeId);
            return APIHelper.Instance.GetAsync<GenericAttribute>("Common", "GetAttributeById", parameters);
        }

        /// <summary>
        /// Inserts an attribute
        /// </summary>
        /// <param name="attribute">attribute</param>
        public virtual void InsertAttribute(GenericAttribute attribute)
        {
            APIHelper.Instance.PostAsync("Common", "InsertAttribute", attribute);
        }

        /// <summary>
        /// Updates the attribute
        /// </summary>
        /// <param name="attribute">Attribute</param>
        public virtual void UpdateAttribute(GenericAttribute attribute)
        {
            APIHelper.Instance.PostAsync("Common", "UpdateAttribute", attribute);
        }

        /// <summary>
        /// Get attributes
        /// </summary>
        /// <param name="entityId">Entity identifier</param>
        /// <param name="keyGroup">Key group</param>
        /// <returns>Get attributes</returns>
        public virtual IList<GenericAttribute> GetAttributesForEntity(int entityId, string keyGroup)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("entityId", entityId);
            parameters.Add("keyGroup", keyGroup);
            return APIHelper.Instance.GetListAsync<GenericAttribute>("Common", "GetAttributesForEntity", parameters);
        }

        /// <summary>
        /// Save attribute value
        /// </summary>
        /// <typeparam name="TPropType">Property type</typeparam>
        /// <param name="entity">Entity</param>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <param name="storeId">Store identifier; pass 0 if this attribute will be available for all stores</param>
        public virtual void SaveAttribute<TPropType>(BaseEntity entity, string key, TPropType value, int storeId = 0)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("key", key);
            parameters.Add("value", value);
            parameters.Add("storeId", storeId);
            APIHelper.Instance.PostAsync("Common", "SaveAttribute", entity, parameters);
        }

        #endregion
    }
}
