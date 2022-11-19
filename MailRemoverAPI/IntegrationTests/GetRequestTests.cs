using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace IntegrationTests
{
    public class GetRequestTests
        : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public GetRequestTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/Email/GetAll")]
        //[InlineData("/api/Email/GetById?Id=dd1e53db-2b4d-405f-99d8-5fb22549ce92")]
        //[InlineData("/api/Email/GetEmision")]
        public async Task Email_GetRequest_OnSuccess_ReturnsStatusCode200(string uri)
        {
            // Arrange
            await using var application = new WebApplicationFactory<Program>();
            using var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(uri);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("/api/Users?firstName=Deimante")]
        //[InlineData("/api/Users/dd1e53db-2b4d-405f-99d8-5fb22549ce92")]
        public async Task Users_GetRequest_OnSuccess_ReturnsStatusCode200(string uri)
        {
            // Arrange
            await using var application = new WebApplicationFactory<Program>();
            using var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(uri);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
