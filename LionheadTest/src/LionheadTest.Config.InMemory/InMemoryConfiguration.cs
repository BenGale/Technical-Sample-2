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
            _lootConfiguration = new List<LootItemWeighting>
            {
                new LootItemWeighting(new LootItem("1", "Sword"), 10),
                new LootItemWeighting(new LootItem("2", "Shield"), 10),
                new LootItemWeighting(new LootItem("3", "Health Potion"), 30),
                new LootItemWeighting(new LootItem("4", "Resurrection Phial"), 30),
                new LootItemWeighting(new LootItem("5", "Scroll of Wisdom"), 20)
            };
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
