using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Shipping;
using Nop.Services.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nop.Api.Controllers
{
    public class CommonController : ApiController
    {
        #region Fields

        private readonly ISearchTermService _searchTermService;
        private readonly IPdfService _pdfService;
        private readonly IMaintenanceService _maintenanceService;
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly IFulltextService _fulltextService;
        private readonly IAddressService _addressService;
        private readonly IAddressAttributeService _addressAttributeService;
        private readonly IAddressAttributeParser _addressAttributeParser;
        private readonly IAddressAttributeFormatter _addressAttributeFormatter;

        #endregion

        #region Ctor

        public CommonController(ISearchTermService searchTermService, IPdfService pdfService, IMaintenanceService maintenanceService, IGenericAttributeService genericAttributeService,
            IFulltextService fulltextService, IAddressService addressService, IAddressAttributeService addressAttributeService, IAddressAttributeParser addressAttributeParser,
            IAddressAttributeFormatter addressAttributeFormatter)
        {
            this._searchTermService = searchTermService;
            this._pdfService = pdfService;
            this._maintenanceService = maintenanceService;
            this._genericAttributeService = genericAttributeService;
            this._fulltextService = fulltextService;
            this._addressService = addressService;
            this._addressAttributeService = addressAttributeService;
            this._addressAttributeParser = addressAttributeParser;
            this._addressAttributeFormatter = addressAttributeFormatter;
        }

        #endregion

        #region Method

        #region Search term

        /// <summary>
        /// Deletes a search term record
        /// </summary>
        /// <param name="searchTerm">Search term</param>
        public void DeleteSearchTerm(SearchTerm searchTerm)
        {
            _searchTermService.DeleteSearchTerm(searchTerm);
        }

        /// <summary>
        /// Gets a search term record by identifier
        /// </summary>
        /// <param name="searchTermId">Search term identifier</param>
        /// <returns>Search term</returns>
        public SearchTerm GetSearchTermById(int searchTermId)
        {
            return _searchTermService.GetSearchTermById(searchTermId);
        }

        /// <summary>
        /// Gets a search term record by keyword
        /// </summary>
        /// <param name="keyword">Search term keyword</param>
        /// <param name="storeId">Store identifier</param>
        /// <returns>Search term</returns>
        public SearchTerm GetSearchTermByKeyword(string keyword, int storeId)
        {
            return _searchTermService.GetSearchTermByKeyword(keyword, storeId);
        }

        /// <summary>
        /// Gets a search term statistics
        /// </summary>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>A list search term report lines</returns>
        public IAPIPagedList<SearchTermReportLine> GetStats(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return _searchTermService.GetStats(pageIndex, pageSize).ConvertPagedListToAPIPagedList();
        }

        /// <summary>
        /// Inserts a search term record
        /// </summary>
        /// <param name="searchTerm">Search term</param>
        public void InsertSearchTerm(SearchTerm searchTerm)
        {
            _searchTermService.InsertSearchTerm(searchTerm);
        }

        /// <summary>
        /// Updates the search term record
        /// </summary>
        /// <param name="searchTerm">Search term</param>
        public void UpdateSearchTerm(SearchTerm searchTerm)
        {
            _searchTermService.UpdateSearchTerm(searchTerm);
        }

        #endregion

        #region PDF

        /// <summary>
        /// Print an order to PDF
        /// </summary>
        /// <param name="order">Order</param>
        /// <param name="languageId">Language identifier; 0 to use a language used when placing an order</param>
        /// <param name="vendorId">Vendor identifier to limit products; 0 to to print all products. If specified, then totals won't be printed</param>
        /// <returns>A path of generated file</returns>
        public string PrintOrderToPdf(Order order, int languageId = 0, int vendorId = 0)
        {
            return _pdfService.PrintOrderToPdf(order, languageId, vendorId);
        }

        /// <summary>
        /// Print orders to PDF
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="orders">Orders</param>
        /// <param name="languageId">Language identifier; 0 to use a language used when placing an order</param>
        /// <param name="vendorId">Vendor identifier to limit products; 0 to to print all products. If specified, then totals won't be printed</param>
        public void PrintOrdersToPdf(Stream stream, IList<Order> orders, int languageId = 0, int vendorId = 0)
        {
            _pdfService.PrintOrdersToPdf(stream, orders, languageId, vendorId);
        }

        /// <summary>
        /// Print packaging slips to PDF
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="shipments">Shipments</param>
        /// <param name="languageId">Language identifier; 0 to use a language used when placing an order</param>
        public void PrintPackagingSlipsToPdf(Stream stream, IList<Shipment> shipments, int languageId = 0)
        {
            _pdfService.PrintPackagingSlipsToPdf(stream, shipments, languageId);
        }


        /// <summary>
        /// Print products to PDF
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="products">Products</param>
        public void PrintProductsToPdf(Stream stream, IList<Product> products)
        {
            _pdfService.PrintProductsToPdf(stream, products);
        }

        #endregion

        #region Maintenance

        /// <summary>
        /// Get the current ident value
        /// </summary>
        /// <typeparam name="T">Entity</typeparam>
        /// <returns>Integer ident; null if cannot get the result</returns>
        public int? GetTableIdent<T>() where T : BaseEntity
        {
            return _maintenanceService.GetTableIdent<T>();
        }

        /// <summary>
        /// Set table ident (is supported)
        /// </summary>
        /// <typeparam name="T">Entity</typeparam>
        /// <param name="ident">Ident value</param>
        public void SetTableIdent<T>(int ident) where T : BaseEntity
        {
            _maintenanceService.SetTableIdent<T>(ident);
        }

        /// <summary>
        /// Gets all backup files
        /// </summary>
        /// <returns>Backup file collection</returns>
        public IList<FileInfo> GetAllBackupFiles()
        {
            return _maintenanceService.GetAllBackupFiles();
        }

        /// <summary>
        /// Creates a backup of the database
        /// </summary>
        public void BackupDatabase()
        {
            _maintenanceService.BackupDatabase();
        }

        /// <summary>
        /// Restores the database from a backup
        /// </summary>
        /// <param name="backupFileName">The name of the backup file</param>
        public void RestoreDatabase(string backupFileName)
        {
            _maintenanceService.RestoreDatabase(backupFileName);
        }

        /// <summary>
        /// Returns the path to the backup file
        /// </summary>
        /// <param name="backupFileName">The name of the backup file</param>
        /// <returns>The path to the backup file</returns>
        public string GetBackupPath(string backupFileName)
        {
            return _maintenanceService.GetBackupPath(backupFileName);
        }

        #endregion

        #region Generic attribute

        /// <summary>
        /// Deletes an attribute
        /// </summary>
        /// <param name="attribute">Attribute</param>
        public void DeleteAttribute(GenericAttribute attribute)
        {
            _genericAttributeService.DeleteAttribute(attribute);
        }

        /// <summary>
        /// Deletes an attributes
        /// </summary>
        /// <param name="attributes">Attributes</param>
        public void DeleteAttributes(IList<GenericAttribute> attributes)
        {
            _genericAttributeService.DeleteAttributes(attributes);
        }

        /// <summary>
        /// Gets an attribute
        /// </summary>
        /// <param name="attributeId">Attribute identifier</param>
        /// <returns>An attribute</returns>
        public GenericAttribute GetAttributeById(int attributeId)
        {
            return _genericAttributeService.GetAttributeById(attributeId);
        }

        /// <summary>
        /// Inserts an attribute
        /// </summary>
        /// <param name="attribute">attribute</param>
        public void InsertAttribute(GenericAttribute attribute)
        {
            _genericAttributeService.InsertAttribute(attribute);
        }

        /// <summary>
        /// Updates the attribute
        /// </summary>
        /// <param name="attribute">Attribute</param>
        public void UpdateAttribute(GenericAttribute attribute)
        {
            _genericAttributeService.UpdateAttribute(attribute);
        }

        /// <summary>
        /// Get attributes
        /// </summary>
        /// <param name="entityId">Entity identifier</param>
        /// <param name="keyGroup">Key group</param>
        /// <returns>Get attributes</returns>
        public IList<GenericAttribute> GetAttributesForEntity(int entityId, string keyGroup)
        {
            return _genericAttributeService.GetAttributesForEntity(entityId, keyGroup);
        }

        /// <summary>
        /// Save attribute value
        /// </summary>
        /// <typeparam name="TPropType">Property type</typeparam>
        /// <param name="entity">Entity</param>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <param name="storeId">Store identifier; pass 0 if this attribute will be available for all stores</param>
        public void SaveAttribute<TPropType>(BaseEntity entity, string key, TPropType value, int storeId = 0)
        {
            _genericAttributeService.SaveAttribute(entity, key, value, storeId);
        }

        #endregion

        #region Full-Text

        /// <summary>
        /// Gets value indicating whether Full-Text is supported
        /// </summary>
        /// <returns>Result</returns>
        public bool IsFullTextSupported()
        {
            return _fulltextService.IsFullTextSupported();
        }

        /// <summary>
        /// Enable Full-Text support
        /// </summary>
        public void EnableFullText()
        {
            _fulltextService.EnableFullText();
        }

        /// <summary>
        /// Disable Full-Text support
        /// </summary>
        public void DisableFullText()
        {
            _fulltextService.DisableFullText();
        }

        #endregion

        #region Address

        /// <summary>
        /// Deletes an address
        /// </summary>
        /// <param name="address">Address</param>
        public void DeleteAddress(Address address)
        {
            _addressService.DeleteAddress(address);
        }

        /// <summary>
        /// Gets total number of addresses by country identifier
        /// </summary>
        /// <param name="countryId">Country identifier</param>
        /// <returns>Number of addresses</returns>
        public int GetAddressTotalByCountryId(int countryId)
        {
            return _addressService.GetAddressTotalByCountryId(countryId);
        }

        /// <summary>
        /// Gets total number of addresses by state/province identifier
        /// </summary>
        /// <param name="stateProvinceId">State/province identifier</param>
        /// <returns>Number of addresses</returns>
        public int GetAddressTotalByStateProvinceId(int stateProvinceId)
        {
            return _addressService.GetAddressTotalByStateProvinceId(stateProvinceId);
        }

        /// <summary>
        /// Gets an address by address identifier
        /// </summary>
        /// <param name="addressId">Address identifier</param>
        /// <returns>Address</returns>
        public Address GetAddressById(int addressId)
        {
            return _addressService.GetAddressById(addressId);
        }

        /// <summary>
        /// Inserts an address
        /// </summary>
        /// <param name="address">Address</param>
        public void InsertAddress(Address address)
        {
            _addressService.InsertAddress(address);
        }

        /// <summary>
        /// Updates the address
        /// </summary>
        /// <param name="address">Address</param>
        public void UpdateAddress(Address address)
        {
            _addressService.UpdateAddress(address);
        }

        /// <summary>
        /// Gets a value indicating whether address is valid (can be saved)
        /// </summary>
        /// <param name="address">Address to validate</param>
        /// <returns>Result</returns>
        public bool IsAddressValid(Address address)
        {
            return _addressService.IsAddressValid(address);
        }

        #endregion

        #region Address attribute

        /// <summary>
        /// Deletes an address attribute
        /// </summary>
        /// <param name="addressAttribute">Address attribute</param>
        public void DeleteAddressAttribute(AddressAttribute addressAttribute)
        {
            _addressAttributeService.DeleteAddressAttribute(addressAttribute);
        }

        /// <summary>
        /// Gets all address attributes
        /// </summary>
        /// <returns>Address attributes</returns>
        public IList<AddressAttribute> GetAllAddressAttributes()
        {
            return _addressAttributeService.GetAllAddressAttributes();
        }

        /// <summary>
        /// Gets an address attribute 
        /// </summary>
        /// <param name="addressAttributeId">Address attribute identifier</param>
        /// <returns>Address attribute</returns>
        public AddressAttribute GetAddressAttributeById(int addressAttributeId)
        {
            return _addressAttributeService.GetAddressAttributeById(addressAttributeId);
        }

        /// <summary>
        /// Inserts an address attribute
        /// </summary>
        /// <param name="addressAttribute">Address attribute</param>
        public void InsertAddressAttribute(AddressAttribute addressAttribute)
        {
            _addressAttributeService.InsertAddressAttribute(addressAttribute);
        }

        /// <summary>
        /// Updates the address attribute
        /// </summary>
        /// <param name="addressAttribute">Address attribute</param>
        public void UpdateAddressAttribute(AddressAttribute addressAttribute)
        {
            _addressAttributeService.UpdateAddressAttribute(addressAttribute);
        }

        /// <summary>
        /// Deletes an address attribute value
        /// </summary>
        /// <param name="addressAttributeValue">Address attribute value</param>
        public void DeleteAddressAttributeValue(AddressAttributeValue addressAttributeValue)
        {
            _addressAttributeService.DeleteAddressAttributeValue(addressAttributeValue);
        }

        /// <summary>
        /// Gets address attribute values by address attribute identifier
        /// </summary>
        /// <param name="addressAttributeId">The address attribute identifier</param>
        /// <returns>Address attribute values</returns>
        public IList<AddressAttributeValue> GetAddressAttributeValues(int addressAttributeId)
        {
            return _addressAttributeService.GetAddressAttributeValues(addressAttributeId);
        }

        /// <summary>
        /// Gets an address attribute value
        /// </summary>
        /// <param name="addressAttributeValueId">Address attribute value identifier</param>
        /// <returns>Address attribute value</returns>
        public AddressAttributeValue GetAddressAttributeValueById(int addressAttributeValueId)
        {
            return _addressAttributeService.GetAddressAttributeValueById(addressAttributeValueId);
        }

        /// <summary>
        /// Inserts a ddress attribute value
        /// </summary>
        /// <param name="addressAttributeValue">Address attribute value</param>
        public void InsertAddressAttributeValue(AddressAttributeValue addressAttributeValue)
        {
            _addressAttributeService.InsertAddressAttributeValue(addressAttributeValue);
        }

        /// <summary>
        /// Updates the ddress attribute value
        /// </summary>
        /// <param name="addressAttributeValue">Address attribute value</param>
        public void UpdateAddressAttributeValue(AddressAttributeValue addressAttributeValue)
        {
            _addressAttributeService.UpdateAddressAttributeValue(addressAttributeValue);
        }

        #endregion

        #region  Address attribute parser

        /// <summary>
        /// Gets selected address attributes
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <returns>Selected address attributes</returns>
        public IList<AddressAttribute> ParseAddressAttributes(string attributesXml)
        {
            return _addressAttributeParser.ParseAddressAttributes(attributesXml);
        }

        /// <summary>
        /// Get address attribute values
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <returns>Address attribute values</returns>
        public IList<AddressAttributeValue> ParseAddressAttributeValues(string attributesXml)
        {
            return _addressAttributeParser.ParseAddressAttributeValues(attributesXml);
        }

        /// <summary>
        /// Gets selected address attribute value
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <param name="addressAttributeId">Address attribute identifier</param>
        /// <returns>Address attribute value</returns>
        public IList<string> ParseValues(string attributesXml, int addressAttributeId)
        {
            return _addressAttributeParser.ParseValues(attributesXml, addressAttributeId);
        }

        /// <summary>
        /// Adds an attribute
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <param name="attribute">Address attribute</param>
        /// <param name="value">Value</param>
        /// <returns>Attributes</returns>
        public string AddAddressAttribute(string attributesXml, AddressAttribute attribute, string value)
        {
            return _addressAttributeParser.AddAddressAttribute(attributesXml, attribute, value);
        }

        /// <summary>
        /// Validates address attributes
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <returns>Warnings</returns>
        public IList<string> GetAttributeWarnings(string attributesXml)
        {
            return _addressAttributeParser.GetAttributeWarnings(attributesXml);
        }

        #endregion

        #region Address Attribute Formatter

        /// <summary>
        /// Formats attributes
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <param name="serapator">Serapator</param>
        /// <param name="htmlEncode">A value indicating whether to encode (HTML) values</param>
        /// <returns>Attributes</returns>
        public string FormatAttributes(string attributesXml,
            string serapator = "<br />",
            bool htmlEncode = true)
        {
            return _addressAttributeFormatter.FormatAttributes(attributesXml, serapator, htmlEncode);
        }

        #endregion

        #endregion
    }
}
