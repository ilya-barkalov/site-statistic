using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SiteStatistic.Core.Data.Entities;

namespace SiteStatistic.Data.EFCore.EntityConfiguration
{
    internal class VisitedSiteSectionConfiguration : IEntityTypeConfiguration<VisitedSiteSection>
    {
        public void Configure(EntityTypeBuilder<VisitedSiteSection> builder)
        {
            builder.ToTable(nameof(VisitedSiteSection), "dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName(nameof(VisitedSiteSection.Id))
                .HasColumnType("int");

            builder.Property(x => x.UserId)
                .HasColumnName(nameof(VisitedSiteSection.UserId))
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.SiteSectionId)
                .HasColumnName(nameof(VisitedSiteSection.SiteSectionId))
                .HasColumnType("int")
                .IsRequired();
        }
    }
}
