using System.ComponentModel.DataAnnotations;

using SiteStatistic.Core.Data.Entities;

using Xunit;

namespace SiteStatistic.Test.Entities
{
    public class UserTest
    {
        [Fact]
        public void User_ValidConstructor_ShouldWork()
        {
            // Act
            var exception = Record.Exception(() => new User("Илья", "Баркалов", "Олегович"));
            
            // Assert
            Assert.Null(exception);
        }

        [Theory]
        [InlineData("", "Баркалов", "Олегович")]
        [InlineData("Илья", "", "Олегович")]
        [InlineData("", "", null)]
        public void User_InvalidConstructor_ShouldFail(string firstName, string lastName, string middleName)
        {
            // Assert
            Assert.Throws<ValidationException>(() => new User(firstName, lastName, middleName));
        }

        [Fact]
        public void User_FullName_ShouldBeEqual()
        {
            // Arrange
            string expected = "Баркалов Илья";

            // Act
            var user = new User("Илья", "Баркалов", null);

            // Assert
            Assert.Equal(expected, user.FullName);
        }

        [Theory]
        [InlineData("Илья", "Баркалов", "")]
        [InlineData("Илья", "Баркалов", null)]
        public void User_MiddleName_ShouldBeNull(string firstName, string lastName, string middleName)
        {
            // Act
            var user = new User(firstName, lastName, middleName);

            // Assert
            Assert.Null(user.MiddleName);
        }
    }
}
