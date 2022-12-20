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
        [InlineData("/api/Users/e033fa78-a839-4276-ed91-08dacbb5abc7", "/api/Users")]
        public async Task Users_PutRequest_OnSuccess_ReturnsStatusCode204(string uri, string uri1)
        {
            // Arrange
            var user1 = new User()
            {
                Id = new Guid("e033fa78-a839-4276-ed91-08dacbb5abc7"),
                FirstName = "Saule",
                LastName = "Saulute",
                UserEmail = "saulute@gmail.com",
                Password = "haha"
            };

            var user = new User()
            {
                Id = new Guid("e033fa78-a839-4276-ed91-08dacbb5abc7"),
                FirstName = "Saule",
                LastName = "Saulutyte",
                UserEmail = "saulute.saulute@gmail.com",
                Password = "haha"
            };

            // Act
            HttpResponseMessage response1 = await _client.PostAsJsonAsync(uri1, user1);
            HttpResponseMessage response = await _client.PutAsJsonAsync(uri, user);

            // Assert
            Assert.Equal(HttpStatusCode.Created, response1.StatusCode);
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
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
