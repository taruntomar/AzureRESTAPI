using Newtonsoft.Json;

namespace AzureRestAPI.ManagementAPI.Entities.VirtualMachine
{
    public partial class Settings
    {
        [JsonProperty("stopOnMultipleConnections")]
        public bool StopOnMultipleConnections { get; set; }

        [JsonProperty("azureResourceId")]
        public string AzureResourceId { get; set; }

        [JsonProperty("workspaceId")]
        public string WorkspaceId { get; set; }
    }
}
