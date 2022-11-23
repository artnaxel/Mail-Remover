namespace IntegrationTests
{
    public class GetRequestTests : BaseTest
    {
        public GetRequestTests(WebApplicationFactory<Program> factory) : base(factory) { }

        [Theory]
        [InlineData("/api/Email/GetAll")]
        [InlineData("/api/Email/GetById?Id=fb020d52-30fb-4e43-82cf-681ff3cd5eb6")]
        //[InlineData("/api/Email/GetEmision")]
        public async Task Email_GetRequest_OnSuccess_ReturnsStatusCode200(string uri)
        {
            // Arrange
            await using var application = new WebApplicationFactory<Program>();
            using var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(uri);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("/api/Users?firstName=Deimante")]
        [InlineData("/api/Users/1e148dec-f7e1-48fb-cd5f-08dab5d87dcc")]
        public async Task Users_GetRequest_OnSuccess_ReturnsStatusCode200(string uri)
        {
            // Arrange
            await using var application = new WebApplicationFactory<Program>();
            using var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(uri);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
