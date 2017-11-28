using Newtonsoft.Json;

namespace AzureRestAPI.ManagementAPI.Entities.VirtualMachine
{
    public partial class OsDisk
    {
        [JsonProperty("createOption")]
        public string CreateOption { get; set; }

        [JsonProperty("caching")]
        public string Caching { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("osType")]
        public string OsType { get; set; }
    }
}
