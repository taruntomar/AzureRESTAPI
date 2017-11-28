using System;
using System.Globalization;
using RestSharp;
using Newtonsoft.Json.Linq;
using TTOAuthManager;

namespace AzureRestAPI
{
    public class AzureAuthenticationManager
    {
        AuthConfig config;
        private RestClient _client;
        private RestRequest _request;
        private string _bearer = "";
        public AzureAuthenticationManager(string resourceName)
        {
            config = new AuthConfig();
            _client = new RestClient();
            _request = new RestRequest();
            _bearer = GetTokenByREST(resourceName);
        }
        //private string _tenant = ConfigurationManager.AppSettings["ida:Tenant"];
        //private string _aadInstance = ConfigurationManager.AppSettings["ida:AADInstance"];
        //private string _clientId = ConfigurationManager.AppSettings["ida:ClientId"];
        //private string _appKey = ConfigurationManager.AppSettings["ida:AppKey"];
        //private string _resourceId = ConfigurationManager.AppSettings["todo:AbilityMonitorResourceId"];
        

        public void SetAuthorizationHeader(RestRequest request)
        {
            request.AddHeader("authorization", "bearer " + _bearer);
        }


        public string GetTokenByREST(string resource)
        {

            var url = @"https://login.microsoftonline.com/372ee9e0-9ce0-4033-a64a-c07073a91ecd/oauth2/token";


            _client.BaseUrl = new Uri(url);
            _request.Parameters.Clear();
            _request.Method = Method.POST;
            _request.AddParameter("client_id", config.ClientId);
            _request.AddParameter("grant_type", "client_credentials");
            _request.AddParameter("resource", resource);
            _request.AddParameter("client_secret", config.ClientSecret);
            _request.AddParameter("scope", "user.read");

            var response = _client.Execute(_request);
            JObject obj = JObject.Parse(response.Content);

            string x = obj["access_token"].ToString();
            return x;



        }

        public string GetToken()
        {
            return _bearer;
        }

    }
}
