using System.Collections.Generic;
using LionheadTest.Domain.Configuration;

namespace LionheadTest.Domain.Model
{
    public class LootTable
    {
        private IReadOnlyList<LootItemWeighting> _lootItems;

        public LootTable(ILootTableConfigProvider configProvider)
        {
            _lootItems = configProvider.GetWeightings();
        }
    }
}
