using DVLD.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DVLD.Infrastructure.Configurations
{
    public class TestAppointmentsViewConfiguration : IEntityTypeConfiguration<TestAppointmentsView>
    {
        public void Configure(EntityTypeBuilder<TestAppointmentsView> builder)
        {
            builder
                 .HasNoKey()
                 .ToView("TestAppointments_View");

            builder.Property(e => e.AppointmentDate).HasColumnType("smalldatetime");
            builder.Property(e => e.ClassNameAr).HasMaxLength(50);
            builder.Property(e => e.ClassNameEn).HasMaxLength(50);
            builder.Property(e => e.FullNameAr).HasMaxLength(83);
            builder.Property(e => e.FullNameEn).HasMaxLength(83);
            builder.Property(e => e.LocalDrivingLicenseApplicationId).HasColumnName("LocalDrivingLicenseApplicationID");
            builder.Property(e => e.PaidFees).HasColumnType("smallmoney");
            builder.Property(e => e.TestAppointmentId).HasColumnName("TestAppointmentID");
            builder.Property(e => e.TestTypeTitle).HasMaxLength(100);
        }
    }
}
