using DVLD.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DVLD.Infrastructure.Configurations
{
    public class LocalDrivingLicenseApplicationsViewConfiguration : IEntityTypeConfiguration<LocalDrivingLicenseApplicationsView>
    {
        public void Configure(EntityTypeBuilder<LocalDrivingLicenseApplicationsView> builder)
        {
            builder
               .HasNoKey()
               .ToView("LocalDrivingLicenseApplications_View");

            builder.Property(e => e.ApplicationDate).HasColumnType("datetime");
            builder.Property(e => e.ClassNameAr).HasMaxLength(50);
            builder.Property(e => e.ClassNameEn).HasMaxLength(50);
            builder.Property(e => e.FullNameAr).HasMaxLength(83);
            builder.Property(e => e.FullNameEn).HasMaxLength(83);
            builder.Property(e => e.LocalDrivingLicenseApplicationId).HasColumnName("LocalDrivingLicenseApplicationID");
            builder.Property(e => e.NationalNo).HasMaxLength(20);
            builder.Property(e => e.Status)
                .HasMaxLength(9)
                .IsUnicode(false);
        }
    }
}
