using BirthManagementSystem.Domain.Abstractions;
using BirthManagementSystem.Domain.Entities;
using BirthManagementSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BirthManagementSystem.Infrastructure;

internal class UnitOfWork : IUnitOfWork
{
    private readonly BirthManagementSystemDbContext _dbContext;

    /// <summary>
    /// Wstrzyknięcie kontekstu połączenia do bazy danych
    /// </summary>
    /// <param name="dbContext"></param>
    public UnitOfWork(BirthManagementSystemDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Implementacja metody do zapisywania zmian na bazie danych
    /// </summary>
    /// <param name="cancellationToken">Token anulowania operacji asynchronicznej</param>
    /// <returns></returns>
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateAuditableEntities();
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Metoda ustawiająca czas dodania lub modyfikacji encji
    /// </summary>
    private void UpdateAuditableEntities()
    {
        var entries = _dbContext
            .ChangeTracker
            .Entries<Entity>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = entry.Entity.UpdatedAt = DateTime.Now;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = DateTime.Now;
            }
        }
    }
}
