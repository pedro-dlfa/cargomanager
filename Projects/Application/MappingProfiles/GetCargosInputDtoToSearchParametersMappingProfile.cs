using AutoMapper;
using CargoManager.Application.DTOs;
using CargoManager.Domain.Entities;

namespace CargoManager.Application.MappingProfiles
{
    public class GetCargosInputDtoToSearchParametersMappingProfile : Profile
    {
        public GetCargosInputDtoToSearchParametersMappingProfile()
        {
            this.CreateMap<GetCargosInputDTO, SearchParameters>();

            this.CreateMap<LocationAreaDTO, LocationArea>();

            this.CreateMap<LocationDTO, GeoLocation>();

            this.CreateMap(typeof(FromToDTO<>), typeof(FromTo<>));

            this.CreateMap<SortableFieldsDTO, SortableFields>();
        }
    }
}