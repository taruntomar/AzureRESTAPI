using Newtonsoft.Json;

namespace AzureRestAPI.ManagementAPI.Entities.VirtualMachine
{
    public partial class VirtualMachineInstanceInfo
    {
        [JsonProperty("disks")]
        public Disk[] Disks { get; set; }

        [JsonProperty("statuses")]
        public Status[] Statuses { get; set; }
    }
    public partial class VirtualMachineInstanceInfo
    {
        public static VirtualMachineInstanceInfo FromJson(string json) => JsonConvert.DeserializeObject<VirtualMachineInstanceInfo>(json, Converter.Settings);
    }
}
