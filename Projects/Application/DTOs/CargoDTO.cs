using System;

namespace CargoManager.Application.DTOs
{
    public class CargoDTO
    {
        public string CompanyId { get; set; }
        public string TransporterId { get; set; }
        public LoadDTO Load { get; set; }
        public int Price { get; set; }
        public PlaceDTO From { get; set; }
        public DateTime Departure { get; set; }
        public PlaceDTO To { get; set; }
        public DateTime Arrival { get; set; }
    }
}
