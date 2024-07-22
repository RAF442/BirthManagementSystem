using BirthManagementSystem.Domain.Abstractions;
using BirthManagementSystem.Domain.Entities;
using BirthManagementSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BirthManagementSystem.Infrastructure.Repositoires;

internal class BabyRepository : IBabyRepository
{
    private readonly BirthManagementSystemDbContext _dbContext;

    public BabyRepository(BirthManagementSystemDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Baby> GetByIdAsync(int id, CancellationToken cancellation = default)
    {
        return await _dbContext.Babies
            .Include(x => x.ApgarScore)
            .Include(x => x.PlaceOfBirth)
            .SingleOrDefaultAsync(x => x.Id == id, cancellation);
    }

    public async Task<Baby> GetByPersonalIdentityNumberAsync(string personal_id_number, CancellationToken cancellation = default)
    {
        return await _dbContext.Babies.SingleOrDefaultAsync(x => x.PersonalIdentityNumber == personal_id_number, cancellation);
    }

    public async Task<bool> IsAlreadyExistAsync(string personal_id_number, CancellationToken cancellation = default)
    {
        return await _dbContext.Babies.AnyAsync(x => x.PersonalIdentityNumber == personal_id_number, cancellation);
    }

    public void Add(Baby baby)
    {
        _dbContext.Babies.Add(baby);
    }

    public void Update(Baby baby)
    {
        _dbContext.Babies.Update(baby);
    }

    public void Delete(Baby baby)
    {
        _dbContext.Babies.Remove(baby);
    }
}
