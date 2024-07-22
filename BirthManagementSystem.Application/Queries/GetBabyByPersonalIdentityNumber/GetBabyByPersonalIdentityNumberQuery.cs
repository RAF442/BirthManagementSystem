using BirthManagementSystem.Application.Dtos;
using MediatR;

namespace BirthManagementSystem.Application.Queries.GetBabyByPersonalIdentityNumber;

public record GetBabyByPersonalIdentityNumberQuery(string PersonalIdentityNumber) : IRequest<BabyDto>
{
}
