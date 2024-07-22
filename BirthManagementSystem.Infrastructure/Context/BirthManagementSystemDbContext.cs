using BirthManagementSystem.Domain.Entities;
using BirthManagementSystem.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace BirthManagementSystem.Infrastructure.Context;

internal class BirthManagementSystemDbContext : DbContext
{
    public DbSet<Baby> Babies { get; set; }
    public DbSet<ApgarScore> ApgarScores { get; set; }

    public BirthManagementSystemDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("birth_management_system");

        modelBuilder.ApplyConfiguration(new BabyConfiguration());
        modelBuilder.ApplyConfiguration(new ApgarScoreConfiguration());
        modelBuilder.ApplyConfiguration(new PlaceOfBirthConfiguration());
    }
}
