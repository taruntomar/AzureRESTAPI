using Newtonsoft.Json;

namespace AzureRestAPI.ManagementAPI.Entities.VirtualMachine
{
    public partial class HardwareProfile
    {
        [JsonProperty("vmSize")]
        public string VmSize { get; set; }
    }
}
