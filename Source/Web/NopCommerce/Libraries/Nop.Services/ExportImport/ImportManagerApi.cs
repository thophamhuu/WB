using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.ExportImport
{
    public partial class ImportManagerApi : IImportManager
    {
        #region Methods

        /// <summary>
        /// Import products from XLSX file
        /// </summary>
        /// <param name="stream">Stream</param>
        public virtual void ImportProductsFromXlsx(Stream stream)
        {
            APIHelper.Instance.PostAsync("ExportImport", "ImportProductsFromXlsx", stream);
        }

        /// <summary>
        /// Import newsletter subscribers from TXT file
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <returns>Number of imported subscribers</returns>
        public virtual int ImportNewsletterSubscribersFromTxt(Stream stream)
        {
            return APIHelper.Instance.PostAsync<int>("ExportImport", "ImportNewsletterSubscribersFromTxt", stream);
        }

        /// <summary>
        /// Import states from TXT file
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <returns>Number of imported states</returns>
        public virtual int ImportStatesFromTxt(Stream stream)
        {
            return APIHelper.Instance.PostAsync<int>("ExportImport", "ImportStatesFromTxt", stream);
        }

        /// <summary>
        /// Import manufacturers from XLSX file
        /// </summary>
        /// <param name="stream">Stream</param>
        public virtual void ImportManufacturersFromXlsx(Stream stream)
        {
            APIHelper.Instance.PostAsync("ExportImport", "ImportManufacturersFromXlsx", stream);
        }

        /// <summary>
        /// Import categories from XLSX file
        /// </summary>
        /// <param name="stream">Stream</param>
        public virtual void ImportCategoriesFromXlsx(Stream stream)
        {
            APIHelper.Instance.PostAsync("ExportImport", "ImportCategoriesFromXlsx", stream);
        }

        #endregion
    }
}
