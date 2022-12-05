using MailRemoverAPI.Entities;

namespace IntegrationTests
{
    public class PutRequestTests : BaseTest
    {
        public PutRequestTests(WebApplicationFactory<Program> factory) : base(factory) { }


        [Theory]
        [InlineData("/api/Users/1c2984ab-7129-4a89-bd59-08dac1187f4f")]
        public async Task Users_PutRequest_OnSuccess_ReturnsStatusCode204(string uri)
        {
            // Arrange
            await using var application = new WebApplicationFactory<Program>();
            using var client = _factory.CreateClient();

            var user = new User()
            {
                FirstName = "Pakeista",
                LastName = "Pakeistukas",
                Id = new Guid("1c2984ab-7129-4a89-bd59-08dac1187f4f")
            };

            // Act
            HttpResponseMessage response = await client.PutAsJsonAsync(uri, user);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
