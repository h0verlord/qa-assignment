using System;
using NUnit.Framework;
using ApiTesting;
using RestSharp;

public class Test
{
    [OneTimeSetUp]
    public void Setup()
    {
        RestfulClient.CreateClient();

    }

    [Test]
    public async Task FirstApiTest()
    {
        // make a request
        var healthCheckRequest = new RestRequest("/ping", Method.Get);
        // get response
        var healthCheckResponse = await RestfulClient.Client.GetAsync(healthCheckRequest);
        Assert.IsTrue(String.Equals("Created", healthCheckResponse.Content));

    }

    [OneTimeTearDown]
    public void TearDown()
    {

    }
}