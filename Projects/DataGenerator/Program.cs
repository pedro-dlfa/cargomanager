using CargoManager.DataAccess.Contracts.Repositories;
using CargoManager.DataAccess.IOC;
using CargoManager.Domain.Entities;
using CargoManager.Utils.Builders;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CargoManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel(
                new DataAccessModule()
                );

            ICargoEsRepository repository = kernel.Get<ICargoEsRepository>();

            Console.WriteLine("Starting ingestion...");

            IEnumerable<Cargo> failures;
            repository.IngestCargos(
                Enumerable.Range(1, 1000)
                    .Select(x => CargoBuilder.GenerateCargo())
                    .ToList(),
                out failures
                );

            Console.WriteLine("Finished!");
        }
    }
}
