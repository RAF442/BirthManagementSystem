using BirthManagementSystem.Domain.Abstractions;
using BirthManagementSystem.Domain.Entities;
using BirthManagementSystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BirthManagementSystem.Infrastructure.Repositoires;

internal class ApgarScoreRepository : IApgarScoreRepository
{
    private readonly BirthManagementSystemDbContext _dbContext;

    public ApgarScoreRepository(BirthManagementSystemDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Add(ApgarScore apgar_score)
        => _dbContext.ApgarScores.Add(apgar_score);

    public async Task<ApgarScore> GetByIdAsync(int id, CancellationToken cancellationToken)
        => await _dbContext.ApgarScores.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<ApgarScore> GetByIdAsyncWithBabiesAsync(int id, CancellationToken cancellationToken)
        => await _dbContext.ApgarScores.Include(x => x.Babies).SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<bool> IsAlreadyExistAsync(int value, CancellationToken cancellationToken)
        => await _dbContext.ApgarScores.SingleOrDefaultAsync(x => x.Value == value, cancellationToken) is not null;
}
