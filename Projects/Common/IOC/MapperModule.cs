using AutoMapper;
using Ninject;
using Ninject.Activation;
using Ninject.Modules;

namespace CargoManager.Common.IOC
{
    public class MapperModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<MapperConfiguration>().ToMethod(BuildConfiguration).InSingletonScope();

            this.Bind<IMapper>().ToMethod(c => c.Kernel.Get<MapperConfiguration>().CreateMapper());
        }

        private static MapperConfiguration BuildConfiguration(IContext context)
        {
            var configuration = new MapperConfiguration(cfg => ConfigureMapper(context, cfg));
            configuration.AssertConfigurationIsValid();

            return configuration;
        }

        private static void ConfigureMapper(IContext context, IMapperConfigurationExpression cfg)
        {
            foreach (var profile in context.Kernel.GetAll<Profile>())
            {
                cfg.AddProfile(profile);
            }
        }
    }
}
