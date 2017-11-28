using AzureRestAPI.ManagementAPI.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;

namespace AzureRestAPI
{
    public class RESTManager
    {

        AzureAuthenticationManager _AzureAuthenticationManager;
        private RestClient _client;
        private RestRequest _request;

        private string _azureBaseUrl = string.Empty;
        public RESTManager(AzureAPIs api)
        {
            string[] resourceInfo = new AzureREST_API_URLs().GetAPIUrl(api);

            _azureBaseUrl = resourceInfo[0];

            _AzureAuthenticationManager = new AzureAuthenticationManager(resourceInfo[1]);
            _client = new RestClient();


        }
        private string CreateUrl(string resource, string api, bool addApiVersion = true)
        {
            return _azureBaseUrl + resource + (addApiVersion ? ("?api-version=" + api) : "");
        }

        public IRestResponse AzureRESTRequest(string resource, Method method, string api = "2017-08-01", bool addApiVersion = true)
        {
            _client.BaseUrl = new Uri(CreateUrl(resource, api, addApiVersion));
            _request = new RestRequest(method);
            _AzureAuthenticationManager.SetAuthorizationHeader(_request);
            _request.AddHeader("Content-Type", "application/json");
            _request.AddHeader("Accept", "application/json");
            IRestResponse response = _client.Execute(_request);
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                Error error = Error.FromJson(response.Content);
                if (error.Code == null)
                {
                    error = Error.FromJson(JObject.Parse(response.Content).First.First.ToString());
                }
                if (error.Code == "InvalidApiVersionParameter" || error.Code == "NoRegisteredProviderFound")
                {
                    string[] par = new string[1] { "The supported api-versions are" };
                    var correctedApi = error.Message.Split(par, StringSplitOptions.None)[1].Split(',')[0].Substring(2);
                    return AzureRESTRequest(resource, method, correctedApi);
                }
            }

            return response;
        }

        public K Parse<K>(IRestResponse response)
        {
            K data_array;

            try
            {
                JObject jobj = JObject.Parse(response.Content);
                data_array = JsonConvert.DeserializeObject<K>(jobj.First.First.ToString());


            }
            catch (Exception ex)
            {
                return default(K);
            }

            return data_array;
        }
    }


}
