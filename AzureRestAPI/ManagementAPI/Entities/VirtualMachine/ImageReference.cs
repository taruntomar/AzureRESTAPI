using Newtonsoft.Json;

namespace AzureRestAPI.ManagementAPI.Entities.VirtualMachine
{
    public partial class ImageReference
    {
        [JsonProperty("publisher")]
        public string Publisher { get; set; }

        [JsonProperty("offer")]
        public string Offer { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
