namespace UnitTests.UserTests
{
    public class GetUserDtoTest
    {
        [Theory]
        [InlineData("Id")]
        public void GetUserModel_HasProperty_True(string input)
        {
            //Arrange

            //Act
            var actual = typeof(GetUserDto).GetProperty(input);

            //Assert
            Assert.NotNull(actual);
        }
    }
}
