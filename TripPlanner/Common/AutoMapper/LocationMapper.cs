using AutoMapper;
using DomainModels;
using Entity.Models;

namespace Common.AutoMapper
{
    public class LocationMapper : Profile
    {
        public LocationMapper()
        {
            CreateMap<Location, LocationDto>()
                .ForMember(c => c.Country, opt => opt.MapFrom(src => src.Country))
                .ForMember(c => c.Name, opt => opt.MapFrom(src => src.Name))
                //.ForMember(c => c.Trips, opt => opt.MapFrom(src => src.Trips))
                .ReverseMap();
        }
    }
}
