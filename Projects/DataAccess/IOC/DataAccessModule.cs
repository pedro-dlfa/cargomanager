using CargoManager.DataAccess.Contracts.Configuration;
using CargoManager.DataAccess.Contracts.Repositories;
using CargoManager.DataAccess.Repositories;
using CargoManager.Common.Configuration;
using Ninject;
using Ninject.Modules;

namespace CargoManager.DataAccess.IOC
{
    public class DataAccessModule : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            this.Bind<ICargoEsRepository>().To<CargoEsRepository>();
            this.Bind<ICargoEsRepositoryConfigSection>().ToMethod(c => c.Kernel.Get<ConfigurationLoader>().LoadConfigurationSection<ICargoEsRepositoryConfigSection>("cargoEsRepository"));
        }
    }
}
