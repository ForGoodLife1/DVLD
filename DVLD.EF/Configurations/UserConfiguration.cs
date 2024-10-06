using DVLD.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DVLD.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.UserId).HasColumnName("UserID");
            builder.Property(e => e.Password).HasMaxLength(20);
            builder.Property(e => e.PersonId).HasColumnName("PersonID");
            builder.Property(e => e.UserNameAr).HasMaxLength(20);
            builder.Property(e => e.UserNameEn).HasMaxLength(20);

            builder.HasOne(d => d.Person).WithMany(p => p.Users)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_People");
        }
    }
}
