using System;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using System.Runtime.Serialization;

namespace Nop.Core.Domain.Orders
{
    /// <summary>
    /// Represents a shopping cart item
    /// </summary>
    public partial class ShoppingCartItem : BaseEntity
    {
        /// <summary>
        /// Gets or sets the store identifier
        /// </summary>
        [DataMember]
        public int StoreId { get; set; }

        /// <summary>
        /// Gets or sets the shopping cart type identifier
        /// </summary>
        [DataMember]
        public int ShoppingCartTypeId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier
        /// </summary>
        [DataMember]
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the product identifier
        /// </summary>
        [DataMember]
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the product attributes in XML format
        /// </summary>
        [DataMember]
        public string AttributesXml { get; set; }

        /// <summary>
        /// Gets or sets the price enter by a customer
        /// </summary>
        [DataMember]
        public decimal CustomerEnteredPrice { get; set; }

        /// <summary>
        /// Gets or sets the quantity
        /// </summary>
        [DataMember]
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the rental product start date (null if it's not a rental product)
        /// </summary>
        [DataMember]
        public DateTime? RentalStartDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the rental product end date (null if it's not a rental product)
        /// </summary>
        [DataMember]
        public DateTime? RentalEndDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of instance creation
        /// </summary>
        [DataMember]
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of instance update
        /// </summary>
        [DataMember]
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// Gets the log type
        /// </summary>
        public ShoppingCartType ShoppingCartType
        {
            get
            {
                return (ShoppingCartType)this.ShoppingCartTypeId;
            }
            set
            {
                this.ShoppingCartTypeId = (int)value;
            }
        }

        /// <summary>
        /// Gets or sets the product
        /// </summary>
        [DataMember]
        public virtual Product Product { get; set; }

        /// <summary>
        /// Gets or sets the customer
        /// </summary>
        [DataMember]
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// Gets a value indicating whether the shopping cart item is free shipping
        /// </summary>
        public bool IsFreeShipping
        {
            get
            {
                var product = this.Product;
                if (product != null)
                    return product.IsFreeShipping;
                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the shopping cart item is ship enabled
        /// </summary>
        public bool IsShipEnabled
        {
            get
            {
                var product = this.Product;
                if (product != null)
                    return product.IsShipEnabled;
                return false;
            }
        }

        /// <summary>
        /// Gets the additional shipping charge
        /// </summary> 
        public decimal AdditionalShippingCharge
        {
            get
            {
                decimal additionalShippingCharge = decimal.Zero;
                var product = this.Product;
                if (product != null)
                    additionalShippingCharge = product.AdditionalShippingCharge * Quantity;
                return additionalShippingCharge;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the shopping cart item is tax exempt
        /// </summary>
        public bool IsTaxExempt
        {
            get
            {
                var product = this.Product;
                if (product != null)
                    return product.IsTaxExempt;
                return false;
            }
        }
    }
}
