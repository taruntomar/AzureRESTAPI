using Newtonsoft.Json;

namespace AzureRestAPI.GraphAPI.Entities
{
    public partial class Users
    {
        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }

        [JsonProperty("value")]
        public AzureADUser[] Value { get; set; }
    }

 
}
