using CargoManager.Domain.Entities;
using CargoManager.Shared.DB;
using System;
using System.Linq;

namespace CargoManager.Utils.Builders
{
    public static class CargoBuilder
    {
        private static readonly Random randomizer = new Random();

        public static Cargo GenerateCargo()
        {
            return new Cargo
            {
                CompanyId = randomizer.Next(1000).ToString(),
                Price = randomizer.Next(200, 10000),
                Load = new Load
                {
                    Volume = randomizer.Next(100, 1000),
                    Weight = randomizer.Next(100, 1000),
                },
                From = PlacesDB.Instance.Places.ElementAt(randomizer.Next(PlacesDB.Instance.Places.Count())),
                Departure = DateTime.Now.Add(TimeSpan.FromHours(randomizer.Next(100, 200))),
                To = PlacesDB.Instance.Places.ElementAt(randomizer.Next(PlacesDB.Instance.Places.Count())),
                Arrival = DateTime.Now.Add(TimeSpan.FromHours(randomizer.Next(200, 300))),
            };
        }
    }
}
