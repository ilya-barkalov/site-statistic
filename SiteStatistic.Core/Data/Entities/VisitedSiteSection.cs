using System;
using System.ComponentModel.DataAnnotations;

namespace SiteStatistic.Core.Data.Entities
{
    /// <summary>
    /// VisitedSiteSection entity
    /// </summary>
    public class VisitedSiteSection
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int Id { get; protected set; }

        /// <summary>
        /// Foreign key to table <see cref="Entities.User"/>
        /// </summary>
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue)]
        public int UserId { get; protected set; }

        /// <summary>
        /// Foreign key to table <see cref="Entities.SiteSection"/>
        /// </summary>
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue)]
        public int SiteSectionId { get; protected set; }

        /// <summary>
        /// Site section visited date
        /// </summary>
        [Required]
        public DateTime VisitedDate { get; protected set; }

        [Obsolete("Constructor using only by ef core", true)]
        protected VisitedSiteSection() { }

        public VisitedSiteSection(int userId, int siteSectionId, DateTime? visitedDate)
        {
            UserId = userId;
            SiteSectionId = siteSectionId;
            VisitedDate = visitedDate.GetValueOrDefault(DateTime.UtcNow);

            Validator.ValidateObject(this, new ValidationContext(this), true);
        }

        public User User { get; set; }

        public SiteSection SiteSection { get; set; }
    }
}
