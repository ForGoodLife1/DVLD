using DVLD.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DVLD.Infrastructure.Configurations
{
    public class DriversViewConfiguration : IEntityTypeConfiguration<DriversView>
    {
        public void Configure(EntityTypeBuilder<DriversView> builder)
        {
            builder
              .HasNoKey()
              .ToView("Drivers_View");

            builder.Property(e => e.CreatedDate).HasColumnType("smalldatetime");
            builder.Property(e => e.DriverId).HasColumnName("DriverID");
            builder.Property(e => e.FullNameAr).HasMaxLength(83);
            builder.Property(e => e.FullNameEn).HasMaxLength(83);
            builder.Property(e => e.NationalNo).HasMaxLength(20);
            builder.Property(e => e.PersonId).HasColumnName("PersonID");
        }
    }
}
