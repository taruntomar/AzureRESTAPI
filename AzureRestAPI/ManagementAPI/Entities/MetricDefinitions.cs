
using System;
using System.Net;
using System.Collections.Generic;

using Newtonsoft.Json;
using AzureRestAPI.ManagementAPI.Entities.VirtualMachine;

namespace AzureRestAPI.ManagementAPI.Entities
{


    public partial class MetricDefinitions
    {
        [JsonProperty("value")]
        public Value[] Value { get; set; }
    }

    public partial class Value
    {
        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("isDimensionRequired")]
        public bool IsDimensionRequired { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("metricAvailabilities")]
        public MetricAvailability[] MetricAvailabilities { get; set; }

        [JsonProperty("resourceId")]
        public string ResourceId { get; set; }

        [JsonProperty("primaryAggregationType")]
        public string PrimaryAggregationType { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }
    }

    public partial class Name
    {
        [JsonProperty("localizedValue")]
        public string LocalizedValue { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public partial class MetricAvailability
    {
        [JsonProperty("retention")]
        public string Retention { get; set; }

        [JsonProperty("timeGrain")]
        public string TimeGrain { get; set; }
    }

    public partial class MetricDefinitions
    {
        public static MetricDefinitions FromJson(string json) => JsonConvert.DeserializeObject<MetricDefinitions>(json, Converter.Settings);
    }

}