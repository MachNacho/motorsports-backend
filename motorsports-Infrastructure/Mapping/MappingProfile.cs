using AutoMapper;
using motorsports_Domain.Entities;
using motorsports_Domain.enums;
using motorsports_Service.DTOs;

namespace motorsports_Infrastructure.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            // Map Driver → DriverDto
            CreateMap<Driver, DriverDTO>()
                .ForMember(dest => dest.Nationality,
                           opt => opt.MapFrom(src => ((NationalityEnums)src.Nationality).ToString().Replace("_", " ")));
            // Map DriverDto → Driver
            CreateMap<DriverDTO, Driver>()
                .ForMember(dest => dest.Nationality,
                           opt => opt.MapFrom(src => (int)Enum.Parse<NationalityEnums>(src.Nationality.Replace(" ", "_"))));
        }
    }
}
