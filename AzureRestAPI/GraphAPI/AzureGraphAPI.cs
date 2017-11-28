using AzureRestAPI.GraphAPI.Entities;
using TTOAuthManager.Azure;

namespace AzureRestAPI.GraphAPI
{
    public class AzureGraphAPI:AzureRestAPI
    {
        #region private fields
        string baseurl = "https://graph.microsoft.com/v1.0";
        #endregion

        public AzureGraphAPI(AzureADE2EManager azureADE2EManager):base(azureADE2EManager)
        {
            
        }

     
        public RestResponse<Users, UsersError> SearchUsers(string searchstring)
        {
            var endpoint = "/users?$filter=startswith(displayName,'" + searchstring + "')";
            var response = RestRequest<Users, UsersError>(endpoint, "User.ReadBasic.All User.Read");
            return response;
        }

        public RestResponse<UserProfile, UserProfileError> GetCurrentUserProfile()
        {
            var endppint = "/me";
            var response = RestRequest<UserProfile, UserProfileError>(endppint, "User.ReadBasic.All User.Read");
            return response;
        }

        public RestResponse<AzureADUser, AzureADUserError> GetUserProfile(string userid)
        {
            var endppint = "/users/" + userid;
            var response = RestRequest<AzureADUser, AzureADUserError>(endppint, "User.ReadBasic.All User.Read");
            return response;
        }
    }

}
