using Nop.Core;
using Nop.Core.Domain.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Affiliate.CategoryMap.Domain
{
    public class ProductMapping : BaseEntity, ILocalizedEntity
    {
        public int ProductId { get; set; }
        public string ProductSourceId { get; set; }
        public string ProductSourceLink { get; set; }
        public int SourceId { get; set; }
        public decimal Price { get; set; }
    }
}
