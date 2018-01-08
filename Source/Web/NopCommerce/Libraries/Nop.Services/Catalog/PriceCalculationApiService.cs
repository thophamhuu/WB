using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Orders;
using Nop.Services.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Catalog
{
    public partial class PriceCalculationApiService
    {
        #region Methods

        /// <summary>
        /// Gets the final price
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="customer">The customer</param>
        /// <param name="additionalCharge">Additional charge</param>
        /// <param name="includeDiscounts">A value indicating whether include discounts or not for final price computation</param>
        /// <param name="quantity">Shopping cart item quantity</param>
        /// <returns>Final price</returns>
        public virtual decimal GetFinalPrice(Product product,
            Customer customer,
            decimal additionalCharge = decimal.Zero,
            bool includeDiscounts = true,
            int quantity = 1)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("product", product);
            parameters.Add("customer", customer);
            parameters.Add("additionalCharge", additionalCharge);
            parameters.Add("includeDiscounts", includeDiscounts);
            parameters.Add("quantity", quantity);
            return APIHelper.Instance.GetAsync<decimal>("Catalogs", "GetFinalPrice", parameters);
        }
        /// <summary>
        /// Gets the final price
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="customer">The customer</param>
        /// <param name="additionalCharge">Additional charge</param>
        /// <param name="includeDiscounts">A value indicating whether include discounts or not for final price computation</param>
        /// <param name="quantity">Shopping cart item quantity</param>
        /// <param name="discountAmount">Applied discount amount</param>
        /// <param name="appliedDiscounts">Applied discounts</param>
        /// <returns>Final price</returns>
        //public virtual decimal GetFinalPrice(Product product,
        //    Customer customer,
        //    decimal additionalCharge,
        //    bool includeDiscounts,
        //    int quantity,
        //    out decimal discountAmount,
        //    out List<DiscountForCaching> appliedDiscounts)
        //{

        //}
        /// <summary>
        /// Gets the final price
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="customer">The customer</param>
        /// <param name="additionalCharge">Additional charge</param>
        /// <param name="includeDiscounts">A value indicating whether include discounts or not for final price computation</param>
        /// <param name="quantity">Shopping cart item quantity</param>
        /// <param name="rentalStartDate">Rental period start date (for rental products)</param>
        /// <param name="rentalEndDate">Rental period end date (for rental products)</param>
        /// <param name="discountAmount">Applied discount amount</param>
        /// <param name="appliedDiscounts">Applied discounts</param>
        /// <returns>Final price</returns>
        //public virtual decimal GetFinalPrice(Product product,
        //    Customer customer,
        //    decimal additionalCharge,
        //    bool includeDiscounts,
        //    int quantity,
        //    DateTime? rentalStartDate,
        //    DateTime? rentalEndDate,
        //    out decimal discountAmount,
        //    out List<DiscountForCaching> appliedDiscounts)
        //{
           
        //}
        /// <summary>
        /// Gets the final price
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="customer">The customer</param>
        /// <param name="overriddenProductPrice">Overridden product price. If specified, then it'll be used instead of a product price. For example, used with product attribute combinations</param>
        /// <param name="additionalCharge">Additional charge</param>
        /// <param name="includeDiscounts">A value indicating whether include discounts or not for final price computation</param>
        /// <param name="quantity">Shopping cart item quantity</param>
        /// <param name="rentalStartDate">Rental period start date (for rental products)</param>
        /// <param name="rentalEndDate">Rental period end date (for rental products)</param>
        /// <param name="discountAmount">Applied discount amount</param>
        /// <param name="appliedDiscounts">Applied discounts</param>
        /// <returns>Final price</returns>
        //public virtual decimal GetFinalPrice(Product product,
        //    Customer customer,
        //    decimal? overriddenProductPrice,
        //    decimal additionalCharge,
        //    bool includeDiscounts,
        //    int quantity,
        //    DateTime? rentalStartDate,
        //    DateTime? rentalEndDate,
        //    out decimal discountAmount,
        //    out List<DiscountForCaching> appliedDiscounts)
        //{
            
        //}



        /// <summary>
        /// Gets the shopping cart unit price (one item)
        /// </summary>
        /// <param name="shoppingCartItem">The shopping cart item</param>
        /// <param name="includeDiscounts">A value indicating whether include discounts or not for price computation</param>
        /// <returns>Shopping cart unit price (one item)</returns>
        //public virtual decimal GetUnitPrice(ShoppingCartItem shoppingCartItem,
        //    bool includeDiscounts = true)
        //{
        //    var parameters = new Dictionary<string, dynamic>();
        //    parameters.Add("shoppingCartItem", shoppingCartItem);
        //    parameters.Add("includeDiscounts", includeDiscounts);
        //    return APIHelper.Instance.GetAsync<decimal>("Catalogs", "GetUnitPrice", parameters);
        //}
        /// <summary>
        /// Gets the shopping cart unit price (one item)
        /// </summary>
        /// <param name="shoppingCartItem">The shopping cart item</param>
        /// <param name="includeDiscounts">A value indicating whether include discounts or not for price computation</param>
        /// <param name="discountAmount">Applied discount amount</param>
        /// <param name="appliedDiscounts">Applied discounts</param>
        /// <returns>Shopping cart unit price (one item)</returns>
        //public virtual decimal GetUnitPrice(ShoppingCartItem shoppingCartItem,
        //    bool includeDiscounts,
        //    out decimal discountAmount,
        //    out List<DiscountForCaching> appliedDiscounts)
        //{
            
        //}
        /// <summary>
        /// Gets the shopping cart unit price (one item)
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="customer">Customer</param>
        /// <param name="shoppingCartType">Shopping cart type</param>
        /// <param name="quantity">Quantity</param>
        /// <param name="attributesXml">Product atrributes (XML format)</param>
        /// <param name="customerEnteredPrice">Customer entered price (if specified)</param>
        /// <param name="rentalStartDate">Rental start date (null for not rental products)</param>
        /// <param name="rentalEndDate">Rental end date (null for not rental products)</param>
        /// <param name="includeDiscounts">A value indicating whether include discounts or not for price computation</param>
        /// <param name="discountAmount">Applied discount amount</param>
        /// <param name="appliedDiscounts">Applied discounts</param>
        /// <returns>Shopping cart unit price (one item)</returns>
        //public virtual decimal GetUnitPrice(Product product,
        //    Customer customer,
        //    ShoppingCartType shoppingCartType,
        //    int quantity,
        //    string attributesXml,
        //    decimal customerEnteredPrice,
        //    DateTime? rentalStartDate, DateTime? rentalEndDate,
        //    bool includeDiscounts,
        //    out decimal discountAmount,
        //    out List<DiscountForCaching> appliedDiscounts)
        //{
            
        //}
        /// <summary>
        /// Gets the shopping cart item sub total
        /// </summary>
        /// <param name="shoppingCartItem">The shopping cart item</param>
        /// <param name="includeDiscounts">A value indicating whether include discounts or not for price computation</param>
        /// <returns>Shopping cart item sub total</returns>
        //public virtual decimal GetSubTotal(ShoppingCartItem shoppingCartItem,
        //    bool includeDiscounts = true)
        //{
           
        //}
        /// <summary>
        /// Gets the shopping cart item sub total
        /// </summary>
        /// <param name="shoppingCartItem">The shopping cart item</param>
        /// <param name="includeDiscounts">A value indicating whether include discounts or not for price computation</param>
        /// <param name="discountAmount">Applied discount amount</param>
        /// <param name="appliedDiscounts">Applied discounts</param>
        /// <param name="maximumDiscountQty">Maximum discounted qty. Return not nullable value if discount cannot be applied to ALL items</param>
        /// <returns>Shopping cart item sub total</returns>
        //public virtual decimal GetSubTotal(ShoppingCartItem shoppingCartItem,
        //    bool includeDiscounts,
        //    out decimal discountAmount,
        //    out List<DiscountForCaching> appliedDiscounts,
        //    out int? maximumDiscountQty)
        //{
           
        //}


        /// <summary>
        /// Gets the product cost (one item)
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="attributesXml">Shopping cart item attributes in XML</param>
        /// <returns>Product cost (one item)</returns>
        public virtual decimal GetProductCost(Product product, string attributesXml)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("product", product);
            parameters.Add("attributesXml", attributesXml);
            return APIHelper.Instance.GetAsync<decimal>("Catalogs", "GetProductCost", parameters);
        }



        /// <summary>
        /// Get a price adjustment of a product attribute value
        /// </summary>
        /// <param name="value">Product attribute value</param>
        /// <returns>Price adjustment</returns>
        public virtual decimal GetProductAttributeValuePriceAdjustment(ProductAttributeValue value)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("value", value);
            return APIHelper.Instance.GetAsync<decimal>("Catalogs", "GetProductAttributeValuePriceAdjustment", parameters);
        }

        #endregion     
    }
}
