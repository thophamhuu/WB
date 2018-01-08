using Nop.Core.Domain.Blogs;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Forums;
using Nop.Core.Domain.Messages;
using Nop.Core.Domain.News;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Shipping;
using Nop.Core.Domain.Vendors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Messages
{
    public partial class WorkflowMessageApiService : IWorkflowMessageService
    {
        #region Methods

        #region Customer workflow

        /// <summary>
        /// Sends 'New customer' notification message to a store owner
        /// </summary>
        /// <param name="customer">Customer instance</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendCustomerRegisteredNotificationMessage(Customer customer, int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.PostAsync<int>("Messages", "SendCustomerRegisteredNotificationMessage", customer, parameters);
        }

        /// <summary>
        /// Sends a welcome message to a customer
        /// </summary>
        /// <param name="customer">Customer instance</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendCustomerWelcomeMessage(Customer customer, int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.PostAsync<int>("Messages", "SendCustomerWelcomeMessage", customer, parameters);
        }

        /// <summary>
        /// Sends an email validation message to a customer
        /// </summary>
        /// <param name="customer">Customer instance</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendCustomerEmailValidationMessage(Customer customer, int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.PostAsync<int>("Messages", "SendCustomerEmailValidationMessage", customer, parameters);
        }

        /// <summary>
        /// Sends an email re-validation message to a customer
        /// </summary>
        /// <param name="customer">Customer instance</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendCustomerEmailRevalidationMessage(Customer customer, int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.PostAsync<int>("Messages", "SendCustomerEmailRevalidationMessage", customer, parameters);
        }

        /// <summary>
        /// Sends password recovery message to a customer
        /// </summary>
        /// <param name="customer">Customer instance</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendCustomerPasswordRecoveryMessage(Customer customer, int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.PostAsync<int>("Messages", "SendCustomerPasswordRecoveryMessage", customer, parameters);
        }

        #endregion

        #region Order workflow

        /// <summary>
        /// Sends an order placed notification to a vendor
        /// </summary>
        /// <param name="order">Order instance</param>
        /// <param name="vendor">Vendor instance</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendOrderPlacedVendorNotification(Order order, Vendor vendor, int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("order", order);
            parameters.Add("vendor", vendor);
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.GetAsync<int>("Messages", "SendOrderPlacedVendorNotification", parameters);
        }

        /// <summary>
        /// Sends an order placed notification to a store owner
        /// </summary>
        /// <param name="order">Order instance</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendOrderPlacedStoreOwnerNotification(Order order, int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.PostAsync<int>("Messages", "SendOrderPlacedStoreOwnerNotification", order, parameters);
        }

        /// <summary>
        /// Sends an order paid notification to a store owner
        /// </summary>
        /// <param name="order">Order instance</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendOrderPaidStoreOwnerNotification(Order order, int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.PostAsync<int>("Messages", "SendOrderPaidStoreOwnerNotification", order, parameters);
        }

        /// <summary>
        /// Sends an order paid notification to a customer
        /// </summary>
        /// <param name="order">Order instance</param>
        /// <param name="languageId">Message language identifier</param>
        /// <param name="attachmentFilePath">Attachment file path</param>
        /// <param name="attachmentFileName">Attachment file name. If specified, then this file name will be sent to a recipient. Otherwise, "AttachmentFilePath" name will be used.</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendOrderPaidCustomerNotification(Order order, int languageId,
            string attachmentFilePath = null, string attachmentFileName = null)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("languageId", languageId);
            parameters.Add("attachmentFilePath", attachmentFilePath);
            parameters.Add("attachmentFileName", attachmentFileName);
            return APIHelper.Instance.PostAsync<int>("Messages", "SendOrderPaidCustomerNotification", order, parameters);
        }

        /// <summary>
        /// Sends an order paid notification to a vendor
        /// </summary>
        /// <param name="order">Order instance</param>
        /// <param name="vendor">Vendor instance</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendOrderPaidVendorNotification(Order order, Vendor vendor, int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("order", order);
            parameters.Add("vendor", vendor);
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.GetAsync<int>("Messages", "SendOrderPaidVendorNotification", parameters);
        }

        /// <summary>
        /// Sends an order placed notification to a customer
        /// </summary>
        /// <param name="order">Order instance</param>
        /// <param name="languageId">Message language identifier</param>
        /// <param name="attachmentFilePath">Attachment file path</param>
        /// <param name="attachmentFileName">Attachment file name. If specified, then this file name will be sent to a recipient. Otherwise, "AttachmentFilePath" name will be used.</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendOrderPlacedCustomerNotification(Order order, int languageId,
            string attachmentFilePath = null, string attachmentFileName = null)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("languageId", languageId);
            parameters.Add("attachmentFilePath", attachmentFilePath);
            parameters.Add("attachmentFileName", attachmentFileName);
            return APIHelper.Instance.PostAsync<int>("Messages", "SendOrderPlacedCustomerNotification", order, parameters);
        }

        /// <summary>
        /// Sends a shipment sent notification to a customer
        /// </summary>
        /// <param name="shipment">Shipment</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendShipmentSentCustomerNotification(Shipment shipment, int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.PostAsync<int>("Messages", "SendShipmentSentCustomerNotification", shipment, parameters);
        }

        /// <summary>
        /// Sends a shipment delivered notification to a customer
        /// </summary>
        /// <param name="shipment">Shipment</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendShipmentDeliveredCustomerNotification(Shipment shipment, int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.PostAsync<int>("Messages", "SendShipmentDeliveredCustomerNotification", shipment, parameters);
        }

        /// <summary>
        /// Sends an order completed notification to a customer
        /// </summary>
        /// <param name="order">Order instance</param>
        /// <param name="languageId">Message language identifier</param>
        /// <param name="attachmentFilePath">Attachment file path</param>
        /// <param name="attachmentFileName">Attachment file name. If specified, then this file name will be sent to a recipient. Otherwise, "AttachmentFilePath" name will be used.</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendOrderCompletedCustomerNotification(Order order, int languageId,
            string attachmentFilePath = null, string attachmentFileName = null)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("languageId", languageId);
            parameters.Add("attachmentFilePath", attachmentFilePath);
            parameters.Add("attachmentFileName", attachmentFileName);
            return APIHelper.Instance.PostAsync<int>("Messages", "SendOrderCompletedCustomerNotification", order, parameters);
        }

        /// <summary>
        /// Sends an order cancelled notification to a customer
        /// </summary>
        /// <param name="order">Order instance</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendOrderCancelledCustomerNotification(Order order, int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.PostAsync<int>("Messages", "SendOrderCancelledCustomerNotification", order, parameters);
        }

        /// <summary>
        /// Sends an order refunded notification to a store owner
        /// </summary>
        /// <param name="order">Order instance</param>
        /// <param name="refundedAmount">Amount refunded</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendOrderRefundedStoreOwnerNotification(Order order, decimal refundedAmount, int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("refundedAmount", refundedAmount);
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.PostAsync<int>("Messages", "SendOrderRefundedStoreOwnerNotification", order, parameters);
        }

        /// <summary>
        /// Sends an order refunded notification to a customer
        /// </summary>
        /// <param name="order">Order instance</param>
        /// <param name="refundedAmount">Amount refunded</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendOrderRefundedCustomerNotification(Order order, decimal refundedAmount, int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("refundedAmount", refundedAmount);
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.PostAsync<int>("Messages", "SendOrderRefundedCustomerNotification", order, parameters);
        }

        /// <summary>
        /// Sends a new order note added notification to a customer
        /// </summary>
        /// <param name="orderNote">Order note</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendNewOrderNoteAddedCustomerNotification(OrderNote orderNote, int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.PostAsync<int>("Messages", "SendNewOrderNoteAddedCustomerNotification", orderNote, parameters);
        }

        /// <summary>
        /// Sends a "Recurring payment cancelled" notification to a store owner
        /// </summary>
        /// <param name="recurringPayment">Recurring payment</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendRecurringPaymentCancelledStoreOwnerNotification(RecurringPayment recurringPayment, int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.PostAsync<int>("Messages", "SendRecurringPaymentCancelledStoreOwnerNotification", recurringPayment, parameters);
        }

        /// <summary>
        /// Sends a "Recurring payment cancelled" notification to a customer
        /// </summary>
        /// <param name="recurringPayment">Recurring payment</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendRecurringPaymentCancelledCustomerNotification(RecurringPayment recurringPayment, int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.PostAsync<int>("Messages", "SendRecurringPaymentCancelledCustomerNotification", recurringPayment, parameters);
        }

        /// <summary>
        /// Sends a "Recurring payment failed" notification to a customer
        /// </summary>
        /// <param name="recurringPayment">Recurring payment</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendRecurringPaymentFailedCustomerNotification(RecurringPayment recurringPayment, int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.PostAsync<int>("Messages", "SendRecurringPaymentFailedCustomerNotification", recurringPayment, parameters);
        }

        #endregion

        #region Newsletter workflow

        /// <summary>
        /// Sends a newsletter subscription activation message
        /// </summary>
        /// <param name="subscription">Newsletter subscription</param>
        /// <param name="languageId">Language identifier</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendNewsLetterSubscriptionActivationMessage(NewsLetterSubscription subscription, int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.PostAsync<int>("Messages", "SendNewsLetterSubscriptionActivationMessage", subscription, parameters);
        }

        /// <summary>
        /// Sends a newsletter subscription deactivation message
        /// </summary>
        /// <param name="subscription">Newsletter subscription</param>
        /// <param name="languageId">Language identifier</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendNewsLetterSubscriptionDeactivationMessage(NewsLetterSubscription subscription, int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.PostAsync<int>("Messages", "SendNewsLetterSubscriptionDeactivationMessage", subscription, parameters);
        }

        #endregion

        #region Send a message to a friend

        /// <summary>
        /// Sends "email a friend" message
        /// </summary>
        /// <param name="customer">Customer instance</param>
        /// <param name="languageId">Message language identifier</param>
        /// <param name="product">Product instance</param>
        /// <param name="customerEmail">Customer's email</param>
        /// <param name="friendsEmail">Friend's email</param>
        /// <param name="personalMessage">Personal message</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendProductEmailAFriendMessage(Customer customer, int languageId,
            Product product, string customerEmail, string friendsEmail, string personalMessage)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customer", customer);
            parameters.Add("languageId", languageId);
            parameters.Add("product", product);
            parameters.Add("customerEmail", customerEmail);
            parameters.Add("friendsEmail", friendsEmail);
            parameters.Add("personalMessage", personalMessage);

            return APIHelper.Instance.PostAsync<int>("Messages", "SendProductEmailAFriendMessage", parameters);
        }

        /// <summary>
        /// Sends wishlist "email a friend" message
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="languageId">Message language identifier</param>
        /// <param name="customerEmail">Customer's email</param>
        /// <param name="friendsEmail">Friend's email</param>
        /// <param name="personalMessage">Personal message</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendWishlistEmailAFriendMessage(Customer customer, int languageId,
             string customerEmail, string friendsEmail, string personalMessage)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customer", customer);
            parameters.Add("languageId", languageId);
            parameters.Add("customerEmail", customerEmail);
            parameters.Add("friendsEmail", friendsEmail);
            parameters.Add("personalMessage", personalMessage);

            return APIHelper.Instance.PostAsync<int>("Messages", "SendWishlistEmailAFriendMessage", parameters);
        }

        #endregion

        #region Return requests

        /// <summary>
        /// Sends 'New Return Request' message to a store owner
        /// </summary>
        /// <param name="returnRequest">Return request</param>
        /// <param name="orderItem">Order item</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendNewReturnRequestStoreOwnerNotification(ReturnRequest returnRequest, OrderItem orderItem, int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("returnRequest", returnRequest);
            parameters.Add("orderItem", orderItem);
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.GetAsync<int>("Messages", "SendNewReturnRequestStoreOwnerNotification", parameters);
        }

        /// <summary>
        /// Sends 'New Return Request' message to a customer
        /// </summary>
        /// <param name="returnRequest">Return request</param>
        /// <param name="orderItem">Order item</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendNewReturnRequestCustomerNotification(ReturnRequest returnRequest, OrderItem orderItem, int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("returnRequest", returnRequest);
            parameters.Add("orderItem", orderItem);
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.GetAsync<int>("Messages", "SendNewReturnRequestCustomerNotification", parameters);
        }

        /// <summary>
        /// Sends 'Return Request status changed' message to a customer
        /// </summary>
        /// <param name="returnRequest">Return request</param>
        /// <param name="orderItem">Order item</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendReturnRequestStatusChangedCustomerNotification(ReturnRequest returnRequest, OrderItem orderItem, int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("returnRequest", returnRequest);
            parameters.Add("orderItem", orderItem);
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.GetAsync<int>("Messages", "SendReturnRequestStatusChangedCustomerNotification", parameters);
        }

        #endregion

        #region Forum Notifications

        /// <summary>
        /// Sends a forum subscription message to a customer
        /// </summary>
        /// <param name="customer">Customer instance</param>
        /// <param name="forumTopic">Forum Topic</param>
        /// <param name="forum">Forum</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public int SendNewForumTopicMessage(Customer customer, ForumTopic forumTopic, Forum forum, int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customer", customer);
            parameters.Add("forumTopic", forumTopic);
            parameters.Add("forum", forum);
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.GetAsync<int>("Messages", "SendNewForumTopicMessage", parameters);
        }

        /// <summary>
        /// Sends a forum subscription message to a customer
        /// </summary>
        /// <param name="customer">Customer instance</param>
        /// <param name="forumPost">Forum post</param>
        /// <param name="forumTopic">Forum Topic</param>
        /// <param name="forum">Forum</param>
        /// <param name="friendlyForumTopicPageIndex">Friendly (starts with 1) forum topic page to use for URL generation</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public int SendNewForumPostMessage(Customer customer, ForumPost forumPost, ForumTopic forumTopic,
            Forum forum, int friendlyForumTopicPageIndex, int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customer", customer);
            parameters.Add("forumPost", forumPost);
            parameters.Add("forumTopic", forumTopic);
            parameters.Add("forum", forum);
            parameters.Add("friendlyForumTopicPageIndex", friendlyForumTopicPageIndex);
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.GetAsync<int>("Messages", "SendNewForumPostMessage", parameters);
        }

        /// <summary>
        /// Sends a private message notification
        /// </summary>
        /// <param name="privateMessage">Private message</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public int SendPrivateMessageNotification(PrivateMessage privateMessage, int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.PostAsync<int>("Messages", "SendPrivateMessageNotification", privateMessage, parameters);
        }

        #endregion

        #region Misc

        /// <summary>
        /// Sends 'New vendor account submitted' message to a store owner
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="vendor">Vendor</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendNewVendorAccountApplyStoreOwnerNotification(Customer customer, Vendor vendor, int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("customer", customer);
            parameters.Add("vendor", vendor);
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.GetAsync<int>("Messages", "SendNewVendorAccountApplyStoreOwnerNotification", parameters);
        }

        /// <summary>
        /// Sends 'Vendor information changed' message to a store owner
        /// </summary>
        /// <param name="vendor">Vendor</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendVendorInformationChangeNotification(Vendor vendor, int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.PostAsync<int>("Messages", "SendVendorInformationChangeNotification", vendor, parameters);
        }

        /// <summary>
        /// Sends a gift card notification
        /// </summary>
        /// <param name="giftCard">Gift card</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendGiftCardNotification(GiftCard giftCard, int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.PostAsync<int>("Messages", "SendGiftCardNotification", giftCard, parameters);
        }

        /// <summary>
        /// Sends a product review notification message to a store owner
        /// </summary>
        /// <param name="productReview">Product review</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendProductReviewNotificationMessage(ProductReview productReview, int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.PostAsync<int>("Messages", "SendProductReviewNotificationMessage", productReview, parameters);
        }

        /// <summary>
        /// Sends a "quantity below" notification to a store owner
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendQuantityBelowStoreOwnerNotification(Product product, int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.PostAsync<int>("Messages", "SendQuantityBelowStoreOwnerNotification", product, parameters);
        }

        /// <summary>
        /// Sends a "quantity below" notification to a store owner
        /// </summary>
        /// <param name="combination">Attribute combination</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendQuantityBelowStoreOwnerNotification(ProductAttributeCombination combination, int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.PostAsync<int>("Messages", "SendQuantityBelowStoreOwnerNotification", combination, parameters);
        }

        /// <summary>
        /// Sends a "new VAT submitted" notification to a store owner
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="vatName">Received VAT name</param>
        /// <param name="vatAddress">Received VAT address</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendNewVatSubmittedStoreOwnerNotification(Customer customer,
            string vatName, string vatAddress, int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("vatName", vatName);
            parameters.Add("vatAddress", vatAddress);
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.PostAsync<int>("Messages", "SendNewVatSubmittedStoreOwnerNotification", customer, parameters);
        }

        /// <summary>
        /// Sends a blog comment notification message to a store owner
        /// </summary>
        /// <param name="blogComment">Blog comment</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendBlogCommentNotificationMessage(BlogComment blogComment, int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.PostAsync<int>("Messages", "SendNewsCommentNotificationMessage", blogComment, parameters);
        }

        /// <summary>
        /// Sends a news comment notification message to a store owner
        /// </summary>
        /// <param name="newsComment">News comment</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendNewsCommentNotificationMessage(NewsComment newsComment, int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.PostAsync<int>("Messages", "SendNewsCommentNotificationMessage", newsComment, parameters);
        }

        /// <summary>
        /// Sends a 'Back in stock' notification message to a customer
        /// </summary>
        /// <param name="subscription">Subscription</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendBackInStockNotification(BackInStockSubscription subscription, int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.PostAsync<int>("Messages", "SendBackInStockNotification", subscription, parameters);
        }

        /// <summary>
        /// Sends "contact us" message
        /// </summary>
        /// <param name="languageId">Message language identifier</param>
        /// <param name="senderEmail">Sender email</param>
        /// <param name="senderName">Sender name</param>
        /// <param name="subject">Email subject. Pass null if you want a message template subject to be used.</param>
        /// <param name="body">Email body</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendContactUsMessage(int languageId, string senderEmail,
            string senderName, string subject, string body)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("languageId", languageId);
            parameters.Add("senderEmail", senderEmail);
            parameters.Add("senderName", senderName);
            parameters.Add("subject", subject);
            parameters.Add("body", body);
            return APIHelper.Instance.GetAsync<int>("Messages", "SendContactUsMessage", parameters);
        }

        /// <summary>
        /// Sends "contact vendor" message
        /// </summary>
        /// <param name="vendor">Vendor</param>
        /// <param name="languageId">Message language identifier</param>
        /// <param name="senderEmail">Sender email</param>
        /// <param name="senderName">Sender name</param>
        /// <param name="subject">Email subject. Pass null if you want a message template subject to be used.</param>
        /// <param name="body">Email body</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendContactVendorMessage(Vendor vendor, int languageId, string senderEmail,
            string senderName, string subject, string body)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("vendor", vendor);
            parameters.Add("languageId", languageId);
            parameters.Add("senderEmail", senderEmail);
            parameters.Add("senderName", senderName);
            parameters.Add("subject", subject);
            parameters.Add("body", body);
            return APIHelper.Instance.GetAsync<int>("Messages", "SendContactVendorMessage", parameters);
        }

        /// <summary>
        /// Sends a test email
        /// </summary>
        /// <param name="messageTemplateId">Message template identifier</param>
        /// <param name="sendToEmail">Send to email</param>
        /// <param name="tokens">Tokens</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendTestEmail(int messageTemplateId, string sendToEmail, List<Token> tokens, int languageId)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("messageTemplateId", messageTemplateId);
            parameters.Add("sendToEmail", sendToEmail);
            parameters.Add("tokens", tokens);
            parameters.Add("languageId", languageId);
            return APIHelper.Instance.GetAsync<int>("Messages", "SendTestEmail", parameters);
        }

        /// <summary>
        /// Send notification
        /// </summary>
        /// <param name="messageTemplate">Message template</param>
        /// <param name="emailAccount">Email account</param>
        /// <param name="languageId">Language identifier</param>
        /// <param name="tokens">Tokens</param>
        /// <param name="toEmailAddress">Recipient email address</param>
        /// <param name="toName">Recipient name</param>
        /// <param name="attachmentFilePath">Attachment file path</param>
        /// <param name="attachmentFileName">Attachment file name</param>
        /// <param name="replyToEmailAddress">"Reply to" email</param>
        /// <param name="replyToName">"Reply to" name</param>
        /// <param name="fromEmail">Sender email. If specified, then it overrides passed "emailAccount" details</param>
        /// <param name="fromName">Sender name. If specified, then it overrides passed "emailAccount" details</param>
        /// <param name="subject">Subject. If specified, then it overrides subject of a message template</param>
        /// <returns>Queued email identifier</returns>
        public virtual int SendNotification(MessageTemplate messageTemplate,
            EmailAccount emailAccount, int languageId, IEnumerable<Token> tokens,
            string toEmailAddress, string toName,
            string attachmentFilePath = null, string attachmentFileName = null,
            string replyToEmailAddress = null, string replyToName = null,
            string fromEmail = null, string fromName = null, string subject = null)
        {
            var parameters = new Dictionary<string, dynamic>();
            parameters.Add("messageTemplate", messageTemplate);
            parameters.Add("emailAccount", emailAccount);
            parameters.Add("languageId", languageId);
            parameters.Add("tokens", tokens);
            parameters.Add("toEmailAddress", toEmailAddress);
            parameters.Add("toName", toName);
            parameters.Add("attachmentFilePath", attachmentFilePath);
            parameters.Add("attachmentFileName", attachmentFileName);
            parameters.Add("replyToEmailAddress", replyToEmailAddress);
            parameters.Add("replyToName", replyToName);
            parameters.Add("fromEmail", fromEmail);
            parameters.Add("fromName", fromName);
            parameters.Add("subject", subject);
            return APIHelper.Instance.GetAsync<int>("Messages", "SendNotification", parameters);
        }

        #endregion

        #endregion
    }
}
