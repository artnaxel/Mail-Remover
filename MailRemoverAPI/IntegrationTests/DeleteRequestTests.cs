using MailRemoverAPI.Entities;
using MailRemoverAPI.Models.User;

namespace IntegrationTests
{
    public class DeleteRequestTests : BaseTest
    {
        public DeleteRequestTests(WebApplicationFactory<Program> factory) : base(factory) { }

        private GetUserDto CreateUser()
        {
            var user = new GetUserDto()
            {
                Id = Guid.NewGuid()
            };

            return user;
        }

        private string GetUserId()
        {
            GetUserDto user = CreateUser();

            return user.Id.ToString();
        }

        [Theory]
        [InlineData("/api/Users/6a11637a-4b50-4013-cb57-08daca445dd2")]
        public async Task Users_DeleteRequest_OnSuccess_ReturnsStatusCode204(string uri)
        {
            // Arrange
            await using var application = new WebApplicationFactory<Program>();
            using var client = _factory.CreateClient();

            var urir = "/api/Users?firstName=Deimante";

            // Act
            var response = await client.DeleteAsync(uri);

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
