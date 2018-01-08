using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Shipping;
using Nop.Services.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Orders
{
    public partial class OrderProcessingApiService : IOrderProcessingService
    {
        #region Methods

        /// <summary>
        /// Checks order status
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>Validated order</returns>
        public virtual void CheckOrderStatus(Order order)
        {
            APIHelper.Instance.PostAsync("OrderProcessings", "CheckOrderStatus", order);
        }

        /// <summary>
        /// Places an order
        /// </summary>
        /// <param name="processPaymentRequest">Process payment request</param>
        /// <returns>Place order result</returns>
        public virtual PlaceOrderResult PlaceOrder(ProcessPaymentRequest processPaymentRequest)
        {
            return APIHelper.Instance.PostAsync<PlaceOrderResult>("OrderProcessings", "PlaceOrder", processPaymentRequest);
        }

        /// <summary>
        /// Update order totals
        /// </summary>
        /// <param name="updateOrderParameters">Parameters for the updating order</param>
        public virtual void UpdateOrderTotals(UpdateOrderParameters updateOrderParameters)
        {
            APIHelper.Instance.PostAsync("OrderProcessings", "UpdateOrderTotals", updateOrderParameters);
        }

        /// <summary>
        /// Deletes an order
        /// </summary>
        /// <param name="order">The order</param>
        public virtual void DeleteOrder(Order order)
        {
            APIHelper.Instance.PostAsync("OrderProcessings", "DeleteOrder", order);
        }

        /// <summary>
        /// Process next recurring payment
        /// </summary>
        /// <param name="recurringPayment">Recurring payment</param>
        /// <param name="paymentResult">Process payment result (info about last payment for automatic recurring payments)</param>
        /// <returns>Collection of errors</returns>
        public virtual IEnumerable<string> ProcessNextRecurringPayment(RecurringPayment recurringPayment, ProcessPaymentResult paymentResult = null)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("recurringPayment", recurringPayment);
            parameters.Add("paymentResult", paymentResult);
            return APIHelper.Instance.GetAsync<IEnumerable<string>>("OrderProcessings", "ProcessNextRecurringPayment", parameters);
        }

        /// <summary>
        /// Cancels a recurring payment
        /// </summary>
        /// <param name="recurringPayment">Recurring payment</param>
        public virtual IList<string> CancelRecurringPayment(RecurringPayment recurringPayment)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("recurringPayment", recurringPayment);
            return APIHelper.Instance.GetAsync<IList<string>>("OrderProcessings", "CancelRecurringPayment", parameters);
        }

        /// <summary>
        /// Gets a value indicating whether a customer can cancel recurring payment
        /// </summary>
        /// <param name="customerToValidate">Customer</param>
        /// <param name="recurringPayment">Recurring Payment</param>
        /// <returns>value indicating whether a customer can cancel recurring payment</returns>
        public virtual bool CanCancelRecurringPayment(Customer customerToValidate, RecurringPayment recurringPayment)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customerToValidate", customerToValidate);
            parameters.Add("recurringPayment", recurringPayment);
            return APIHelper.Instance.GetAsync<bool>("OrderProcessings", "CanCancelRecurringPayment", parameters);
        }


        /// <summary>
        /// Gets a value indicating whether a customer can retry last failed recurring payment
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="recurringPayment">Recurring Payment</param>
        /// <returns>True if a customer can retry payment; otherwise false</returns>
        public virtual bool CanRetryLastRecurringPayment(Customer customer, RecurringPayment recurringPayment)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customer", customer);
            parameters.Add("recurringPayment", recurringPayment);
            return APIHelper.Instance.GetAsync<bool>("OrderProcessings", "CanRetryLastRecurringPayment", parameters);
        }


        /// <summary>
        /// Send a shipment
        /// </summary>
        /// <param name="shipment">Shipment</param>
        /// <param name="notifyCustomer">True to notify customer</param>
        public virtual void Ship(Shipment shipment, bool notifyCustomer)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("notifyCustomer", notifyCustomer);
            APIHelper.Instance.PostAsync("OrderProcessings", "Ship", shipment, parameters);
        }

        /// <summary>
        /// Marks a shipment as delivered
        /// </summary>
        /// <param name="shipment">Shipment</param>
        /// <param name="notifyCustomer">True to notify customer</param>
        public virtual void Deliver(Shipment shipment, bool notifyCustomer)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("notifyCustomer", notifyCustomer);
            APIHelper.Instance.PostAsync("OrderProcessings", "Deliver", shipment, parameters);
        }



        /// <summary>
        /// Gets a value indicating whether cancel is allowed
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>A value indicating whether cancel is allowed</returns>
        public virtual bool CanCancelOrder(Order order)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("order", order);
            return APIHelper.Instance.GetAsync<bool>("OrderProcessings", "CanCancelOrder", parameters);
        }

        /// <summary>
        /// Cancels order
        /// </summary>
        /// <param name="order">Order</param>
        /// <param name="notifyCustomer">True to notify customer</param>
        public virtual void CancelOrder(Order order, bool notifyCustomer)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("notifyCustomer", notifyCustomer);
            APIHelper.Instance.PostAsync("OrderProcessings", "CancelOrder", order, parameters);
        }

        /// <summary>
        /// Gets a value indicating whether order can be marked as authorized
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>A value indicating whether order can be marked as authorized</returns>
        public virtual bool CanMarkOrderAsAuthorized(Order order)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("order", order);
            return APIHelper.Instance.GetAsync<bool>("OrderProcessings", "CanMarkOrderAsAuthorized", parameters);
        }

        /// <summary>
        /// Marks order as authorized
        /// </summary>
        /// <param name="order">Order</param>
        public virtual void MarkAsAuthorized(Order order)
        {
            APIHelper.Instance.PostAsync("OrderProcessings", "MarkAsAuthorized", order);
        }


        /// <summary>
        /// Gets a value indicating whether capture from admin panel is allowed
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>A value indicating whether capture from admin panel is allowed</returns>
        public virtual bool CanCapture(Order order)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("order", order);
            return APIHelper.Instance.GetAsync<bool>("OrderProcessings", "CanCapture", parameters);
        }

        /// <summary>
        /// Capture an order (from admin panel)
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>A list of errors; empty list if no errors</returns>
        public virtual IList<string> Capture(Order order)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("order", order);
            return APIHelper.Instance.GetAsync<IList<string>>("OrderProcessings", "Capture", parameters);
        }

        /// <summary>
        /// Gets a value indicating whether order can be marked as paid
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>A value indicating whether order can be marked as paid</returns>
        public virtual bool CanMarkOrderAsPaid(Order order)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("order", order);
            return APIHelper.Instance.GetAsync<bool>("OrderProcessings", "CanMarkOrderAsPaid", parameters);
        }

        /// <summary>
        /// Marks order as paid
        /// </summary>
        /// <param name="order">Order</param>
        public virtual void MarkOrderAsPaid(Order order)
        {
            APIHelper.Instance.PostAsync("OrderProcessings", "MarkOrderAsPaid", order);
        }
        

        /// <summary>
        /// Gets a value indicating whether refund from admin panel is allowed
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>A value indicating whether refund from admin panel is allowed</returns>
        public virtual bool CanRefund(Order order)
        {
            return APIHelper.Instance.PostAsync<bool>("OrderProcessings", "CanRefund", order);
        }

        /// <summary>
        /// Refunds an order (from admin panel)
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>A list of errors; empty list if no errors</returns>
        public virtual IList<string> Refund(Order order)
        {
            return APIHelper.Instance.PostAsync<IList<string>>("OrderProcessings", "Refund", order);
        }

        /// <summary>
        /// Gets a value indicating whether order can be marked as refunded
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>A value indicating whether order can be marked as refunded</returns>
        public virtual bool CanRefundOffline(Order order)
        {
            return APIHelper.Instance.PostAsync<bool>("OrderProcessings", "CanRefundOffline", order);
        }

        /// <summary>
        /// Refunds an order (offline)
        /// </summary>
        /// <param name="order">Order</param>
        public virtual void RefundOffline(Order order)
        {
            APIHelper.Instance.PostAsync<bool>("OrderProcessings", "RefundOffline", order);
        }

        /// <summary>
        /// Gets a value indicating whether partial refund from admin panel is allowed
        /// </summary>
        /// <param name="order">Order</param>
        /// <param name="amountToRefund">Amount to refund</param>
        /// <returns>A value indicating whether refund from admin panel is allowed</returns>
        public virtual bool CanPartiallyRefund(Order order, decimal amountToRefund)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("amountToRefund", amountToRefund);
            return APIHelper.Instance.PostAsync<bool>("OrderProcessings", "CanPartiallyRefund", order, parameters);
        }

        /// <summary>
        /// Partially refunds an order (from admin panel)
        /// </summary>
        /// <param name="order">Order</param>
        /// <param name="amountToRefund">Amount to refund</param>
        /// <returns>A list of errors; empty list if no errors</returns>
        public virtual IList<string> PartiallyRefund(Order order, decimal amountToRefund)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("amountToRefund", amountToRefund);
            return APIHelper.Instance.PostAsync<IList<string>>("OrderProcessings", "PartiallyRefund", order, parameters);
        }

        /// <summary>
        /// Gets a value indicating whether order can be marked as partially refunded
        /// </summary>
        /// <param name="order">Order</param>
        /// <param name="amountToRefund">Amount to refund</param>
        /// <returns>A value indicating whether order can be marked as partially refunded</returns>
        public virtual bool CanPartiallyRefundOffline(Order order, decimal amountToRefund)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("amountToRefund", amountToRefund);
            return APIHelper.Instance.PostAsync<bool>("OrderProcessings", "CanPartiallyRefundOffline", order, parameters);
        }

        /// <summary>
        /// Partially refunds an order (offline)
        /// </summary>
        /// <param name="order">Order</param>
        /// <param name="amountToRefund">Amount to refund</param>
        public virtual void PartiallyRefundOffline(Order order, decimal amountToRefund)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("amountToRefund", amountToRefund);
            APIHelper.Instance.PostAsync("OrderProcessings", "PartiallyRefundOffline", order, parameters);
        }



        /// <summary>
        /// Gets a value indicating whether void from admin panel is allowed
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>A value indicating whether void from admin panel is allowed</returns>
        public virtual bool CanVoid(Order order)
        {
            return APIHelper.Instance.PostAsync("OrderProcessings", "CanVoid", order);
        }

        /// <summary>
        /// Voids order (from admin panel)
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>Voided order</returns>
        public virtual IList<string> Void(Order order)
        {
            return APIHelper.Instance.PostAsync<IList<string>>("OrderProcessings", "Void", order);
        }

        /// <summary>
        /// Gets a value indicating whether order can be marked as voided
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>A value indicating whether order can be marked as voided</returns>
        public virtual bool CanVoidOffline(Order order)
        {
            return APIHelper.Instance.PostAsync<bool>("OrderProcessings", "CanVoidOffline", order);
        }

        /// <summary>
        /// Voids order (offline)
        /// </summary>
        /// <param name="order">Order</param>
        public virtual void VoidOffline(Order order)
        {
            APIHelper.Instance.PostAsync("OrderProcessings", "VoidOffline", order);
        }



        /// <summary>
        /// Place order items in current user shopping cart.
        /// </summary>
        /// <param name="order">The order</param>
        public virtual void ReOrder(Order order)
        {
            APIHelper.Instance.PostAsync("OrderProcessings", "ReOrder", order);
        }

        /// <summary>
        /// Check whether return request is allowed
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>Result</returns>
        public virtual bool IsReturnRequestAllowed(Order order)
        {
            return APIHelper.Instance.PostAsync<bool>("OrderProcessings", "IsReturnRequestAllowed", order);
        }



        /// <summary>
        /// Valdiate minimum order sub-total amount
        /// </summary>
        /// <param name="cart">Shopping cart</param>
        /// <returns>true - OK; false - minimum order sub-total amount is not reached</returns>
        public virtual bool ValidateMinOrderSubtotalAmount(IList<ShoppingCartItem> cart)
        {
            return APIHelper.Instance.PostAsync<bool>("OrderProcessings", "ValidateMinOrderSubtotalAmount", cart);
        }

        /// <summary>
        /// Valdiate minimum order total amount
        /// </summary>
        /// <param name="cart">Shopping cart</param>
        /// <returns>true - OK; false - minimum order total amount is not reached</returns>
        public virtual bool ValidateMinOrderTotalAmount(IList<ShoppingCartItem> cart)
        {
            return APIHelper.Instance.PostAsync<bool>("OrderProcessings", "ValidateMinOrderTotalAmount", cart);
        }

        /// <summary>
        /// Gets a value indicating whether payment workflow is required
        /// </summary>
        /// <param name="cart">Shopping cart</param>
        /// <param name="useRewardPoints">A value indicating reward points should be used; null to detect current choice of the customer</param>
        /// <returns>true - OK; false - minimum order total amount is not reached</returns>
        public virtual bool IsPaymentWorkflowRequired(IList<ShoppingCartItem> cart, bool? useRewardPoints = null)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("useRewardPoints", useRewardPoints);
            return APIHelper.Instance.PostAsync<bool>("OrderProcessings", "IsPaymentWorkflowRequired", cart, parameters);
        }

        #endregion
    }
}
