using BirthManagementSystem.Application.Configuration.Queries;
using BirthManagementSystem.Application.Dtos;

namespace BirthManagementSystem.Application.Queries.Babies.GetBabiesWithDetails;

public record GetBabiesWithDetailsQuery : IQuery<IEnumerable<BabyDetailsDto>>;
