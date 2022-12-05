namespace IntegrationTests
{
    public class GetRequestTests : BaseTest
    {

        //string responseBody = await response.Content.ReadAsStringAsync();
        // parse response body from json to object




        public GetRequestTests(WebApplicationFactory<Program> factory) : base(factory) { }

        // Email

        [Theory]
        [InlineData("/api/Email/GetAll")]
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

        /*[Theory]
        [InlineData("api/Email/GetById")]
        public async Task Email_GetByIdRequest_OnSuccess_ReturnsStatusCode200(string uri) { }*/

        // Emission

        /*[Theory]
        [InlineData("api/Email/GetEmision")]
        public async Task Emission_GetEmision_OnSuccess_ReturnsStatusCode200(string uri) { }*/

        // Gmails

        [Theory]
        [InlineData("api/Gmails/GetAll")]
        public async Task Gmail_GetAllGmails_OnSuccess_ReturnsStatusCode200(string uri) 
        {
            await using var application = new WebApplicationFactory<Program>();
            using var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(uri);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        /*[Theory]
        [InlineData("api/Gmails/GetById")]
        public async Task Gmail_GetByIdGmail_OnSuccess_ReturnsStatusCode200(string uri) { }*/

        [Theory]
        [InlineData("/api/Gmails/GetProfile?Id=6e546687-9db2-41b3-95fa-f8f55c16a2aa")]
        public async Task Gmail_GetProfileGmail_OnSuccess_ReturnsStatusCode200(string uri)
        {
            await using var application = new WebApplicationFactory<Program>();
            using var client = _factory.CreateClient();

            // Act

            var response = await client.GetAsync(uri);


            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        // GoogleAuth

        /*[Theory]
        [InlineData("api/GoogleAuth/Get")]
        public async Task GoogleAuth_GetGoogleAuth_OnSuccess_ReturnsStatusCode200(string uri) { }*/

        /*[Theory]
        [InlineData("api/GoogleAuth/Code")]
        public async Task GoogleAuth_GetGoogleAuthCode_OnSuccess_ReturnsStatusCode200(string uri) { }*/

        // Users

        [Theory]
        [InlineData("/api/Users?firstName=Deimante")]
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

        /*[Theory]
        [InlineData("api/Users/")]
        public async Task Users_getUserById_OnSuccess_ReturnsStatusCode200(string uri) { }*/
    }
}
