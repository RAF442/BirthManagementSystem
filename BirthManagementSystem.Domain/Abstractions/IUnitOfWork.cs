namespace BirthManagementSystem.Domain.Abstractions;

/// <summary>
/// Abstrakcja wzorca UnitOfWork
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Metoda do zapisywania zmian na bazie danych, 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
