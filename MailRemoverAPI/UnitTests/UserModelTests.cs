using MailRemoverAPI.Models.User;

namespace UnitTests
{
    public class UserModelTest
    {
        [Theory]
        [InlineData("FirstName")]
        [InlineData("LastName")]
        [InlineData("Password")]
        public void UserModel_HasProperty_True(string input)
        {
            //Arrange

            //Act
            var actual = typeof(CreateUserDto).GetProperty(input);

            //Assert
            Assert.NotNull(actual);
        }
    }
}
