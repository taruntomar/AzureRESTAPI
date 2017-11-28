using Newtonsoft.Json;

namespace AzureRestAPI.ManagementAPI.Entities.VirtualMachine
{
    public partial class OtherProperties
    {
        [JsonProperty("provisioningState")]
        public string ProvisioningState { get; set; }

        [JsonProperty("settings")]
        public Settings Settings { get; set; }

        [JsonProperty("autoUpgradeMinorVersion")]
        public bool AutoUpgradeMinorVersion { get; set; }

        [JsonProperty("publisher")]
        public string Publisher { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("typeHandlerVersion")]
        public string TypeHandlerVersion { get; set; }
    }
}
