using RestSharp;

namespace ApiTesting
{
    public class Client
    {
        public static RestClient ApiClient { get; set; }
        public static RestClientOptions ClientOptions { get; set; }

        public static RestRequest Request { get; set; }
        public static RestResponse Response { get; set; }

        public static void CreateClient()
        {
            var options = new RestClientOptions("")
            {
                ThrowOnAnyError = true,
                Timeout = 1000
            };

            ApiClient = new RestClient(options);
        }

        public void MakeRequest(){
            
        }
    }
}