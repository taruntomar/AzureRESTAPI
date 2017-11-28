namespace AzureRestAPI
{
    public class AzureREST_API_URLs
        {
            public string[] GetAPIUrl(AzureAPIs apiname)
            {
                string[] resourceInfo = new string[2];
                if (apiname == AzureAPIs.ManagementAPI)
                {
                    resourceInfo[0] = @"https://management.azure.com/";
                    resourceInfo[1] = @"https://management.core.windows.net/";
                }
                else if (apiname == AzureAPIs.GraphAPI)
                {
                    resourceInfo[0] = @"https://graph.windows.net/";
                    resourceInfo[1] = @"https://graph.windows.net/";
                }


                return resourceInfo;

            }

        }


}
