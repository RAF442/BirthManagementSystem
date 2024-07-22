using BirthManagementSystem.Application.Dtos;
using MediatR;

namespace BirthManagementSystem.Application.Queries.Babies.GetBabyById;

public record GetBabyByIdQuery(int Id) : IRequest<BabyDetailsDto>
{
}
