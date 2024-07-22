using BirthManagementSystem.Domain.Entities;

namespace BirthManagementSystem.Domain.Abstractions;

public interface IBabyReadOnlyRepository
{
    Task<IEnumerable<Baby>> GetAllAsync(CancellationToken cancellation = default);

    Task<IEnumerable<Baby>> GetAllWithDetailsAsync(CancellationToken cancellation = default);
}
