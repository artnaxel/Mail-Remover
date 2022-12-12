 namespace UnitTests.UserTests
{
    public class CreateUserDtoTest
    {
        [Theory]
        [InlineData("FirstName")]
        [InlineData("LastName")]
        [InlineData("Password")]
        public void CreateUserModel_HasProperty_True(string input)
        {
            //Arrange

            //Act
            var actual = typeof(CreateUserDto).GetProperty(input);

            //Assert
            Assert.NotNull(actual);
        }
    }
}
