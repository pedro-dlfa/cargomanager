using CargoManager.Application.DTOs;

namespace CargoManager.Application.Contracts.Services
{
    public interface ICargoService
    {
        GetCargosOutputDTO GetCargos(GetCargosInputDTO dto);
    }
}
