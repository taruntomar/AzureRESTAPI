using Newtonsoft.Json;

namespace AzureRestAPI.ManagementAPI.Entities.VirtualMachine
{
    public partial class Disk
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("statuses")]
        public Status[] Statuses { get; set; }
    }
}
