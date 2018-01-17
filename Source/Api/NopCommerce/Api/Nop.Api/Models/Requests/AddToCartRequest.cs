using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nop.Api.Models.Requests
{
    public class AddToCartRequest
    {
        public int customerId { get; set; }
        public int productId { get; set; }
        public ShoppingCartType shoppingCartType { get; set; }
        public int storeId { get; set; }
        public string attributesXml { get; set; } = null;
        public decimal customerEnteredPrice { get; set; } = decimal.Zero;
        public DateTime? rentalStartDate { get; set; } = null;
        public DateTime? rentalEndDate { get; set; } = null;
        public int quantity { get; set; } = 1;
        public bool automaticallyAddRequiredProductsIfEnabled { get; set; } = true;
    }
}