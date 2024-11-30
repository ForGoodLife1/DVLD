using DVLD.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DVLD.Infrastructure.Configurations
{
    public class TestTypeConfiguration : IEntityTypeConfiguration<TestType>
    {
        public void Configure(EntityTypeBuilder<TestType> builder)
        {
            builder.Property(e => e.TestTypeId).HasColumnName("TestTypeID");
            builder.Property(e => e.TestTypeDescription).HasMaxLength(500);
            builder.Property(e => e.TestTypeFees).HasColumnType("smallmoney");
            builder.Property(e => e.TestTypeTitle).HasMaxLength(100);
        }
    }
}
