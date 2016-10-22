using AutoMapper;
using CargoManager.Application.Contracts.Mappers;
using CargoManager.Application.Contracts.Services;
using CargoManager.Application.Contracts.Services.Internal;
using CargoManager.Application.Mappers;
using CargoManager.Application.MappingProfiles;
using CargoManager.Application.Services;
using Ninject.Modules;

namespace CargoManager.Application.IOC
{
    public class ApplicationModule : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            this.Bind<ICargoService>().To<CargoService>();
            this.Bind<IInternalCargoService>().To<InternalCargoService>();
            this.Bind<IGetCargosInputDtoMapper>().To<GetCargosInputDtoMapper>();
            this.Bind<IGetCargosOutputDtoMapper>().To<GetCargosOutputDtoMapper>();
            this.Bind<Profile>().To<GetCargosInputDtoToSearchParametersMappingProfile>().Named("GetCargosInputDtoToSearchParametersMappingProfile");
            this.Bind<Profile>().To<CargoToCargoDtoMappingProfile>().Named("CargoToCargoDtoMappingProfile");
        }
    }
}
