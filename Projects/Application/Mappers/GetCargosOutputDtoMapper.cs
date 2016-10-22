using AutoMapper;
using CargoManager.Application.Contracts.Mappers;
using CargoManager.Application.DTOs;
using CargoManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CargoManager.Application.Mappers
{
    public class GetCargosOutputDtoMapper : IGetCargosOutputDtoMapper
    {
        private readonly IMapper mapper;

        public GetCargosOutputDtoMapper(IMapper mapper)
        {
            if (mapper == null)
            {
                throw new ArgumentNullException("mapper");
            }

            this.mapper = mapper;
        }

        public GetCargosOutputDTO MapFrom(IEnumerable<Tuple<Cargo, double>> cargosWithDistance)
        {
            if (cargosWithDistance == null)
            {
                throw new ArgumentNullException("cargosWithDistance");
            }

            return new GetCargosOutputDTO
            {
                Cargos = cargosWithDistance.Select(c => new CargoWithDistanceDTO
                {
                    Cargo = this.mapper.Map<CargoDTO>(c.Item1),
                    Distance = c.Item2
                })
            };
        }
    }
}