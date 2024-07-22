using BirthManagementSystem.Application.Configuration.Commands;
using BirthManagementSystem.Domain.Abstractions;
using BirthManagementSystem.Domain.Exceptions;
using FluentValidation;
using FluentValidation.Results;

namespace BirthManagementSystem.Application.Commands.Babies.UpdateBaby;

internal class UpdateBabyCommandHandler : ICommandHandler<UpdateBabyCommand>
{
    private readonly IBabyRepository _babyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<UpdateBabyCommand> _validator;

    public UpdateBabyCommandHandler(IBabyRepository babyRepository, IUnitOfWork unitOfWork, IValidator<UpdateBabyCommand> validator)
    {
        _babyRepository = babyRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }
    public async Task Handle(UpdateBabyCommand request, CancellationToken cancellationToken)
    {
        ValidationResult result = _validator.Validate(request);
        if (!result.IsValid)
        {
            var errorList = result.Errors.Select(x => x.ErrorMessage);
            throw new ValidationException($"Invalid command, reasons: {string.Join(",", errorList.ToArray())}");
        }

        var baby = await _babyRepository.GetByIdAsync(request.Id, cancellationToken);
        if (baby == null)
        {
            throw new BabyNotFoundException(request.Id);
        }

        baby.FirstName = request.FirstName;
        baby.SecondName = request.SecondName;
        baby.LastName = request.LastName;
        baby.PersonalIdentityNumber = request.PersonalIdentityNumber;
        baby.DateOfBirth = request.DateOfBirth;

        _babyRepository.Update(baby);
        await _unitOfWork.SaveChangesAsync();
    }
}
