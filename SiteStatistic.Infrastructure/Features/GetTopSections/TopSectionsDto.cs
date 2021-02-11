namespace SiteStatistic.Infrastructure.Features.GetTopSections
{
    /// <summary>
    /// sp_GetTopSections result
    /// </summary>
    public class TopSectionsDto
    {
        /// <summary>
        /// Section name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Number of visits
        /// </summary>
        public string NumberOfVisits { get; set; }
    }
}
