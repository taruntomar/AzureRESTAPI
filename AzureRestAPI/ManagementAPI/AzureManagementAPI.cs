using AzureRestAPI.ManagementAPI.Entities;
using AzureRestAPI.ManagementAPI.Entities.Subscription;
using AzureRestAPI.ManagementAPI.Entities.VirtualMachine;
using System.Linq;

namespace AzureRestAPI.ManagementAPI
{
    public partial class AzureManagementAPI:AzureRestAPI
    {
        #region private fields
        #endregion
        public AzureManagementAPI()
        {
            BaseURL = "https://management.azure.com/";
            Authenticator.Config.Resource = @"https://management.azure.com/";
            Authenticator.Config.Authority = @"https://management.core.windows.net/";
        }
        

        public RestResponse<BasicResourceInfo[],Error>  ListResources(string subscriptionId, string resourceGroupName, Product[] products)
        {
            string endpoint = @"subscriptions/" + subscriptionId + @"/resourceGroups/" + resourceGroupName + @"/resources";
            var response = RestRequest<BasicResourceInfo[], Error>(endpoint, "");
            return response;

            //List<object> services = new List<object>();
            //Service[] servicesz = Parse<Service[]>(response);
            //if (servicesz == null)
            //    return null;

            //return servicesz.Select(x => AbstractServiceDetail(x, products)).ToArray();

        }

        public RestResponse<Subscription[],Error> Subscriptions()
        {
            string endpoint = @"subscriptions/";
            var response = RestRequest< Subscription[],Error>(endpoint,"");
            return response;
        }

        public RestResponse<VirtualMachine,Error> GetProductDetail(string subscriptionId, string resourceGroupName, string provider, string serviceType, string serviceName)
        {
            var endpoint = "subscriptions/" + subscriptionId + "/resourceGroups/" + resourceGroupName + "/providers/" + provider + "/" + serviceType + "/" + serviceName;
            var response = RestRequest<VirtualMachine, Error>(endpoint,"");
            return response;
        }

        public RestResponse<VirtualMachineInstanceInfo,Error> GetProductDetail(string subscriptionId, string resourceGroupName, string provider, string serviceType, string serviceName, string extraParameter)
        {
            var resource = "subscriptions/" + subscriptionId + "/resourceGroups/" + resourceGroupName + "/providers/" + provider + "/" + serviceType + "/" + serviceName + "/" + extraParameter;
            var response = RestRequest< VirtualMachineInstanceInfo, Error>(resource, "");
            return response;
        }

        public RestResponse<MetricDefinitions,Error> GetMetricDefinitions(string subscriptionId, string resourceGroupName, string provider, string serviceType, string serviceName, string extraParameter)
        {
            var resource = "subscriptions/" + subscriptionId + "/resourceGroups/" + resourceGroupName + "/providers/" + provider + "/" + serviceType + "/" + serviceName + "/" + extraParameter;
            var response = RestRequest<MetricDefinitions, Error>(resource,"");
            return response;

            //return md.Value.Select(x => new { id = x.Id, name = x.Name.Value, unit = x.Unit, selected = false });
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

        public RestResponse<ResourceGroup[],Error> GetResourceGroups(string subscriptionId)
        {
            string resource = @"subscriptions/" + subscriptionId + @"/resourceGroups/";
            var response = RestRequest<ResourceGroup[], Error>(resource,"");
            return response;
            //return resourceGroups.Select(x => new { id=x.id,name=x.name, img = "/Content/images/azure_products/resourcegroup.svg" });

        }

        public RestResponse<Metric,Error> GetMetrics(string subscriptionId, string resourceGroupName, string provider, string serviceType, string serviceName, string extraParameter)
        {
            var endPoint = "subscriptions/" + subscriptionId + "/resourceGroups/" + resourceGroupName + "/providers/" + provider + "/" + serviceType + "/" + serviceName + "/" + extraParameter;
            var response = RestRequest<Metric, Error>(endPoint, "");
            return response;

            //Metric md = Metric.FromJson(response.Content);

            //return md.Value.First().Timeseries.First().Data;
        }
    }
}
