using System.Device.Location;

namespace CargoManager.Domain.Entities
{
    public class LocationArea
    {
        public GeoCoordinate Location { get; set; }
        public float MaxDistance { get; set; }
    }
}
