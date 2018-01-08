using Nop.Core.Domain.Media;
using Nop.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Media
{
    public partial class DownloadApiService : IDownloadService
    {
        #region Methods

        /// <summary>
        /// Gets a download
        /// </summary>
        /// <param name="downloadId">Download identifier</param>
        /// <returns>Download</returns>
        public virtual Download GetDownloadById(int downloadId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("downloadId", downloadId);
            return APIHelper.Instance.GetAsync<Download>("Media", "GetDownloadById", parameters);
        }

        /// <summary>
        /// Gets a download by GUID
        /// </summary>
        /// <param name="downloadGuid">Download GUID</param>
        /// <returns>Download</returns>
        public virtual Download GetDownloadByGuid(Guid downloadGuid)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("downloadGuid", downloadGuid);
            return APIHelper.Instance.GetAsync<Download>("Media", "GetDownloadByGuid", parameters);
        }

        /// <summary>
        /// Deletes a download
        /// </summary>
        /// <param name="download">Download</param>
        public virtual void DeleteDownload(Download download)
        {
            APIHelper.Instance.PostAsync("Media", "DeleteDownload", download);
        }

        /// <summary>
        /// Inserts a download
        /// </summary>
        /// <param name="download">Download</param>
        public virtual void InsertDownload(Download download)
        {
            APIHelper.Instance.PostAsync("Media", "InsertDownload", download);
        }

        /// <summary>
        /// Updates the download
        /// </summary>
        /// <param name="download">Download</param>
        public virtual void UpdateDownload(Download download)
        {
            APIHelper.Instance.PostAsync("Media", "UpdateDownload", download);
        }

        /// <summary>
        /// Gets a value indicating whether download is allowed
        /// </summary>
        /// <param name="orderItem">Order item to check</param>
        /// <returns>True if download is allowed; otherwise, false.</returns>
        public virtual bool IsDownloadAllowed(OrderItem orderItem)
        {
            return APIHelper.Instance.PostAsync<bool>("Media", "IsDownloadAllowed", orderItem);
        }

        /// <summary>
        /// Gets a value indicating whether license download is allowed
        /// </summary>
        /// <param name="orderItem">Order item to check</param>
        /// <returns>True if license download is allowed; otherwise, false.</returns>
        public virtual bool IsLicenseDownloadAllowed(OrderItem orderItem)
        {
            return APIHelper.Instance.PostAsync<bool>("Media", "IsLicenseDownloadAllowed", orderItem);
        }

        #endregion
    }
}
