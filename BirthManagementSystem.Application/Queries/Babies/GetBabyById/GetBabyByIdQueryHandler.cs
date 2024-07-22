using AutoMapper;
using BirthManagementSystem.Application.Dtos;
using BirthManagementSystem.Domain.Abstractions;
using MediatR;

namespace BirthManagementSystem.Application.Queries.Babies.GetBabyById;

internal class GetBabyByIdQueryHandler : IRequestHandler<GetBabyByIdQuery, BabyDetailsDto>
{
    private readonly IBabyRepository _babyRepository;
    private readonly IMapper _mapper;

    public GetBabyByIdQueryHandler(IBabyRepository babyRepository, IMapper mapper)
    {
        _babyRepository = babyRepository;
        _mapper = mapper;
    }

    public async Task<BabyDetailsDto> Handle(GetBabyByIdQuery request, CancellationToken cancellationToken)
    {
        var baby = await _babyRepository.GetByIdAsync(request.Id, cancellationToken);

        var babyDto = _mapper.Map<BabyDetailsDto>(baby);

        return babyDto;
    }
}
