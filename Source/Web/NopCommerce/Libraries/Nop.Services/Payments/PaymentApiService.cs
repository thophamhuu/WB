using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Payments
{
    public partial class PaymentApiService : IPaymentService
    {
        #region Methods

        #region Payment methods

        /// <summary>
        /// Load active payment methods
        /// </summary>
        /// <param name="customer">Load records allowed only to a specified customer; pass null to ignore ACL permissions</param>
        /// <param name="storeId">Load records allowed only in a specified store; pass 0 to load all records</param>
        /// <param name="filterByCountryId">Load records allowed only in a specified country; pass 0 to load all records</param>
        /// <returns>Payment methods</returns>
        public virtual IList<IPaymentMethod> LoadActivePaymentMethods(Customer customer = null, int storeId = 0, int filterByCountryId = 0)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customer", customer);
            parameters.Add("storeId", storeId);
            parameters.Add("filterByCountryId", filterByCountryId);
            return APIHelper.Instance.GetListAsync<IPaymentMethod>("Payments", "LoadActivePaymentMethods", parameters);
        }

        /// <summary>
        /// Load payment provider by system name
        /// </summary>
        /// <param name="systemName">System name</param>
        /// <returns>Found payment provider</returns>
        public virtual IPaymentMethod LoadPaymentMethodBySystemName(string systemName)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("systemName", systemName);
            return APIHelper.Instance.GetAsync<IPaymentMethod>("Payments", "LoadPaymentMethodBySystemName", parameters);
        }

        /// <summary>
        /// Load all payment providers
        /// </summary>
        /// <param name="customer">Load records allowed only to a specified customer; pass null to ignore ACL permissions</param>
        /// <param name="storeId">Load records allowed only in a specified store; pass 0 to load all records</param>
        /// <param name="filterByCountryId">Load records allowed only in a specified country; pass 0 to load all records</param>
        /// <returns>Payment providers</returns>
        public virtual IList<IPaymentMethod> LoadAllPaymentMethods(Customer customer = null, int storeId = 0, int filterByCountryId = 0)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customer", customer);
            parameters.Add("storeId", storeId);
            parameters.Add("filterByCountryId", filterByCountryId);
            return APIHelper.Instance.GetListAsync<IPaymentMethod>("Payments", "LoadAllPaymentMethods", parameters);
        }

        #endregion

        #region Restrictions

        /// <summary>
        /// Gets a list of coutnry identifiers in which a certain payment method is now allowed
        /// </summary>
        /// <param name="paymentMethod">Payment method</param>
        /// <returns>A list of country identifiers</returns>
        public virtual IList<int> GetRestictedCountryIds(IPaymentMethod paymentMethod)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("paymentMethod", paymentMethod);
            return APIHelper.Instance.GetListAsync<int>("Payments", "GetRestictedCountryIds", parameters);
        }

        /// <summary>
        /// Saves a list of coutnry identifiers in which a certain payment method is now allowed
        /// </summary>
        /// <param name="paymentMethod">Payment method</param>
        /// <param name="countryIds">A list of country identifiers</param>
        public virtual void SaveRestictedCountryIds(IPaymentMethod paymentMethod, List<int> countryIds)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("paymentMethod", paymentMethod);
            parameters.Add("countryIds", countryIds);
            APIHelper.Instance.GetListAsync<int>("Payments", "SaveRestictedCountryIds", parameters);
        }

        #endregion

        #region Processing

        /// <summary>
        /// Process a payment
        /// </summary>
        /// <param name="processPaymentRequest">Payment info required for an order processing</param>
        /// <returns>Process payment result</returns>
        public virtual ProcessPaymentResult ProcessPayment(ProcessPaymentRequest processPaymentRequest)
        {
            return APIHelper.Instance.PostAsync<ProcessPaymentResult>("Payments", "ProcessPayment", processPaymentRequest);
        }

        /// <summary>
        /// Post process payment (used by payment gateways that require redirecting to a third-party URL)
        /// </summary>
        /// <param name="postProcessPaymentRequest">Payment info required for an order processing</param>
        public virtual void PostProcessPayment(PostProcessPaymentRequest postProcessPaymentRequest)
        {
            APIHelper.Instance.PostAsync("Payments", "PostProcessPayment", postProcessPaymentRequest);
        }

        /// <summary>
        /// Gets a value indicating whether customers can complete a payment after order is placed but not completed (for redirection payment methods)
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>Result</returns>
        public virtual bool CanRePostProcessPayment(Order order)
        {
            return APIHelper.Instance.PostAsync<bool>("Payments", "CanRePostProcessPayment", order);
        }

        /// <summary>
        /// Gets an additional handling fee of a payment method
        /// </summary>
        /// <param name="cart">Shoping cart</param>
        /// <param name="paymentMethodSystemName">Payment method system name</param>
        /// <returns>Additional handling fee</returns>
        public virtual decimal GetAdditionalHandlingFee(IList<ShoppingCartItem> cart, string paymentMethodSystemName)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("cart", cart);
            parameters.Add("paymentMethodSystemName", paymentMethodSystemName);
            return APIHelper.Instance.GetAsync<decimal>("Payments", "GetAdditionalHandlingFee", parameters);
        }

        /// <summary>
        /// Gets a value indicating whether capture is supported by payment method
        /// </summary>
        /// <param name="paymentMethodSystemName">Payment method system name</param>
        /// <returns>A value indicating whether capture is supported</returns>
        public virtual bool SupportCapture(string paymentMethodSystemName)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("paymentMethodSystemName", paymentMethodSystemName);
            return APIHelper.Instance.GetAsync<bool>("Payments", "SupportCapture", parameters);
        }

        /// <summary>
        /// Captures payment
        /// </summary>
        /// <param name="capturePaymentRequest">Capture payment request</param>
        /// <returns>Capture payment result</returns>
        public virtual CapturePaymentResult Capture(CapturePaymentRequest capturePaymentRequest)
        {
            return APIHelper.Instance.PostAsync<CapturePaymentResult>("Payments", "Capture", capturePaymentRequest);
        }

        /// <summary>
        /// Gets a value indicating whether partial refund is supported by payment method
        /// </summary>
        /// <param name="paymentMethodSystemName">Payment method system name</param>
        /// <returns>A value indicating whether partial refund is supported</returns>
        public virtual bool SupportPartiallyRefund(string paymentMethodSystemName)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("paymentMethodSystemName", paymentMethodSystemName);
            return APIHelper.Instance.GetAsync<bool>("Payments", "SupportPartiallyRefund", parameters);
        }

        /// <summary>
        /// Gets a value indicating whether refund is supported by payment method
        /// </summary>
        /// <param name="paymentMethodSystemName">Payment method system name</param>
        /// <returns>A value indicating whether refund is supported</returns>
        public virtual bool SupportRefund(string paymentMethodSystemName)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("paymentMethodSystemName", paymentMethodSystemName);
            return APIHelper.Instance.GetAsync<bool>("Payments", "SupportRefund", parameters);
        }

        /// <summary>
        /// Refunds a payment
        /// </summary>
        /// <param name="refundPaymentRequest">Request</param>
        /// <returns>Result</returns>
        public virtual RefundPaymentResult Refund(RefundPaymentRequest refundPaymentRequest)
        {
            return APIHelper.Instance.PostAsync<RefundPaymentResult>("Payments", "Refund", refundPaymentRequest);
        }

        /// <summary>
        /// Gets a value indicating whether void is supported by payment method
        /// </summary>
        /// <param name="paymentMethodSystemName">Payment method system name</param>
        /// <returns>A value indicating whether void is supported</returns>
        public virtual bool SupportVoid(string paymentMethodSystemName)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("paymentMethodSystemName", paymentMethodSystemName);
            return APIHelper.Instance.GetAsync<bool>("Payments", "SupportVoid", parameters);
        }

        /// <summary>
        /// Voids a payment
        /// </summary>
        /// <param name="voidPaymentRequest">Request</param>
        /// <returns>Result</returns>
        public virtual VoidPaymentResult Void(VoidPaymentRequest voidPaymentRequest)
        {
            return APIHelper.Instance.PostAsync<VoidPaymentResult>("Payments", "Void", voidPaymentRequest);
        }

        /// <summary>
        /// Gets a recurring payment type of payment method
        /// </summary>
        /// <param name="paymentMethodSystemName">Payment method system name</param>
        /// <returns>A recurring payment type of payment method</returns>
        public virtual RecurringPaymentType GetRecurringPaymentType(string paymentMethodSystemName)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("paymentMethodSystemName", paymentMethodSystemName);
            return APIHelper.Instance.GetAsync<RecurringPaymentType>("Payments", "GetRecurringPaymentType", parameters);
        }

        /// <summary>
        /// Process recurring payment
        /// </summary>
        /// <param name="processPaymentRequest">Payment info required for an order processing</param>
        /// <returns>Process payment result</returns>
        public virtual ProcessPaymentResult ProcessRecurringPayment(ProcessPaymentRequest processPaymentRequest)
        {
            return APIHelper.Instance.PostAsync<ProcessPaymentResult>("Payments", "ProcessRecurringPayment", processPaymentRequest);
        }

        /// <summary>
        /// Cancels a recurring payment
        /// </summary>
        /// <param name="cancelPaymentRequest">Request</param>
        /// <returns>Result</returns>
        public virtual CancelRecurringPaymentResult CancelRecurringPayment(CancelRecurringPaymentRequest cancelPaymentRequest)
        {
            return APIHelper.Instance.PostAsync<CancelRecurringPaymentResult>("Payments", "CancelRecurringPayment", cancelPaymentRequest);
        }

        /// <summary>
        /// Gets masked credit card number
        /// </summary>
        /// <param name="creditCardNumber">Credit card number</param>
        /// <returns>Masked credit card number</returns>
        public virtual string GetMaskedCreditCardNumber(string creditCardNumber)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("creditCardNumber", creditCardNumber);
            return APIHelper.Instance.GetAsync<string>("Payments", "GetMaskedCreditCardNumber", parameters);
        }

        #endregion

        #endregion
    }
}
