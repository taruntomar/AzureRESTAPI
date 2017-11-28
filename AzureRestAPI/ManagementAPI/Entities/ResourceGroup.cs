using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureRestAPI.ManagementAPI.Entities
{
    public class ResourceGroup
    {
        public string id { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public ResourceGroupProperties properties { get; set; }

    }

    public class ResourceGroupProperties
    {
        public string provisioningState { get; set; }
    }
}
