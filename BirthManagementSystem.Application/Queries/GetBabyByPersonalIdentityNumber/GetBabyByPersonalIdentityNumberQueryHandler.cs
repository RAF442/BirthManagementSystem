using AutoMapper;
using BirthManagementSystem.Application.Dtos;
using BirthManagementSystem.Application.Queries.Babies.GetBabyById;
using BirthManagementSystem.Domain.Abstractions;
using MediatR;

namespace BirthManagementSystem.Application.Queries.GetBabyByPersonalIdentityNumber;

internal class GetBabyByPersonalIdentityNumberQueryHandler : IRequestHandler<GetBabyByPersonalIdentityNumberQuery, BabyDto>
{
    private readonly IBabyRepository _babyRepository;
    private readonly IMapper _mapper;

    public GetBabyByPersonalIdentityNumberQueryHandler(IBabyRepository babyRepository, IMapper mapper)
    {
        _babyRepository = babyRepository;
        _mapper = mapper;
    }

    public async Task<BabyDto> Handle(GetBabyByPersonalIdentityNumberQuery request, CancellationToken cancellationToken)
    {
        var baby = await _babyRepository.GetByPersonalIdentityNumberAsync(request.PersonalIdentityNumber, cancellationToken);

        var babyDto = _mapper.Map<BabyDto>(baby);

        return babyDto;
    }
}
