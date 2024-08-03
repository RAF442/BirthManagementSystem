using AutoMapper;
using BirthManagementSystem.Application.Dtos;
using BirthManagementSystem.Domain.Abstractions;
using MediatR;

namespace BirthManagementSystem.Application.Queries.Babies.GetBabies;

internal class GetBabiesQueryHandler : IRequestHandler<GetBabiesQuery, IEnumerable<BabyDto>>
{
    private readonly IBabyReadOnlyRepository _babyReadOnlyRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Wstrzyknięcie repozytorium do obsługi dzieci
    /// </summary>
    /// <param name="babyReadOnlyRepository"></param>
    /// <param name="mapper"></param>
    public GetBabiesQueryHandler(IBabyReadOnlyRepository babyReadOnlyRepository, IMapper mapper)
    {
        _babyReadOnlyRepository = babyReadOnlyRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Obsługa metody zwracającej wszystkie dzieci
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Obiekt babiesDto</returns>
    public async Task<IEnumerable<BabyDto>> Handle(GetBabiesQuery request, CancellationToken cancellationToken)
    {
        var babies = await _babyReadOnlyRepository.GetAllAsync(cancellationToken);

        var babiesDto = _mapper.Map<IEnumerable<BabyDto>>(babies);

        return babiesDto;
    }
}
