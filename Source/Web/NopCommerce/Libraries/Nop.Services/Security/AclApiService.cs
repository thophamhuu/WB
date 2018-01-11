using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Security
{
    public partial class AclApiService : IAclService
    {
        #region Constants

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : entity ID
        /// {1} : entity name
        /// </remarks>
        private const string ACLRECORD_BY_ENTITYID_NAME_KEY = "Nop.aclrecord.entityid-name-{0}-{1}";
        /// <summary>
        /// Key pattern to clear cache
        /// </summary>
        private const string ACLRECORD_PATTERN_KEY = "Nop.aclrecord.";

        #endregion

        #region Fields

        private readonly IWorkContext _workContext;
        private readonly CatalogSettings _catalogSettings;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="cacheManager">Cache manager</param>
        /// <param name="workContext">Work context</param>
        /// <param name="aclRecordRepository">ACL record repository</param>
        /// <param name="catalogSettings">Catalog settings</param>
        /// <param name="eventPublisher">Event publisher</param>
        public AclApiService(IWorkContext workContext, CatalogSettings catalogSettings)
        {
            this._workContext = workContext;
            this._catalogSettings = catalogSettings;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Deletes an ACL record
        /// </summary>
        /// <param name="aclRecord">ACL record</param>
        public virtual void DeleteAclRecord(AclRecord aclRecord)
        {
            APIHelper.Instance.PostAsync("Security", "DeleteAclRecord", aclRecord);
        }

        /// <summary>
        /// Gets an ACL record
        /// </summary>
        /// <param name="aclRecordId">ACL record identifier</param>
        /// <returns>ACL record</returns>
        public virtual AclRecord GetAclRecordById(int aclRecordId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("aclRecordId", aclRecordId);
            return APIHelper.Instance.GetAsync<AclRecord>("Security", "GetAclRecordById", parameters);
        }

        /// <summary>
        /// Gets ACL records
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="entity">Entity</param>
        /// <returns>ACL records</returns>
        public virtual IList<AclRecord> GetAclRecords<T>(T entity) where T : BaseEntity, IAclSupported
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("entityName", typeof(T).Name);
            parameters.Add("entityId", entity.Id);
            return APIHelper.Instance.GetListAsync<AclRecord>("Security", "GetAclRecords", parameters);
        }


        /// <summary>
        /// Inserts an ACL record
        /// </summary>
        /// <param name="aclRecord">ACL record</param>
        public virtual void InsertAclRecord(AclRecord aclRecord)
        {
            APIHelper.Instance.PostAsync("Security", "InsertAclRecord", aclRecord);
        }

        /// <summary>
        /// Inserts an ACL record
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="customerRoleId">Customer role id</param>
        /// <param name="entity">Entity</param>
        public virtual void InsertAclRecord<T>(T entity, int customerRoleId) where T : BaseEntity, IAclSupported
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customerRoleId", customerRoleId);
            APIHelper.Instance.PostAsync("Security", "InsertAclRecord", entity, parameters);
        }

        /// <summary>
        /// Updates the ACL record
        /// </summary>
        /// <param name="aclRecord">ACL record</param>
        public virtual void UpdateAclRecord(AclRecord aclRecord)
        {
            APIHelper.Instance.PostAsync("Security", "UpdateAclRecord", aclRecord);
        }

        /// <summary>
        /// Find customer role identifiers with granted access
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="entity">Wntity</param>
        /// <returns>Customer role identifiers</returns>
        public virtual int[] GetCustomerRoleIdsWithAccess<T>(T entity) where T : BaseEntity, IAclSupported
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("entity", entity);
            return APIHelper.Instance.GetAsync<int[]>("Security", "GetCustomerRoleIdsWithAccess", parameters);
        }

        /// <summary>
        /// Authorize ACL permission
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="entity">Wntity</param>
        /// <returns>true - authorized; otherwise, false</returns>
        public virtual bool Authorize<T>(T entity) where T : BaseEntity, IAclSupported
        {
            return Authorize(entity, _workContext.CurrentCustomer);
        }

        /// <summary>
        /// Authorize ACL permission
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="entity">Wntity</param>
        /// <param name="customer">Customer</param>
        /// <returns>true - authorized; otherwise, false</returns>
        public virtual bool Authorize<T>(T entity, Customer customer) where T : BaseEntity, IAclSupported
        {
            if (entity == null)
                return false;

            if (customer == null)
                return false;

            if (_catalogSettings.IgnoreAcl)
                return true;

            if (!entity.SubjectToAcl)
                return true;

            foreach (var role1 in customer.CustomerRoles.Where(cr => cr.Active))
                foreach (var role2Id in GetCustomerRoleIdsWithAccess(entity))
                    if (role1.Id == role2Id)
                        //yes, we have such permission
                        return true;

            //no permission found
            return false;
        }
        #endregion
    }
}
