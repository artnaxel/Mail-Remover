using MailRemoverAPI.Entities;

namespace IntegrationTests
{
    public class PutRequestTests : BaseTest
    {
        public PutRequestTests(WebApplicationFactory<Program> factory) : base(factory) { }


        [Theory]
        [InlineData("/api/Users/bf82f7c5-708f-4180-8117-f89aa672bf5a")]
        public async Task Users_PutRequest_OnSuccess_ReturnsStatusCode204(string uri)
        {
            // Arrange
            await using var application = new WebApplicationFactory<Program>();
            using var client = _factory.CreateClient();

            var user = new User()
            {
                FirstName = "Objektasss",
                LastName = "Pakeistassss",
                Id = new Guid("bf82f7c5-708f-4180-8117-f89aa672bf5a")
            };

            // Act
            HttpResponseMessage response = await client.PutAsJsonAsync(uri, user);

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
