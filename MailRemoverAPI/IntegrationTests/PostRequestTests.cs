using MailRemoverAPI.Entities;
using MailRemoverAPI.Models.User;

namespace IntegrationTests
{
    public class PostRequestTests : BaseTest
    {
        public PostRequestTests(WebApplicationFactory<Program> factory) : base(factory) { }

        [Theory]
        [InlineData("/api/Users")]
        public async Task Users_PostRequest_OnSuccess_ReturnsStatusCode201(string uri)
        {
            // Arrange
            await using var application = new WebApplicationFactory<Program>();
            using var client = _factory.CreateClient();

            var user = new CreateUserDto()
            {
                FirstName = "Karolina",
                LastName = "Karoliniene",
                Password = "bc6vbahd6"
            };

            // Act
            HttpResponseMessage response = await client.PostAsJsonAsync(uri, user);

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        /*[Theory]
        [InlineData("/api/Email/Create")]
        public async Task Email_PostRequest_OnSuccess_ReturnsStatusCode201(string uri)
        {
        }*/

        [Theory]
        [InlineData("/login?id=e033fa78-a839-4276-ed91-08dacbb5abc5&Password=labukas")]
        public async Task Users_LoginRequest_OnSuccess_ReturnsStatusCode200(string uri)
        {
            // Arrange
            await using var application = new WebApplicationFactory<Program>();
            using var client = _factory.CreateClient();

            var user = new User()
            {
                Id = new Guid("e033fa78-a839-4276-ed91-08dacbb5abc5"),
                Password = "labukas"
            };

            // Act
            HttpResponseMessage response = await client.PostAsJsonAsync(uri, user);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}