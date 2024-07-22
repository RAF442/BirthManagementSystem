using BirthManagementSystem.Application.Dtos;
using MediatR;

namespace BirthManagementSystem.Application.Queries.Babies.GetBabies;

public record GetBabiesQuery() : IRequest<IEnumerable<BabyDto>>
{
}
