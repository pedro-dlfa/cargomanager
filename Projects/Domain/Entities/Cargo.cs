using System;

namespace CargoManager.Domain.Entities
{
    public class Cargo
    {
        public string CompanyId { get; set; }
        public string TransporterId { get; set; }
        public Load Load { get; set; }
        public int Price { get; set; }
        public Place From { get; set; }
        public DateTime Departure { get; set; }
        public Place To { get; set; }
        public DateTime Arrival { get; set; }
    }
}
