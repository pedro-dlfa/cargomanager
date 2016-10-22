using AutoMapper;
using CargoManager.Application.DTOs;
using CargoManager.Domain.Entities;
using System.Device.Location;

namespace CargoManager.Application.MappingProfiles
{
    public class GetCargosInputDtoToSearchParametersMappingProfile : Profile
    {
        public GetCargosInputDtoToSearchParametersMappingProfile()
        {
            this.CreateMap<GetCargosInputDTO, SearchParameters>()
                .ForMember(dst => dst.Price, src => src.MapFrom(f => f.Price))
                .ForMember(dst => dst.Volume, src => src.MapFrom(f => f.Volume))
                .ForMember(dst => dst.Weight, src => src.MapFrom(f => f.Weight))
                .ForMember(dst => dst.Departure, src => src.MapFrom(f => f.Departure))
                .ForMember(dst => dst.Arrival, src => src.MapFrom(f => f.Arrival))
                .ForMember(dst => dst.OriginArea, src => src.MapFrom(f => f.OriginArea))
                .ForMember(dst => dst.DestinationArea, src => src.MapFrom(f => f.DestinationArea));

            this.CreateMap<LocationAreaDTO, LocationArea>()
                .ForMember(dst => dst.Location, src => src.MapFrom(f => f.Location));

            this.CreateMap<LocationDTO, GeoCoordinate>()
                .ForMember(dst => dst.Latitude, src => src.MapFrom(f => f.Lat))
                .ForMember(dst => dst.Longitude, src => src.MapFrom(f => f.Lon))
                .ForMember(dst => dst.Altitude, src => src.Ignore())
                .ForMember(dst => dst.Altitude, src => src.Ignore())
                .ForMember(dst => dst.HorizontalAccuracy, src => src.Ignore())
                .ForMember(dst => dst.VerticalAccuracy, src => src.Ignore())
                .ForMember(dst => dst.Speed, src => src.Ignore())
                .ForMember(dst => dst.Course, src => src.Ignore());

            this.CreateMap(typeof(FromToDTO<>), typeof(FromTo<>));
        }
    }
}