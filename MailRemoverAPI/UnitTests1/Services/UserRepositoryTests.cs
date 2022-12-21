using FluentAssertions;
using MailRemoverAPI.Controllers;
using MailRemoverAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using UnitTests.Services.Fixtures;

namespace UnitTests.Services
{
    public class UserRepositoryTests
    {
        [Fact]
        public async Task GetUser_OnSuccess_ReturnsStatusCode200()
        {
            // Arrange
            var mockUserService = new Mock<IUserRepository>();
            mockUserService
                .Setup(service => service.GetAllAsync())
                .ReturnsAsync(UsersFixtures.GetUserControllerTests());

            var sut = new UserController(mockUserService.Object);

            // Act
            var result = (OkObjectResult)await sut.GetAll();

            // Assert
            result.StatusCode.Should().Be(200);
        }
    }
}
