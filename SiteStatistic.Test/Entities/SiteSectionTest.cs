using System.ComponentModel.DataAnnotations;

using SiteStatistic.Core.Data.Entities;

using Xunit;

namespace SiteStatistic.Test.Entities
{
    public class SiteSectionTest
    {
        [Fact]
        public void SiteSection_ValidConstructor_ShouldWork()
        {
            // Act
            var exception = Record.Exception(() => new SiteSection("Каталог"));

            // Assert
            Assert.Null(exception);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("ЛК")]
        public void SiteSection_InvalidConstructor_ShouldFail(string name)
        {
            // Assert
            Assert.Throws<ValidationException>(() => new SiteSection(name));
        }
    }
}
