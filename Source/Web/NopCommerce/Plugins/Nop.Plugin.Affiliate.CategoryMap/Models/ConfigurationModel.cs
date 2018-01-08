using Nop.Web.Framework;
using Nop.Web.Framework.Mvc;

namespace Nop.Plugin.Affiliate.CategoryMap.Models
{
    public class ConfigurationModel : BaseNopModel
    {
        public int ActiveStoreScopeConfiguration { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Affiliate.CategoryMap.AdditionalCostPercent")]
        public decimal AdditionalCostPercent { get; set; }
    }
}