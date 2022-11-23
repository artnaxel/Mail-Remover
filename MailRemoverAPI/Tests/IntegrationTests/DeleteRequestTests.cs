using MailRemoverAPI.Models.User;

namespace IntegrationTests
{
    public class DeleteRequestTests : BaseTest
    {
        public DeleteRequestTests(WebApplicationFactory<Program> factory) : base(factory) { }

        [Theory]
        [InlineData("/api/Users/14bcd064-3df4-4f80-e8a1-08daca423ee9")]
        public async Task Users_DeleteRequest_OnSuccess_ReturnsStatusCode204(string uri)
        {
            // Arrange
            await using var application = new WebApplicationFactory<Program>();
            using var client = _factory.CreateClient();

            // Act
            var response = await client.DeleteAsync(uri);

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
