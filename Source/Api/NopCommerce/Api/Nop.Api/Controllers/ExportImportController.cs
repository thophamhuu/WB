using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Messages;
using Nop.Core.Domain.Orders;
using Nop.Services.ExportImport;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nop.Api.Controllers
{
    [Authorize]
    public class ExportImportController : ApiController
    {
        #region Fields

        private readonly IExportManager _exportManager;
        private readonly IImportManager _importManager;

        #endregion

        #region Ctor

        public ExportImportController(IExportManager exportManager, IImportManager importManager)
        {
            this._exportManager = exportManager;
            this._importManager = importManager;
        }

        #endregion

        #region Method

        #region Export manager

        /// <summary>
        /// Export manufacturer list to xml
        /// </summary>
        /// <param name="manufacturers">Manufacturers</param>
        /// <returns>Result in XML format</returns>
        public string ExportManufacturersToXml(IList<Manufacturer> manufacturers)
        {
            return _exportManager.ExportManufacturersToXml(manufacturers);
        }

        /// <summary>
        /// Export manufacturers to XLSX
        /// </summary>
        /// <param name="manufacturers">Manufactures</param>
        public byte[] ExportManufacturersToXlsx(IEnumerable<Manufacturer> manufacturers)
        {
            return _exportManager.ExportManufacturersToXlsx(manufacturers);
        }

        /// <summary>
        /// Export category list to xml
        /// </summary>
        /// <returns>Result in XML format</returns>
        public string ExportCategoriesToXml()
        {
            return _exportManager.ExportCategoriesToXml();
        }

        /// <summary>
        /// Export categories to XLSX
        /// </summary>
        /// <param name="categories">Categories</param>
        public byte[] ExportCategoriesToXlsx(IEnumerable<Category> categories)
        {
            return _exportManager.ExportCategoriesToXlsx(categories);
        }

        /// <summary>
        /// Export product list to xml
        /// </summary>
        /// <param name="products">Products</param>
        /// <returns>Result in XML format</returns>
        public string ExportProductsToXml(IList<Product> products)
        {
            return _exportManager.ExportProductsToXml(products);
        }

        /// <summary>
        /// Export products to XLSX
        /// </summary>
        /// <param name="products">Products</param>
        public byte[] ExportProductsToXlsx(IEnumerable<Product> products)
        {
            return _exportManager.ExportProductsToXlsx(products);
        }

        /// <summary>
        /// Export order list to xml
        /// </summary>
        /// <param name="orders">Orders</param>
        /// <returns>Result in XML format</returns>
        public string ExportOrdersToXml(IList<Order> orders)
        {
            return _exportManager.ExportOrdersToXml(orders);
        }

        /// <summary>
        /// Export orders to XLSX
        /// </summary>
        /// <param name="orders">Orders</param>
        public byte[] ExportOrdersToXlsx(IList<Order> orders)
        {
            return _exportManager.ExportOrdersToXlsx(orders);
        }

        /// <summary>
        /// Export customer list to XLSX
        /// </summary>
        /// <param name="customers">Customers</param>
        public byte[] ExportCustomersToXlsx(IList<Customer> customers)
        {
            return _exportManager.ExportCustomersToXlsx(customers);
        }

        /// <summary>
        /// Export customer list to xml
        /// </summary>
        /// <param name="customers">Customers</param>
        /// <returns>Result in XML format</returns>
        public string ExportCustomersToXml(IList<Customer> customers)
        {
            return _exportManager.ExportCustomersToXml(customers);
        }

        /// <summary>
        /// Export newsletter subscribers to TXT
        /// </summary>
        /// <param name="subscriptions">Subscriptions</param>
        /// <returns>Result in TXT (string) format</returns>
        public string ExportNewsletterSubscribersToTxt(IList<NewsLetterSubscription> subscriptions)
        {
            return _exportManager.ExportNewsletterSubscribersToTxt(subscriptions);
        }

        /// <summary>
        /// Export states to TXT
        /// </summary>
        /// <param name="states">States</param>
        /// <returns>Result in TXT (string) format</returns>
        public string ExportStatesToTxt(IList<StateProvince> states)
        {
            return _exportManager.ExportStatesToTxt(states);
        }

        #endregion

        #region Import manager

        /// <summary>
        /// Import products from XLSX file
        /// </summary>
        /// <param name="stream">Stream</param>
        public void ImportProductsFromXlsx(Stream stream)
        {
            _importManager.ImportProductsFromXlsx(stream);
        }

        /// <summary>
        /// Import newsletter subscribers from TXT file
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <returns>Number of imported subscribers</returns>
        public int ImportNewsletterSubscribersFromTxt(Stream stream)
        {
            return _importManager.ImportNewsletterSubscribersFromTxt(stream);
        }

        /// <summary>
        /// Import states from TXT file
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <returns>Number of imported states</returns>
        public int ImportStatesFromTxt(Stream stream)
        {
            return _importManager.ImportStatesFromTxt(stream);
        }

        /// <summary>
        /// Import manufacturers from XLSX file
        /// </summary>
        /// <param name="stream">Stream</param>
        public void ImportManufacturersFromXlsx(Stream stream)
        {
            _importManager.ImportManufacturersFromXlsx(stream);
        }

        /// <summary>
        /// Import categories from XLSX file
        /// </summary>
        /// <param name="stream">Stream</param>
        public void ImportCategoriesFromXlsx(Stream stream)
        {
            _importManager.ImportCategoriesFromXlsx(stream);
        }

        #endregion

        #endregion
    }
}
