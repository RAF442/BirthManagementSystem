using AutoMapper;
using BirthManagementSystem.Application.Configuration.Commands;
using BirthManagementSystem.Application.Dtos;
using BirthManagementSystem.Domain.Abstractions;
using BirthManagementSystem.Domain.Entities;
using BirthManagementSystem.Domain.Exceptions;

namespace BirthManagementSystem.Application.Commands.ApgarScores.AddApgarScore;

public class AddApgarScoreCommandHandler : ICommandHandler<AddApgarScoreCommand, ApgarScoreDto>
{
    private readonly IApgarScoreRepository _apgarScoreRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AddApgarScoreCommandHandler(IApgarScoreRepository apgarScoreRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _apgarScoreRepository = apgarScoreRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<ApgarScoreDto> Handle(AddApgarScoreCommand request, CancellationToken cancellationToken)
    {
        bool isAlreadyExist = await _apgarScoreRepository.IsAlreadyExistAsync(request.Value, cancellationToken);
        if (isAlreadyExist)
        {
            throw new ApgarScoreAlreadyExistsException(request.Value);
        }

        var newApgarScore = new ApgarScore()
        {
            Name = request.Name,
            Value = request.Value,
        };

        _apgarScoreRepository.Add(newApgarScore);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var ApgarScoreDto = _mapper.Map<ApgarScoreDto>(newApgarScore);
        return ApgarScoreDto;
    }
}
