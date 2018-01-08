using Newtonsoft.Json;
using Nop.Core.Configuration;
using System;
using System.Collections.Generic;

namespace Nop.Plugin.Affiliate.Amazon
{
    public class AffiliateAmazonSettings : ISettings
    {
        public DateTime? RunTaskTime { get; set; }
        public string Service { get; set; }

        public string Endpoint { get; set; }
        public string Version { get; set; }
        public string Accounts { get; set; }
        public int Durations { get; set; }
        public string AssociateTag
        {
            get
            {
                return Account.AssociateTag;
            }
        }
        public string AWSAccessKeyID
        {
            get
            {
                return Account.AccessKeyID;
            }
        }
        public string AWSSecretKey
        {
            get
            {
                return Account.SecretKey;
            }
        }
        public int Index { get; set; }
        public AffiliateAmazonAccount Account
        {
            get
            {
                return ListAccounts[Index];
            }
        }
        public int Wait
        {
            get
            {
                if (!Account.UsedTime.HasValue)
                    return 0;
                int spent = (int)(DateTime.Now - Account.UsedTime.Value).TotalMilliseconds;
                return Durations - spent;
            }
        }
        public List<AffiliateAmazonAccount> ListAccounts
        {
            get
            {
                var list = !string.IsNullOrEmpty(Accounts) && !string.IsNullOrWhiteSpace(Accounts) ? JsonConvert.DeserializeObject<List<AffiliateAmazonAccount>>(Accounts) : new List<AffiliateAmazonAccount>();
                list.ForEach(x =>
                {
                    if (!x.UsedTime.HasValue)
                        x.IsUsed = false;
                    else
                    {
                        var ms = (int)DateTime.Now.Subtract(x.UsedTime.Value).TotalMilliseconds;
                        if (ms >= Durations)
                            x.IsUsed = false;
                        else
                            x.IsUsed = true;
                    }
                });
                return list;
            }
        }
    }
    public class AffiliateAmazonAccount
    {
        public string AssociateTag { get; set; }
        public string AccessKeyID { get; set; }
        public string SecretKey { get; set; }
        public DateTime? UsedTime { get; set; }
        public bool IsUsed { get; set; }
    }
}