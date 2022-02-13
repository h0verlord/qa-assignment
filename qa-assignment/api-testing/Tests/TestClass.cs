using System;
using NUnit.Framework;
using ApiTesting;
using RestSharp;
using ResponseBody;
using Newtonsoft.Json;

public class Test
{
    [OneTimeSetUp]
    public void Setup()
    {
        RestfulClient.CreateClient();
    }

    [Test]
    public async Task HealthCheckTest()
    {
        var healthCheckRequest = new RestRequest("ping");
        var healthCheckResponse = await RestfulClient.Client.ExecuteGetAsync(healthCheckRequest);
        Assert.IsTrue(String.Equals("Created", healthCheckResponse.Content));
    }
    /// <summary>
    /// Call GetBookingIds,
    /// Call GetBooking,
    /// Call UpdateBooking,
    /// Call GetBooking Again and Verify.
    /// </summary>
    /// <returns></returns>
    [Test]
    public async Task GetBookingIdsTest()
    {
        var getBookingIdsRequest = new RestRequest("booking");
        var response = await RestfulClient.Client.ExecuteGetAsync(getBookingIdsRequest);
        var responseObject = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(response.Content);
        System.Console.WriteLine(response);
    }

    [Test]
    public async Task GetBookingTest()
    {
        var getBookingIdsRequest = new RestRequest("booking/{id}")
            .AddUrlSegment("id", 1);
        var response = await RestfulClient.Client.ExecuteGetAsync(getBookingIdsRequest);
        System.Console.WriteLine(response);
    }

    [Test]
    public async Task CreateBookingTest()
    {
        var createBookingBody = new CreateBooking();
        // var response = await RestfulClient.Client.PostJsonAsync<CreateBooking, CreateBookingResponse>("booking", createBookingBody);
        // System.Console.WriteLine(response);
    }



    [OneTimeTearDown]
    public void TearDown()
    {

    }
}