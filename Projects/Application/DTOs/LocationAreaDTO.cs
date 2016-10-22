using System.ComponentModel.DataAnnotations;

namespace CargoManager.Application.DTOs
{
    public class LocationAreaDTO
    {
        [Required(ErrorMessage = "Location is required")]
        public LocationDTO Location { get; set; }
        public float MaxDistance { get; set; }
    }
}
