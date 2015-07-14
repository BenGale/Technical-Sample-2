using System.Collections.Generic;
using System.Linq;
using LionheadTest.Domain.Configuration;
using LionheadTest.Domain.Model;

namespace LionheadTest.Config.InMemory
{
    public class InMemoryConfiguration : ILootTableConfig
    {
        private readonly List<LootItemWeighting> _lootConfiguration;

        public InMemoryConfiguration()
        {
            _lootConfiguration = new List<LootItemWeighting>();
        }

        public void AddItem(LootItem item, int dropWeight)
        {
            if (_lootConfiguration.Any(configuration => configuration.Item.Identifier == item.Identifier)) return;

            _lootConfiguration.Add(new LootItemWeighting(item, dropWeight));
        }

        public void RemoveItem(string identifier)
        {
            var item = _lootConfiguration.Single(configuration => configuration.Item.Identifier == identifier);
            _lootConfiguration.Remove(item);
        }

        public IReadOnlyList<LootItemWeighting> GetWeightings()
        {
            return _lootConfiguration;
        }
    }
}
