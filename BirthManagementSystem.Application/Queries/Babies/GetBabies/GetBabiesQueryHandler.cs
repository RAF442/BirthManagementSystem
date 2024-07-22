using AutoMapper;
using BirthManagementSystem.Application.Dtos;
using BirthManagementSystem.Domain.Abstractions;
using MediatR;

namespace BirthManagementSystem.Application.Queries.Babies.GetBabies;

internal class GetBabiesQueryHandler : IRequestHandler<GetBabiesQuery, IEnumerable<BabyDto>>
{
    private readonly IBabyReadOnlyRepository _babyReadOnlyRepository;
    private readonly IMapper _mapper;

    public GetBabiesQueryHandler(IBabyReadOnlyRepository babyReadOnlyRepository, IMapper mapper)
    {
        _babyReadOnlyRepository = babyReadOnlyRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BabyDto>> Handle(GetBabiesQuery request, CancellationToken cancellationToken)
    {
        var babies = await _babyReadOnlyRepository.GetAllAsync(cancellationToken);

        var babiesDto = _mapper.Map<IEnumerable<BabyDto>>(babies);

        return babiesDto;
    }
}
