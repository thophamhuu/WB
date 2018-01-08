using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Orders
{
    public partial class ShoppingCartApiService : IShoppingCartService
    {
        #region Methods

        /// <summary>
        /// Delete shopping cart item
        /// </summary>
        /// <param name="shoppingCartItem">Shopping cart item</param>
        /// <param name="resetCheckoutData">A value indicating whether to reset checkout data</param>
        /// <param name="ensureOnlyActiveCheckoutAttributes">A value indicating whether to ensure that only active checkout attributes are attached to the current customer</param>
        public virtual void DeleteShoppingCartItem(ShoppingCartItem shoppingCartItem, bool resetCheckoutData = true,
            bool ensureOnlyActiveCheckoutAttributes = false)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("resetCheckoutData", resetCheckoutData);
            parameters.Add("ensureOnlyActiveCheckoutAttributes", ensureOnlyActiveCheckoutAttributes);
            APIHelper.Instance.PostAsync("Orders", "GetBlogCommentsCount", shoppingCartItem, parameters);
        }

        /// <summary>
        /// Deletes expired shopping cart items
        /// </summary>
        /// <param name="olderThanUtc">Older than date and time</param>
        /// <returns>Number of deleted items</returns>
        public virtual int DeleteExpiredShoppingCartItems(DateTime olderThanUtc)
        {
            return APIHelper.Instance.PostAsync<int>("Orders", "DeleteExpiredShoppingCartItems", olderThanUtc);
        }

        /// <summary>
        /// Validates required products (products which require some other products to be added to the cart)
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="shoppingCartType">Shopping cart type</param>
        /// <param name="product">Product</param>
        /// <param name="storeId">Store identifier</param>
        /// <param name="automaticallyAddRequiredProductsIfEnabled">Automatically add required products if enabled</param>
        /// <returns>Warnings</returns>
        public virtual IList<string> GetRequiredProductWarnings(Customer customer,
            ShoppingCartType shoppingCartType, Product product,
            int storeId, bool automaticallyAddRequiredProductsIfEnabled)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customer", customer);
            parameters.Add("shoppingCartType", shoppingCartType);
            parameters.Add("product", product);
            parameters.Add("storeId", storeId);
            parameters.Add("automaticallyAddRequiredProductsIfEnabled", automaticallyAddRequiredProductsIfEnabled);

            return APIHelper.Instance.GetListAsync<string>("Orders", "GetRequiredProductWarnings", parameters);
        }

        /// <summary>
        /// Validates a product for standard properties
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="shoppingCartType">Shopping cart type</param>
        /// <param name="product">Product</param>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <param name="customerEnteredPrice">Customer entered price</param>
        /// <param name="quantity">Quantity</param>
        /// <returns>Warnings</returns>
        public virtual IList<string> GetStandardWarnings(Customer customer, ShoppingCartType shoppingCartType,
            Product product, string attributesXml, decimal customerEnteredPrice,
            int quantity)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customer", customer);
            parameters.Add("shoppingCartType", shoppingCartType);
            parameters.Add("product", product);
            parameters.Add("attributesXml", attributesXml);
            parameters.Add("customerEnteredPrice", customerEnteredPrice);
            parameters.Add("quantity", quantity);

            return APIHelper.Instance.GetListAsync<string>("Orders", "GetStandardWarnings", parameters);
        }

        /// <summary>
        /// Validates shopping cart item attributes
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="shoppingCartType">Shopping cart type</param>
        /// <param name="product">Product</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <param name="ignoreNonCombinableAttributes">A value indicating whether we should ignore non-combinable attributes</param>
        /// <returns>Warnings</returns>
        public virtual IList<string> GetShoppingCartItemAttributeWarnings(Customer customer,
            ShoppingCartType shoppingCartType,
            Product product,
            int quantity = 1,
            string attributesXml = "",
            bool ignoreNonCombinableAttributes = false)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customer", customer);
            parameters.Add("shoppingCartType", shoppingCartType);
            parameters.Add("product", product);
            parameters.Add("quantity", quantity);
            parameters.Add("attributesXml", attributesXml);
            parameters.Add("ignoreNonCombinableAttributes", ignoreNonCombinableAttributes);

            return APIHelper.Instance.GetListAsync<string>("Orders", "GetShoppingCartItemAttributeWarnings", parameters);
        }

        /// <summary>
        /// Validates shopping cart item (gift card)
        /// </summary>
        /// <param name="shoppingCartType">Shopping cart type</param>
        /// <param name="product">Product</param>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <returns>Warnings</returns>
        public virtual IList<string> GetShoppingCartItemGiftCardWarnings(ShoppingCartType shoppingCartType,
            Product product, string attributesXml)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("shoppingCartType", shoppingCartType);
            parameters.Add("product", product);
            parameters.Add("attributesXml", attributesXml);

            return APIHelper.Instance.GetListAsync<string>("Orders", "GetShoppingCartItemGiftCardWarnings", parameters);
        }

        /// <summary>
        /// Validates shopping cart item for rental products
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="rentalStartDate">Rental start date</param>
        /// <param name="rentalEndDate">Rental end date</param>
        /// <returns>Warnings</returns>
        public virtual IList<string> GetRentalProductWarnings(Product product,
            DateTime? rentalStartDate = null, DateTime? rentalEndDate = null)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("product", product);
            if (rentalStartDate.HasValue)
                parameters.Add("rentalStartDate", CommonHelper.DateTimeUtcToStringAPI(rentalStartDate.Value));
            if (rentalEndDate.HasValue)
                parameters.Add("rentalEndDate", CommonHelper.DateTimeUtcToStringAPI(rentalEndDate.Value));

            return APIHelper.Instance.GetListAsync<string>("Orders", "GetRentalProductWarnings", parameters);
        }


        /// <summary>
        /// Validates shopping cart item
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="shoppingCartType">Shopping cart type</param>
        /// <param name="product">Product</param>
        /// <param name="storeId">Store identifier</param>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <param name="customerEnteredPrice">Customer entered price</param>
        /// <param name="rentalStartDate">Rental start date</param>
        /// <param name="rentalEndDate">Rental end date</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="automaticallyAddRequiredProductsIfEnabled">Automatically add required products if enabled</param>
        /// <param name="getStandardWarnings">A value indicating whether we should validate a product for standard properties</param>
        /// <param name="getAttributesWarnings">A value indicating whether we should validate product attributes</param>
        /// <param name="getGiftCardWarnings">A value indicating whether we should validate gift card properties</param>
        /// <param name="getRequiredProductWarnings">A value indicating whether we should validate required products (products which require other products to be added to the cart)</param>
        /// <param name="getRentalWarnings">A value indicating whether we should validate rental properties</param>
        /// <returns>Warnings</returns>
        public virtual IList<string> GetShoppingCartItemWarnings(Customer customer, ShoppingCartType shoppingCartType,
            Product product, int storeId,
            string attributesXml, decimal customerEnteredPrice,
            DateTime? rentalStartDate = null, DateTime? rentalEndDate = null,
            int quantity = 1, bool automaticallyAddRequiredProductsIfEnabled = true,
            bool getStandardWarnings = true, bool getAttributesWarnings = true,
            bool getGiftCardWarnings = true, bool getRequiredProductWarnings = true,
            bool getRentalWarnings = true)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customer", customer);
            parameters.Add("shoppingCartType", shoppingCartType);
            parameters.Add("product", product);
            parameters.Add("storeId", storeId);
            parameters.Add("attributesXml", attributesXml);
            parameters.Add("customerEnteredPrice", customerEnteredPrice);
            if (rentalStartDate.HasValue)
                parameters.Add("rentalStartDate", CommonHelper.DateTimeUtcToStringAPI(rentalStartDate.Value));
            if (rentalEndDate.HasValue)
                parameters.Add("rentalEndDate", CommonHelper.DateTimeUtcToStringAPI(rentalEndDate.Value));
            parameters.Add("quantity", quantity);
            parameters.Add("automaticallyAddRequiredProductsIfEnabled", automaticallyAddRequiredProductsIfEnabled);
            parameters.Add("getStandardWarnings", getStandardWarnings);
            parameters.Add("getAttributesWarnings", getAttributesWarnings);
            parameters.Add("getGiftCardWarnings", getGiftCardWarnings);
            parameters.Add("getRequiredProductWarnings", getRequiredProductWarnings);
            parameters.Add("getRentalWarnings", getRentalWarnings);

            return APIHelper.Instance.GetListAsync<string>("Orders", "GetShoppingCartItemWarnings", parameters);
        }

        /// <summary>
        /// Validates whether this shopping cart is valid
        /// </summary>
        /// <param name="shoppingCart">Shopping cart</param>
        /// <param name="checkoutAttributesXml">Checkout attributes in XML format</param>
        /// <param name="validateCheckoutAttributes">A value indicating whether to validate checkout attributes</param>
        /// <returns>Warnings</returns>
        public virtual IList<string> GetShoppingCartWarnings(IList<ShoppingCartItem> shoppingCart,
            string checkoutAttributesXml, bool validateCheckoutAttributes)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("shoppingCart", shoppingCart);
            parameters.Add("checkoutAttributesXml", checkoutAttributesXml);
            parameters.Add("validateCheckoutAttributes", validateCheckoutAttributes);

            return APIHelper.Instance.GetListAsync<string>("Orders", "GetShoppingCartWarnings", parameters);
        }

        /// <summary>
        /// Finds a shopping cart item in the cart
        /// </summary>
        /// <param name="shoppingCart">Shopping cart</param>
        /// <param name="shoppingCartType">Shopping cart type</param>
        /// <param name="product">Product</param>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <param name="customerEnteredPrice">Price entered by a customer</param>
        /// <param name="rentalStartDate">Rental start date</param>
        /// <param name="rentalEndDate">Rental end date</param>
        /// <returns>Found shopping cart item</returns>
        public virtual ShoppingCartItem FindShoppingCartItemInTheCart(IList<ShoppingCartItem> shoppingCart,
            ShoppingCartType shoppingCartType,
            Product product,
            string attributesXml = "",
            decimal customerEnteredPrice = decimal.Zero,
            DateTime? rentalStartDate = null,
            DateTime? rentalEndDate = null)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("shoppingCart", shoppingCart);
            parameters.Add("shoppingCartType", shoppingCartType);
            parameters.Add("product", product);
            parameters.Add("attributesXml", attributesXml);
            parameters.Add("customerEnteredPrice", customerEnteredPrice);
            if (rentalStartDate.HasValue)
                parameters.Add("rentalStartDate", CommonHelper.DateTimeUtcToStringAPI(rentalStartDate.Value));
            if (rentalEndDate.HasValue)
                parameters.Add("rentalEndDate", CommonHelper.DateTimeUtcToStringAPI(rentalEndDate.Value));

            return APIHelper.Instance.GetAsync<ShoppingCartItem>("Orders", "FindShoppingCartItemInTheCart", parameters);
        }

        /// <summary>
        /// Add a product to shopping cart
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="product">Product</param>
        /// <param name="shoppingCartType">Shopping cart type</param>
        /// <param name="storeId">Store identifier</param>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <param name="customerEnteredPrice">The price enter by a customer</param>
        /// <param name="rentalStartDate">Rental start date</param>
        /// <param name="rentalEndDate">Rental end date</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="automaticallyAddRequiredProductsIfEnabled">Automatically add required products if enabled</param>
        /// <returns>Warnings</returns>
        public virtual IList<string> AddToCart(Customer customer, Product product,
            ShoppingCartType shoppingCartType, int storeId, string attributesXml = null,
            decimal customerEnteredPrice = decimal.Zero,
            DateTime? rentalStartDate = null, DateTime? rentalEndDate = null,
            int quantity = 1, bool automaticallyAddRequiredProductsIfEnabled = true)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customer", customer);
            parameters.Add("product", product);
            parameters.Add("shoppingCartType", shoppingCartType);
            parameters.Add("storeId", storeId);
            parameters.Add("attributesXml", attributesXml);
            parameters.Add("customerEnteredPrice", customerEnteredPrice);
            if (rentalStartDate.HasValue)
                parameters.Add("rentalStartDate", CommonHelper.DateTimeUtcToStringAPI(rentalStartDate.Value));
            if (rentalEndDate.HasValue)
                parameters.Add("rentalEndDate", CommonHelper.DateTimeUtcToStringAPI(rentalEndDate.Value));
            parameters.Add("quantity", quantity);
            parameters.Add("automaticallyAddRequiredProductsIfEnabled", automaticallyAddRequiredProductsIfEnabled);

            return APIHelper.Instance.GetListAsync<string>("Orders", "AddToCart", parameters);
        }

        /// <summary>
        /// Updates the shopping cart item
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="shoppingCartItemId">Shopping cart item identifier</param>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <param name="customerEnteredPrice">New customer entered price</param>
        /// <param name="rentalStartDate">Rental start date</param>
        /// <param name="rentalEndDate">Rental end date</param>
        /// <param name="quantity">New shopping cart item quantity</param>
        /// <param name="resetCheckoutData">A value indicating whether to reset checkout data</param>
        /// <returns>Warnings</returns>
        public virtual IList<string> UpdateShoppingCartItem(Customer customer,
            int shoppingCartItemId, string attributesXml,
            decimal customerEnteredPrice,
            DateTime? rentalStartDate = null, DateTime? rentalEndDate = null,
            int quantity = 1, bool resetCheckoutData = true)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customer", customer);
            parameters.Add("shoppingCartItemId", shoppingCartItemId);
            parameters.Add("attributesXml", attributesXml);
            parameters.Add("customerEnteredPrice", customerEnteredPrice);
            if (rentalStartDate.HasValue)
                parameters.Add("rentalStartDate", CommonHelper.DateTimeUtcToStringAPI(rentalStartDate.Value));
            if (rentalEndDate.HasValue)
                parameters.Add("rentalEndDate", CommonHelper.DateTimeUtcToStringAPI(rentalEndDate.Value));
            parameters.Add("quantity", quantity);
            parameters.Add("resetCheckoutData", resetCheckoutData);

            return APIHelper.Instance.GetListAsync<string>("Orders", "UpdateShoppingCartItem", parameters);
        }

        /// <summary>
        /// Migrate shopping cart
        /// </summary>
        /// <param name="fromCustomer">From customer</param>
        /// <param name="toCustomer">To customer</param>
        /// <param name="includeCouponCodes">A value indicating whether to coupon codes (discount and gift card) should be also re-applied</param>
        public virtual void MigrateShoppingCart(Customer fromCustomer, Customer toCustomer, bool includeCouponCodes)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("fromCustomer", fromCustomer);
            parameters.Add("toCustomer", toCustomer);
            parameters.Add("includeCouponCodes", includeCouponCodes);

            APIHelper.Instance.PostAsync("Orders", "MigrateShoppingCart", parameters);
        }

        #endregion
    }
}
