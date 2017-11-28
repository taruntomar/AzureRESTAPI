using AzureRestAPI.ManagementAPI.Entities;
using AzureRestAPI.ManagementAPI.Entities.Subscription;
using AzureRestAPI.ManagementAPI.Entities.VirtualMachine;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using TTOAuthManager.Azure;

namespace AzureRestAPI.ManagementAPI
{
    public class AzureManagementAPI:AzureRestAPI
    {
        #region private fields
        string baseurl = "https://graph.microsoft.com/v1.0";
        private RESTManager _azureManager;
        #endregion
        public AzureManagementAPI(AzureADE2EManager azureADE2EManager) :base(azureADE2EManager)
        {
            _azureManager = new RESTManager(AzureAPIs.ManagementAPI);
        }

        public BasicResourceInfo[]  ListResources(string subscriptionId, string resourceGroupName, Product[] products)
        {
            string resource = @"subscriptions/" + subscriptionId + @"/resourceGroups/" + resourceGroupName + @"/resources";
            IRestResponse response = _azureManager.AzureRESTRequest(resource, Method.GET);
            List<object> services = new List<object>();
            Service[] servicesz = _azureManager.Parse<Service[]>(response);
            if (servicesz == null)
                return null;

            return servicesz.Select(x => AbstractServiceDetail(x, products)).ToArray();

        }

        public Subscription[] GetSubscriptions()
        {
            string resource = @"subscriptions/";
            IRestResponse response = _azureManager.AzureRESTRequest(resource, Method.GET);
            Subscription[] subs = _azureManager.Parse<Subscription[]>(response);
            //var subs = subscriptions.Select(x => new { id = x.subscriptionId, name = x.displayName, img = "/Content/images/azure_products/subscriptions.svg" });

            return subs;
        }

        public dynamic GetProductDetail(string subscriptionId, string resourceGroupName, string provider, string serviceType, string serviceName)
        {
            var resource = "subscriptions/" + subscriptionId + "/resourceGroups/" + resourceGroupName + "/providers/" + provider + "/" + serviceType + "/" + serviceName;
            IRestResponse response = _azureManager.AzureRESTRequest(resource, Method.GET);

            VirtualMachine vm = VirtualMachine.FromJson(response.Content);

            return vm;
        }

        public dynamic GetProductDetail(string subscriptionId, string resourceGroupName, string provider, string serviceType, string serviceName, string extraParameter)
        {
            var resource = "subscriptions/" + subscriptionId + "/resourceGroups/" + resourceGroupName + "/providers/" + provider + "/" + serviceType + "/" + serviceName + "/" + extraParameter;
            IRestResponse response = _azureManager.AzureRESTRequest(resource, Method.GET);

            VirtualMachineInstanceInfo vm = VirtualMachineInstanceInfo.FromJson(response.Content);

            return vm;
        }

        public dynamic GetMetricDefinitions(string subscriptionId, string resourceGroupName, string provider, string serviceType, string serviceName, string extraParameter)
        {
            var resource = "subscriptions/" + subscriptionId + "/resourceGroups/" + resourceGroupName + "/providers/" + provider + "/" + serviceType + "/" + serviceName + "/" + extraParameter;
            IRestResponse response = _azureManager.AzureRESTRequest(resource, Method.GET);

            MetricDefinitions md = MetricDefinitions.FromJson(response.Content);

            return md.Value.Select(x => new { id = x.Id, name = x.Name.Value, unit = x.Unit, selected = false });
        }

        private BasicResourceInfo AbstractServiceDetail(Service service, Product[] products)
        {
            var img = getIconForResource(service.type, products).ToString();
            var appName = img.Substring(img.LastIndexOf('/') + 1).Replace(".svg", "");
            var label = appName;
            var route = appName.ToLower();
            return new BasicResourceInfo { id = service.id, name = service.name, img = img, appName = appName, label = label, route = route };
        }

        private object getIconForResource(string type, Product[] products)
        {
            if (products != null)
            {
                Product p = products.FirstOrDefault(x => x.type.ToString().Length != 0 && type.Contains(x.type.ToString()));
                if (p != null)
                {
                    return @"/Content/images/azure_products/" + p.icon;
                }
            }
            return @"/Content/images/azure_products/storage.svg";

        }



        public ResourceGroup[] GetResourceGroups(string subscriptionId)
        {
            string resource = @"subscriptions/" + subscriptionId + @"/resourceGroups/";

            IRestResponse response = _azureManager.AzureRESTRequest(resource, Method.GET);
            ResourceGroup[] resourceGroups = _azureManager.Parse<ResourceGroup[]>(response);
            return resourceGroups;
            //return resourceGroups.Select(x => new { id=x.id,name=x.name, img = "/Content/images/azure_products/resourcegroup.svg" });

        }

        public dynamic GetMetrics(string subscriptionId, string resourceGroupName, string provider, string serviceType, string serviceName, string extraParameter, bool addApiVersion)
        {
            var resource = "subscriptions/" + subscriptionId + "/resourceGroups/" + resourceGroupName + "/providers/" + provider + "/" + serviceType + "/" + serviceName + "/" + extraParameter;
            IRestResponse response = _azureManager.AzureRESTRequest(resource, Method.GET, "", addApiVersion);

            Metric md = Metric.FromJson(response.Content);

            return md.Value.First().Timeseries.First().Data;
        }

        public class BasicResourceInfo
        {
            public string id { get; set; }
            public string name { get; set; }
            public string img { get; set; }
            public string label { get; set; }
            public string appName { get; set; }
            public string route { get; set; }

        }
    }
}
