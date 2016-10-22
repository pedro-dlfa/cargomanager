using System;

namespace CargoManager.Application.DTOs
{
    public class GetCargosInputDTO
    {
        public FromToDTO<float?> Price { get; set; }
        public FromToDTO<float?> Volume { get; set; }
        public FromToDTO<float?> Weight { get; set; }
        public LocationAreaDTO OriginArea { get; set; }
        public LocationAreaDTO DestinationArea { get; set; }
        public FromToDTO<DateTime?> Departure { get; set; }
        public FromToDTO<DateTime?> Arrival { get; set; }
        public int? Limit { get; set; }
        public int? Offset { get; set; }
    }
}
