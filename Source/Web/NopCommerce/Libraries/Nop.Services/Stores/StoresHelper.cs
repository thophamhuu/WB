using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Services.Discounts;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Stores
{
    public static class StoresHelper
    {
        public static object GetFinalPrice(Product product,
            Customer customer,
            decimal? overriddenProductPrice,
            decimal additionalCharge,
            bool includeDiscounts,
            int quantity,
            DateTime? rentalStartDate,
            DateTime? rentalEndDate,
            decimal discountAmount,
            List<DiscountForCaching> appliedDiscounts)
        {
            dynamic expando = new ExpandoObject();
            expando.product = product;
            expando.customer = customer;
            expando.overriddenProductPrice = overriddenProductPrice;
            expando.additionalCharge = additionalCharge;
            expando.includeDiscounts = includeDiscounts;
            expando.quantity = quantity;
            expando.rentalStartDate = rentalStartDate;
            expando.rentalEndDate = rentalEndDate;
            expando.discountAmount = discountAmount;
            expando.appliedDiscounts = appliedDiscounts;

            return APIHelper.Instance.PostAsync<object>("Catalogs", "GetFinalPrice", expando);
        }
    }
}
