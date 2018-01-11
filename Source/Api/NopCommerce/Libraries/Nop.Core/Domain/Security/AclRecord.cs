using Nop.Core.Domain.Customers;
using System.Runtime.Serialization;

namespace Nop.Core.Domain.Security
{
    /// <summary>
    /// Represents an ACL record
    /// </summary>
    public partial class AclRecord : BaseEntity
    {
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        [DataMember]
        public int EntityId { get; set; }

        /// <summary>
        /// Gets or sets the entity name
        /// </summary>
        [DataMember]
        public string EntityName { get; set; }

        /// <summary>
        /// Gets or sets the customer role identifier
        /// </summary>
        [DataMember]
        public int CustomerRoleId { get; set; }

        /// <summary>
        /// Gets or sets the customer role
        /// </summary>
        public virtual CustomerRole CustomerRole { get; set; }
    }
}
