using System.Diagnostics;
using LionheadTest.API.Logging;
using LionheadTest.Config.InMemory;
using LionheadTest.Domain;
using LionheadTest.Domain.Configuration;
using LionheadTest.Domain.Logging;
using Ninject.Modules;

namespace LionheadTest.API.IoC
{
    public class DomainModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILootTableConfig>().To<InMemoryConfiguration>().InSingletonScope();
            Bind<ILogger>().To<TraceLogger>();
            Bind<ILootTable>().To<LootTable>();
        }
    }
}