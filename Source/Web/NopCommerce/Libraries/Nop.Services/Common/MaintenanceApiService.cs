using Nop.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Common
{
    public partial class MaintenanceApiService : IMaintenanceService
    {
        #region Methods

        /// <summary>
        /// Get the current ident value
        /// </summary>
        /// <typeparam name="T">Entity</typeparam>
        /// <returns>Integer ident; null if cannot get the result</returns>
        public virtual int? GetTableIdent<T>() where T : BaseEntity
        {
            return APIHelper.Instance.GetAsync<int>("Common", "GetTableIdent", null);
        }

        /// <summary>
        /// Set table ident (is supported)
        /// </summary>
        /// <typeparam name="T">Entity</typeparam>
        /// <param name="ident">Ident value</param>
        public virtual void SetTableIdent<T>(int ident) where T : BaseEntity
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("ident", ident);
            APIHelper.Instance.PostAsync("Common", "SetTableIdent", parameters);
        }

        /// <summary>
        /// Gets all backup files
        /// </summary>
        /// <returns>Backup file collection</returns>
        public virtual IList<FileInfo> GetAllBackupFiles()
        {
            return APIHelper.Instance.GetListAsync<FileInfo>("Common", "GetAllBackupFiles", null);
        }

        /// <summary>
        /// Creates a backup of the database
        /// </summary>
        public virtual void BackupDatabase()
        {
            APIHelper.Instance.PostAsync("Common", "BackupDatabase", null);
        }

        /// <summary>
        /// Restores the database from a backup
        /// </summary>
        /// <param name="backupFileName">The name of the backup file</param>
        public virtual void RestoreDatabase(string backupFileName)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("backupFileName", backupFileName);
            APIHelper.Instance.PostAsync("Common", "RestoreDatabase", parameters);
        }

        /// <summary>
        /// Returns the path to the backup file
        /// </summary>
        /// <param name="backupFileName">The name of the backup file</param>
        /// <returns>The path to the backup file</returns>
        public virtual string GetBackupPath(string backupFileName)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("backupFileName", backupFileName);
            return APIHelper.Instance.GetAsync<string>("Common", "GetBackupPath", parameters);
        }

        #endregion
    }
}
