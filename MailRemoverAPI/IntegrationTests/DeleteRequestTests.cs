using System;
using System.Collections.Generic;
using System.Linq;
namespace IntegrationTests
{
    public class DeleteRequestTests
        : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public DeleteRequestTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        /*[Theory]
        [InlineData("/api/Users/id")]
        public async Task Users_DeleteRequest_OnSuccess_ReturnsStatusCode204(string uri)
        {
            // Arrange
            await using var application = new WebApplicationFactory<Program>();
            using var client = _factory.CreateClient();

            // Act
            var response = await client.DeleteAsync(uri);

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }*/
    }
}
