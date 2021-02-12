using System.Collections.Generic;

namespace SiteStatistic.Infrastructure.Features.GetTopUsers
{
    public class TopUsersDto
    {
        public TopUsersDto()
        {

        }

        /// <summary>
        /// Order id
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// User full name
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Most visited sections (only equals visited count)
        /// </summary>
        public IEnumerable<string> Sections { get; set; }
    }

    /// <summary>
    /// sp_GetTopUsers result
    /// </summary>
    public class TopUsersDtoRaw
    {
        /// <summary>
        /// Order id
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// User full name
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Site section name
        /// </summary>
        public string SectionName { get; set; }
    }
}
