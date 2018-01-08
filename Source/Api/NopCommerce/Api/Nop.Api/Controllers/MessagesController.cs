using Nop.Core;
using Nop.Core.Domain.Blogs;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Forums;
using Nop.Core.Domain.Messages;
using Nop.Core.Domain.News;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Shipping;
using Nop.Core.Domain.Vendors;
using Nop.Services.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nop.Api.Controllers
{
    [Authorize]
    public class MessagesController : ApiController
    {
        #region Fields

        private readonly ICampaignService _campaignService;
        private readonly IEmailAccountService _emailAccountService;
        private readonly IMessageTemplateService _messageTemplateService;
        private readonly INewsLetterSubscriptionService _newsLetterSubscriptionService;
        private readonly IQueuedEmailService _queuedEmailService;
        private readonly IWorkflowMessageService _workflowMessageService;

        #endregion

        #region Ctor

        public MessagesController(ICampaignService campaignService, IEmailAccountService emailAccountService, IMessageTemplateService messageTemplateService,
            INewsLetterSubscriptionService newsLetterSubscriptionService, IQueuedEmailService queuedEmailService, IWorkflowMessageService workflowMessageService)
        {
            this._campaignService = campaignService;
            this._emailAccountService = emailAccountService;
            this._messageTemplateService = messageTemplateService;
            this._newsLetterSubscriptionService = newsLetterSubscriptionService;
            this._queuedEmailService = queuedEmailService;
            this._workflowMessageService = workflowMessageService;
        }

        #endregion

        #region Method

        #region Campaign

        /// <summary>
        /// Inserts a campaign
        /// </summary>
        /// <param name="campaign">Campaign</param>        
        public void InsertCampaign(Campaign campaign)
        {
            _campaignService.InsertCampaign(campaign);
        }

        /// <summary>
        /// Updates a campaign
        /// </summary>
        /// <param name="campaign">Campaign</param>
        public void UpdateCampaign(Campaign campaign)
        {
            _campaignService.UpdateCampaign(campaign);
        }

        /// <summary>
        /// Deleted a queued email
        /// </summary>
        /// <param name="campaign">Campaign</param>
        public void DeleteCampaign(Campaign campaign)
        {
            _campaignService.DeleteCampaign(campaign);
        }

        /// <summary>
        /// Gets a campaign by identifier
        /// </summary>
        /// <param name="campaignId">Campaign identifier</param>
        /// <returns>Campaign</returns>
        public Campaign GetCampaignById(int campaignId)
        {
            return _campaignService.GetCampaignById(campaignId);
        }

        /// <summary>
        /// Gets all campaigns
        /// </summary>
        /// <param name="storeId">Store identifier; 0 to load all records</param>
        /// <returns>Campaigns</returns>
        public IList<Campaign> GetAllCampaigns(int storeId = 0)
        {
            return _campaignService.GetAllCampaigns(storeId);
        }

        /// <summary>
        /// Sends a campaign to specified emails
        /// </summary>
        /// <param name="campaign">Campaign</param>
        /// <param name="emailAccount">Email account</param>
        /// <param name="subscriptions">Subscriptions</param>
        /// <returns>Total emails sent</returns>
        public int SendCampaign(Campaign campaign, EmailAccount emailAccount,
            IEnumerable<NewsLetterSubscription> subscriptions)
        {
            return _campaignService.SendCampaign(campaign, emailAccount, subscriptions);
        }

        /// <summary>
        /// Sends a campaign to specified email
        /// </summary>
        /// <param name="campaign">Campaign</param>
        /// <param name="emailAccount">Email account</param>
        /// <param name="email">Email</param>
        public void SendCampaign(Campaign campaign, EmailAccount emailAccount, string email)
        {
            _campaignService.SendCampaign(campaign, emailAccount, email);
        }

        #endregion

        #region Email account

        /// <summary>
        /// Inserts an email account
        /// </summary>
        /// <param name="emailAccount">Email account</param>
        public void InsertEmailAccount(EmailAccount emailAccount)
        {
            _emailAccountService.InsertEmailAccount(emailAccount);
        }

        /// <summary>
        /// Updates an email account
        /// </summary>
        /// <param name="emailAccount">Email account</param>
        public void UpdateEmailAccount(EmailAccount emailAccount)
        {
            _emailAccountService.UpdateEmailAccount(emailAccount);
        }

        /// <summary>
        /// Deletes an email account
        /// </summary>
        /// <param name="emailAccount">Email account</param>
        public void DeleteEmailAccount(EmailAccount emailAccount)
        {
            _emailAccountService.DeleteEmailAccount(emailAccount);
        }

        /// <summary>
        /// Gets an email account by identifier
        /// </summary>
        /// <param name="emailAccountId">The email account identifier</param>
        /// <returns>Email account</returns>
        public EmailAccount GetEmailAccountById(int emailAccountId)
        {
            return _emailAccountService.GetEmailAccountById(emailAccountId);
        }

        /// <summary>
        /// Gets all email accounts
        /// </summary>
        /// <returns>Email accounts list</returns>
        public IList<EmailAccount> GetAllEmailAccounts()
        {
            return _emailAccountService.GetAllEmailAccounts();
        }

        #endregion

        #region IMessageTemplateService

        /// <summary>
        /// Delete a message template
        /// </summary>
        /// <param name="messageTemplate">Message template</param>
        public void DeleteMessageTemplate(MessageTemplate messageTemplate)
        {
            _messageTemplateService.DeleteMessageTemplate(messageTemplate);
        }

        /// <summary>
        /// Inserts a message template
        /// </summary>
        /// <param name="messageTemplate">Message template</param>
        public void InsertMessageTemplate(MessageTemplate messageTemplate)
        {
            _messageTemplateService.InsertMessageTemplate(messageTemplate);
        }

        /// <summary>
        /// Updates a message template
        /// </summary>
        /// <param name="messageTemplate">Message template</param>
        void UpdateMessageTemplate(MessageTemplate messageTemplate)
        {
            _messageTemplateService.UpdateMessageTemplate(messageTemplate);
        }

        /// <summary>
        /// Gets a message template by identifier
        /// </summary>
        /// <param name="messageTemplateId">Message template identifier</param>
        /// <returns>Message template</returns>
        public MessageTemplate GetMessageTemplateById(int messageTemplateId)
        {
            return _messageTemplateService.GetMessageTemplateById(messageTemplateId);
        }

        /// <summary>
        /// Gets a message template by name
        /// </summary>
        /// <param name="messageTemplateName">Message template name</param>
        /// <param name="storeId">Store identifier</param>
        /// <returns>Message template</returns>
        public MessageTemplate GetMessageTemplateByName(string messageTemplateName, int storeId)
        {
            return _messageTemplateService.GetMessageTemplateByName(messageTemplateName, storeId);
        }

        /// <summary>
        /// Gets all message templates
        /// </summary>
        /// <param name="storeId">Store identifier; pass 0 to load all records</param>
        /// <returns>Message template list</returns>
        public IList<MessageTemplate> GetAllMessageTemplates(int storeId)
        {
            return _messageTemplateService.GetAllMessageTemplates(storeId);
        }

        /// <summary>
        /// Create a copy of message template with all depended data
        /// </summary>
        /// <param name="messageTemplate">Message template</param>
        /// <returns>Message template copy</returns>
        public MessageTemplate CopyMessageTemplate(MessageTemplate messageTemplate)
        {
            return _messageTemplateService.CopyMessageTemplate(messageTemplate);
        }

        #endregion

        #region NewsLetter subscription

        /// <summary>
        /// Inserts a newsletter subscription
        /// </summary>
        /// <param name="newsLetterSubscription">NewsLetter subscription</param>
        /// <param name="publishSubscriptionEvents">if set to <c>true</c> [publish subscription events].</param>
        public void InsertNewsLetterSubscription(NewsLetterSubscription newsLetterSubscription, bool publishSubscriptionEvents = true)
        {
            _newsLetterSubscriptionService.InsertNewsLetterSubscription(newsLetterSubscription, publishSubscriptionEvents);
        }

        /// <summary>
        /// Updates a newsletter subscription
        /// </summary>
        /// <param name="newsLetterSubscription">NewsLetter subscription</param>
        /// <param name="publishSubscriptionEvents">if set to <c>true</c> [publish subscription events].</param>
        public void UpdateNewsLetterSubscription(NewsLetterSubscription newsLetterSubscription, bool publishSubscriptionEvents = true)
        {
            _newsLetterSubscriptionService.UpdateNewsLetterSubscription(newsLetterSubscription, publishSubscriptionEvents);
        }

        /// <summary>
        /// Deletes a newsletter subscription
        /// </summary>
        /// <param name="newsLetterSubscription">NewsLetter subscription</param>
        /// <param name="publishSubscriptionEvents">if set to <c>true</c> [publish subscription events].</param>
        public void DeleteNewsLetterSubscription(NewsLetterSubscription newsLetterSubscription, bool publishSubscriptionEvents = true)
        {
            _newsLetterSubscriptionService.DeleteNewsLetterSubscription(newsLetterSubscription, publishSubscriptionEvents);
        }

        /// <summary>
        /// Gets a newsletter subscription by newsletter subscription identifier
        /// </summary>
        /// <param name="newsLetterSubscriptionId">The newsletter subscription identifier</param>
        /// <returns>NewsLetter subscription</returns>
        public NewsLetterSubscription GetNewsLetterSubscriptionById(int newsLetterSubscriptionId)
        {
            return _newsLetterSubscriptionService.GetNewsLetterSubscriptionById(newsLetterSubscriptionId);
        }

        /// <summary>
        /// Gets a newsletter subscription by newsletter subscription GUID
        /// </summary>
        /// <param name="newsLetterSubscriptionGuid">The newsletter subscription GUID</param>
        /// <returns>NewsLetter subscription</returns>
        public NewsLetterSubscription GetNewsLetterSubscriptionByGuid(Guid newsLetterSubscriptionGuid)
        {
            return _newsLetterSubscriptionService.GetNewsLetterSubscriptionByGuid(newsLetterSubscriptionGuid);
        }

        /// <summary>
        /// Gets a newsletter subscription by email and store ID
        /// </summary>
        /// <param name="email">The newsletter subscription email</param>
        /// <param name="storeId">Store identifier</param>
        /// <returns>NewsLetter subscription</returns>
        public NewsLetterSubscription GetNewsLetterSubscriptionByEmailAndStoreId(string email, int storeId)
        {
            return _newsLetterSubscriptionService.GetNewsLetterSubscriptionByEmailAndStoreId(email, storeId);
        }

        /// <summary>
        /// Gets the newsletter subscription list
        /// </summary>
        /// <param name="email">Email to search or string. Empty to load all records.</param>
        /// <param name="createdFromUtc">Created date from (UTC); null to load all records</param>
        /// <param name="createdToUtc">Created date to (UTC); null to load all records</param>
        /// <param name="storeId">Store identifier. 0 to load all records.</param>
        /// <param name="isActive">Value indicating whether subscriber record should be active or not; null to load all records</param>
        /// <param name="customerRoleId">Customer role identifier. Used to filter subscribers by customer role. 0 to load all records.</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>NewsLetterSubscription entities</returns>
        public IAPIPagedList<NewsLetterSubscription> GetAllNewsLetterSubscriptions(string email = null,
            DateTime? createdFromUtc = null, DateTime? createdToUtc = null,
            int storeId = 0, bool? isActive = null, int customerRoleId = 0,
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return _newsLetterSubscriptionService.GetAllNewsLetterSubscriptions(email, createdFromUtc, createdToUtc, storeId, isActive, customerRoleId, pageIndex, pageSize).ConvertPagedListToAPIPagedList();
        }

        #endregion

        #region Queued email

        /// <summary>
        /// Inserts a queued email
        /// </summary>
        /// <param name="queuedEmail">Queued email</param>
        public void InsertQueuedEmail(QueuedEmail queuedEmail)
        {
            _queuedEmailService.InsertQueuedEmail(queuedEmail);
        }

        /// <summary>
        /// Updates a queued email
        /// </summary>
        /// <param name="queuedEmail">Queued email</param>
        public void UpdateQueuedEmail(QueuedEmail queuedEmail)
        {
            _queuedEmailService.UpdateQueuedEmail(queuedEmail);
        }

        /// <summary>
        /// Deleted a queued email
        /// </summary>
        /// <param name="queuedEmail">Queued email</param>
        public void DeleteQueuedEmail(QueuedEmail queuedEmail)
        {
            _queuedEmailService.DeleteQueuedEmail(queuedEmail);
        }

        /// <summary>
        /// Deleted a queued emails
        /// </summary>
        /// <param name="queuedEmails">Queued emails</param>
        public void DeleteQueuedEmails(IList<QueuedEmail> queuedEmails)
        {
            _queuedEmailService.DeleteQueuedEmails(queuedEmails);
        }

        /// <summary>
        /// Gets a queued email by identifier
        /// </summary>
        /// <param name="queuedEmailId">Queued email identifier</param>
        /// <returns>Queued email</returns>
        public QueuedEmail GetQueuedEmailById(int queuedEmailId)
        {
            return _queuedEmailService.GetQueuedEmailById(queuedEmailId);
        }

        /// <summary>
        /// Get queued emails by identifiers
        /// </summary>
        /// <param name="queuedEmailIds">queued email identifiers</param>
        /// <returns>Queued emails</returns>
        public IList<QueuedEmail> GetQueuedEmailsByIds(int[] queuedEmailIds)
        {
            return _queuedEmailService.GetQueuedEmailsByIds(queuedEmailIds);
        }

        /// <summary>
        /// Search queued emails
        /// </summary>
        /// <param name="fromEmail">From Email</param>
        /// <param name="toEmail">To Email</param>
        /// <param name="createdFromUtc">Created date from (UTC); null to load all records</param>
        /// <param name="createdToUtc">Created date to (UTC); null to load all records</param>
        /// <param name="loadNotSentItemsOnly">A value indicating whether to load only not sent emails</param>
        /// <param name="loadOnlyItemsToBeSent">A value indicating whether to load only emails for ready to be sent</param>
        /// <param name="maxSendTries">Maximum send tries</param>
        /// <param name="loadNewest">A value indicating whether we should sort queued email descending; otherwise, ascending.</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Queued emails</returns>
        public IAPIPagedList<QueuedEmail> SearchEmails(string fromEmail,
            string toEmail, DateTime? createdFromUtc, DateTime? createdToUtc,
            bool loadNotSentItemsOnly, bool loadOnlyItemsToBeSent, int maxSendTries,
            bool loadNewest, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return _queuedEmailService.SearchEmails(fromEmail, toEmail, createdFromUtc, createdToUtc, loadNotSentItemsOnly, loadOnlyItemsToBeSent, maxSendTries, loadNewest, pageIndex, pageSize).ConvertPagedListToAPIPagedList();
        }

        /// <summary>
        /// Delete all queued emails
        /// </summary>
        public void DeleteAllEmails()
        {
            _queuedEmailService.DeleteAllEmails();
        }

        #endregion

        #region Workflow Message

        #region Customer workflow

        /// <summary>
        /// Sends 'New customer' notification message to a store owner
        /// </summary>
        /// <param name="customer">Customer instance</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public int SendCustomerRegisteredNotificationMessage(Customer customer, int languageId)
        {
            return _workflowMessageService.SendCustomerRegisteredNotificationMessage(customer, languageId);
        }

        /// <summary>
        /// Sends a welcome message to a customer
        /// </summary>
        /// <param name="customer">Customer instance</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public int SendCustomerWelcomeMessage(Customer customer, int languageId)
        {
            return _workflowMessageService.SendCustomerWelcomeMessage(customer, languageId);
        }

        /// <summary>
        /// Sends an email validation message to a customer
        /// </summary>
        /// <param name="customer">Customer instance</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public int SendCustomerEmailValidationMessage(Customer customer, int languageId)
        {
            return _workflowMessageService.SendCustomerEmailValidationMessage(customer, languageId);
        }

        /// <summary>
        /// Sends an email re-validation message to a customer
        /// </summary>
        /// <param name="customer">Customer instance</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public int SendCustomerEmailRevalidationMessage(Customer customer, int languageId)
        {
            return _workflowMessageService.SendCustomerEmailRevalidationMessage(customer, languageId);
        }

        /// <summary>
        /// Sends password recovery message to a customer
        /// </summary>
        /// <param name="customer">Customer instance</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public int SendCustomerPasswordRecoveryMessage(Customer customer, int languageId)
        {
            return _workflowMessageService.SendCustomerPasswordRecoveryMessage(customer, languageId);
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
        public int SendOrderPlacedVendorNotification(Order order, Vendor vendor, int languageId)
        {
            return _workflowMessageService.SendOrderPlacedVendorNotification(order, vendor, languageId);
        }

        /// <summary>
        /// Sends an order placed notification to a store owner
        /// </summary>
        /// <param name="order">Order instance</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public int SendOrderPlacedStoreOwnerNotification(Order order, int languageId)
        {
            return _workflowMessageService.SendOrderPlacedStoreOwnerNotification(order, languageId);
        }

        /// <summary>
        /// Sends an order paid notification to a store owner
        /// </summary>
        /// <param name="order">Order instance</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public int SendOrderPaidStoreOwnerNotification(Order order, int languageId)
        {
            return _workflowMessageService.SendOrderPaidStoreOwnerNotification(order, languageId);
        }

        /// <summary>
        /// Sends an order paid notification to a customer
        /// </summary>
        /// <param name="order">Order instance</param>
        /// <param name="languageId">Message language identifier</param>
        /// <param name="attachmentFilePath">Attachment file path</param>
        /// <param name="attachmentFileName">Attachment file name. If specified, then this file name will be sent to a recipient. Otherwise, "AttachmentFilePath" name will be used.</param>
        /// <returns>Queued email identifier</returns>
        public int SendOrderPaidCustomerNotification(Order order, int languageId,
            string attachmentFilePath = null, string attachmentFileName = null)
        {
            return _workflowMessageService.SendOrderPaidCustomerNotification(order, languageId, attachmentFilePath, attachmentFileName);
        }

        /// <summary>
        /// Sends an order paid notification to a vendor
        /// </summary>
        /// <param name="order">Order instance</param>
        /// <param name="vendor">Vendor instance</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public int SendOrderPaidVendorNotification(Order order, Vendor vendor, int languageId)
        {
            return _workflowMessageService.SendOrderPaidVendorNotification(order, vendor, languageId);
        }

        /// <summary>
        /// Sends an order placed notification to a customer
        /// </summary>
        /// <param name="order">Order instance</param>
        /// <param name="languageId">Message language identifier</param>
        /// <param name="attachmentFilePath">Attachment file path</param>
        /// <param name="attachmentFileName">Attachment file name. If specified, then this file name will be sent to a recipient. Otherwise, "AttachmentFilePath" name will be used.</param>
        /// <returns>Queued email identifier</returns>
        public int SendOrderPlacedCustomerNotification(Order order, int languageId,
            string attachmentFilePath = null, string attachmentFileName = null)
        {
            return _workflowMessageService.SendOrderPlacedCustomerNotification(order, languageId, attachmentFilePath, attachmentFileName);
        }

        /// <summary>
        /// Sends a shipment sent notification to a customer
        /// </summary>
        /// <param name="shipment">Shipment</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public int SendShipmentSentCustomerNotification(Shipment shipment, int languageId)
        {
            return _workflowMessageService.SendShipmentSentCustomerNotification(shipment, languageId);
        }

        /// <summary>
        /// Sends a shipment delivered notification to a customer
        /// </summary>
        /// <param name="shipment">Shipment</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public int SendShipmentDeliveredCustomerNotification(Shipment shipment, int languageId)
        {
            return _workflowMessageService.SendShipmentDeliveredCustomerNotification(shipment, languageId);
        }

        /// <summary>
        /// Sends an order completed notification to a customer
        /// </summary>
        /// <param name="order">Order instance</param>
        /// <param name="languageId">Message language identifier</param>
        /// <param name="attachmentFilePath">Attachment file path</param>
        /// <param name="attachmentFileName">Attachment file name. If specified, then this file name will be sent to a recipient. Otherwise, "AttachmentFilePath" name will be used.</param>
        /// <returns>Queued email identifier</returns>
        public int SendOrderCompletedCustomerNotification(Order order, int languageId,
            string attachmentFilePath = null, string attachmentFileName = null)
        {
            return _workflowMessageService.SendOrderCompletedCustomerNotification(order, languageId, attachmentFilePath, attachmentFileName);
        }

        /// <summary>
        /// Sends an order cancelled notification to a customer
        /// </summary>
        /// <param name="order">Order instance</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public int SendOrderCancelledCustomerNotification(Order order, int languageId)
        {
            return _workflowMessageService.SendOrderCancelledCustomerNotification(order, languageId);
        }

        /// <summary>
        /// Sends an order refunded notification to a store owner
        /// </summary>
        /// <param name="order">Order instance</param>
        /// <param name="refundedAmount">Amount refunded</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public int SendOrderRefundedStoreOwnerNotification(Order order, decimal refundedAmount, int languageId)
        {
            return _workflowMessageService.SendOrderRefundedStoreOwnerNotification(order, refundedAmount, languageId);
        }

        /// <summary>
        /// Sends an order refunded notification to a customer
        /// </summary>
        /// <param name="order">Order instance</param>
        /// <param name="refundedAmount">Amount refunded</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public int SendOrderRefundedCustomerNotification(Order order, decimal refundedAmount, int languageId)
        {
            return _workflowMessageService.SendOrderRefundedCustomerNotification(order, refundedAmount, languageId);
        }

        /// <summary>
        /// Sends a new order note added notification to a customer
        /// </summary>
        /// <param name="orderNote">Order note</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public int SendNewOrderNoteAddedCustomerNotification(OrderNote orderNote, int languageId)
        {
            return _workflowMessageService.SendNewOrderNoteAddedCustomerNotification(orderNote, languageId);
        }

        /// <summary>
        /// Sends a "Recurring payment cancelled" notification to a store owner
        /// </summary>
        /// <param name="recurringPayment">Recurring payment</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public int SendRecurringPaymentCancelledStoreOwnerNotification(RecurringPayment recurringPayment, int languageId)
        {
            return _workflowMessageService.SendRecurringPaymentCancelledStoreOwnerNotification(recurringPayment, languageId);
        }

        /// <summary>
        /// Sends a "Recurring payment cancelled" notification to a customer
        /// </summary>
        /// <param name="recurringPayment">Recurring payment</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public int SendRecurringPaymentCancelledCustomerNotification(RecurringPayment recurringPayment, int languageId)
        {
            return _workflowMessageService.SendRecurringPaymentCancelledCustomerNotification(recurringPayment, languageId);
        }

        /// <summary>
        /// Sends a "Recurring payment failed" notification to a customer
        /// </summary>
        /// <param name="recurringPayment">Recurring payment</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public int SendRecurringPaymentFailedCustomerNotification(RecurringPayment recurringPayment, int languageId)
        {
            return _workflowMessageService.SendRecurringPaymentFailedCustomerNotification(recurringPayment, languageId);
        }

        #endregion

        #region Newsletter workflow

        /// <summary>
        /// Sends a newsletter subscription activation message
        /// </summary>
        /// <param name="subscription">Newsletter subscription</param>
        /// <param name="languageId">Language identifier</param>
        /// <returns>Queued email identifier</returns>
        public int SendNewsLetterSubscriptionActivationMessage(NewsLetterSubscription subscription,
            int languageId)
        {
            return _workflowMessageService.SendNewsLetterSubscriptionActivationMessage(subscription, languageId);
        }

        /// <summary>
        /// Sends a newsletter subscription deactivation message
        /// </summary>
        /// <param name="subscription">Newsletter subscription</param>
        /// <param name="languageId">Language identifier</param>
        /// <returns>Queued email identifier</returns>
        public int SendNewsLetterSubscriptionDeactivationMessage(NewsLetterSubscription subscription,
            int languageId)
        {
            return _workflowMessageService.SendNewsLetterSubscriptionDeactivationMessage(subscription, languageId);
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
        public int SendProductEmailAFriendMessage(Customer customer, int languageId,
            Product product, string customerEmail, string friendsEmail, string personalMessage)
        {
            return _workflowMessageService.SendProductEmailAFriendMessage(customer, languageId, product, customerEmail, friendsEmail, personalMessage);
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
        public int SendWishlistEmailAFriendMessage(Customer customer, int languageId,
             string customerEmail, string friendsEmail, string personalMessage)
        {
            return _workflowMessageService.SendWishlistEmailAFriendMessage(customer, languageId, customerEmail, friendsEmail, personalMessage);
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
        public int SendNewReturnRequestStoreOwnerNotification(ReturnRequest returnRequest, OrderItem orderItem, int languageId)
        {
            return _workflowMessageService.SendNewReturnRequestStoreOwnerNotification(returnRequest, orderItem, languageId);
        }

        /// <summary>
        /// Sends 'New Return Request' message to a customer
        /// </summary>
        /// <param name="returnRequest">Return request</param>
        /// <param name="orderItem">Order item</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public int SendNewReturnRequestCustomerNotification(ReturnRequest returnRequest, OrderItem orderItem, int languageId)
        {
            return _workflowMessageService.SendNewReturnRequestCustomerNotification(returnRequest, orderItem, languageId);
        }

        /// <summary>
        /// Sends 'Return Request status changed' message to a customer
        /// </summary>
        /// <param name="returnRequest">Return request</param>
        /// <param name="orderItem">Order item</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public int SendReturnRequestStatusChangedCustomerNotification(ReturnRequest returnRequest, OrderItem orderItem, int languageId)
        {
            return _workflowMessageService.SendReturnRequestStatusChangedCustomerNotification(returnRequest, orderItem, languageId);
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
        public int SendNewForumTopicMessage(Customer customer,
            ForumTopic forumTopic, Forum forum, int languageId)
        {
            return _workflowMessageService.SendNewForumTopicMessage(customer, forumTopic, forum, languageId);
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
        public int SendNewForumPostMessage(Customer customer,
            ForumPost forumPost, ForumTopic forumTopic,
            Forum forum, int friendlyForumTopicPageIndex,
            int languageId)
        {
            return _workflowMessageService.SendNewForumPostMessage(customer, forumPost, forumTopic, forum, friendlyForumTopicPageIndex, languageId);
        }

        /// <summary>
        /// Sends a private message notification
        /// </summary>
        /// <param name="privateMessage">Private message</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public int SendPrivateMessageNotification(PrivateMessage privateMessage, int languageId)
        {
            return _workflowMessageService.SendPrivateMessageNotification(privateMessage, languageId);
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
        public int SendNewVendorAccountApplyStoreOwnerNotification(Customer customer, Vendor vendor, int languageId)
        {
            return _workflowMessageService.SendNewVendorAccountApplyStoreOwnerNotification(customer, vendor, languageId);
        }

        /// <summary>
        /// Sends 'Vendor information change' message to a store owner
        /// </summary>
        /// <param name="vendor">Vendor</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public int SendVendorInformationChangeNotification(Vendor vendor, int languageId)
        {
            return _workflowMessageService.SendVendorInformationChangeNotification(vendor, languageId);
        }

        /// <summary>
        /// Sends a product review notification message to a store owner
        /// </summary>
        /// <param name="productReview">Product review</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public int SendProductReviewNotificationMessage(ProductReview productReview,
            int languageId)
        {
            return _workflowMessageService.SendProductReviewNotificationMessage(productReview, languageId);
        }


        /// <summary>
        /// Sends a gift card notification
        /// </summary>
        /// <param name="giftCard">Gift card</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public int SendGiftCardNotification(GiftCard giftCard, int languageId)
        {
            return _workflowMessageService.SendGiftCardNotification(giftCard, languageId);
        }


        /// <summary>
        /// Sends a "quantity below" notification to a store owner
        /// </summary>
        /// <param name="product">Product</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public int SendQuantityBelowStoreOwnerNotification(Product product, int languageId)
        {
            return _workflowMessageService.SendQuantityBelowStoreOwnerNotification(product, languageId);
        }

        /// <summary>
        /// Sends a "quantity below" notification to a store owner
        /// </summary>
        /// <param name="combination">Attribute combination</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public int SendQuantityBelowStoreOwnerNotification(ProductAttributeCombination combination, int languageId)
        {
            return _workflowMessageService.SendQuantityBelowStoreOwnerNotification(combination, languageId);
        }

        /// <summary>
        /// Sends a "new VAT submitted" notification to a store owner
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="vatName">Received VAT name</param>
        /// <param name="vatAddress">Received VAT address</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public int SendNewVatSubmittedStoreOwnerNotification(Customer customer,
            string vatName, string vatAddress, int languageId)
        {
            return _workflowMessageService.SendNewVatSubmittedStoreOwnerNotification(customer, vatName, vatAddress, languageId);
        }

        /// <summary>
        /// Sends a blog comment notification message to a store owner
        /// </summary>
        /// <param name="blogComment">Blog comment</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public int SendBlogCommentNotificationMessage(BlogComment blogComment, int languageId)
        {
            return _workflowMessageService.SendBlogCommentNotificationMessage(blogComment, languageId);
        }

        /// <summary>
        /// Sends a news comment notification message to a store owner
        /// </summary>
        /// <param name="newsComment">News comment</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public int SendNewsCommentNotificationMessage(NewsComment newsComment, int languageId)
        {
            return _workflowMessageService.SendNewsCommentNotificationMessage(newsComment, languageId);
        }

        /// <summary>
        /// Sends a 'Back in stock' notification message to a customer
        /// </summary>
        /// <param name="subscription">Subscription</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public int SendBackInStockNotification(BackInStockSubscription subscription, int languageId)
        {
            return _workflowMessageService.SendBackInStockNotification(subscription, languageId);
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
        public int SendContactUsMessage(int languageId, string senderEmail, string senderName, string subject, string body)
        {
            return _workflowMessageService.SendContactUsMessage(languageId, senderEmail, senderName, subject, body);
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
        public int SendContactVendorMessage(Vendor vendor, int languageId, string senderEmail,
            string senderName, string subject, string body)
        {
            return _workflowMessageService.SendContactVendorMessage(vendor, languageId, senderEmail, senderName, subject, body);
        }

        /// <summary>
        /// Sends a test email
        /// </summary>
        /// <param name="messageTemplateId">Message template identifier</param>
        /// <param name="sendToEmail">Send to email</param>
        /// <param name="tokens">Tokens</param>
        /// <param name="languageId">Message language identifier</param>
        /// <returns>Queued email identifier</returns>
        public int SendTestEmail(int messageTemplateId, string sendToEmail, List<Token> tokens, int languageId)
        {
            return _workflowMessageService.SendTestEmail(messageTemplateId, sendToEmail, tokens, languageId);
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
        public int SendNotification(MessageTemplate messageTemplate,
            EmailAccount emailAccount, int languageId, IEnumerable<Token> tokens,
            string toEmailAddress, string toName,
            string attachmentFilePath = null, string attachmentFileName = null,
            string replyToEmailAddress = null, string replyToName = null,
            string fromEmail = null, string fromName = null, string subject = null)
        {
            return _workflowMessageService.SendNotification(messageTemplate, emailAccount, languageId, tokens, toEmailAddress, toName, attachmentFilePath, attachmentFileName, replyToEmailAddress, replyToName, fromEmail, fromName, subject);
        }

        #endregion

        #endregion

        #endregion
    }
}
