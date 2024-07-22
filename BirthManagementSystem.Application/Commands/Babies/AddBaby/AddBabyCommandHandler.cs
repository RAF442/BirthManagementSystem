using AutoMapper;
using BirthManagementSystem.Application.Configuration.Commands;
using BirthManagementSystem.Application.Dtos;
using BirthManagementSystem.Domain.Abstractions;
using BirthManagementSystem.Domain.Entities;
using BirthManagementSystem.Domain.Exceptions;
using FluentValidation;
using FluentValidation.Results;

namespace BirthManagementSystem.Application.Commands.Babies.AddBaby;

internal class AddBabyCommandHandler : ICommandHandler<AddBabyCommand, BabyDto>
{
    private readonly IBabyRepository _babyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<AddBabyCommand> _validator;

    public AddBabyCommandHandler(IBabyRepository babyRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<AddBabyCommand> validator)
    {
        _babyRepository = babyRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<BabyDto> Handle(AddBabyCommand request, CancellationToken cancellationToken)
    {
        ValidationResult result = _validator.Validate(request);
        if (!result.IsValid)
        {
            var errorList = result.Errors.Select(x => x.ErrorMessage);
            throw new ValidationException($"Invalid command, reasons: {string.Join(",", errorList.ToArray())}");
        }

        bool isAlreadyExist = await _babyRepository.IsAlreadyExistAsync(request.PersonalIdentityNumber, cancellationToken);
        if (isAlreadyExist)
        {
            throw new BabyAlreadyExistException(request.PersonalIdentityNumber);
        }

        var newBaby = new Baby()
        {
            FirstName = request.FirstName,
            SecondName = request.SecondName,
            LastName = request.LastName,
            PersonalIdentityNumber = request.PersonalIdentityNumber,
            DateOfBirth = request.DateOfBirth,
            PlaceOfBirth = new PlaceOfBirth()
            {
                StreetName = request.StreetName,
                StreetNumber = request.StreetNumber,
                City = request.City,
                PostalCode = request.PostalCode
            }
        };

        _babyRepository.Add(newBaby);
        await _unitOfWork.SaveChangesAsync();

        var babyDto = _mapper.Map<BabyDto>(newBaby);

        return babyDto;
    }
}
