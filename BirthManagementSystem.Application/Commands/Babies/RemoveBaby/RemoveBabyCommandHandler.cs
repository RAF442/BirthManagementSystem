using BirthManagementSystem.Application.Configuration.Commands;
using BirthManagementSystem.Domain.Abstractions;
using BirthManagementSystem.Domain.Exceptions;

namespace BirthManagementSystem.Application.Commands.Babies.RemoveBaby;

internal class RemoveBabyCommandHandler : ICommandHandler<RemoveBabyCommand>
{
    private readonly IBabyRepository _babyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveBabyCommandHandler(IBabyRepository babyRepository, IUnitOfWork unitOfWork)
    {
        _babyRepository = babyRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(RemoveBabyCommand request, CancellationToken cancellationToken)
    {
        var baby = await _babyRepository.GetByIdAsync(request.Id, cancellationToken);
        if (baby == null)
        {
            throw new BabyNotFoundException(request.Id);
        }

        _babyRepository.Delete(baby);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
