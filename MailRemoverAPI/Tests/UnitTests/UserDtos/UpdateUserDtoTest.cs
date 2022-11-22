namespace UnitTests.UserTests
{
    public class UpdateUserDtoTest
    {
        [Theory]
        [InlineData("Id")]
        public void UpdateUserModel_HasProperty_True(string input)
        {
            //Arrange

            //Act
            var actual = typeof(UpdateUserDto).GetProperty(input);

            //Assert
            Assert.NotNull(actual);
        }
    }
}
