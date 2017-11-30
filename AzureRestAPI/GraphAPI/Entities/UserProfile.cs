using Newtonsoft.Json;
using Open.OAuthManager.Azure.Entities;

namespace AzureRestAPI.GraphAPI.Entities
{
    public partial class UserProfile
    {
        [JsonProperty("givenName")]
        public string GivenName { get; set; }

        [JsonProperty("mobilePhone")]
        public string MobilePhone { get; set; }

        [JsonProperty("businessPhones")]
        public object[] BusinessPhones { get; set; }

        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("jobTitle")]
        public object JobTitle { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("mail")]
        public string Mail { get; set; }

        [JsonProperty("preferredLanguage")]
        public object PreferredLanguage { get; set; }

        [JsonProperty("officeLocation")]
        public string OfficeLocation { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("userPrincipalName")]
        public string UserPrincipalName { get; set; }
    }
    public partial class UserProfile
    {
        public static UserProfile FromJson(string json) => JsonConvert.DeserializeObject<UserProfile>(json, Converter.Settings);
    }
}
