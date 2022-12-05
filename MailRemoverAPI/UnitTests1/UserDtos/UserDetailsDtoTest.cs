namespace UnitTests.UserTests
{
    public class UserDetailsDtoTest
    {
        [Theory]
        [InlineData("FirstName")]
        [InlineData("LastName")]
        [InlineData("UserId")]
        [InlineData("Emails")]
        public void UserDetailsModel_HasProperty_True(string input)
        {
            //Arrange

            //Act
            var actual = typeof(UserDetailsDto).GetProperty(input);

            //Assert
            Assert.NotNull(actual);
        }
    }
}
