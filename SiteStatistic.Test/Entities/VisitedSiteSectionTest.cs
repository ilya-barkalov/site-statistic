using System.ComponentModel.DataAnnotations;

using SiteStatistic.Core.Data.Entities;

using Xunit;

namespace SiteStatistic.Test.Entities
{
    public class VisitedSiteSectionTest
    {
        [Fact]
        public void VisitedSiteSection_ValidConstructor_ShouldWork()
        {
            // Act
            var exception = Record.Exception(() => new VisitedSiteSection(1, 1, null));

            // Assert
            Assert.Null(exception);
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(0, 1)]
        [InlineData(0, 0)]
        public void VisitedSiteSection_InvalidConstructor_ShouldFail(int userId, int siteSectionId)
        {
            // Assert
            Assert.Throws<ValidationException>(() => new VisitedSiteSection(userId, siteSectionId, null));
        }
    }
}
