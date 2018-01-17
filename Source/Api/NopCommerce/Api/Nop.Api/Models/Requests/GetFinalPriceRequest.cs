using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Services.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nop.Api.Models.Requests
{
    public class GetFinalPriceRequest
    {
        public Product product { get; set; }
        public Customer customer { get; set; }
        public decimal additionalCharge { get; set; }
        public bool includeDiscounts { get; set; }
        public int quantity { get; set; }
        public DateTime? rentalStartDate { get; set; }
        public DateTime? rentalEndDate { get; set; }
        public decimal discountAmount { get; set; }
        public List<DiscountForCaching> appliedDiscounts { get; set; }
    }
}