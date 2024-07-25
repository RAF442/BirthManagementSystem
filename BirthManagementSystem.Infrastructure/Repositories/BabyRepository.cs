using BirthManagementSystem.Domain.Abstractions;
using BirthManagementSystem.Domain.Entities;
using BirthManagementSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BirthManagementSystem.Infrastructure.Repositoires;

internal class BabyRepository : IBabyRepository
{
    private readonly BirthManagementSystemDbContext _dbContext;

    /// <summary>
    /// Wstrzyknięcie kontekstu połączenia do bazy danych
    /// </summary>
    public BabyRepository(BirthManagementSystemDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Implementacja metody pobierającej dziecko po identyfikatorze
    /// </summary>
    /// <param name="id">Identyfikator dziecka</param>
    /// <param name="cancellation">Token anulowania operacji asynchronicznej</param>
    /// <returns>Dziecko</returns>
    public async Task<Baby> GetByIdAsync(int id, CancellationToken cancellation = default)
    {
        return await _dbContext.Babies
            .Include(x => x.ApgarScore)
            .Include(x => x.PlaceOfBirth)
            .SingleOrDefaultAsync(x => x.Id == id, cancellation);
    }

    /// <summary>
    /// Implementacja metody pobierającej dziecko po numerze PESEL
    /// </summary>
    /// <param name="personal_id_number">Numer PESEL dziecka</param>
    /// <param name="cancellation">Token anulowania operacji asynchronicznej</param>
    /// <returns>Dziecko</returns>
    public async Task<Baby> GetByPersonalIdentityNumberAsync(string personal_id_number, CancellationToken cancellation = default)
    {
        return await _dbContext.Babies.SingleOrDefaultAsync(x => x.PersonalIdentityNumber == personal_id_number, cancellation);
    }

    /// <summary>
    /// Implementacja metody sprawdzającej czy istnieje dziecko o podanym numerze PESEL
    /// </summary>
    /// <param name="personal_id_number">Numer PESEL dziecka</param>
    /// <param name="cancellation">Token anulowania operacji asynchronicznej</param>
    /// <returns>Metoda zwraca true gdy w tabeli Babies istnieje już dziecko o podanym numerze PESEL lub false w przeciwnym przypadku.</returns>
    public async Task<bool> IsAlreadyExistAsync(string personal_id_number, CancellationToken cancellation = default)
    {
        return await _dbContext.Babies.AnyAsync(x => x.PersonalIdentityNumber == personal_id_number, cancellation);
    }

    /// <summary>
    /// Iplementacja metody dodającej nowe dziecko do bazy danych
    /// </summary>
    /// <param name="baby"></param>
    public void Add(Baby baby)
    {
        _dbContext.Babies.Add(baby);
    }

    /// <summary>
    /// Implementacja metody aktualizującej dziecko w bazie danych
    /// </summary>
    /// <param name="baby"></param>
    public void Update(Baby baby)
    {
        _dbContext.Babies.Update(baby);
    }

    /// <summary>
    /// Iplementacja metody usuwającej dziecko z bazy danych
    /// </summary>
    /// <param name="baby"></param>
    public void Delete(Baby baby)
    {
        _dbContext.Babies.Remove(baby);
    }
}
