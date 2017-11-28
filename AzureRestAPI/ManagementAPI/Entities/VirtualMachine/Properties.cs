using Newtonsoft.Json;

namespace AzureRestAPI.ManagementAPI.Entities.VirtualMachine
{
    public partial class Properties
    {
        [JsonProperty("networkProfile")]
        public NetworkProfile NetworkProfile { get; set; }

        [JsonProperty("provisioningState")]
        public string ProvisioningState { get; set; }

        [JsonProperty("hardwareProfile")]
        public HardwareProfile HardwareProfile { get; set; }

        [JsonProperty("osProfile")]
        public OsProfile OsProfile { get; set; }

        [JsonProperty("storageProfile")]
        public StorageProfile StorageProfile { get; set; }
    }
}
