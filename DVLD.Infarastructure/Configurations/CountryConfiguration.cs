using DVLD.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DVLD.Infrastructure.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(e => e.CountryId).HasName("PK__Countrie__10D160BFDBD6933F");
            builder.Property(e => e.CountryId).HasColumnName("CountryID");
            builder.Property(e => e.CountryNameAr).HasMaxLength(50);
            builder.Property(e => e.CountryNameEn).HasMaxLength(50);
        }
    }
}
