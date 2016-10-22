using AutoMapper;
using CargoManager.Application.Contracts.Mappers;
using CargoManager.Application.DTOs;
using CargoManager.Domain.Entities;
using System;

namespace CargoManager.Application.Mappers
{
    public class GetCargosInputDtoMapper : IGetCargosInputDtoMapper
    {
        private readonly IMapper mapper;

        public GetCargosInputDtoMapper(IMapper mapper)
        {
            if (mapper == null)
            {
                throw new ArgumentNullException("mapper");
            }

            this.mapper = mapper;
        }

        public SearchParameters Map(GetCargosInputDTO dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException("dto");
            }

            return this.mapper.Map<SearchParameters>(dto);
        }
    }
}