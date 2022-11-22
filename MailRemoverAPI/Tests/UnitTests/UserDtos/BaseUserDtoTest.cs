namespace UnitTests.UserTests
{
    public class BaseUserDtoTest
    {
        [Theory]
        [InlineData("FirstName")]
        [InlineData("LastName")]
        public void BaseUserModel_HasProperty_True(string input)
        {
            //Arrange

            //Act
            var actual = typeof(BaseUserDto).GetProperty(input);

            //Assert
            Assert.NotNull(actual);
        }
    }
}
