using CargoManager.Application.Contracts.Mappers;
using CargoManager.Application.Contracts.Services;
using CargoManager.Application.Contracts.Services.Internal;
using CargoManager.Application.DTOs;
using CargoManager.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CargoManager.Application.Services
{
    public class CargoService : ICargoService
    {
        private readonly IInternalCargoService cargoService;
        private readonly IGetCargosInputDtoMapper getCargosInputMapper;
        private readonly IGetCargosOutputDtoMapper getCargosOutputMapper;

        public CargoService(
            IInternalCargoService cargoService,
            IGetCargosInputDtoMapper getCargosInputMapper,
            IGetCargosOutputDtoMapper getCargosOutputMapper
            )
        {
            if (cargoService == null)
            {
                throw new ArgumentNullException("cargoService");
            }
            if (getCargosInputMapper == null)
            {
                throw new ArgumentNullException("getCargosInputMapper");
            }
            if (getCargosOutputMapper == null)
            {
                throw new ArgumentNullException("getCargosOutputMapper");
            }

            this.cargoService = cargoService;
            this.getCargosInputMapper = getCargosInputMapper;
            this.getCargosOutputMapper = getCargosOutputMapper;
        }

        public GetCargosOutputDTO GetCargos(GetCargosInputDTO dto)
        {
            SearchParameters parameters = this.getCargosInputMapper.Map(dto);
            IEnumerable<Tuple<Cargo, double>> cargosWithDistance = this.cargoService.GetCargos(parameters);
            return this.getCargosOutputMapper.MapFrom(cargosWithDistance);
        }
    }
}
