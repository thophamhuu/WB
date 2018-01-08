using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Shipping;
using Nop.Services.Orders;
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
    public class OrderProcessingsController : ApiController
    {
        #region Fields

        private readonly IOrderProcessingService _orderProcessingService;

        #endregion

        #region Ctor

        public OrderProcessingsController(IOrderProcessingService orderProcessingService)
        {
            this._orderProcessingService = orderProcessingService;
        }

        #endregion

        #region Method

        /// <summary>
        /// Checks order status
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>Validated order</returns>
        public void CheckOrderStatus(Order order)
        {
            _orderProcessingService.CheckOrderStatus(order);
        }

        /// <summary>
        /// Places an order
        /// </summary>
        /// <param name="processPaymentRequest">Process payment request</param>
        /// <returns>Place order result</returns>
        public PlaceOrderResult PlaceOrder(ProcessPaymentRequest processPaymentRequest)
        {
            return _orderProcessingService.PlaceOrder(processPaymentRequest);
        }

        /// <summary>
        /// Update order totals
        /// </summary>
        /// <param name="updateOrderParameters">Parameters for the updating order</param>
        public void UpdateOrderTotals(UpdateOrderParameters updateOrderParameters)
        {
            _orderProcessingService.UpdateOrderTotals(updateOrderParameters);
        }

        /// <summary>
        /// Deletes an order
        /// </summary>
        /// <param name="order">The order</param>
        public void DeleteOrder(Order order)
        {
            _orderProcessingService.DeleteOrder(order);
        }


        /// <summary>
        /// Process next recurring payment
        /// </summary>
        /// <param name="recurringPayment">Recurring payment</param>
        /// <param name="paymentResult">Process payment result (info about last payment for automatic recurring payments)</param>
        /// <returns>Collection of errors</returns>
        public IEnumerable<string> ProcessNextRecurringPayment(RecurringPayment recurringPayment, ProcessPaymentResult paymentResult = null)
        {
            return _orderProcessingService.ProcessNextRecurringPayment(recurringPayment, paymentResult);
        }

        /// <summary>
        /// Cancels a recurring payment
        /// </summary>
        /// <param name="recurringPayment">Recurring payment</param>
        public IList<string> CancelRecurringPayment(RecurringPayment recurringPayment)
        {
            return _orderProcessingService.CancelRecurringPayment(recurringPayment);
        }

        /// <summary>
        /// Gets a value indicating whether a customer can cancel recurring payment
        /// </summary>
        /// <param name="customerToValidate">Customer</param>
        /// <param name="recurringPayment">Recurring Payment</param>
        /// <returns>value indicating whether a customer can cancel recurring payment</returns>
        public bool CanCancelRecurringPayment(Customer customerToValidate, RecurringPayment recurringPayment)
        {
            return _orderProcessingService.CanCancelRecurringPayment(customerToValidate, recurringPayment);
        }

        /// <summary>
        /// Gets a value indicating whether a customer can retry last failed recurring payment
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="recurringPayment">Recurring Payment</param>
        /// <returns>True if a customer can retry payment; otherwise false</returns>
        public bool CanRetryLastRecurringPayment(Customer customer, RecurringPayment recurringPayment)
        {
            return _orderProcessingService.CanRetryLastRecurringPayment(customer, recurringPayment);
        }



        /// <summary>
        /// Send a shipment
        /// </summary>
        /// <param name="shipment">Shipment</param>
        /// <param name="notifyCustomer">True to notify customer</param>
        public void Ship(Shipment shipment, bool notifyCustomer)
        {
            _orderProcessingService.Ship(shipment, notifyCustomer);
        }

        /// <summary>
        /// Marks a shipment as delivered
        /// </summary>
        /// <param name="shipment">Shipment</param>
        /// <param name="notifyCustomer">True to notify customer</param>
        public void Deliver(Shipment shipment, bool notifyCustomer)
        {
            _orderProcessingService.Deliver(shipment, notifyCustomer);
        }



        /// <summary>
        /// Gets a value indicating whether cancel is allowed
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>A value indicating whether cancel is allowed</returns>
        public bool CanCancelOrder(Order order)
        {
            return _orderProcessingService.CanCancelOrder(order);
        }

        /// <summary>
        /// Cancels order
        /// </summary>
        /// <param name="order">Order</param>
        /// <param name="notifyCustomer">True to notify customer</param>
        public void CancelOrder(Order order, bool notifyCustomer)
        {
            _orderProcessingService.CancelOrder(order, notifyCustomer);
        }



        /// <summary>
        /// Gets a value indicating whether order can be marked as authorized
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>A value indicating whether order can be marked as authorized</returns>
        public bool CanMarkOrderAsAuthorized(Order order)
        {
            return _orderProcessingService.CanMarkOrderAsAuthorized(order);
        }

        /// <summary>
        /// Marks order as authorized
        /// </summary>
        /// <param name="order">Order</param>
        public void MarkAsAuthorized(Order order)
        {
            _orderProcessingService.MarkAsAuthorized(order);
        }



        /// <summary>
        /// Gets a value indicating whether capture from admin panel is allowed
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>A value indicating whether capture from admin panel is allowed</returns>
        public bool CanCapture(Order order)
        {
            return _orderProcessingService.CanCapture(order);
        }

        /// <summary>
        /// Capture an order (from admin panel)
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>A list of errors; empty list if no errors</returns>
        public IList<string> Capture(Order order)
        {
            return _orderProcessingService.Capture(order);
        }

        /// <summary>
        /// Gets a value indicating whether order can be marked as paid
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>A value indicating whether order can be marked as paid</returns>
        public bool CanMarkOrderAsPaid(Order order)
        {
            return _orderProcessingService.CanMarkOrderAsPaid(order);
        }

        /// <summary>
        /// Marks order as paid
        /// </summary>
        /// <param name="order">Order</param>
        public void MarkOrderAsPaid(Order order)
        {
            _orderProcessingService.MarkOrderAsPaid(order);
        }



        /// <summary>
        /// Gets a value indicating whether refund from admin panel is allowed
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>A value indicating whether refund from admin panel is allowed</returns>
        public bool CanRefund(Order order)
        {
            return _orderProcessingService.CanRefund(order);
        }

        /// <summary>
        /// Refunds an order (from admin panel)
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>A list of errors; empty list if no errors</returns>
        public IList<string> Refund(Order order)
        {
            return _orderProcessingService.Refund(order);
        }

        /// <summary>
        /// Gets a value indicating whether order can be marked as refunded
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>A value indicating whether order can be marked as refunded</returns>
        public bool CanRefundOffline(Order order)
        {
            return _orderProcessingService.CanRefundOffline(order);
        }

        /// <summary>
        /// Refunds an order (offline)
        /// </summary>
        /// <param name="order">Order</param>
        public void RefundOffline(Order order)
        {
            _orderProcessingService.RefundOffline(order);
        }

        /// <summary>
        /// Gets a value indicating whether partial refund from admin panel is allowed
        /// </summary>
        /// <param name="order">Order</param>
        /// <param name="amountToRefund">Amount to refund</param>
        /// <returns>A value indicating whether refund from admin panel is allowed</returns>
        public bool CanPartiallyRefund(Order order, decimal amountToRefund)
        {
            return _orderProcessingService.CanPartiallyRefund(order, amountToRefund);
        }

        /// <summary>
        /// Partially refunds an order (from admin panel)
        /// </summary>
        /// <param name="order">Order</param>
        /// <param name="amountToRefund">Amount to refund</param>
        /// <returns>A list of errors; empty list if no errors</returns>
        public IList<string> PartiallyRefund(Order order, decimal amountToRefund)
        {
            return _orderProcessingService.PartiallyRefund(order, amountToRefund);
        }

        /// <summary>
        /// Gets a value indicating whether order can be marked as partially refunded
        /// </summary>
        /// <param name="order">Order</param>
        /// <param name="amountToRefund">Amount to refund</param>
        /// <returns>A value indicating whether order can be marked as partially refunded</returns>
        public bool CanPartiallyRefundOffline(Order order, decimal amountToRefund)
        {
            return _orderProcessingService.CanPartiallyRefundOffline(order, amountToRefund);
        }

        /// <summary>
        /// Partially refunds an order (offline)
        /// </summary>
        /// <param name="order">Order</param>
        /// <param name="amountToRefund">Amount to refund</param>
        public void PartiallyRefundOffline(Order order, decimal amountToRefund)
        {
            _orderProcessingService.PartiallyRefundOffline(order, amountToRefund);
        }


        /// <summary>
        /// Gets a value indicating whether void from admin panel is allowed
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>A value indicating whether void from admin panel is allowed</returns>
        public bool CanVoid(Order order)
        {
            return _orderProcessingService.CanVoid(order);
        }

        /// <summary>
        /// Voids order (from admin panel)
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>Voided order</returns>
        public IList<string> Void(Order order)
        {
            return _orderProcessingService.Void(order);
        }

        /// <summary>
        /// Gets a value indicating whether order can be marked as voided
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>A value indicating whether order can be marked as voided</returns>
        public bool CanVoidOffline(Order order)
        {
            return _orderProcessingService.CanVoidOffline(order);
        }

        /// <summary>
        /// Voids order (offline)
        /// </summary>
        /// <param name="order">Order</param>
        public void VoidOffline(Order order)
        {
            _orderProcessingService.VoidOffline(order);
        }



        /// <summary>
        /// Place order items in current user shopping cart.
        /// </summary>
        /// <param name="order">The order</param>
        public void ReOrder(Order order)
        {
            _orderProcessingService.ReOrder(order);
        }

        /// <summary>
        /// Check whether return request is allowed
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>Result</returns>
        public bool IsReturnRequestAllowed(Order order)
        {
            return _orderProcessingService.IsReturnRequestAllowed(order);
        }



        /// <summary>
        /// Valdiate minimum order sub-total amount
        /// </summary>
        /// <param name="cart">Shopping cart</param>
        /// <returns>true - OK; false - minimum order sub-total amount is not reached</returns>
        public bool ValidateMinOrderSubtotalAmount(IList<ShoppingCartItem> cart)
        {
            return _orderProcessingService.ValidateMinOrderSubtotalAmount(cart);
        }

        /// <summary>
        /// Valdiate minimum order total amount
        /// </summary>
        /// <param name="cart">Shopping cart</param>
        /// <returns>true - OK; false - minimum order total amount is not reached</returns>
        public bool ValidateMinOrderTotalAmount(IList<ShoppingCartItem> cart)
        {
            return _orderProcessingService.ValidateMinOrderTotalAmount(cart);
        }

        /// <summary>
        /// Gets a value indicating whether payment workflow is required
        /// </summary>
        /// <param name="cart">Shopping cart</param>
        /// <param name="useRewardPoints">A value indicating reward points should be used; null to detect current choice of the customer</param>
        /// <returns>true - OK; false - minimum order total amount is not reached</returns>
        public bool IsPaymentWorkflowRequired(IList<ShoppingCartItem> cart, bool? useRewardPoints = null)
        {
            return _orderProcessingService.IsPaymentWorkflowRequired(cart, useRewardPoints);
        }

        #endregion
    }
}
