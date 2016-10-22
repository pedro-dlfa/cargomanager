using CargoManager.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CargoManager.Application.Contracts.Services.Internal
{
    public interface IInternalCargoService
    {
        IEnumerable<Tuple<Cargo, double>> GetCargos(SearchParameters parameters);
    }
}
