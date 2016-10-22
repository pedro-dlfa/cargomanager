
using CargoManager.DataAccess.Configuration;
using CargoManager.DataAccess.Contracts.Repositories;
using CargoManager.DataAccess.Repositories;
using CargoManager.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Device.Location;

namespace CargoManager.IntegrationTests.Repositories
{
    [TestClass]
    public class CargoEsRepositoryTest
    {
        //private IElasticClient client;
        public ICargoEsRepository sut;


        [TestInitialize]
        public void TestInitialize()
        {
            this.sut = new CargoEsRepository(new CargoEsRepositoryConfigSection());
        }

        [TestMethod]
        public void SearchCargos_AllParameters_Ok()
        {
            var parameters = new SearchParameters
            {
                Price = new FromTo<float?> { From = 10, To = 20 },
                Volume = new FromTo<float?> { From = 30, To = 40 },
                Weight = new FromTo<float?> { From = 50, To = 60 },
                Departure = new FromTo<DateTime?> {
                    From = DateTime.Now.AddDays(2),
                    To = DateTime.Now.AddDays(3)
                },
                Arrival = new FromTo<DateTime?>
                {
                    From = DateTime.Now.AddDays(4),
                    To = DateTime.Now.AddDays(5)
                },
                OriginArea = new LocationArea
                {
                    Location = new GeoCoordinate { Latitude = 1, Longitude = 2 },
                    MaxDistance = 100
                },
                DestinationArea = new LocationArea
                {
                    Location = new GeoCoordinate { Latitude = 3, Longitude = 4 },
                    MaxDistance = 200
                },
                Offset = 1,
                Limit = 2
            };

            var result = this.sut.SearchCargos(parameters);
        }

        [TestMethod]
        public void SearchCargos_OnlyFromParameters_Ok()
        {
            var parameters = new SearchParameters
            {
                Price = new FromTo<float?> { From = 10 },
                Volume = new FromTo<float?> { From = 30 },
                Weight = new FromTo<float?> { From = 50 },
                Departure = new FromTo<DateTime?>
                {
                    From = DateTime.Now.AddDays(2)
                },
                Arrival = new FromTo<DateTime?>
                {
                    From = DateTime.Now.AddDays(4)
                },
                OriginArea = new LocationArea
                {
                    Location = new GeoCoordinate { Latitude = 1, Longitude = 2 },
                    MaxDistance = 100
                }
            };

            var result = this.sut.SearchCargos(parameters);
        }

        [TestMethod]
        public void SearchCargos_OnlyToParameters_Ok()
        {
            var parameters = new SearchParameters
            {
                Price = new FromTo<float?> { To = 20 },
                Volume = new FromTo<float?> { To = 40 },
                Weight = new FromTo<float?> { To = 60 },
                Departure = new FromTo<DateTime?>
                {
                    To = DateTime.Now.AddDays(3)
                },
                Arrival = new FromTo<DateTime?>
                {
                    To = DateTime.Now.AddDays(5)
                },
                OriginArea = new LocationArea
                {
                    Location = new GeoCoordinate { Latitude = 1, Longitude = 2 },
                    MaxDistance = 100
                }
            };

            var result = this.sut.SearchCargos(parameters);
        }
    }
}
