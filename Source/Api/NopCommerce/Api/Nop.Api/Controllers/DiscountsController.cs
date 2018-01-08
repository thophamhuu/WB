using Nop.Core;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Discounts;
using Nop.Services.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nop.Api.Controllers
{
    [Authorize]
    public class DiscountsController : ApiController
    {
        #region Fields

        private readonly IDiscountService _discountService;

        #endregion

        #region Ctor

        public DiscountsController(IDiscountService discountService)
        {
            this._discountService = discountService;
        }

        #endregion

        #region Method

        #region Discounts

        /// <summary>
        /// Delete discount
        /// </summary>
        /// <param name="discount">Discount</param>
        public void DeleteDiscount(Discount discount)
        {
            _discountService.DeleteDiscount(discount);
        }

        /// <summary>
        /// Gets a discount
        /// </summary>
        /// <param name="discountId">Discount identifier</param>
        /// <returns>Discount</returns>
        public Discount GetDiscountById(int discountId)
        {
            return _discountService.GetDiscountById(discountId);
        }

        /// <summary>
        /// Gets all discounts
        /// </summary>
        /// <param name="discountType">Discount type; null to load all discount</param>
        /// <param name="couponCode">Coupon code to find (exact match)</param>
        /// <param name="discountName">Discount name</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Discounts</returns>
        public IList<Discount> GetAllDiscounts(DiscountType? discountType = null,
            string couponCode = "", string discountName = "", bool showHidden = false)
        {
            return _discountService.GetAllDiscounts(discountType, couponCode, discountName, showHidden);
        }

        /// <summary>
        /// Inserts a discount
        /// </summary>
        /// <param name="discount">Discount</param>
        public void InsertDiscount(Discount discount)
        {
            _discountService.InsertDiscount(discount);
        }

        /// <summary>
        /// Updates the discount
        /// </summary>
        /// <param name="discount">Discount</param>
        public void UpdateDiscount(Discount discount)
        {
            _discountService.UpdateDiscount(discount);
        }

        #endregion

        #region Discounts (caching)

        /// <summary>
        /// Gets all discounts (cachable models)
        /// </summary>
        /// <param name="discountType">Discount type; null to load all discount</param>
        /// <param name="couponCode">Coupon code to find (exact match)</param>
        /// <param name="discountName">Discount name</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Discounts</returns>
        public IList<DiscountForCaching> GetAllDiscountsForCaching(DiscountType? discountType = null,
            string couponCode = "", string discountName = "", bool showHidden = false)
        {
            return _discountService.GetAllDiscountsForCaching(discountType, couponCode, discountName, showHidden);
        }

        /// <summary>
        /// Get category identifiers to which a discount is applied
        /// </summary>
        /// <param name="discount">Discount</param>
        /// <param name="customer">Customer</param>
        /// <returns>Category identifiers</returns>
        public IList<int> GetAppliedCategoryIds(DiscountForCaching discount, Customer customer)
        {
            return _discountService.GetAppliedCategoryIds(discount, customer);
        }

        /// <summary>
        /// Get manufacturer identifiers to which a discount is applied
        /// </summary>
        /// <param name="discount">Discount</param>
        /// <param name="customer">Customer</param>
        /// <returns>Manufacturer identifiers</returns>
        public IList<int> GetAppliedManufacturerIds(DiscountForCaching discount, Customer customer)
        {
            return _discountService.GetAppliedManufacturerIds(discount, customer);
        }

        #endregion

        #region Discount requirements

        /// <summary>
        /// Get all discount requirements
        /// </summary>
        /// <param name="discountId">Discont identifier</param>
        /// <param name="topLevelOnly">Whether to load top-level requirements only (without parent identifier)</param>
        /// <returns>Requirements</returns>
        public IList<DiscountRequirement> GetAllDiscountRequirements(int discountId = 0, bool topLevelOnly = false)
        {
            return _discountService.GetAllDiscountRequirements(discountId, topLevelOnly);
        }

        /// <summary>
        /// Delete discount requirement
        /// </summary>
        /// <param name="discountRequirement">Discount requirement</param>
        public void DeleteDiscountRequirement(DiscountRequirement discountRequirement)
        {
            _discountService.DeleteDiscountRequirement(discountRequirement);
        }

        /// <summary>
        /// Load discount requirement rule by system name
        /// </summary>
        /// <param name="systemName">System name</param>
        /// <returns>Found discount requirement rule</returns>
        public IDiscountRequirementRule LoadDiscountRequirementRuleBySystemName(string systemName)
        {
            return _discountService.LoadDiscountRequirementRuleBySystemName(systemName);
        }

        /// <summary>
        /// Load all discount requirement rules
        /// </summary>
        /// <param name="customer">Load records allowed only to a specified customer; pass null to ignore ACL permissions</param>
        /// <returns>Discount requirement rules</returns>
        public IList<IDiscountRequirementRule> LoadAllDiscountRequirementRules(Customer customer = null)
        {
            return _discountService.LoadAllDiscountRequirementRules(customer);
        }

        #endregion

        #region Validation

        /// <summary>
        /// Validate discount
        /// </summary>
        /// <param name="discount">Discount</param>
        /// <param name="customer">Customer</param>
        /// <returns>Discount validation result</returns>
        public DiscountValidationResult ValidateDiscount(Discount discount, Customer customer)
        {
            return _discountService.ValidateDiscount(discount, customer);
        }

        /// <summary>
        /// Validate discount
        /// </summary>
        /// <param name="discount">Discount</param>
        /// <param name="customer">Customer</param>
        /// <param name="couponCodesToValidate">Coupon codes to validate</param>
        /// <returns>Discount validation result</returns>
        public DiscountValidationResult ValidateDiscount(Discount discount, Customer customer, string[] couponCodesToValidate)
        {
            return _discountService.ValidateDiscount(discount, customer, couponCodesToValidate);
        }

        /// <summary>
        /// Validate discount
        /// </summary>
        /// <param name="discount">Discount</param>
        /// <param name="customer">Customer</param>
        /// <returns>Discount validation result</returns>
        public DiscountValidationResult ValidateDiscount(DiscountForCaching discount, Customer customer)
        {
            return _discountService.ValidateDiscount(discount, customer);
        }

        /// <summary>
        /// Validate discount
        /// </summary>
        /// <param name="discount">Discount</param>
        /// <param name="customer">Customer</param>
        /// <param name="couponCodesToValidate">Coupon codes to validate</param>
        /// <returns>Discount validation result</returns>
        public DiscountValidationResult ValidateDiscount(DiscountForCaching discount, Customer customer, string[] couponCodesToValidate)
        {
            return _discountService.ValidateDiscount(discount, customer, couponCodesToValidate);
        }

        #endregion

        #region Discount usage history

        /// <summary>
        /// Gets a discount usage history record
        /// </summary>
        /// <param name="discountUsageHistoryId">Discount usage history record identifier</param>
        /// <returns>Discount usage history</returns>
        public DiscountUsageHistory GetDiscountUsageHistoryById(int discountUsageHistoryId)
        {
            return _discountService.GetDiscountUsageHistoryById(discountUsageHistoryId);
        }

        /// <summary>
        /// Gets all discount usage history records
        /// </summary>
        /// <param name="discountId">Discount identifier; null to load all records</param>
        /// <param name="customerId">Customer identifier; null to load all records</param>
        /// <param name="orderId">Order identifier; null to load all records</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Discount usage history records</returns>
        public IAPIPagedList<DiscountUsageHistory> GetAllDiscountUsageHistory(int? discountId = null,
            int? customerId = null, int? orderId = null,
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return _discountService.GetAllDiscountUsageHistory(discountId, customerId, orderId, pageIndex, pageSize).ConvertPagedListToAPIPagedList();
        }

        /// <summary>
        /// Insert discount usage history record
        /// </summary>
        /// <param name="discountUsageHistory">Discount usage history record</param>
        public void InsertDiscountUsageHistory(DiscountUsageHistory discountUsageHistory)
        {
            _discountService.InsertDiscountUsageHistory(discountUsageHistory);
        }

        /// <summary>
        /// Update discount usage history record
        /// </summary>
        /// <param name="discountUsageHistory">Discount usage history record</param>
        public void UpdateDiscountUsageHistory(DiscountUsageHistory discountUsageHistory)
        {
            _discountService.UpdateDiscountUsageHistory(discountUsageHistory);
        }

        /// <summary>
        /// Delete discount usage history record
        /// </summary>
        /// <param name="discountUsageHistory">Discount usage history record</param>
        public void DeleteDiscountUsageHistory(DiscountUsageHistory discountUsageHistory)
        {
            _discountService.DeleteDiscountUsageHistory(discountUsageHistory);
        }

        #endregion

        #endregion
    }
}
