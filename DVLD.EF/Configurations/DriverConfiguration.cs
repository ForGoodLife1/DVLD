using DVLD.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DVLD.Infrastructure.Configurations
{
    public class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.HasKey(e => e.DriverId).HasName("PK_Drivers_1");

            builder.Property(e => e.DriverId).HasColumnName("DriverID");
            builder.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");
            builder.Property(e => e.CreatedDate).HasColumnType("smalldatetime");
            builder.Property(e => e.PersonId).HasColumnName("PersonID");

            builder.HasOne(d => d.CreatedByUser).WithMany(p => p.Drivers)
                .HasForeignKey(d => d.CreatedByUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Drivers_Users");

            builder.HasOne(d => d.Person).WithMany(p => p.Drivers)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Drivers_People");
        }
    }
}
