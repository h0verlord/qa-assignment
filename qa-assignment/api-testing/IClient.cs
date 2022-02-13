using RestSharp;
using RestSharp.Authenticators;

namespace ApiTesting
{
    public interface IRestfulBookerClient
    {
        Task<Booking> GetBooking(string booking);

    }

    public class RestfulBookerClient : IRestfulBookerClient, IDisposable
    {
        readonly RestClient _client;

        public RestfulBookerClient(string user, string pass)
        {
            var options = new RestClientOptions("https://restful-booker.herokuapp.com");

            _client = new RestClient(options)
            {
                Authenticator = new HttpBasicAuthenticator(
                    Environment.GetEnvironmentVariable("qaUser"),
                    Environment.GetEnvironmentVariable("qaPAss")
                )
            };
        }

        public async Task<Booking> GetBooking(string booking)
        {
            var response = await _client.GetJsonAsync<BookingSingleObject<Booking>>(
                "booking/:id",
                new { booking }
            );
            return response!.data;
        }

        record BookingSingleObject<T>(T data);

        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }
    }

    public record Booking(
            string firstname,
            string lastname,
            int totalprice,
            bool ddepositpaid,
            object bookingddates,
            string additionalneeds);

}