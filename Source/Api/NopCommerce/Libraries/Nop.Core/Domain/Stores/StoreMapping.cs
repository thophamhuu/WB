using System.Runtime.Serialization;

namespace Nop.Core.Domain.Stores
{
    /// <summary>
    /// Represents a store mapping record
    /// </summary>
    public partial class StoreMapping : BaseEntity
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
        /// Gets or sets the store identifier
        /// </summary>
        [DataMember]
        public int StoreId { get; set; }

        /// <summary>
        /// Gets or sets the store
        /// </summary>
        public virtual Store Store { get; set; }
    }
}
