using BirthManagementSystem.Domain.Abstractions;
using BirthManagementSystem.Domain.Entities;
using BirthManagementSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BirthManagementSystem.Infrastructure.Repositoires;

/// <summary>
/// Repozytorium tylko do odczytu (brak możliwości modyfikacji danych lub ich usuwania)
/// </summary>
internal class BabyReadOnlyRepository : IBabyReadOnlyRepository
{
    private readonly BirthManagementSystemDbContext _dbContext;

    /// <summary>
    /// Wstrzyknięcie kontekstu połączenia do bazy danych
    /// </summary>
    /// <param name="dbContext"></param>
    public BabyReadOnlyRepository(BirthManagementSystemDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Implementacja metody pobierającej wszystkie dzieci
    /// </summary>
    /// <param name="cancellation">Token anulowania operacji asynchronicznej</param>
    /// <returns>Zwraca listę wszystkich dzieci</returns>
    public async Task<IEnumerable<Baby>> GetAllAsync(CancellationToken cancellation = default)
    {
        return await _dbContext.Babies.AsNoTracking().ToListAsync(cancellation);
    }

    /// <summary>
    /// Implementacja metody pobierającej wszystkie dzieci ze szczegółowymi danymi
    /// </summary>
    /// <param name="cancellation">Token anulowania operacji asynchronicznej</param>
    /// <returns></returns>
    public async Task<IEnumerable<Baby>> GetAllWithDetailsAsync(CancellationToken cancellation = default)
    {
        return await _dbContext.Babies
            .Include(x => x.PlaceOfBirth)
            .Include(x => x.ApgarScore)
            .AsNoTracking().ToListAsync(cancellation);
    }
}
