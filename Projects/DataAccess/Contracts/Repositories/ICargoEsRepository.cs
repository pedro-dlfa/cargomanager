using CargoManager.Domain.Entities;
using System.Collections.Generic;

namespace CargoManager.DataAccess.Contracts.Repositories
{
    public interface ICargoEsRepository
    {
        bool IngestCargos(IEnumerable<Cargo> cargoList, out IEnumerable<Cargo> failures);

        IEnumerable<Cargo> SearchCargos(SearchParameters parameters);
    }
}
