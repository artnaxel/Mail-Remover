using MailRemoverAPI.Entities;
using System;

namespace IntegrationTests
{
    public class PutRequestTests
        : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Program> _factory;

        public PutRequestTests(
            CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Theory]
        [InlineData("/api/Gmails/RefreshAccessToken?id=2546b0ca-9d4c-4044-a1a2-5f04baae4fad")]
        public async Task Gmails_PutRequest_OnSuccess_ReturnsStatusCode200(string uri)
        {
            // Arrange
            var user = new User()
            {
                FirstName = "Deimante",
                LastName = "Jagucanskyte",
                Id = new Guid("2546b0ca-9d4c-4044-a1a2-5f04baae4fad")
            };

            // Act
            HttpResponseMessage response = await _client.PutAsJsonAsync(uri, user);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
