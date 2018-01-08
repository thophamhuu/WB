using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Shipping;
using Nop.Services.Shipping;
using Nop.Services.Shipping.Date;
using Nop.Services.Shipping.Pickup;
using Nop.Services.Shipping.Tracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace Nop.Api.Controllers
{
    [Authorize]
    public class ShippingsController : ApiController
    {
        #region Fields

        private readonly IShippingService _shippingService;
        private readonly IShipmentService _shipmentService;
        private readonly IDateRangeService _dateRangeService;
        private readonly IShipmentTracker _shipmentTracker;

        #endregion

        #region Ctor

        public ShippingsController(IShippingService shippingService, IShipmentService shipmentService, IDateRangeService dateRangeService, IShipmentTracker shipmentTracker)
        {
            this._shippingService = shippingService;
            this._shipmentService = shipmentService;
            this._dateRangeService = dateRangeService;
            this._shipmentTracker = shipmentTracker;
        }

        #endregion

        #region Method

        #region Shipping

        #region Shipping rate computation methods

        /// <summary>
        /// Load active shipping rate computation methods
        /// </summary>
        /// <param name="customer">Load records allowed only to a specified customer; pass null to ignore ACL permissions</param>
        /// <param name="storeId">Load records allowed only in a specified store; pass 0 to load all records</param>
        /// <returns>Shipping rate computation methods</returns>
        public IList<IShippingRateComputationMethod> LoadActiveShippingRateComputationMethods(Customer customer = null, int storeId = 0)
        {
            return _shippingService.LoadActiveShippingRateComputationMethods(customer, storeId);
        }

        /// <summary>
        /// Load shipping rate computation method by system name
        /// </summary>
        /// <param name="systemName">System name</param>
        /// <returns>Found Shipping rate computation method</returns>
        public IShippingRateComputationMethod LoadShippingRateComputationMethodBySystemName(string systemName)
        {
            return _shippingService.LoadShippingRateComputationMethodBySystemName(systemName);
        }

        /// <summary>
        /// Load all shipping rate computation methods
        /// </summary>
        /// <param name="customer">Load records allowed only to a specified customer; pass null to ignore ACL permissions</param>
        /// <param name="storeId">Load records allowed only in a specified store; pass 0 to load all records</param>
        /// <returns>Shipping rate computation methods</returns>
        public IList<IShippingRateComputationMethod> LoadAllShippingRateComputationMethods(Customer customer = null, int storeId = 0)
        {
            return _shippingService.LoadAllShippingRateComputationMethods(customer, storeId);
        }

        #endregion

        #region Shipping methods

        /// <summary>
        /// Deletes a shipping method
        /// </summary>
        /// <param name="shippingMethod">The shipping method</param>
        public void DeleteShippingMethod([FromBody]ShippingMethod shippingMethod)
        {
            _shippingService.DeleteShippingMethod(shippingMethod);
        }

        /// <summary>
        /// Gets a shipping method
        /// </summary>
        /// <param name="shippingMethodId">The shipping method identifier</param>
        /// <returns>Shipping method</returns>
        public ShippingMethod GetShippingMethodById(int shippingMethodId)
        {
            return _shippingService.GetShippingMethodById(shippingMethodId);
        }


        /// <summary>
        /// Gets all shipping methods
        /// </summary>
        /// <param name="filterByCountryId">The country indentifier to filter by</param>
        /// <returns>Shipping methods</returns>
        public IList<ShippingMethod> GetAllShippingMethods(int? filterByCountryId = null)
        {
            return _shippingService.GetAllShippingMethods(filterByCountryId);
        }

        /// <summary>
        /// Inserts a shipping method
        /// </summary>
        /// <param name="shippingMethod">Shipping method</param>
        public void InsertShippingMethod([FromBody]ShippingMethod shippingMethod)
        {
            _shippingService.InsertShippingMethod(shippingMethod);
        }

        /// <summary>
        /// Updates the shipping method
        /// </summary>
        /// <param name="shippingMethod">Shipping method</param>
        public void UpdateShippingMethod([FromBody]ShippingMethod shippingMethod)
        {
            _shippingService.UpdateShippingMethod(shippingMethod);
        }

        #endregion

        #region Warehouses

        /// <summary>
        /// Deletes a warehouse
        /// </summary>
        /// <param name="warehouse">The warehouse</param>
        public void DeleteWarehouse([FromBody]Warehouse warehouse)
        {
            _shippingService.DeleteWarehouse(warehouse);
        }

        /// <summary>
        /// Gets a warehouse
        /// </summary>
        /// <param name="warehouseId">The warehouse identifier</param>
        /// <returns>Warehouse</returns>
        public Warehouse GetWarehouseById(int warehouseId)
        {
            return _shippingService.GetWarehouseById(warehouseId);
        }

        /// <summary>
        /// Gets all warehouses
        /// </summary>
        /// <returns>Warehouses</returns>
        public IList<Warehouse> GetAllWarehouses()
        {
            return _shippingService.GetAllWarehouses();
        }

        /// <summary>
        /// Inserts a warehouse
        /// </summary>
        /// <param name="warehouse">Warehouse</param>
        public void InsertWarehouse([FromBody]Warehouse warehouse)
        {
            _shippingService.InsertWarehouse(warehouse);
        }

        /// <summary>
        /// Updates the warehouse
        /// </summary>
        /// <param name="warehouse">Warehouse</param>
        public void UpdateWarehouse([FromBody]Warehouse warehouse)
        {
            _shippingService.UpdateWarehouse(warehouse);
        }

        #endregion

        #region Pickup points

        /// <summary>
        /// Load active pickup point providers
        /// </summary>
        /// <param name="customer">Load records allowed only to a specified customer; pass null to ignore ACL permissions</param>
        /// <param name="storeId">Load records allowed only in a specified store; pass 0 to load all records</param>
        /// <returns>Pickup point providers</returns>
        public IList<IPickupPointProvider> LoadActivePickupPointProviders(Customer customer = null, int storeId = 0)
        {
            return _shippingService.LoadActivePickupPointProviders(customer, storeId);
        }

        /// <summary>
        /// Load pickup point provider by system name
        /// </summary>
        /// <param name="systemName">System name</param>
        /// <returns>Found pickup point provider</returns>
        public IPickupPointProvider LoadPickupPointProviderBySystemName(string systemName)
        {
            return _shippingService.LoadPickupPointProviderBySystemName(systemName);
        }

        /// <summary>
        /// Load all pickup point providers
        /// </summary>
        /// <param name="customer">Load records allowed only to a specified customer; pass null to ignore ACL permissions</param>
        /// <param name="storeId">Load records allowed only in a specified store; pass 0 to load all records</param>
        /// <returns>Pickup point providers</returns>
        public IList<IPickupPointProvider> LoadAllPickupPointProviders(Customer customer = null, int storeId = 0)
        {
            return _shippingService.LoadAllPickupPointProviders(customer, storeId);
        }

        #endregion

        #region Workflow

        /// <summary>
        /// Gets shopping cart item weight (of one item)
        /// </summary>
        /// <param name="shoppingCartItem">Shopping cart item</param>
        /// <returns>Shopping cart item weight</returns>
        public decimal GetShoppingCartItemWeight(ShoppingCartItem shoppingCartItem)
        {
            return _shippingService.GetShoppingCartItemWeight(shoppingCartItem);
        }

        /// <summary>
        /// Gets shopping cart weight
        /// </summary>
        /// <param name="request">Request</param>
        /// <param name="includeCheckoutAttributes">A value indicating whether we should calculate weights of selected checkotu attributes</param>
        /// <returns>Total weight</returns>
        public decimal GetTotalWeight(GetShippingOptionRequest request, bool includeCheckoutAttributes = true)
        {
            return _shippingService.GetTotalWeight(request, includeCheckoutAttributes);
        }

        /// <summary>
        /// Get dimensions of associated products (for quantity 1)
        /// </summary>
        /// <param name="shoppingCartItem">Shopping cart item</param>
        /// <param name="width">Width</param>
        /// <param name="length">Length</param>
        /// <param name="height">Height</param>
        public void GetAssociatedProductDimensions(ShoppingCartItem shoppingCartItem,
            out decimal width, out decimal length, out decimal height)
        {
            _shippingService.GetAssociatedProductDimensions(shoppingCartItem, out width, out length, out height);
        }

        /// <summary>
        /// Get total dimensions
        /// </summary>
        /// <param name="packageItems">Package items</param>
        /// <param name="width">Width</param>
        /// <param name="length">Length</param>
        /// <param name="height">Height</param>
        public void GetDimensions(IList<GetShippingOptionRequest.PackageItem> packageItems,
            out decimal width, out decimal length, out decimal height)
        {
            _shippingService.GetDimensions(packageItems, out width, out length, out height);
        }

        /// <summary>
        /// Get the nearest warehouse for the specified address
        /// </summary>
        /// <param name="address">Address</param>
        /// <param name="warehouses">List of warehouses, if null all warehouses are used.</param>
        /// <returns></returns>
        public Warehouse GetNearestWarehouse(Address address, IList<Warehouse> warehouses = null)
        {
            return _shippingService.GetNearestWarehouse(address, warehouses);
        }

        /// <summary>
        /// Create shipment packages (requests) from shopping cart
        /// </summary>
        /// <param name="cart">Shopping cart</param>
        /// <param name="shippingAddress">Shipping address</param>
        /// <param name="storeId">Load records allowed only in a specified store; pass 0 to load all records</param>
        /// <returns>Shipment packages (requests)</returns>
        /// <param name="shippingFromMultipleLocations">Value indicating whether shipping is done from multiple locations (warehouses)</param>
        public IList<GetShippingOptionRequest> CreateShippingOptionRequests(IList<ShoppingCartItem> cart,
            Address shippingAddress, int storeId, out bool shippingFromMultipleLocations)
        {
            return _shippingService.CreateShippingOptionRequests(cart, shippingAddress, storeId, out shippingFromMultipleLocations);
        }

        /// <summary>
        ///  Gets available shipping options
        /// </summary>
        /// <param name="cart">Shopping cart</param>
        /// <param name="shippingAddress">Shipping address</param>
        /// <param name="customer">Load records allowed only to a specified customer; pass null to ignore ACL permissions</param>
        /// <param name="allowedShippingRateComputationMethodSystemName">Filter by shipping rate computation method identifier; null to load shipping options of all shipping rate computation methods</param>
        /// <param name="storeId">Load records allowed only in a specified store; pass 0 to load all records</param>
        /// <returns>Shipping options</returns>
        public GetShippingOptionResponse GetShippingOptions(IList<ShoppingCartItem> cart, Address shippingAddress,
            Customer customer = null, string allowedShippingRateComputationMethodSystemName = "", int storeId = 0)
        {
            return _shippingService.GetShippingOptions(cart, shippingAddress, customer, allowedShippingRateComputationMethodSystemName, storeId);
        }

        /// <summary>
        /// Gets available pickup points
        /// </summary>
        /// <param name="address">Address</param>
        /// <param name="customer">Load records allowed only to a specified customer; pass null to ignore ACL permissions</param>
        /// <param name="providerSystemName">Filter by provider identifier; null to load pickup points of all providers</param>
        /// <param name="storeId">Load records allowed only in a specified store; pass 0 to load all records</param>
        /// <returns>Pickup points</returns>
        public GetPickupPointsResponse GetPickupPoints(Address address, Customer customer = null, string providerSystemName = null, int storeId = 0)
        {
            return _shippingService.GetPickupPoints(address, customer, providerSystemName, storeId);
        }

        #endregion

        #endregion

        #region Shipment

        /// <summary>
        /// Deletes a shipment
        /// </summary>
        /// <param name="shipment">Shipment</param>
        public void DeleteShipment([FromBody]Shipment shipment)
        {
            _shipmentService.DeleteShipment(shipment);
        }

        /// <summary>
        /// Search shipments
        /// </summary>
        /// <param name="vendorId">Vendor identifier; 0 to load all records</param>
        /// <param name="warehouseId">Warehouse identifier, only shipments with products from a specified warehouse will be loaded; 0 to load all orders</param>
        /// <param name="shippingCountryId">Shipping country identifier; 0 to load all records</param>
        /// <param name="shippingStateId">Shipping state identifier; 0 to load all records</param>
        /// <param name="shippingCity">Shipping city; null to load all records</param>
        /// <param name="trackingNumber">Search by tracking number</param>
        /// <param name="loadNotShipped">A value indicating whether we should load only not shipped shipments</param>
        /// <param name="createdFromUtc">Created date from (UTC); null to load all records</param>
        /// <param name="createdToUtc">Created date to (UTC); null to load all records</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Shipments</returns>
        public IAPIPagedList<Shipment> GetAllShipments(int vendorId = 0, int warehouseId = 0,
            int shippingCountryId = 0,
            int shippingStateId = 0,
            string shippingCity = null,
            string trackingNumber = null,
            bool loadNotShipped = false,
            DateTime? createdFromUtc = null, DateTime? createdToUtc = null,
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return _shipmentService.GetAllShipments(vendorId, warehouseId, shippingCountryId, shippingStateId, shippingCity, trackingNumber, loadNotShipped, createdFromUtc, createdToUtc, pageIndex, pageSize).ConvertPagedListToAPIPagedList();
        }

        /// <summary>
        /// Get shipment by identifiers
        /// </summary>
        /// <param name="shipmentIds">Shipment identifiers</param>
        /// <returns>Shipments</returns>
        public IList<Shipment> GetShipmentsByIds(int[] shipmentIds)
        {
            return _shipmentService.GetShipmentsByIds(shipmentIds);
        }

        /// <summary>
        /// Gets a shipment
        /// </summary>
        /// <param name="shipmentId">Shipment identifier</param>
        /// <returns>Shipment</returns>
        public Shipment GetShipmentById(int shipmentId)
        {
            return _shipmentService.GetShipmentById(shipmentId);
        }

        /// <summary>
        /// Inserts a shipment
        /// </summary>
        /// <param name="shipment">Shipment</param>
        public void InsertShipment([FromBody]Shipment shipment)
        {
            _shipmentService.InsertShipment(shipment);
        }

        /// <summary>
        /// Updates the shipment
        /// </summary>
        /// <param name="shipment">Shipment</param>
        public void UpdateShipment([FromBody]Shipment shipment)
        {
            _shipmentService.UpdateShipment(shipment);
        }


        /// <summary>
        /// Deletes a shipment item
        /// </summary>
        /// <param name="shipmentItem">Shipment item</param>
        public void DeleteShipmentItem([FromBody]ShipmentItem shipmentItem)
        {
            _shipmentService.DeleteShipmentItem(shipmentItem);
        }

        /// <summary>
        /// Gets a shipment item
        /// </summary>
        /// <param name="shipmentItemId">Shipment item identifier</param>
        /// <returns>Shipment item</returns>
        public ShipmentItem GetShipmentItemById(int shipmentItemId)
        {
            return _shipmentService.GetShipmentItemById(shipmentItemId);
        }

        /// <summary>
        /// Inserts a shipment item
        /// </summary>
        /// <param name="shipmentItem">Shipment item</param>
        public void InsertShipmentItem([FromBody]ShipmentItem shipmentItem)
        {
            _shipmentService.InsertShipmentItem(shipmentItem);
        }

        /// <summary>
        /// Updates the shipment item
        /// </summary>
        /// <param name="shipmentItem">Shipment item</param>
        public void UpdateShipmentItem([FromBody]ShipmentItem shipmentItem)
        {
            _shipmentService.UpdateShipmentItem(shipmentItem);
        }



        /// <summary>
        /// Get quantity in shipments. For example, get planned quantity to be shipped
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="warehouseId">Warehouse identifier</param>
        /// <param name="ignoreShipped">Ignore already shipped shipments</param>
        /// <param name="ignoreDelivered">Ignore already delivered shipments</param>
        /// <returns>Quantity</returns>
        public int GetQuantityInShipments(Product product, int warehouseId,
            bool ignoreShipped, bool ignoreDelivered)
        {
            return _shipmentService.GetQuantityInShipments(product, warehouseId, ignoreShipped, ignoreDelivered);
        }

        #endregion

        #region Date

        #region Delivery dates

        /// <summary>
        /// Delete a delivery date
        /// </summary>
        /// <param name="deliveryDate">The delivery date</param>
        public void DeleteDeliveryDate([FromBody]DeliveryDate deliveryDate)
        {
            _dateRangeService.DeleteDeliveryDate(deliveryDate);
        }

        /// <summary>
        /// Get a delivery date
        /// </summary>
        /// <param name="deliveryDateId">The delivery date identifier</param>
        /// <returns>Delivery date</returns>
        public DeliveryDate GetDeliveryDateById(int deliveryDateId)
        {
            return _dateRangeService.GetDeliveryDateById(deliveryDateId);
        }

        /// <summary>
        /// Get all delivery dates
        /// </summary>
        /// <returns>Delivery dates</returns>
        public IList<DeliveryDate> GetAllDeliveryDates()
        {
            return _dateRangeService.GetAllDeliveryDates();
        }

        /// <summary>
        /// Insert a delivery date
        /// </summary>
        /// <param name="deliveryDate">Delivery date</param>
        public void InsertDeliveryDate([FromBody]DeliveryDate deliveryDate)
        {
            _dateRangeService.InsertDeliveryDate(deliveryDate);
        }

        /// <summary>
        /// Update the delivery date
        /// </summary>
        /// <param name="deliveryDate">Delivery date</param>
        public void UpdateDeliveryDate([FromBody]DeliveryDate deliveryDate)
        {
            _dateRangeService.UpdateDeliveryDate(deliveryDate);
        }

        #endregion

        #region Product availability ranges

        /// <summary>
        /// Get a product availability range
        /// </summary>
        /// <param name="productAvailabilityRangeId">The product availability range identifier</param>
        /// <returns>Product availability range</returns>
        public ProductAvailabilityRange GetProductAvailabilityRangeById(int productAvailabilityRangeId)
        {
            return _dateRangeService.GetProductAvailabilityRangeById(productAvailabilityRangeId);
        }

        /// <summary>
        /// Get all product availability ranges
        /// </summary>
        /// <returns>Product availability ranges</returns>
        public IList<ProductAvailabilityRange> GetAllProductAvailabilityRanges()
        {
            return _dateRangeService.GetAllProductAvailabilityRanges();
        }

        /// <summary>
        /// Insert the product availability range
        /// </summary>
        /// <param name="productAvailabilityRange">Product availability range</param>
        public void InsertProductAvailabilityRange([FromBody]ProductAvailabilityRange productAvailabilityRange)
        {
            _dateRangeService.InsertProductAvailabilityRange(productAvailabilityRange);
        }

        /// <summary>
        /// Update the product availability range
        /// </summary>
        /// <param name="productAvailabilityRange">Product availability range</param>
        public void UpdateProductAvailabilityRange([FromBody]ProductAvailabilityRange productAvailabilityRange)
        {
            _dateRangeService.UpdateProductAvailabilityRange(productAvailabilityRange);
        }

        /// <summary>
        /// Delete the product availability range
        /// </summary>
        /// <param name="productAvailabilityRange">Product availability range</param>
        public void DeleteProductAvailabilityRange([FromBody]ProductAvailabilityRange productAvailabilityRange)
        {
            _dateRangeService.DeleteProductAvailabilityRange(productAvailabilityRange);
        }

        #endregion


        #endregion

        #endregion
    }
}
