using BirthManagementSystem.Domain.Entities;
using BirthManagementSystem.Infrastructure.Config.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BirthManagementSystem.Infrastructure.Config;

public class BabyConfiguration : BaseEntityConfiguration<Baby>
{
    public override void Configure(EntityTypeBuilder<Baby> builder)
    {
        builder.ToTable("Babies");

        builder.Property(s => s.FirstName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(s => s.SecondName)
            .HasMaxLength(50);

        builder.Property(s => s.LastName)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(x => x.PersonalIdentityNumber)
            .IsUnique();
        builder.Property(x => x.PersonalIdentityNumber)
            .HasMaxLength (11)
            .IsRequired();

        builder.Property(s => s.DateOfBirth)
            .HasConversion<DateOnlyConverter>()
            .HasColumnType("date")
            .IsRequired();

        builder.HasOne(x => x.ApgarScore)
            .WithMany(x => x.Babies)
            .HasForeignKey(x => x.ApgarScoreId);

        builder.HasOne(x => x.PlaceOfBirth)
            .WithOne(x => x.Baby)
            .HasForeignKey<PlaceOfBirth>(x => x.BabyId);

        base.Configure(builder);
    }
}
