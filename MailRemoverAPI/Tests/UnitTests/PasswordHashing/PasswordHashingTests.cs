using MailRemoverAPI.Services;

namespace UnitTests.PasswordHashingTests
{
    public class PasswordHashingTests
    {
        [Theory]
        [InlineData("Labas122", "Labas122")]
        [InlineData("HHiHH124", "HHiHH124")]
        [InlineData("12!gU4", "12!gU4")]
        public void HashPassword_Works(string input, string expected)
        {
            //Arrange

            //Act
            var actual = PasswordServices.hashPassword(input);

            //Assert
            Assert.NotEqual(expected, actual);
        }
    }
}
