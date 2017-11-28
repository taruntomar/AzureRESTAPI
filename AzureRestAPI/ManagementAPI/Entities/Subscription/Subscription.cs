using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureRestAPI.ManagementAPI.Entities.Subscription
{
    public class Subscription
    {
        public string id { get; set; }
        public string subscriptionId { get; set; }

        public string displayName { get; set; }
        public string state { get; set; }


        public SubscriptionPolicies SubscriptionPolicies { get; set; }

        public string authorizaionSource { get; set; }


    }

   
}
