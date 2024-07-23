using BirthManagementSystem.Domain.Entities;

namespace BirthManagementSystem.Domain.Abstractions;

/// <summary>
/// Abstrakcja dostępu do danych (warstwa Domenowa), implementacja dostępu w warstwie Inrastruktury
/// </summary>
public interface IBabyRepository
{
    /// <summary>
    /// Pobranie dziecka po identyfikatorze
    /// </summary>
    /// <param name="id">Identyfikator dziecka</param>
    /// <param name="cancellation">Anulowanie zadania w trakcie jego wykonania (długotrwałe operacje)</param>
    /// <returns>Dziecko</returns>
    Task<Baby> GetByIdAsync(int id, CancellationToken cancellation = default);

    /// <summary>
    /// Pobranie dziecka po numerze PESEL
    /// </summary>
    /// <param name="personal_id_number">Numer PESEL dziecka</param>
    /// <param name="cancellation">Anulowanie zadania w trakcie jego wykonania (długotrwałe operacje)</param>
    /// <returns>Dziecko</returns>
    Task<Baby> GetByPersonalIdentityNumberAsync(string personal_id_number, CancellationToken cancellation = default);

    /// <summary>
    /// Sprawdzenie czy dziecko o podanym numerze PESEL już istnieje
    /// </summary>
    /// <param name="personal_id_number">Numer PESEL dziecka</param>
    /// <param name="cancellation">Anulowanie zadania w trakcie jego wykonania (długotrwałe operacje)</param>
    /// <returns></returns>
    Task<bool> IsAlreadyExistAsync(string personal_id_number, CancellationToken cancellation = default);

    /// <summary>
    /// Dodanie nowego dziecka
    /// </summary>
    /// <param name="baby">Dziecko</param>
    void Add(Baby baby);

    /// <summary>
    /// Aktualizacja dziecka
    /// </summary>
    /// <param name="baby">Dziecko</param>
    void Update(Baby baby);

    /// <summary>
    /// Usunięcie dziecka
    /// </summary>
    /// <param name="baby">Dziecko</param>
    void Delete(Baby baby);
}
