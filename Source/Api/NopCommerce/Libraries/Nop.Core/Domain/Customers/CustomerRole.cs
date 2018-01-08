using System.Collections.Generic;
using Nop.Core.Domain.Security;
using System;
using System.Runtime.Serialization;

namespace Nop.Core.Domain.Customers
{
    /// <summary>
    /// Represents a customer role
    /// </summary>
    [DataContract(IsReference =true)]
    public partial class CustomerRole : BaseEntity
    {
        private ICollection<PermissionRecord> _permissionRecords;

        /// <summary>
        /// Gets or sets the customer role name
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer role is marked as free shiping
        /// </summary>
        [DataMember]
        public bool FreeShipping { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer role is marked as tax exempt
        /// </summary>
        [DataMember]
        public bool TaxExempt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer role is active
        /// </summary>
        [DataMember]
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer role is system
        /// </summary>
        [DataMember]
        public bool IsSystemRole { get; set; }

        /// <summary>
        /// Gets or sets the customer role system name
        /// </summary>
        [DataMember]
        public string SystemName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customers must change passwords after a specified time
        /// </summary>
        [DataMember]
        public bool EnablePasswordLifetime { get; set; }

        /// <summary>
        /// Gets or sets a product identifier that is required by this customer role. 
        /// A customer is added to this customer role once a specified product is purchased.
        /// </summary>
        [DataMember]
        public int PurchasedWithProductId { get; set; }

        /// <summary>
        /// Gets or sets the permission records
        /// </summary>
        [DataMember]
        public virtual ICollection<PermissionRecord> PermissionRecords
        {
            get { return _permissionRecords ?? (_permissionRecords = new List<PermissionRecord>()); }
            protected set { _permissionRecords = value; }
        }
    }

}