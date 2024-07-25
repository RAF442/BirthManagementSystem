using BirthManagementSystem.Domain.Entities;
using BirthManagementSystem.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace BirthManagementSystem.Infrastructure.Context;

/// <summary>
/// Klasa kontekstu reprezentująca połączenie z bazą danych
/// </summary>
internal class BirthManagementSystemDbContext : DbContext
{
    /// <summary>
    /// Właściwość DbSet dla encji Baby
    /// </summary>
    public DbSet<Baby> Babies { get; set; }

    /// <summary>
    /// Właściwość DbSet dla encji ApgarScore
    /// </summary>
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
