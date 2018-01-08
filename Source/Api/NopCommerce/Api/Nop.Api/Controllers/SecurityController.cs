using Nop.Core;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Security;
using Nop.Services.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nop.Api.Controllers
{
    [Authorize]
    public class SecurityController : ApiController
    {
        #region Fields

        private readonly IAclService _aclService;
        private readonly IEncryptionService _encryptionService;
        private readonly IPermissionService _permissionService;

        #endregion

        #region Ctor

        public SecurityController(IAclService aclService, IEncryptionService encryptionService, IPermissionService permissionService)
        {
            this._aclService = aclService;
            this._encryptionService = encryptionService;
            this._permissionService = permissionService;
        }

        #endregion

        #region Method

        #region ACL record

        /// <summary>
        /// Deletes an ACL record
        /// </summary>
        /// <param name="aclRecord">ACL record</param>
        public void DeleteAclRecord([FromBody]AclRecord aclRecord)
        {
            _aclService.DeleteAclRecord(aclRecord);
        }

        /// <summary>
        /// Gets an ACL record
        /// </summary>
        /// <param name="aclRecordId">ACL record identifier</param>
        /// <returns>ACL record</returns>
        public AclRecord GetAclRecordById(int aclRecordId)
        {
            return _aclService.GetAclRecordById(aclRecordId);
        }

        /// <summary>
        /// Gets ACL records
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="entity">Entity</param>
        /// <returns>ACL records</returns>
        public IList<AclRecord> GetAclRecords<T>(T entity) where T : BaseEntity, IAclSupported
        {
            return _aclService.GetAclRecords(entity);
        }

        /// <summary>
        /// Inserts an ACL record
        /// </summary>
        /// <param name="aclRecord">ACL record</param>
        public void InsertAclRecord([FromBody]AclRecord aclRecord)
        {
            _aclService.InsertAclRecord(aclRecord);
        }

        /// <summary>
        /// Inserts an ACL record
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="customerRoleId">Customer role id</param>
        /// <param name="entity">Entity</param>
        public void InsertAclRecord<T>(T entity, int customerRoleId) where T : BaseEntity, IAclSupported
        {
            _aclService.InsertAclRecord(entity, customerRoleId);
        }

        /// <summary>
        /// Updates the ACL record
        /// </summary>
        /// <param name="aclRecord">ACL record</param>
        public void UpdateAclRecord([FromBody]AclRecord aclRecord)
        {
            _aclService.UpdateAclRecord(aclRecord);
        }

        /// <summary>
        /// Find customer role identifiers with granted access
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="entity">Wntity</param>
        /// <returns>Customer role identifiers</returns>
        public int[] GetCustomerRoleIdsWithAccess<T>(T entity) where T : BaseEntity, IAclSupported
        {
            return _aclService.GetCustomerRoleIdsWithAccess(entity);
        }

        /// <summary>
        /// Authorize ACL permission
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="entity">Wntity</param>
        /// <returns>true - authorized; otherwise, false</returns>
        public bool Authorize<T>(T entity) where T : BaseEntity, IAclSupported
        {
            return _aclService.Authorize(entity);
        }

        /// <summary>
        /// Authorize ACL permission
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="entity">Wntity</param>
        /// <param name="customer">Customer</param>
        /// <returns>true - authorized; otherwise, false</returns>
        public bool Authorize<T>(T entity, Customer customer) where T : BaseEntity, IAclSupported
        {
            return _aclService.Authorize(entity, customer);
        }

        #endregion

        #region Encryption

        /// <summary>
        /// Create salt key
        /// </summary>
        /// <param name="size">Key size</param>
        /// <returns>Salt key</returns>
        public string CreateSaltKey(int size)
        {
            return _encryptionService.CreateSaltKey(size);
        }

        /// <summary>
        /// Create a password hash
        /// </summary>
        /// <param name="password">{assword</param>
        /// <param name="saltkey">Salk key</param>
        /// <param name="passwordFormat">Password format (hash algorithm)</param>
        /// <returns>Password hash</returns>
        public string CreatePasswordHash([FromBody]string password, [FromBody]string saltkey, [FromBody]string passwordFormat = "SHA1")
        {
            return _encryptionService.CreatePasswordHash(password, saltkey, passwordFormat);
        }

        /// <summary>
        /// Create a data hash
        /// </summary>
        /// <param name="data">The data for calculating the hash</param>
        /// <param name="hashAlgorithm">Hash algorithm</param>
        /// <returns>Data hash</returns>
        public string CreateHash(byte[] data, string hashAlgorithm = "SHA1")
        {
            return _encryptionService.CreateHash(data, hashAlgorithm);
        }

        /// <summary>
        /// Encrypt text
        /// </summary>
        /// <param name="plainText">Text to encrypt</param>
        /// <param name="encryptionPrivateKey">Encryption private key</param>
        /// <returns>Encrypted text</returns>
        public string EncryptText(string plainText, string encryptionPrivateKey = "")
        {
            return _encryptionService.EncryptText(plainText, encryptionPrivateKey);
        }

        /// <summary>
        /// Decrypt text
        /// </summary>
        /// <param name="cipherText">Text to decrypt</param>
        /// <param name="encryptionPrivateKey">Encryption private key</param>
        /// <returns>Decrypted text</returns>
        public string DecryptText(string cipherText, string encryptionPrivateKey = "")
        {
            return _encryptionService.DecryptText(cipherText, encryptionPrivateKey);
        }

        #endregion

        #region Permission

        /// <summary>
        /// Delete a permission
        /// </summary>
        /// <param name="permission">Permission</param>
        public void DeletePermissionRecord([FromBody]PermissionRecord permission)
        {
            _permissionService.DeletePermissionRecord(permission);
        }

        /// <summary>
        /// Gets a permission
        /// </summary>
        /// <param name="permissionId">Permission identifier</param>
        /// <returns>Permission</returns>
        public PermissionRecord GetPermissionRecordById(int permissionId)
        {
            return _permissionService.GetPermissionRecordById(permissionId);
        }

        /// <summary>
        /// Gets a permission
        /// </summary>
        /// <param name="systemName">Permission system name</param>
        /// <returns>Permission</returns>
        public PermissionRecord GetPermissionRecordBySystemName(string systemName)
        {
            return _permissionService.GetPermissionRecordBySystemName(systemName);
        }

        /// <summary>
        /// Gets all permissions
        /// </summary>
        /// <returns>Permissions</returns>
        public IList<PermissionRecord> GetAllPermissionRecords()
        {
            return _permissionService.GetAllPermissionRecords();
        }

        /// <summary>
        /// Inserts a permission
        /// </summary>
        /// <param name="permission">Permission</param>
        public void InsertPermissionRecord([FromBody]PermissionRecord permission)
        {
            _permissionService.InsertPermissionRecord(permission);
        }

        /// <summary>
        /// Updates the permission
        /// </summary>
        /// <param name="permission">Permission</param>
        public void UpdatePermissionRecord([FromBody]PermissionRecord permission)
        {
            _permissionService.UpdatePermissionRecord(permission);
        }

        /// <summary>
        /// Install permissions
        /// </summary>
        /// <param name="permissionProvider">Permission provider</param>
        public void InstallPermissions([FromBody]IPermissionProvider permissionProvider)
        {
            _permissionService.InstallPermissions(permissionProvider);
        }

        /// <summary>
        /// Uninstall permissions
        /// </summary>
        /// <param name="permissionProvider">Permission provider</param>
        public void UninstallPermissions([FromBody]IPermissionProvider permissionProvider)
        {
            _permissionService.UninstallPermissions(permissionProvider);
        }

        /// <summary>
        /// Authorize permission
        /// </summary>
        /// <param name="permission">Permission record</param>
        /// <returns>true - authorized; otherwise, false</returns>
        public bool Authorize([FromBody]PermissionRecord permission)
        {
            return _permissionService.Authorize(permission);
        }

        /// <summary>
        /// Authorize permission
        /// </summary>
        /// <param name="permission">Permission record</param>
        /// <param name="customer">Customer</param>
        /// <returns>true - authorized; otherwise, false</returns>
        public bool Authorize(PermissionRecord permission, Customer customer)
        {
            return _permissionService.Authorize(permission, customer);
        }

        /// <summary>
        /// Authorize permission
        /// </summary>
        /// <param name="permissionRecordSystemName">Permission record system name</param>
        /// <returns>true - authorized; otherwise, false</returns>
        public bool Authorize(string permissionRecordSystemName)
        {
            return _permissionService.Authorize(permissionRecordSystemName);
        }

        /// <summary>
        /// Authorize permission
        /// </summary>
        /// <param name="permissionRecordSystemName">Permission record system name</param>
        /// <param name="customer">Customer</param>
        /// <returns>true - authorized; otherwise, false</returns>
        public bool Authorize(string permissionRecordSystemName, Customer customer)
        {
            return _permissionService.Authorize(permissionRecordSystemName, customer);
        }

        #endregion

        #endregion
    }
}
