using Newtonsoft.Json;

namespace AzureRestAPI.ManagementAPI.Entities.VirtualMachine
{
    public partial class StorageProfile
    {
        [JsonProperty("imageReference")]
        public ImageReference ImageReference { get; set; }

        [JsonProperty("dataDisks")]
        public object[] DataDisks { get; set; }

        [JsonProperty("osDisk")]
        public OsDisk OsDisk { get; set; }
    }
}
