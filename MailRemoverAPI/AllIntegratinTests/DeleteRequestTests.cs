using System;

namespace IntegrationTests
{
    public class DeleteRequestTests
        : IClassFixture<CustomWebApplicationFactory<Program>>
    {

        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Program> _factory;

        public DeleteRequestTests(
            CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Theory]
        [InlineData("/api/Users/e033fa78-a839-4276-ed91-08dacbb5abc5", "/api/Users")]
        public async Task Users_DeleteRequest_OnSuccess_ReturnsStatusCode204(string uri, string uri1)
        {
            // Arrange
            var user = new User()
            {
                Id = new Guid("e033fa78-a839-4276-ed91-08dacbb5abc5"),
                FirstName = "Karolina",
                LastName = "Karolinute",
                UserEmail = "Karolina@gmail.com",
                Password = "laaabas"
            };

            // Act
            await _client.PostAsJsonAsync(uri1, user);
            var response = await _client.DeleteAsync(uri);

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
