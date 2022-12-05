using FluentAssertions;
using MailRemoverAPI.Controllers;
using MailRemoverAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using UnitTests.Fixtures;

/*namespace UnitTests.Services
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

        [Fact]
        public async Task GetUserById_OnSuccess_returnsStatusCode200()
        {
            // Arrange
            var mockUserService = new Mock<IUserRepository>();

            mockUserService
                .Setup(service => service.GetAllAsync())
                .ReturnsAsync(UsersFixtures.GetUserControllerTests());

            var sut = new UserController(mockUserService.Object);

            var Id = new Guid("c8d69fc2-45d6-4112-b853-6f6c5cd7c498");

            // Act
            var result = (OkObjectResult)await sut.GetById(Id);

            // Assert
            result.StatusCode.Should().Be(200);
        }
    }
}*/
