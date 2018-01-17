using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Orders;
using Nop.Services.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nop.Api.Models.Requests
{
    public class GetUnitPriceRequest
    {
        public Product product { get; set; }
        public Customer customer { get; set; }
        public ShoppingCartType shoppingCartType { get; set; }
        public int quantity { get; set; }
        public string attributesXml { get; set; }
        public decimal customerEnteredPrice { get; set; }
        public DateTime? rentalStartDate { get; set; }
        public DateTime? rentalEndDate { get; set; }
        public bool includeDiscounts { get; set; }
        public decimal discountAmount { get; set; }
        public List<DiscountForCaching> appliedDiscounts { get; set; }
    }
}