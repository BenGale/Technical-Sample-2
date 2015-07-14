using LionheadTest.Config.InMemory;
using LionheadTest.Domain.Configuration;
using Ninject.Modules;

namespace LionheadTest.API.IoC
{
    public class ConfigurationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILootTableConfig>().To<InMemoryConfiguration>().InSingletonScope();
        }
    }
}