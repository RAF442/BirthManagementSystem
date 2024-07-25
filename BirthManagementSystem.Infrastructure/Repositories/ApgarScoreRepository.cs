using BirthManagementSystem.Domain.Abstractions;
using BirthManagementSystem.Domain.Entities;
using BirthManagementSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BirthManagementSystem.Infrastructure.Repositoires;

internal class ApgarScoreRepository : IApgarScoreRepository
{
    private readonly BirthManagementSystemDbContext _dbContext;

    /// <summary>
    /// Wstrzyknięcie kontekstu połączenia z bazą danych
    /// </summary>
    /// <param name="dbContext"></param>
    public ApgarScoreRepository(BirthManagementSystemDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Implemetacja metody dodającej nowy wynik w skali Apgar
    /// </summary>
    /// <param name="apgar_score"></param>
    public void Add(ApgarScore apgar_score)
        => _dbContext.ApgarScores.Add(apgar_score);

    /// <summary>
    /// Implementacja metody pobierającej wynik w skali Apgar po id
    /// </summary>
    /// <param name="id">id wyniku w skali Apgar</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Wynik w skali Apgar</returns>
    public async Task<ApgarScore> GetByIdAsync(int id, CancellationToken cancellationToken)
        => await _dbContext.ApgarScores.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

    /// <summary>
    /// Implementacja metody pobierającej wynik w skali Apgar po id wraz z dziećmi, które otrzymały dany wynik 
    /// </summary>
    /// <param name="id">id wyniku w skali Apgar</param>
    /// <param name="cancellationToken">Token anulowania operacji asynchronicznej</param>
    /// <returns>Wynik w skali Apgar. Dzieci, które go otzrymały.</returns>
    public async Task<ApgarScore> GetByIdAsyncWithBabiesAsync(int id, CancellationToken cancellationToken)
        => await _dbContext.ApgarScores.Include(x => x.Babies).SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

    /// <summary>
    /// Implementacja metody sprawdzającej czy czy podany wynik  skali Apgar już istnieje
    /// </summary>
    /// <param name="value">Wartość wyniku w skali Apgar</param>
    /// <param name="cancellationToken">Token anulowania operacji asynchronicznej</param>
    /// <returns>Metoda zwróci true, jeśli dany wynik w skali Apgar istniej w tabeli ApgarScores, w przeciwnym razie zwróci wartość false</returns>
    public async Task<bool> IsAlreadyExistAsync(int value, CancellationToken cancellationToken)
        => await _dbContext.ApgarScores.SingleOrDefaultAsync(x => x.Value == value, cancellationToken) is not null;
}
