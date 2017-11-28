
using AzureRestAPI.ManagementAPI.Entities.VirtualMachine;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureRestAPI.ManagementAPI.Entities
{

    public partial class Error
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public partial class Error
    {
        public static Error FromJson(string json) => JsonConvert.DeserializeObject<Error>(json, Converter.Settings);
    }

}