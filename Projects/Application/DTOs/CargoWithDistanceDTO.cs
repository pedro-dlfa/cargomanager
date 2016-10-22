using System;

namespace CargoManager.Application.DTOs
{
    public class CargoWithDistanceDTO : CargoDTO
    {
        public CargoDTO Cargo { get; set; }
        public double Distance { get; set; }
    }
}
