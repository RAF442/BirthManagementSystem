using BirthManagementSystem.Application.Configuration.Queries;
using BirthManagementSystem.Application.Dtos;

namespace BirthManagementSystem.Application.Queries.ApgarScores.GetApgarScoreBabies;

public record GetApgarScoreBabiesQuery (int Id) : IQuery<IEnumerable<BabyDto>>;
