
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureRestAPI.ManagementAPI.Entities
{
    public class Service
    {

        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public SKU sku { get; set; }
        public string managedBy { get; set; }
        public string location { get; set; }
        //public string[] tags { get; set; }


    }

    public class SKU
    {
        public string name { get; set; }
        public string tier { get; set; }

    }
}