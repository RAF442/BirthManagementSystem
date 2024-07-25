using BirthManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BirthManagementSystem.Infrastructure.Config;

/// <summary>
/// Konfiguracja encji PlaceOfBirth
/// </summary>
public class PlaceOfBirthConfiguration : BaseEntityConfiguration<PlaceOfBirth>
{
    public override void Configure(EntityTypeBuilder<PlaceOfBirth> builder)
    {
        builder.ToTable("PlacesOfBirth");

        builder.Property(x => x.StreetName)
            .HasMaxLength(120)
            .IsRequired();

        builder.Property(x => x.StreetNumber)
            .HasMaxLength(16)
            .IsRequired();

        builder.Property(x => x.City)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.PostalCode)
            .HasMaxLength(16)
            .IsRequired();

        base.Configure(builder);
    }
}
