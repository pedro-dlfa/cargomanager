using AutoMapper;
using CargoManager.Application.DTOs;
using CargoManager.Domain.Entities;
using System.Device.Location;

namespace CargoManager.Application.MappingProfiles
{
    public class CargoToCargoDtoMappingProfile : Profile
    {
        public CargoToCargoDtoMappingProfile()
        {
            this.CreateMap<Cargo, CargoDTO>()
                .ForMember(dst => dst.Load, opt => opt.MapFrom(src => src.Load))
                .ForMember(dst => dst.From, opt => opt.MapFrom(src => src.From))
                .ForMember(dst => dst.To, opt => opt.MapFrom(src => src.To));

            this.CreateMap<Load, LoadDTO>();

            this.CreateMap<Place, PlaceDTO>()
                .ForMember(dst => dst.Location, opt => opt.MapFrom(src => src.Location));

            this.CreateMap<GeoCoordinate, LocationDTO>()
                .ForMember(dst => dst.Lat, src => src.MapFrom(f => f.Latitude))
                .ForMember(dst => dst.Lon, src => src.MapFrom(f => f.Longitude));
        }
    }
}