using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Security
{
    public partial class PermissionApiService : IPermissionService
    {
        #region Methods

        /// <summary>
        /// Delete a permission
        /// </summary>
        /// <param name="permission">Permission</param>
        public virtual void DeletePermissionRecord(PermissionRecord permission)
        {
            APIHelper.Instance.PostAsync("Security", "DeletePermissionRecord", permission);
        }

        /// <summary>
        /// Gets a permission
        /// </summary>
        /// <param name="permissionId">Permission identifier</param>
        /// <returns>Permission</returns>
        public virtual PermissionRecord GetPermissionRecordById(int permissionId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("permissionId", permissionId);
            return APIHelper.Instance.GetAsync<PermissionRecord>("Security", "GetPermissionRecordById", parameters);
        }

        /// <summary>
        /// Gets a permission
        /// </summary>
        /// <param name="systemName">Permission system name</param>
        /// <returns>Permission</returns>
        public virtual PermissionRecord GetPermissionRecordBySystemName(string systemName)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("systemName", systemName);
            return APIHelper.Instance.GetAsync<PermissionRecord>("Security", "GetPermissionRecordBySystemName", parameters);
        }

        /// <summary>
        /// Gets all permissions
        /// </summary>
        /// <returns>Permissions</returns>
        public virtual IList<PermissionRecord> GetAllPermissionRecords()
        {
            return APIHelper.Instance.GetListAsync<PermissionRecord>("Security", "GetAllPermissionRecords", null);
        }

        /// <summary>
        /// Inserts a permission
        /// </summary>
        /// <param name="permission">Permission</param>
        public virtual void InsertPermissionRecord(PermissionRecord permission)
        {
            APIHelper.Instance.PostAsync("Security", "InsertPermissionRecord", permission);
        }

        /// <summary>
        /// Updates the permission
        /// </summary>
        /// <param name="permission">Permission</param>
        public virtual void UpdatePermissionRecord(PermissionRecord permission)
        {
            APIHelper.Instance.PostAsync("Security", "UpdatePermissionRecord", permission);
        }

        /// <summary>
        /// Install permissions
        /// </summary>
        /// <param name="permissionProvider">Permission provider</param>
        public virtual void InstallPermissions(IPermissionProvider permissionProvider)
        {
            APIHelper.Instance.PostAsync("Security", "InstallPermissions", permissionProvider);
        }

        /// <summary>
        /// Uninstall permissions
        /// </summary>
        /// <param name="permissionProvider">Permission provider</param>
        public virtual void UninstallPermissions(IPermissionProvider permissionProvider)
        {
            APIHelper.Instance.PostAsync("Security", "UninstallPermissions", permissionProvider);
        }

        /// <summary>
        /// Authorize permission
        /// </summary>
        /// <param name="permission">Permission record</param>
        /// <returns>true - authorized; otherwise, false</returns>
        public virtual bool Authorize(PermissionRecord permission)
        {
           return APIHelper.Instance.PostAsync<bool>("Security", "Authorize", permission);
        }

        /// <summary>
        /// Authorize permission
        /// </summary>
        /// <param name="permission">Permission record</param>
        /// <param name="customer">Customer</param>
        /// <returns>true - authorized; otherwise, false</returns>
        public virtual bool Authorize(PermissionRecord permission, Customer customer)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("permission", permission);
            parameters.Add("customer", customer);
            return APIHelper.Instance.PostAsync<bool>("Security", "Authorize", parameters);
        }

        /// <summary>
        /// Authorize permission
        /// </summary>
        /// <param name="permissionRecordSystemName">Permission record system name</param>
        /// <returns>true - authorized; otherwise, false</returns>
        public virtual bool Authorize(string permissionRecordSystemName)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("permissionRecordSystemName", permissionRecordSystemName);
            return APIHelper.Instance.PostAsync<bool>("Security", "Authorize", parameters);
        }

        /// <summary>
        /// Authorize permission
        /// </summary>
        /// <param name="permissionRecordSystemName">Permission record system name</param>
        /// <param name="customer">Customer</param>
        /// <returns>true - authorized; otherwise, false</returns>
        public virtual bool Authorize(string permissionRecordSystemName, Customer customer)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("permissionRecordSystemName", permissionRecordSystemName);
            return APIHelper.Instance.PostAsync<bool>("Security", "Authorize", customer, parameters);
        }

        #endregion
    }
}
