using Nop.Core;
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
            parameters.Add("entity", entity);
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
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("entity", entity);
            return APIHelper.Instance.GetAsync<bool>("Security", "Authorize", parameters);
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
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("entity", entity);
            parameters.Add("customer", customer);
            return APIHelper.Instance.GetAsync<bool>("Security", "Authorize", parameters);
        }
        #endregion
    }
}
