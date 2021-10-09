using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LateralApp.Entities.Location.Mappings
{
    public class CountryMap : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries");

            // Primary Key
            builder.HasKey(t => t.Id);

            // Properties

            builder.Property(t => t.CountryAbbr)
                .IsRequired()
                .HasMaxLength(3)
                .IsFixedLength();

            builder.Property(t => t.CountryNo)
               .IsRequired()
               .HasMaxLength(50);

            builder.Property(t => t.CountryName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(t => t.Remark)
                .HasMaxLength(500);

            builder.Property(t => t.RowVersion)
                .IsRowVersion();

        }
    }
}
