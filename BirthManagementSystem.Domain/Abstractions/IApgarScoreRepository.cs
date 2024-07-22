using BirthManagementSystem.Domain.Entities;

namespace BirthManagementSystem.Domain.Abstractions;

public interface IApgarScoreRepository
{
    Task<ApgarScore> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task<ApgarScore> GetByIdAsyncWithBabiesAsync(int id, CancellationToken cancellationToken);

    Task<bool> IsAlreadyExistAsync(int value, CancellationToken cancellationToken);

    void Add(ApgarScore apgar_score);
}
