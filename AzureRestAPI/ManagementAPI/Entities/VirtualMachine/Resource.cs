using Newtonsoft.Json;

namespace AzureRestAPI.ManagementAPI.Entities.VirtualMachine
{
    public partial class Resource
    {
        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("properties")]
        public OtherProperties Properties { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
