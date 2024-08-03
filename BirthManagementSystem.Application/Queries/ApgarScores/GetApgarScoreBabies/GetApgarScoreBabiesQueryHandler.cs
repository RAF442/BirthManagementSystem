using AutoMapper;
using BirthManagementSystem.Application.Configuration.Queries;
using BirthManagementSystem.Application.Dtos;
using BirthManagementSystem.Domain.Abstractions;
using BirthManagementSystem.Domain.Exceptions;

namespace BirthManagementSystem.Application.Queries.ApgarScores.GetApgarScoreBabies;

public class GetApgarScoreBabiesQueryHandler : IQueryHandler<GetApgarScoreBabiesQuery, IEnumerable<BabyDto>>
{
    private readonly IApgarScoreRepository _apgarScoreRepository;
    private readonly IMapper _mapper;

    public GetApgarScoreBabiesQueryHandler(IApgarScoreRepository apgarScoreRepository, IMapper mapper)
    {
        _apgarScoreRepository = apgarScoreRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Pobranie wyniku w skali Apgar po identyfikatorze wraz z dziećmi, które otrzymały dany wynik
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ApgarScoreNotFoundException"></exception>
    public async Task<IEnumerable<BabyDto>> Handle(GetApgarScoreBabiesQuery request, CancellationToken cancellationToken)
    {
        var apgar_score = await _apgarScoreRepository.GetByIdAsyncWithBabiesAsync(request.Id, cancellationToken);
        if (apgar_score == null)
        {
            throw new ApgarScoreNotFoundException(request.Id);
        }

        var babiesDto = _mapper.Map<IEnumerable<BabyDto>>(apgar_score.Babies);
        return babiesDto;
    }
}
