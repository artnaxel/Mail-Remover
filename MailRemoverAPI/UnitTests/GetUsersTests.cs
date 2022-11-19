using MailRemoverAPI.Controllers;
using MailRemoverAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using UnitTests.Fixtures;
using FluentAssertions;
using MailRemoverAPI.Entities;

namespace UnitTests
{
    public class GetUsersTests
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

        [Fact]
        public async Task Get_OnSuccess_ReturnsListOfUsers()
        {
            // Arrange
            var mockUserService = new Mock<IUserRepository>();
            mockUserService
                .Setup(service => service.GetAllAsync())
                .ReturnsAsync(UsersFixtures.GetUserControllerTests());

            var sut = new UserController(mockUserService.Object);

            // Act
            var result = await sut.GetAll();

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<List<User>>();
        }
    }
}
