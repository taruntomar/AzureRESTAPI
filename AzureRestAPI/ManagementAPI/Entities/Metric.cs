
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Open.OAuthManager.Azure.Entities;

namespace AzureRestAPI.ManagementAPI.Entities
{
    public partial class Metric
    {
        [JsonProperty("interval")]
        public string Interval { get; set; }

        [JsonProperty("cost")]
        public long Cost { get; set; }

        [JsonProperty("timespan")]
        public string Timespan { get; set; }

        [JsonProperty("value")]
        public Value[] Value { get; set; }
    }

    public partial class Value
    {


        [JsonProperty("type")]
        public string Type { get; set; }


        [JsonProperty("timeseries")]
        public Timesery[] Timeseries { get; set; }


    }



    public partial class Timesery
    {
        [JsonProperty("data")]
        public Datum[] Data { get; set; }

        [JsonProperty("metadatavalues")]
        public object[] Metadatavalues { get; set; }
    }

    public partial class Datum
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("average")]
        public double Average { get; set; }

        [JsonProperty("timeStamp")]
        public string TimeStamp { get; set; }
    }

    public partial class Metric
    {
        public static Metric FromJson(string json) => JsonConvert.DeserializeObject<Metric>(json, Converter.Settings);
    }

}