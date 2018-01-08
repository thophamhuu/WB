using Nop.Core;
using Nop.Core.Domain.Vendors;
using Nop.Services.Vendors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nop.Api.Controllers
{
    [Authorize]
    public class VendorsController : ApiController
    {
        #region Fields

        private readonly IVendorService _vendorService;

        #endregion

        #region Ctor

        public VendorsController(IVendorService vendorService)
        {
            this._vendorService = vendorService;
        }

        #endregion

        #region Method

        /// <summary>
        /// Gets a vendor by vendor identifier
        /// </summary>
        /// <param name="vendorId">Vendor identifier</param>
        /// <returns>Vendor</returns>
        public Vendor GetVendorById(int vendorId)
        {
            return _vendorService.GetVendorById(vendorId);
        }

        /// <summary>
        /// Delete a vendor
        /// </summary>
        /// <param name="vendor">Vendor</param>
        public void DeleteVendor([FromBody]Vendor vendor)
        {
            _vendorService.DeleteVendor(vendor);
        }

        /// <summary>
        /// Gets all vendors
        /// </summary>
        /// <param name="name">Vendor name</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Vendors</returns>
        public IAPIPagedList<Vendor> GetAllVendors(string name = "",
            int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            return _vendorService.GetAllVendors(name, pageIndex, pageSize, showHidden).ConvertPagedListToAPIPagedList();
        }

        /// <summary>
        /// Inserts a vendor
        /// </summary>
        /// <param name="vendor">Vendor</param>
        public void InsertVendor([FromBody]Vendor vendor)
        {
            _vendorService.InsertVendor(vendor);
        }

        /// <summary>
        /// Updates the vendor
        /// </summary>
        /// <param name="vendor">Vendor</param>
        public void UpdateVendor([FromBody]Vendor vendor)
        {
            _vendorService.UpdateVendor(vendor);
        }



        /// <summary>
        /// Gets a vendor note note
        /// </summary>
        /// <param name="vendorNoteId">The vendor note identifier</param>
        /// <returns>Vendor note</returns>
        public VendorNote GetVendorNoteById(int vendorNoteId)
        {
            return _vendorService.GetVendorNoteById(vendorNoteId);
        }

        /// <summary>
        /// Deletes a vendor note
        /// </summary>
        /// <param name="vendorNote">The vendor note</param>
        public void DeleteVendorNote([FromBody]VendorNote vendorNote)
        {
            _vendorService.DeleteVendorNote(vendorNote);
        }

        #endregion
    }
}
