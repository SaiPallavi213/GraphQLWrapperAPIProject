using GraphQLWrapper.API.Models;
using GraphQLWrapper.API.Services;
using MockGraphQLApiTest.Helper;
using MockGraphQLApiTest.MockData;
using Moq;
using Moq.Protected;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MockGraphQLApiTest.Services
{
    /// <summary>
    /// TestClientService Class: xUnit Test Class for mocking the Client Service for the Rest ApI
    /// </summary>
    public class TestClientService
    {
        //Public Rest Api to be accessed using GraphQL
        private string sBaseUrl = "https://dummy.restapiexample.com";

        //Employee Endpoint of the Public Rest Api containing the JSON data
        private string sEndpoint = "/api/v1/employees";

        [Fact]
        public async Task GetList()
        {
            //Arrange

            //Getting Employee Mock data
            var mockData = EmployeeMock.Get();

            //Getting HttpMessageHandler for Mocking
            var mockHandler = HttpClientHelper.GetResults(mockData);

            //Creating HttpClient from HttpMessageHandler for mocking 
            var mockHttpClient = new HttpClient(mockHandler.Object);

            mockHttpClient.BaseAddress = new Uri(sBaseUrl);

            var clientService = new ClientService(mockHttpClient);

            /// Act
            //Getting the data from Rest Api endpoint using GraphQL
            var results = await clientService.GetAllAsync();

            /// Assert
            //Checking if Result set is Null or not
            Assert.NotNull(results);

            mockHandler
            .Protected() //SendAsync method of HttpMessage handler is protected
            .Verify(
                "SendAsync",  //Method to be mocked
                Times.Exactly(1), //Number of Method Invocations
                ItExpr.Is<HttpRequestMessage>(
                    req => req.Method == HttpMethod.Get &&
                    req.RequestUri == new Uri(string.Concat(sBaseUrl, sEndpoint))),
                ItExpr.IsAny<CancellationToken>()
                );

        }
    }
}
