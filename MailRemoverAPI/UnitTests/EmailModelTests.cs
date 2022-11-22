using MailRemoverAPI.Entities;

namespace UnitTests
{
    public class EmailModelTests
    {
        [Theory]
        [InlineData("Type")]
        [InlineData("Address")]
        [InlineData("Token")]
        [InlineData("UserId")]
        [InlineData("User")]
        public void EmailModel_HasProperty_True(string input)
        {
            //Arrange

            //Act
            var actual = typeof(Email).GetProperty(input);

            //Assert
            Assert.NotNull(actual);
        }
    }
}
