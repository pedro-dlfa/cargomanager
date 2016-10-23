using CargoManager.Domain.Entities;
using CargoManager.Shared.Resources;
using CargoManager.Shared.Utils;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CargoManager.Shared.DB
{
    public class PlacesDB
    {
        public static PlacesDB instance;
        private List<Place> places;

        public IEnumerable<Place> Places
        {
            get
            {
                return places.AsReadOnly();
            }
        }

        private PlacesDB()
        {
            this.places = 
                CsvReader.ReadString(
                    SharedResources.cities,
                    (s) => new Place
                    {
                        City = s[0],
                        Province = s[1],
                        Location = new GeoLocation
                        {
                            Lat = double.Parse(s[3], CultureInfo.InvariantCulture),
                            Lon = double.Parse(s[4], CultureInfo.InvariantCulture)
                        }
                    }
                )
                .ToList();
        }

        public static PlacesDB Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlacesDB();
                }
                return instance;
            }
        }
    }
}
