using AutoMapper;
using BirthManagementSystem.Application.Dtos;
using BirthManagementSystem.Domain.Entities;

namespace BirthManagementSystem.Application.Configuration.Mappings;

public class BabyMappingProfile : Profile
{
    public BabyMappingProfile()
    {
        CreateMap<Baby, BabyDto>();

        CreateMap<PlaceOfBirth, PlaceOfBirthDto>();

        CreateMap<Baby, BabyDetailsDto>();
    }
}
