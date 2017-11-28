
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureRestAPI.ManagementAPI.Entities
{
    public class Product
    {
        public string name { get; set; }
        public string icon { get; set; }
        public object type { get; set; }
    }

    public class ServiceDetail
    {
        public string PartNumber { get; set; }
        public string Service { get; set; }
        public string UnitOfMeasure { get; set; }
        public double UnitPrice { get; set; }
        public string CurrencyCode
        { get; set; }

        public string Region { get; set; }

    }
}
