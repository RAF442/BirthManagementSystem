using BirthManagementSystem.Application.Configuration.Commands;
using BirthManagementSystem.Domain.Abstractions;
using BirthManagementSystem.Domain.Exceptions;

namespace BirthManagementSystem.Application.Commands.ApgarScores.GiveBabyApgarScore;

internal class GiveBabyApgarScoreCommandHandler : ICommandHandler<GiveBabyApgarScoreCommand>
{
    private readonly IBabyRepository _babyRepository;
    private readonly IApgarScoreRepository _apgarScoreRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GiveBabyApgarScoreCommandHandler(IBabyRepository babyRepository, IApgarScoreRepository apgarScoreRepository, IUnitOfWork unitOfWork)
    {
        _babyRepository = babyRepository;
        _apgarScoreRepository = apgarScoreRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(GiveBabyApgarScoreCommand request, CancellationToken cancellationToken)
    {
        var baby = await _babyRepository.GetByIdAsync(request.Id, cancellationToken);
        if (baby == null)
        {
            throw new BabyNotFoundException(request.Id);
        }

        var apgar_score = await _apgarScoreRepository.GetByIdAsync(request.ApgarScoreId, cancellationToken);
        if (apgar_score == null)
        {
            throw new ApgarScoreNotFoundException(request.ApgarScoreId);
        }

        baby.ApgarScoreId = apgar_score.Id;
        baby.ApgarScore = apgar_score;

        _babyRepository.Update(baby);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
