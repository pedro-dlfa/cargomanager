using Nest;

namespace CargoManager.Domain.Entities
{
    public class Place
    {
        [GeoPoint]
        public GeoLocation Location { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
    }
}
