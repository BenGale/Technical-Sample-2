using System.Collections.Generic;

namespace LionheadTest.Domain.Configuration
{
    public interface ILootTableConfigProvider
    {
        IReadOnlyList<LootItemWeighting> GetWeightings();
    }
}
