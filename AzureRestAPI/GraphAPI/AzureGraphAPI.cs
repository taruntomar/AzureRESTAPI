using AzureRestAPI.GraphAPI.Entities;

namespace AzureRestAPI.GraphAPI
{
    public class AzureGraphAPI:AzureRestAPI
    {
        public AzureGraphAPI():base()
        {
            BaseURL = "https://graph.microsoft.com/v1.0";
            Authenticator.Config.Resource = @"https://graph.windows.net/";
            Authenticator.Config.Authority = @"https://graph.windows.net/";
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
