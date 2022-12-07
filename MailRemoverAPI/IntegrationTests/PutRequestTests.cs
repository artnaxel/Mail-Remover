namespace IntegrationTests
{
    public class PutRequestTests : BaseTest
    {
        public PutRequestTests(WebApplicationFactory<Program> factory) : base(factory) { }

        [Theory]
        [InlineData("/api/Users/94144d9e-f505-472c-9206-0adf33f143ef")]
        public async Task Users_PutRequest_OnSuccess_ReturnsStatusCode204(string uri)
        {
            // Arrange
            await using var application = new WebApplicationFactory<Program>();
            using var client = _factory.CreateClient();

            var user = new User()
            {
                FirstName = "Deimante",
                LastName = "Jagu",
                Id = new Guid("94144d9e-f505-472c-9206-0adf33f143ef")
            };

            // Act
            HttpResponseMessage response = await client.PutAsJsonAsync(uri, user);

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Theory]
        [InlineData("/api/Gmails/RefreshAccessToken?id=fb020d52-30fb-4e43-82cf-681ff3cd5eb6")]
        public async Task Gmails_PutRequest_OnSuccess_ReturnsStatusCode204(string uri)
        {
            // Arrange
            await using var application = new WebApplicationFactory<Program>();
            client = _factory.CreateClient();

            var user = new User()
            {
                FirstName = "Deimante",
                LastName = "Jagu",
                Id = new Guid("94144d9e-f505-472c-9206-0adf33f143ef")
            };

            // Act
            HttpResponseMessage response = await client.PutAsJsonAsync(uri, user);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
