using MailRemoverAPI.Entities;

namespace IntegrationTests
{
    public class PutRequestTests
        : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public PutRequestTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/Users")]
        //[InlineData("/api/Users/dd1e53db-2b4d-405f-99d8-5fb22549ce92")]
        public async Task Users_PostRequest_OnSuccess_ReturnsStatusCode201(string uri)
        {
            // Arrange
            await using var application = new WebApplicationFactory<Program>();
            using var client = _factory.CreateClient();

            var user = new User()
            {
                FirstName = "Karolina",
                LastName = "Karoliniene",
                Password = "bc6vbahd6"
            };

            // Act
            HttpResponseMessage response = await client.PutAsJsonAsync(uri, user);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
