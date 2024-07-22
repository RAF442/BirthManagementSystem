using BirthManagementSystem.Domain.Abstractions;
using BirthManagementSystem.Domain.Entities;
using BirthManagementSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BirthManagementSystem.Infrastructure.Repositoires;

internal class BabyReadOnlyRepository : IBabyReadOnlyRepository
{
    private readonly BirthManagementSystemDbContext _dbContext;

    public BabyReadOnlyRepository(BirthManagementSystemDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<Baby>> GetAllAsync(CancellationToken cancellation = default)
    {
        return await _dbContext.Babies.AsNoTracking().ToListAsync(cancellation);
    }

    public async Task<IEnumerable<Baby>> GetAllWithDetailsAsync(CancellationToken cancellation = default)
    {
        return await _dbContext.Babies
            .Include(x => x.PlaceOfBirth)
            .Include(x => x.ApgarScore)
            .AsNoTracking().ToListAsync(cancellation);
    }
}
