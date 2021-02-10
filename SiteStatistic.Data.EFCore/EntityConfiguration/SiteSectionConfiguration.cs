using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SiteStatistic.Core.Data.Entities;

namespace SiteStatistic.Data.EFCore.EntityConfiguration
{
    internal class SiteSectionConfiguration : IEntityTypeConfiguration<SiteSection>
    {
        public void Configure(EntityTypeBuilder<SiteSection> builder)
        {
            builder.ToTable(nameof(SiteSection), "dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName(nameof(SiteSection.Id))
                .HasColumnType("int");

            builder.Property(x => x.Name)
                .HasColumnName(nameof(SiteSection.Name))
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder.HasMany(x => x.VisitedSiteSections)
                .WithOne(x => x.SiteSection)
                .HasForeignKey(x => x.SiteSectionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
