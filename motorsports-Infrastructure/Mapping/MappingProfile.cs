using AutoMapper;
using motorsports_Domain.Entities;
using motorsports_Domain.enums;
using motorsports_Service.DTOs;

namespace motorsports_Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Map Driver → DriverDto
            CreateMap<DriverEntity, DriverDTO>()
                .ForMember(dest => dest.Nationality,
                           opt => opt.MapFrom(src => ((NationalityEnums)src.Nationality).ToString().Replace("_", " ")));
            // Map DriverDto → Driver
            CreateMap<CreateDriverDTO, DriverEntity>()
                .ForMember(dest => dest.Nationality,
                           opt => opt.MapFrom(src => (int)Enum.Parse<NationalityEnums>(src.Nationality.Replace(" ", "_"))));

            // Map Team → TeamDto
            CreateMap<TeamEntity,TeamDTO>().ForMember(dest => dest.Country,
                           opt => opt.MapFrom(src => ((NationalityEnums)src.Country).ToString().Replace("_", " ")));
        }
    }
}
