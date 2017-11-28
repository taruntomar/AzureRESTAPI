using Newtonsoft.Json;

namespace AzureRestAPI.ManagementAPI.Entities.VirtualMachine
{
    public partial class VirtualMachine
    {
        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("properties")]
        public Properties Properties { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("resources")]
        public Resource[] Resources { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class VirtualMachine
    {
        public static VirtualMachine FromJson(string json) => JsonConvert.DeserializeObject<VirtualMachine>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this VirtualMachine self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}
