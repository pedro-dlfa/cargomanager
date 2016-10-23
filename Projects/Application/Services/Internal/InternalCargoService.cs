using CargoManager.Application.Contracts.Services.Internal;
using CargoManager.DataAccess.Contracts.Repositories;
using CargoManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;

namespace CargoManager.Application.Services
{
    public class InternalCargoService : IInternalCargoService
    {
        private const double KILOMETERS_SCALE_FACTOR = 0.001;

        private readonly ICargoEsRepository cargoRepository;

        public InternalCargoService(ICargoEsRepository cargoRepository)
        {
            if (cargoRepository == null)
            {
                throw new ArgumentNullException("cargoRepository");
            }

            this.cargoRepository = cargoRepository;
        }

        public IEnumerable<Tuple<Cargo, double>> GetCargos(SearchParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            IEnumerable<Cargo> cargos = cargoRepository.SearchCargos(parameters);

            GeoCoordinate position = new GeoCoordinate(
                parameters.OriginArea.Location.Lat,
                parameters.OriginArea.Location.Lon);

            return cargos
                .Select(c => 
                    new Tuple<Cargo, double>(c, KILOMETERS_SCALE_FACTOR * position.GetDistanceTo(
                        new GeoCoordinate(
                            c.From.Location.Lat, 
                            c.From.Location.Lon))))
                .ToList();
        }
    }
}
