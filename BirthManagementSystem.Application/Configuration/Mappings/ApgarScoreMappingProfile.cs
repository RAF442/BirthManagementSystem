using AutoMapper;
using BirthManagementSystem.Application.Dtos;
using BirthManagementSystem.Domain.Entities;

namespace BirthManagementSystem.Application.Configuration.Mappings;

public class ApgarScoreMappingProfile : Profile
{
    public ApgarScoreMappingProfile()
    {
        CreateMap<ApgarScore, ApgarScoreDto>();
    }
}
