using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SiteStatistic.Core.Data.Entities;

namespace SiteStatistic.Data.EFCore.EntityConfiguration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User), "dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName(nameof(User.Id))
                .HasColumnType("int");

            builder.Property(x => x.FirstName)
                .HasColumnName(nameof(User.FirstName))
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasColumnName(nameof(User.LastName))
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            builder.Property(x => x.MiddleName)
                .HasColumnName(nameof(User.MiddleName))
                .HasColumnType("nvarchar(50)");
        }
    }
}
