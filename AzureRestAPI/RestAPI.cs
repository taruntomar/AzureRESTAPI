using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTOAuthManager.Azure;
using TTOAuthManager.Azure.Entities;

namespace AzureRestAPI
{
    public class AzureRestAPI
    {
        #region private fields
        protected AzureADE2EManager _AzureADE2EManager;
        protected string baseurl=string.Empty;
        #endregion

        public AzureRestAPI(AzureADE2EManager azureADE2EManager)
        {
            _AzureADE2EManager = azureADE2EManager;
        }
        protected RestResponse<IRestResponse, OAuthErrors> RestRequest(string endpoint,string scope)
        {
            var resp = new RestResponse<IRestResponse, OAuthErrors>();
            var url = baseurl + endpoint;
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest(Method.GET);
            _AzureADE2EManager.Scope = scope;
            var access_token = _AzureADE2EManager.GetAccessToken();
            if (access_token.Error == OAuthErrors.None)
            {
                string token = access_token.Result.AccessToken;
                request.AddHeader("Authorization", "bearer " + token);
                IRestResponse response = client.Execute(request);
                resp.IsSucceeded = true;
                resp.Error = OAuthErrors.None;
                resp.Result = response;
            }
            else
            {
                resp.IsSucceeded = false;
                resp.Error = access_token.Error;
            }
            return resp;
        }
        protected RestResponse<R, E> RestRequest<R, E>(string endppint,string scope)
        {
            var resp = new RestResponse<R, E>();
            var response = RestRequest(endppint,scope);
            if (response.IsSucceeded)
            {
                resp.OAuthError = OAuthErrors.None;
                if (response.Result.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    E error = JsonConvert.DeserializeObject<E>(response.Result.Content, Converter.Settings);
                    resp.Error = error;
                    resp.IsSucceeded = false;

                }
                else
                {
                    R result = JsonConvert.DeserializeObject<R>(response.Result.Content, TTOAuthManager.Azure.Entities.Converter.Settings);
                    resp.Result = result;
                    resp.IsSucceeded = true;
                }
            }
            else
            {
                resp.OAuthError = response.OAuthError;
                resp.IsSucceeded = false;
            }

            return resp;
        }


    }
}
