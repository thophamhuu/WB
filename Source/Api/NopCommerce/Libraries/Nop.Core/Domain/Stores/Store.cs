using Nop.Core.Domain.Localization;
using System.Runtime.Serialization;

namespace Nop.Core.Domain.Stores
{
    /// <summary>
    /// Represents a store
    /// </summary>
    public partial class Store : BaseEntity, ILocalizedEntity
    {
        /// <summary>
        /// Gets or sets the store name
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the store URL
        /// </summary>
        [DataMember]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether SSL is enabled
        /// </summary>
        [DataMember]
        public bool SslEnabled { get; set; }

        /// <summary>
        /// Gets or sets the store secure URL (HTTPS)
        /// </summary>
        [DataMember]
        public string SecureUrl { get; set; }

        /// <summary>
        /// Gets or sets the comma separated list of possible HTTP_HOST values
        /// </summary>
        public string Hosts { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the default language for this store; 0 is set when we use the default language display order
        /// </summary>
        [DataMember]
        public int DefaultLanguageId { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        [DataMember]
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets the company name
        /// </summary>
        [DataMember]
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the company address
        /// </summary>
        [DataMember]
        public string CompanyAddress { get; set; }

        /// <summary>
        /// Gets or sets the store phone number
        /// </summary>
        [DataMember]
        public string CompanyPhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the company VAT (used in Europe Union countries)
        /// </summary>
        [DataMember]
        public string CompanyVat { get; set; }
    }
}
