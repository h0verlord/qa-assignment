using RestSharp;
using RestSharp.Authenticators;

namespace ApiTesting
{
    class RestfulClient
    {
        public static RestClient Client { get; set; }


        public static void CreateClient()
        {
            var options = new RestClientOptions("https://restful-booker.herokuapp.com")
            {
                ThrowOnAnyError = true,
                Timeout = 5000
            };
            Client = new RestClient(options)
            {
                Authenticator = new HttpBasicAuthenticator(
                    Environment.GetEnvironmentVariable("qaUser"),
                    Environment.GetEnvironmentVariable("qaPass")
                )
            };
        }
    }
}