using Newtonsoft.Json;

namespace AzureRestAPI.ManagementAPI.Entities.VirtualMachine
{
    public partial class OsProfile
    {
        [JsonProperty("computerName")]
        public string ComputerName { get; set; }

        [JsonProperty("adminUsername")]
        public string AdminUsername { get; set; }

        [JsonProperty("secrets")]
        public object[] Secrets { get; set; }

        [JsonProperty("windowsConfiguration")]
        public WindowsConfiguration WindowsConfiguration { get; set; }
    }
}
