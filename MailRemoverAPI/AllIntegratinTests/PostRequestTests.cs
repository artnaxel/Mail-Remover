using Azure.Core;
using MailRemoverAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationTests
{
    public class PostRequestTests
        : IClassFixture<CustomWebApplicationFactory<Program>>
    {

        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Program> _factory;

        public PostRequestTests(
            CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Theory]
        [InlineData("/api/Users")]
        public async Task Users_PostRequest_OnSuccess_ReturnsStatusCode201(string uri)
        {
            // Arrange
            var user = new User()
            {
                Id = new Guid("e033fa78-a839-4276-ed91-08dacbb5abc5"),
                FirstName = "Rimas",
                LastName = "Rimukas",
                UserEmail = "rimukas@gmail.com",
                Password = "baba123"
            };

            // Act
            HttpResponseMessage response = await _client.PostAsJsonAsync(uri, user);

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Theory]
        [InlineData("/login", "/api/Users")]
        public async Task Users_LoginRequest_OnSuccess_ReturnsStatusCode200(string uri, string uri1)
        {
            // Arrange
            var user = new User()
            {
                Id = new Guid("e033fa78-a839-4276-ed91-08dacbb5abc6"),
                FirstName = "Lina",
                LastName = "Linute",
                UserEmail = "linute@gmail.com",
                Password = "labas"
            };

            // Act
            await _client.PostAsJsonAsync(uri1, user);
            HttpResponseMessage response = await _client.PostAsJsonAsync(uri, user);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}