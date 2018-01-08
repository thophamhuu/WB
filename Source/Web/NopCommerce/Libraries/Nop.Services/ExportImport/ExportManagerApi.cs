using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Messages;
using Nop.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.ExportImport
{
    public partial class ExportManagerApi : IExportManager
    {
        #region Methods

        /// <summary>
        /// Export manufacturer list to xml
        /// </summary>
        /// <param name="manufacturers">Manufacturers</param>
        /// <returns>Result in XML format</returns>
        public virtual string ExportManufacturersToXml(IList<Manufacturer> manufacturers)
        {
            return APIHelper.Instance.PostAsync<string>("ExportImport", "ExportManufacturersToXml", manufacturers);
        }

        /// <summary>
        /// Export manufacturers to XLSX
        /// </summary>
        /// <param name="manufacturers">Manufactures</param>
        public virtual byte[] ExportManufacturersToXlsx(IEnumerable<Manufacturer> manufacturers)
        {
            return APIHelper.Instance.PostAsync<byte[]>("ExportImport", "ExportManufacturersToXlsx", manufacturers);
        }

        /// <summary>
        /// Export category list to xml
        /// </summary>
        /// <returns>Result in XML format</returns>
        public virtual string ExportCategoriesToXml()
        {
            return APIHelper.Instance.PostAsync<string>("ExportImport", "ExportCategoriesToXml", null);
        }

        /// <summary>
        /// Export categories to XLSX
        /// </summary>
        /// <param name="categories">Categories</param>
        public virtual byte[] ExportCategoriesToXlsx(IEnumerable<Category> categories)
        {
            return APIHelper.Instance.PostAsync<byte[]>("ExportImport", "ExportCategoriesToXlsx", categories);
        }

        /// <summary>
        /// Export product list to xml
        /// </summary>
        /// <param name="products">Products</param>
        /// <returns>Result in XML format</returns>
        public virtual string ExportProductsToXml(IList<Product> products)
        {
            return APIHelper.Instance.PostAsync<string>("ExportImport", "ExportProductsToXml", products);
        }

        /// <summary>
        /// Export products to XLSX
        /// </summary>
        /// <param name="products">Products</param>
        public virtual byte[] ExportProductsToXlsx(IEnumerable<Product> products)
        {
            return APIHelper.Instance.PostAsync<byte[]>("ExportImport", "ExportProductsToXlsx", products);
        }

        /// <summary>
        /// Export order list to xml
        /// </summary>
        /// <param name="orders">Orders</param>
        /// <returns>Result in XML format</returns>
        public virtual string ExportOrdersToXml(IList<Order> orders)
        {
            return APIHelper.Instance.PostAsync<string>("ExportImport", "ExportOrdersToXml", orders);
        }

        /// <summary>
        /// Export orders to XLSX
        /// </summary>
        /// <param name="orders">Orders</param>
        public virtual byte[] ExportOrdersToXlsx(IList<Order> orders)
        {
            return APIHelper.Instance.PostAsync<byte[]>("ExportImport", "ExportOrdersToXlsx", orders);
        }

        /// <summary>
        /// Export customer list to XLSX
        /// </summary>
        /// <param name="customers">Customers</param>
        public virtual byte[] ExportCustomersToXlsx(IList<Customer> customers)
        {
            return APIHelper.Instance.PostAsync<byte[]>("ExportImport", "ExportCustomersToXlsx", customers);
        }

        /// <summary>
        /// Export customer list to xml
        /// </summary>
        /// <param name="customers">Customers</param>
        /// <returns>Result in XML format</returns>
        public virtual string ExportCustomersToXml(IList<Customer> customers)
        {
            return APIHelper.Instance.PostAsync<string>("ExportImport", "ExportCustomersToXml", customers);
        }

        /// <summary>
        /// Export newsletter subscribers to TXT
        /// </summary>
        /// <param name="subscriptions">Subscriptions</param>
        /// <returns>Result in TXT (string) format</returns>
        public virtual string ExportNewsletterSubscribersToTxt(IList<NewsLetterSubscription> subscriptions)
        {
            return APIHelper.Instance.PostAsync<string>("ExportImport", "ExportNewsletterSubscribersToTxt", subscriptions);
        }

        /// <summary>
        /// Export states to TXT
        /// </summary>
        /// <param name="states">States</param>
        /// <returns>Result in TXT (string) format</returns>
        public virtual string ExportStatesToTxt(IList<StateProvince> states)
        {
            return APIHelper.Instance.PostAsync<string>("ExportImport", "ExportStatesToTxt", states);
        }

        #endregion
    }
}
