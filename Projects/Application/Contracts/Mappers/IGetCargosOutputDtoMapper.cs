using CargoManager.Application.DTOs;
using CargoManager.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CargoManager.Application.Contracts.Mappers
{
    public interface IGetCargosOutputDtoMapper
    {
        GetCargosOutputDTO MapFrom(IEnumerable<Tuple<Cargo, double>> cargosWithDistance);
    }
}