namespace IntegrationTests
{
    public class DeleteRequestTests : BaseTest
    {
        public DeleteRequestTests(WebApplicationFactory<Program> factory) : base(factory) { }

        [Theory]
        [InlineData("/api/Users/f04e19bc-5405-4723-89da-3803e68ad539")]
        public async Task Users_DeleteRequest_OnSuccess_ReturnsStatusCode204(string uri)
        {
            // Arrange
            await using var application = new WebApplicationFactory<Program>();
            using var client = _factory.CreateClient();

            var response = await client.DeleteAsync(uri);

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
