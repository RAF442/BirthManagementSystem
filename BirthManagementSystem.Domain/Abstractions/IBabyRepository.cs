using BirthManagementSystem.Domain.Entities;

namespace BirthManagementSystem.Domain.Abstractions;

public interface IBabyRepository
{
    Task<Baby> GetByIdAsync(int id, CancellationToken cancellation = default);
    Task<Baby> GetByPersonalIdentityNumberAsync(string personal_id_number, CancellationToken cancellation = default);
    Task<bool> IsAlreadyExistAsync(string personal_id_number, CancellationToken cancellation = default);

    void Add(Baby baby);
    void Update(Baby baby);
    void Delete(Baby baby);
}
