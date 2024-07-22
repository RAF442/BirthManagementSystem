using BirthManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BirthManagementSystem.Infrastructure.Config;

public class ApgarScoreConfiguration : BaseEntityConfiguration<ApgarScore>
{
    public override void Configure(EntityTypeBuilder<ApgarScore> builder)
    {
        builder.ToTable("ApgarScores");

        builder.Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Value)
            .IsRequired();

        builder.HasMany(x => x.Babies)
            .WithOne(x => x.ApgarScore)
            .HasForeignKey(x => x.ApgarScoreId);

        base.Configure(builder);
    }
}
