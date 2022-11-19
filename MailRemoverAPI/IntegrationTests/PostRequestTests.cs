using MailRemoverAPI.Entities;
using MailRemoverAPI.Models.User;
using Moq;
using System.Net.Http.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace IntegrationTests
{
    public class PostRequestTests
        : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public PostRequestTests(WebApplicationFactory<Program> factory)
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
        //[InlineData("/api/Users/dd1e53db-2b4d-405f-99d8-5fb22549ce92")]
        public async Task Email_PostRequest_OnSuccess_ReturnsStatusCode201(string uri)
        {
            // Arrange
            await using var application = new WebApplicationFactory<Program>();
            using var client = _factory.CreateClient();

            var email = new CreateUserDto()
            {
                FirstName = "Karolina",
                LastName = "Karoliniene",
                Password = "bc6vbahd6"
            };

            // Act
            HttpResponseMessage response = await client.PostAsJsonAsync(uri, email);

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);*/
        }

        /*[Theory]
        [InlineData("/api/login")]
        //[InlineData("/api/Users/dd1e53db-2b4d-405f-99d8-5fb22549ce92")]
        public async Task Users_LoginRequest_OnSuccess_ReturnsStatusCode200(string uri)
        {
            // Arrange
            await using var application = new WebApplicationFactory<Program>();
            using var client = _factory.CreateClient();

            //"id": "ad2c0be5-810d-4d8f-9127-08daca3ed5cb"

            var user = new User()
            {
                FirstName = "Rimante",
                LastName = "Rimantyte",
                Password = "hihihaha",
                Id = new Guid("{ad2c0be5-810d-4d8f-9127-08daca3ed5cb}")
            };

            // Act
            HttpResponseMessage response = await client.PostAsJsonAsync(uri, user);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }*/
    }
}
