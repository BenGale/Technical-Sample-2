using System.Collections.Generic;
using LionheadTest.Domain.Model;

namespace LionheadTest.Domain.Configuration
{
    public interface ILootTableConfig
    {
        void AddItem(LootItem item, int dropWeight);
        IReadOnlyList<LootItemWeighting> GetWeightings();
    }
}
