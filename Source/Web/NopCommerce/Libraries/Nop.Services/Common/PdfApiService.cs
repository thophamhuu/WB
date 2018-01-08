using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Shipping;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Common
{
    public partial class PdfApiService : IPdfService
    {
        #region Methods

        /// <summary>
        /// Print an order to PDF
        /// </summary>
        /// <param name="order">Order</param>
        /// <param name="languageId">Language identifier; 0 to use a language used when placing an order</param>
        /// <param name="vendorId">Vendor identifier to limit products; 0 to to print all products. If specified, then totals won't be printed</param>
        /// <returns>A path of generated file</returns>
        public virtual string PrintOrderToPdf(Order order, int languageId = 0, int vendorId = 0)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("languageId", languageId);
            parameters.Add("vendorId", vendorId);
            return APIHelper.Instance.PostAsync<string>("Common", "PrintOrderToPdf", order, parameters);
        }

        /// <summary>
        /// Print orders to PDF
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="orders">Orders</param>
        /// <param name="languageId">Language identifier; 0 to use a language used when placing an order</param>
        /// <param name="vendorId">Vendor identifier to limit products; 0 to to print all products. If specified, then totals won't be printed</param>
        public virtual void PrintOrdersToPdf(Stream stream, IList<Order> orders, int languageId = 0, int vendorId = 0)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("orders", orders);
            parameters.Add("languageId", languageId);
            parameters.Add("vendorId", vendorId);
            APIHelper.Instance.PostAsync("Common", "PrintOrdersToPdf", stream, parameters);
        }

        /// <summary>
        /// Print packaging slips to PDF
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="shipments">Shipments</param>
        /// <param name="languageId">Language identifier; 0 to use a language used when placing an order</param>
        public virtual void PrintPackagingSlipsToPdf(Stream stream, IList<Shipment> shipments, int languageId = 0)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("shipments", shipments);
            parameters.Add("languageId", languageId);
            APIHelper.Instance.PostAsync("Common", "PrintPackagingSlipsToPdf", stream, parameters);
        }

        /// <summary>
        /// Print products to PDF
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="products">Products</param>
        public virtual void PrintProductsToPdf(Stream stream, IList<Product> products)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("products", products);
            APIHelper.Instance.PostAsync("Common", "PrintPackagingSlipsToPdf", stream, parameters);
        }

        #endregion
    }
}
