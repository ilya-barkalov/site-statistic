using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SiteStatistic.Core.Data.Entities
{
    /// <summary>
    /// SiteSection entity
    /// </summary>
    public class SiteSection
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int Id { get; protected set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 3)]
        public string Name { get; protected set; }

        [Obsolete("Constructor using only by ef core", true)]
        protected SiteSection() { }

        public SiteSection(string name)
        {
            Name = name;

            Validator.ValidateObject(this, new ValidationContext(this), true);
        }

        public ICollection<VisitedSiteSection> VisitedSiteSections { get; protected set; }
    }
}
