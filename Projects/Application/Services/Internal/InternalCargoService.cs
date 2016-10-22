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

            GeoCoordinate position = parameters.OriginArea.Location;
            return cargos.Select(c => new Tuple<Cargo, double>(c, position.GetDistanceTo(c.From.Location))).ToList();
        }
    }
}
