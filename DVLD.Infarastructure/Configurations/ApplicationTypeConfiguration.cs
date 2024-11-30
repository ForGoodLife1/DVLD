using DVLD.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DVLD.Infrastructure.Configurations
{
    public class ApplicationTypeConfiguration : IEntityTypeConfiguration<ApplicationType>
    {
        public void Configure(EntityTypeBuilder<ApplicationType> builder)
        {
            builder.Property(e => e.ApplicationTypeId).HasColumnName("ApplicationTypeID");
            builder.Property(e => e.ApplicationFees).HasColumnType("smallmoney");
            builder.Property(e => e.ApplicationTypeTitle).HasMaxLength(150);
        }
    }
}
