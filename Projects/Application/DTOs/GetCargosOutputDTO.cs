using System.Collections.Generic;

namespace CargoManager.Application.DTOs
{
    public class GetCargosOutputDTO
    {
        public IEnumerable<CargoWithDistanceDTO> Cargos { get; set; }
    }
}
