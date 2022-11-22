using FluentAssertions;
using MailRemoverAPI.Controllers;
using MailRemoverAPI.Entities;
using MailRemoverAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using UnitTests.Services.Fixtures;

namespace UnitTests.Services
{
    public class EmailRepositoryTests
    {
        [Fact]
        public async Task GetEmail_OnSuccess_ReturnsStatusCode200()
        {
            // Arrange
            var mockUserService = new Mock<IEmailRepository>();
            mockUserService
                .Setup(service => service.GetAllAsync())
                .ReturnsAsync(EmailFixture.GetEmailControllerTests());

            var sut = new EmailController(mockUserService.Object);

            // Act
            var result = (OkObjectResult)await sut.GetAll();

            // Assert
            result.StatusCode.Should().Be(200);
        }

        /*[Fact]
        public async Task GetEmailById_OnSuccess_returnsStatusCode200()
        {
            // Arrange
            var mockUserService = new Mock<IEmailRepository>();

            mockUserService
                .Setup(service => service.GetAllAsync())
                .ReturnsAsync(EmailFixture.GetEmailControllerTests());

            var sut = new EmailController(mockUserService.Object);

            var Id = new Guid("487d101f-ab59-42f2-839e-000b680667cb");

            // Act
            var result = (OkObjectResult)await sut.GetById(Id);

            // Assert
            result.StatusCode.Should().Be(200);
        }*/
    }
}
