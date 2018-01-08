using Nop.Core;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Discounts
{
    public partial class DiscountApiService : IDiscountService
    {
        #region Methods

        #region Discounts

        /// <summary>
        /// Delete discount
        /// </summary>
        /// <param name="discount">Discount</param>
        public virtual void DeleteDiscount(Discount discount)
        {
            APIHelper.Instance.PostAsync("Discounts", "DeleteDiscount", discount);
        }

        /// <summary>
        /// Gets a discount
        /// </summary>
        /// <param name="discountId">Discount identifier</param>
        /// <returns>Discount</returns>
        public virtual Discount GetDiscountById(int discountId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("discountId", discountId);
            return APIHelper.Instance.GetAsync<Discount>("Discounts", "GetDiscountById", parameters);
        }

        /// <summary>
        /// Gets all discounts
        /// </summary>
        /// <param name="discountType">Discount type; null to load all discount</param>
        /// <param name="couponCode">Coupon code to find (exact match)</param>
        /// <param name="discountName">Discount name</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Discounts</returns>
        public virtual IList<Discount> GetAllDiscounts(DiscountType? discountType = null,
            string couponCode = "", string discountName = "", bool showHidden = false)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("discountType", discountType);
            parameters.Add("couponCode", couponCode);
            parameters.Add("discountName", discountName);
            parameters.Add("showHidden", showHidden);
            return APIHelper.Instance.GetListAsync<Discount>("Discounts", "GetAllDiscounts", parameters);
        }

        /// <summary>
        /// Inserts a discount
        /// </summary>
        /// <param name="discount">Discount</param>
        public virtual void InsertDiscount(Discount discount)
        {
            APIHelper.Instance.PostAsync("Discounts", "InsertDiscount", discount);
        }

        /// <summary>
        /// Updates the discount
        /// </summary>
        /// <param name="discount">Discount</param>
        public virtual void UpdateDiscount(Discount discount)
        {
            APIHelper.Instance.PostAsync("Discounts", "UpdateDiscount", discount);
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
        public virtual IList<DiscountForCaching> GetAllDiscountsForCaching(DiscountType? discountType = null,
            string couponCode = "", string discountName = "", bool showHidden = false)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("discountType", discountType);
            parameters.Add("couponCode", couponCode);
            parameters.Add("discountName", discountName);
            parameters.Add("showHidden", showHidden);
            return APIHelper.Instance.GetListAsync<DiscountForCaching>("Discounts", "GetAllDiscountsForCaching", parameters);
        }

        /// <summary>
        /// Get category identifiers to which a discount is applied
        /// </summary>
        /// <param name="discount">Discount</param>
        /// <param name="customer">Customer</param>
        /// <returns>Category identifiers</returns>
        public virtual IList<int> GetAppliedCategoryIds(DiscountForCaching discount, Customer customer)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("discount", discount);
            parameters.Add("customer", customer);
            return APIHelper.Instance.GetListAsync<int>("Discounts", "GetAppliedCategoryIds", parameters);
        }

        /// <summary>
        /// Get manufacturer identifiers to which a discount is applied
        /// </summary>
        /// <param name="discount">Discount</param>
        /// <param name="customer">Customer</param>
        /// <returns>Manufacturer identifiers</returns>
        public virtual IList<int> GetAppliedManufacturerIds(DiscountForCaching discount, Customer customer)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("discount", discount);
            parameters.Add("customer", customer);
            return APIHelper.Instance.GetListAsync<int>("Discounts", "GetAppliedManufacturerIds", parameters);
        }

        #endregion

        #region Discount requirements

        /// <summary>
        /// Get all discount requirements
        /// </summary>
        /// <param name="discountId">Discont identifier</param>
        /// <param name="topLevelOnly">Whether to load top-level requirements only (without parent identifier)</param>
        /// <returns>Requirements</returns>
        public virtual IList<DiscountRequirement> GetAllDiscountRequirements(int discountId = 0, bool topLevelOnly = false)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("discountId", discountId);
            parameters.Add("topLevelOnly", topLevelOnly);
            return APIHelper.Instance.GetListAsync<DiscountRequirement>("Discounts", "GetAllDiscountRequirements", parameters);
        }

        /// <summary>
        /// Delete discount requirement
        /// </summary>
        /// <param name="discountRequirement">Discount requirement</param>
        public virtual void DeleteDiscountRequirement(DiscountRequirement discountRequirement)
        {
            APIHelper.Instance.PostAsync("Discounts", "DeleteDiscountRequirement", discountRequirement);
        }

        /// <summary>
        /// Load discount requirement rule by system name
        /// </summary>
        /// <param name="systemName">System name</param>
        /// <returns>Found discount requirement rule</returns>
        public virtual IDiscountRequirementRule LoadDiscountRequirementRuleBySystemName(string systemName)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("systemName", systemName);
            return APIHelper.Instance.GetAsync<IDiscountRequirementRule>("Discounts", "LoadDiscountRequirementRuleBySystemName", parameters);
        }

        /// <summary>
        /// Load all discount requirement rules
        /// </summary>
        /// <param name="customer">Load records allowed only to a specified customer; pass null to ignore ACL permissions</param>
        /// <returns>Discount requirement rules</returns>
        public virtual IList<IDiscountRequirementRule> LoadAllDiscountRequirementRules(Customer customer = null)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customer", customer);
            return APIHelper.Instance.GetListAsync<IDiscountRequirementRule>("Discounts", "LoadAllDiscountRequirementRules", parameters);
        }

        #endregion

        #region Validation

        /// <summary>
        /// Validate discount
        /// </summary>
        /// <param name="discount">Discount</param>
        /// <param name="customer">Customer</param>
        /// <returns>Discount validation result</returns>
        public virtual DiscountValidationResult ValidateDiscount(Discount discount, Customer customer)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("discount", discount);
            parameters.Add("customer", customer);
            return APIHelper.Instance.GetAsync<DiscountValidationResult>("Discounts", "ValidateDiscount", parameters);
        }

        /// <summary>
        /// Validate discount
        /// </summary>
        /// <param name="discount">Discount</param>
        /// <param name="customer">Customer</param>
        /// <param name="couponCodesToValidate">Coupon codes to validate</param>
        /// <returns>Discount validation result</returns>
        public virtual DiscountValidationResult ValidateDiscount(Discount discount, Customer customer, string[] couponCodesToValidate)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("discount", discount);
            parameters.Add("customer", customer);
            parameters.Add("couponCodesToValidate", couponCodesToValidate);
            return APIHelper.Instance.GetAsync<DiscountValidationResult>("Discounts", "ValidateDiscount", parameters);
        }

        /// <summary>
        /// Validate discount
        /// </summary>
        /// <param name="discount">Discount</param>
        /// <param name="customer">Customer</param>
        /// <returns>Discount validation result</returns>
        public virtual DiscountValidationResult ValidateDiscount(DiscountForCaching discount, Customer customer)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("discount", discount);
            parameters.Add("customer", customer);
            return APIHelper.Instance.GetAsync<DiscountValidationResult>("Discounts", "ValidateDiscount", parameters);
        }

        /// <summary>
        /// Validate discount
        /// </summary>
        /// <param name="discount">Discount</param>
        /// <param name="customer">Customer</param>
        /// <param name="couponCodesToValidate">Coupon codes to validate</param>
        /// <returns>Discount validation result</returns>
        public virtual DiscountValidationResult ValidateDiscount(DiscountForCaching discount, Customer customer, string[] couponCodesToValidate)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("discount", discount);
            parameters.Add("customer", customer);
            parameters.Add("couponCodesToValidate", couponCodesToValidate);
            return APIHelper.Instance.GetAsync<DiscountValidationResult>("Discounts", "ValidateDiscount", parameters);
        }

        #endregion

        #region Discount usage history

        /// <summary>
        /// Gets a discount usage history record
        /// </summary>
        /// <param name="discountUsageHistoryId">Discount usage history record identifier</param>
        /// <returns>Discount usage history</returns>
        public virtual DiscountUsageHistory GetDiscountUsageHistoryById(int discountUsageHistoryId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("discountUsageHistoryId", discountUsageHistoryId);
            return APIHelper.Instance.GetAsync<DiscountUsageHistory>("Discounts", "GetDiscountUsageHistoryById", parameters);
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
        public virtual IPagedList<DiscountUsageHistory> GetAllDiscountUsageHistory(int? discountId = null,
            int? customerId = null, int? orderId = null,
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("discountId", discountId);
            parameters.Add("customerId", customerId);
            parameters.Add("orderId", orderId);
            parameters.Add("pageIndex", pageIndex);
            parameters.Add("pageSize", pageSize);
            return APIHelper.Instance.GetPagedListAsync<DiscountUsageHistory>("Discounts", "GetAllDiscountUsageHistory", parameters);
        }

        /// <summary>
        /// Insert discount usage history record
        /// </summary>
        /// <param name="discountUsageHistory">Discount usage history record</param>
        public virtual void InsertDiscountUsageHistory(DiscountUsageHistory discountUsageHistory)
        {
            APIHelper.Instance.PostAsync("Directory", "InsertDiscountUsageHistory", discountUsageHistory);
        }

        /// <summary>
        /// Update discount usage history record
        /// </summary>
        /// <param name="discountUsageHistory">Discount usage history record</param>
        public virtual void UpdateDiscountUsageHistory(DiscountUsageHistory discountUsageHistory)
        {
            APIHelper.Instance.PostAsync("Directory", "UpdateDiscountUsageHistory", discountUsageHistory);
        }

        /// <summary>
        /// Delete discount usage history record
        /// </summary>
        /// <param name="discountUsageHistory">Discount usage history record</param>
        public virtual void DeleteDiscountUsageHistory(DiscountUsageHistory discountUsageHistory)
        {
            APIHelper.Instance.PostAsync("Directory", "DeleteDiscountUsageHistory", discountUsageHistory);
        }

        #endregion

        #endregion
    }
}
