using DVLD.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DVLD.Infrastructure.Configurations
{
    public class InternationalLicenseConfiguration : IEntityTypeConfiguration<InternationalLicense>
    {
        public void Configure(EntityTypeBuilder<InternationalLicense> builder)
        {
            builder.Property(e => e.InternationalLicenseId).HasColumnName("InternationalLicenseID");
            builder.Property(e => e.ApplicationId).HasColumnName("ApplicationID");
            builder.Property(e => e.CreatedByUserId).HasColumnName("CreatedByUserID");
            builder.Property(e => e.DriverId).HasColumnName("DriverID");
            builder.Property(e => e.ExpirationDate).HasColumnType("smalldatetime");
            builder.Property(e => e.IssueDate).HasColumnType("smalldatetime");
            builder.Property(e => e.IssuedUsingLocalLicenseId).HasColumnName("IssuedUsingLocalLicenseID");

            builder.HasOne(d => d.Application).WithMany(p => p.InternationalLicenses)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InternationalLicenses_Applications");

            builder.HasOne(d => d.CreatedByUser).WithMany(p => p.InternationalLicenses)
                .HasForeignKey(d => d.CreatedByUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InternationalLicenses_Users");

            builder.HasOne(d => d.Driver).WithMany(p => p.InternationalLicenses)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InternationalLicenses_Drivers");

            builder.HasOne(d => d.IssuedUsingLocalLicense).WithMany(p => p.InternationalLicenses)
                .HasForeignKey(d => d.IssuedUsingLocalLicenseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InternationalLicenses_Licenses");
        }
    }
}
