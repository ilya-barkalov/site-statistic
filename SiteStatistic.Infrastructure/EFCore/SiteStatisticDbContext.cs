using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SiteStatistic.Core.Data.Entities;

namespace SiteStatistic.Infrastructure.EFCore
{
    public class SiteStatisticDbContext : DbContext
    {
        public SiteStatisticDbContext(DbContextOptions options) 
            : base(options) { }

        #region DbSet
        /// <summary>
        /// [dbo].[User]
        /// </summary>
        public DbSet<User> User { get; set; }
        /// <summary>
        /// [dbo].[SiteSections]
        /// </summary>
        public DbSet<SiteSection> SiteSections { get; set; }
        /// <summary>
        /// [dbo].[VisitedSiteSections]
        /// </summary>
        public DbSet<VisitedSiteSection> VisitedSiteSections { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
