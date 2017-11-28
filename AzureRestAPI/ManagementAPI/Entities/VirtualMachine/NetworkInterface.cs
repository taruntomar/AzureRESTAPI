using Newtonsoft.Json;

namespace AzureRestAPI.ManagementAPI.Entities.VirtualMachine
{
    public partial class NetworkInterface
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
