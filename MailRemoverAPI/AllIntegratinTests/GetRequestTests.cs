using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using System.Net;
using Xunit;

namespace IntegrationTests
{
    public class GetRequestTests
        : IClassFixture<CustomWebApplicationFactory<Program>>
    {

        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Program> _factory;

        public GetRequestTests(
            CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Theory]
        // Email
        [InlineData("/api/Email/GetAll")]
        [InlineData("/api/Email/GetById?Id=e734d8e4-ac32-4d7c-b9d4-11562c487bea")]
        [InlineData("api/Email/GetEmision?mb=59458247")]
        // Gmail
        [InlineData("api/Gmails/GetAll")]
        // Google Auth
        [InlineData("/api/GoogleAuth/Get?user_id=fb020d52-30fb-4e43-82cf-681ff3cd5eb6")]
        //Users
        [InlineData("/api/Users?userEmail=greta.virpsaite%40gmail.com")]
        public async Task GetRequest_OnSuccess_ReturnsStatusCode200(string uri)
        {
            // Act
            var response = await _client.GetAsync(uri);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
