using Newtonsoft.Json;

namespace AzureRestAPI.ManagementAPI.Entities.VirtualMachine
{
    public partial class Status
    {
        [JsonProperty("displayStatus")]
        public string DisplayStatus { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("level")]
        public string Level { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }
    }
}
