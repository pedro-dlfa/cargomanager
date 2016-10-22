using Location = System.Device.Location;
using Nest;

namespace CargoManager.Domain.Entities
{
    public class Place
    {
        [GeoPoint]
        public Location.GeoCoordinate Location { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
    }
}
