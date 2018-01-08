using Nop.Plugin.Affiliate.Amazon.Models;
using Nop.Plugin.Affiliate.Amazon.Models.Response;
using System.Collections.Generic;

namespace Nop.Plugin.Affiliate.Amazon.Services
{
    public partial interface IAmazonService
    {
        BrowseNodeLookupResponse BrowseNodeLookup(AffiliateAmazonSettings amazonSettings, string browseNodeId, string responseGroup = "BrowseNodeInfo");
        ItemSearchResponse ItemSearch(AffiliateAmazonSettings amazonSettings, string searchIndex, string browseNode, string Keywords = "", string responseGroup = "Small", params KeyValuePair<string, string>[] param);
        ItemLookupResponse ItemLookup(AffiliateAmazonSettings amazonSettings, string itemId, string responseGroup = "", params KeyValuePair<string, string>[] param);

        void SyncCategory(AffiliateAmazonSettings amazonSettings, string browseNodeID = "");
        void SyncProducts(int storeId, int categoryId, string keyword, SyncProperties syncProperties);
        void UpdateProducts(int storeId,int categoryId, SyncProperties syncProperties);
        void SyncProduct(int storeId, int productSourceId, SyncProperties syncProperties);
    }
}
