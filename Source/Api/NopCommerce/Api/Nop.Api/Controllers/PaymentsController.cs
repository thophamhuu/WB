using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Orders;
using Nop.Services.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nop.Api.Controllers
{
    [Authorize]
    public class PaymentsController : ApiController
    {
        #region Fields

        private readonly IPaymentService _paymentService;

        #endregion

        #region Ctor

        public PaymentsController(IPaymentService paymentService)
        {
            this._paymentService = paymentService;
        }

        #endregion

        #region Method

        #region Payment methods

        /// <summary>
        /// Load active payment methods
        /// </summary>
        /// <param name="customer">Load records allowed only to a specified customer; pass null to ignore ACL permissions</param>
        /// <param name="storeId">Load records allowed only in a specified store; pass 0 to load all records</param>
        /// <param name="filterByCountryId">Load records allowed only in a specified country; pass 0 to load all records</param>
        /// <returns>Payment methods</returns>
        public IList<IPaymentMethod> LoadActivePaymentMethods(Customer customer = null, int storeId = 0, int filterByCountryId = 0)
        {
            return _paymentService.LoadActivePaymentMethods(customer, storeId, filterByCountryId);
        }

        /// <summary>
        /// Load payment provider by system name
        /// </summary>
        /// <param name="systemName">System name</param>
        /// <returns>Found payment provider</returns>
        public IPaymentMethod LoadPaymentMethodBySystemName(string systemName)
        {
            return _paymentService.LoadPaymentMethodBySystemName(systemName);
        }

        /// <summary>
        /// Load all payment providers
        /// </summary>
        /// <param name="customer">Load records allowed only to a specified customer; pass null to ignore ACL permissions</param>
        /// <param name="storeId">Load records allowed only in a specified store; pass 0 to load all records</param>
        /// <param name="filterByCountryId">Load records allowed only in a specified country; pass 0 to load all records</param>
        /// <returns>Payment providers</returns>
        public IList<IPaymentMethod> LoadAllPaymentMethods(Customer customer = null, int storeId = 0, int filterByCountryId = 0)
        {
            return _paymentService.LoadAllPaymentMethods(customer, storeId, filterByCountryId);
        }

        #endregion

        #region Restrictions

        /// <summary>
        /// Gets a list of coutnry identifiers in which a certain payment method is now allowed
        /// </summary>
        /// <param name="paymentMethod">Payment method</param>
        /// <returns>A list of country identifiers</returns>
        public IList<int> GetRestictedCountryIds(IPaymentMethod paymentMethod)
        {
            return _paymentService.GetRestictedCountryIds(paymentMethod);
        }

        /// <summary>
        /// Saves a list of coutnry identifiers in which a certain payment method is now allowed
        /// </summary>
        /// <param name="paymentMethod">Payment method</param>
        /// <param name="countryIds">A list of country identifiers</param>
        public void SaveRestictedCountryIds(IPaymentMethod paymentMethod, List<int> countryIds)
        {
            _paymentService.SaveRestictedCountryIds(paymentMethod, countryIds);
        }

        #endregion

        #region Processing

        /// <summary>
        /// Process a payment
        /// </summary>
        /// <param name="processPaymentRequest">Payment info required for an order processing</param>
        /// <returns>Process payment result</returns>
        public ProcessPaymentResult ProcessPayment(ProcessPaymentRequest processPaymentRequest)
        {
            return _paymentService.ProcessPayment(processPaymentRequest);
        }

        /// <summary>
        /// Post process payment (used by payment gateways that require redirecting to a third-party URL)
        /// </summary>
        /// <param name="postProcessPaymentRequest">Payment info required for an order processing</param>
        public void PostProcessPayment(PostProcessPaymentRequest postProcessPaymentRequest)
        {
            _paymentService.PostProcessPayment(postProcessPaymentRequest);
        }

        /// <summary>
        /// Gets a value indicating whether customers can complete a payment after order is placed but not completed (for redirection payment methods)
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>Result</returns>
        public bool CanRePostProcessPayment(Order order)
        {
            return _paymentService.CanRePostProcessPayment(order);
        }

        /// <summary>
        /// Gets an additional handling fee of a payment method
        /// </summary>
        /// <param name="cart">Shoping cart</param>
        /// <param name="paymentMethodSystemName">Payment method system name</param>
        /// <returns>Additional handling fee</returns>
        public decimal GetAdditionalHandlingFee(IList<ShoppingCartItem> cart, string paymentMethodSystemName)
        {
            return _paymentService.GetAdditionalHandlingFee(cart, paymentMethodSystemName);
        }

        /// <summary>
        /// Gets a value indicating whether capture is supported by payment method
        /// </summary>
        /// <param name="paymentMethodSystemName">Payment method system name</param>
        /// <returns>A value indicating whether capture is supported</returns>
        public bool SupportCapture(string paymentMethodSystemName)
        {
            return _paymentService.SupportCapture(paymentMethodSystemName);
        }

        /// <summary>
        /// Captures payment
        /// </summary>
        /// <param name="capturePaymentRequest">Capture payment request</param>
        /// <returns>Capture payment result</returns>
        public CapturePaymentResult Capture(CapturePaymentRequest capturePaymentRequest)
        {
            return _paymentService.Capture(capturePaymentRequest);
        }

        /// <summary>
        /// Gets a value indicating whether partial refund is supported by payment method
        /// </summary>
        /// <param name="paymentMethodSystemName">Payment method system name</param>
        /// <returns>A value indicating whether partial refund is supported</returns>
        public bool SupportPartiallyRefund(string paymentMethodSystemName)
        {
            return _paymentService.SupportPartiallyRefund(paymentMethodSystemName);
        }

        /// <summary>
        /// Gets a value indicating whether refund is supported by payment method
        /// </summary>
        /// <param name="paymentMethodSystemName">Payment method system name</param>
        /// <returns>A value indicating whether refund is supported</returns>
        public bool SupportRefund(string paymentMethodSystemName)
        {
            return _paymentService.SupportPartiallyRefund(paymentMethodSystemName);
        }

        /// <summary>
        /// Refunds a payment
        /// </summary>
        /// <param name="refundPaymentRequest">Request</param>
        /// <returns>Result</returns>
        public RefundPaymentResult Refund(RefundPaymentRequest refundPaymentRequest)
        {
            return _paymentService.Refund(refundPaymentRequest);
        }

        /// <summary>
        /// Gets a value indicating whether void is supported by payment method
        /// </summary>
        /// <param name="paymentMethodSystemName">Payment method system name</param>
        /// <returns>A value indicating whether void is supported</returns>
        public bool SupportVoid(string paymentMethodSystemName)
        {
            return _paymentService.SupportVoid(paymentMethodSystemName);
        }

        /// <summary>
        /// Voids a payment
        /// </summary>
        /// <param name="voidPaymentRequest">Request</param>
        /// <returns>Result</returns>
        public VoidPaymentResult Void(VoidPaymentRequest voidPaymentRequest)
        {
            return _paymentService.Void(voidPaymentRequest);
        }

        /// <summary>
        /// Gets a recurring payment type of payment method
        /// </summary>
        /// <param name="paymentMethodSystemName">Payment method system name</param>
        /// <returns>A recurring payment type of payment method</returns>
        public RecurringPaymentType GetRecurringPaymentType(string paymentMethodSystemName)
        {
            return _paymentService.GetRecurringPaymentType(paymentMethodSystemName);
        }

        /// <summary>
        /// Process recurring payment
        /// </summary>
        /// <param name="processPaymentRequest">Payment info required for an order processing</param>
        /// <returns>Process payment result</returns>
        public ProcessPaymentResult ProcessRecurringPayment(ProcessPaymentRequest processPaymentRequest)
        {
            return _paymentService.ProcessRecurringPayment(processPaymentRequest);
        }

        /// <summary>
        /// Cancels a recurring payment
        /// </summary>
        /// <param name="cancelPaymentRequest">Request</param>
        /// <returns>Result</returns>
        public CancelRecurringPaymentResult CancelRecurringPayment(CancelRecurringPaymentRequest cancelPaymentRequest)
        {
            return _paymentService.CancelRecurringPayment(cancelPaymentRequest);
        }

        /// <summary>
        /// Gets masked credit card number
        /// </summary>
        /// <param name="creditCardNumber">Credit card number</param>
        /// <returns>Masked credit card number</returns>
        public string GetMaskedCreditCardNumber(string creditCardNumber)
        {
            return _paymentService.GetMaskedCreditCardNumber(creditCardNumber);
        }

        #endregion

        #endregion
    }
}
