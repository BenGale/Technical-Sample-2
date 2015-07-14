using LionheadTest.Config.InMemory;
using LionheadTest.Domain;
using LionheadTest.Domain.Configuration;
using Ninject.Modules;

namespace LionheadTest.API.IoC
{
    public class DomainModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILootTableConfig>().To<InMemoryConfiguration>().InSingletonScope();
            Bind<ILootTable>().To<LootTable>();
        }
    }
}