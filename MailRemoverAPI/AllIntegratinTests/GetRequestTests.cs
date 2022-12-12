using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Xunit;

namespace IntegrationTests
{
    public class GetRequestTests : BaseTest
    {
        public GetRequestTests(WebApplicationFactory<Program> factory) : base(factory) { }

        [Theory]
        // Email
        [InlineData("/api/Email/GetAll")]
        [InlineData("/api/Email/GetById?Id=e734d8e4-ac32-4d7c-b9d4-11562c487bea")]
        [InlineData("api/Email/GetEmision?mb=59458247")]
        // Gmail
        [InlineData("api/Gmails/GetAll")]
        [InlineData("api/Gmails/GetById")]
        [InlineData("/api/Gmails/GetProfile?Id=6e546687-9db2-41b3-95fa-f8f55c16a2aa")]
        // Google Auth
        [InlineData("/api/GoogleAuth/Get?user_id=fb020d52-30fb-4e43-82cf-681ff3cd5eb6")]
        //Users
        [InlineData("/api/Users?firstName=Deimante")]
        public async Task GetRequest_OnSuccess_ReturnsStatusCode200(string uri)
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
