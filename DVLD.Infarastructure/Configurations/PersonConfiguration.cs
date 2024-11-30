using DVLD.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DVLD.Infrastructure.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(e => e.PersonId).HasColumnName("PersonID");
            builder.Property(e => e.Address).HasMaxLength(500);
            builder.Property(e => e.DateOfBirth).HasColumnType("datetime");
            builder.Property(e => e.Email).HasMaxLength(50);
            builder.Property(e => e.FirstNameAr).HasMaxLength(20);
            builder.Property(e => e.FirstNameEn).HasMaxLength(20);
            builder.Property(e => e.Gendor).HasComment("0 Male , 1 Femail");
            builder.Property(e => e.ImagePath).HasMaxLength(250);
            builder.Property(e => e.LastNameAr).HasMaxLength(20);
            builder.Property(e => e.LastNameEn).HasMaxLength(20);
            builder.Property(e => e.NationalNo).HasMaxLength(20);
            builder.Property(e => e.NationalityCountryId).HasColumnName("NationalityCountryID");
            builder.Property(e => e.Phone).HasMaxLength(20);
            builder.Property(e => e.SecondNameAr).HasMaxLength(20);
            builder.Property(e => e.SecondNameEn).HasMaxLength(20);
            builder.Property(e => e.ThirdNameAr).HasMaxLength(20);
            builder.Property(e => e.ThirdNameEn).HasMaxLength(20);

            builder.HasOne(d => d.NationalityCountry).WithMany(p => p.People)
                .HasForeignKey(d => d.NationalityCountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_People_Countries1");
        }
    }
}
