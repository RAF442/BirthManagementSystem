using AutoMapper;
using BirthManagementSystem.Application.Configuration.Queries;
using BirthManagementSystem.Application.Dtos;
using BirthManagementSystem.Domain.Abstractions;

namespace BirthManagementSystem.Application.Queries.Babies.GetBabiesWithDetails;

public class GetBabiesWithDetailsQueryHandler : IQueryHandler<GetBabiesWithDetailsQuery, IEnumerable<BabyDetailsDto>>
{
    private readonly IBabyReadOnlyRepository _babyReadOnlyRepository;
    private readonly IMapper _mapper;

    public GetBabiesWithDetailsQueryHandler(IBabyReadOnlyRepository babyReadOnlyRepository, IMapper mapper)
    {
        _babyReadOnlyRepository = babyReadOnlyRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Obsługa metody zwracającej wszystkie dzieci ze szczegółowymi informacjami
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IEnumerable<BabyDetailsDto>> Handle(GetBabiesWithDetailsQuery request, CancellationToken cancellationToken)
    {
        var babies = await _babyReadOnlyRepository.GetAllWithDetailsAsync(cancellationToken);

        var babiesDto = _mapper.Map<IEnumerable<BabyDetailsDto>>(babies);

        return babiesDto;
    }
}
