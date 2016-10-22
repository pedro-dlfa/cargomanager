using CargoManager.Application.DTOs;
using CargoManager.Domain.Entities;

namespace CargoManager.Application.Contracts.Mappers
{
    public interface IGetCargosInputDtoMapper
    {
        SearchParameters Map(GetCargosInputDTO dto);
    }
}