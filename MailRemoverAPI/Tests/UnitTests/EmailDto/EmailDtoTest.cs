using MailRemoverAPI.Models.Email;

namespace UnitTests.EmailTests
{
    public class EmailDtoTest
    {
        [Theory]
        [InlineData("Type")]
        [InlineData("Address")]
        public void EmailModel_HasProperty_True(string input)
        {
            //Arrange

            //Act
            var actual = typeof(EmailDto).GetProperty(input);

            //Assert
            Assert.NotNull(actual);
        }
    }
}
