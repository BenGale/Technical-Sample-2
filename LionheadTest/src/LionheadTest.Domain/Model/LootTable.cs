using System;
using System.Collections.Generic;
using System.Linq;
using LionheadTest.Domain.Configuration;

namespace LionheadTest.Domain.Model
{
    public class LootTable
    {
        private int _weightingTotal;
        private readonly IReadOnlyList<LootWeightRange> _lootItems;

        public LootTable(ILootTableConfigProvider configProvider)
        {
            _lootItems = CreateWeightedRanges(configProvider.GetWeightings());
        }

        public LootItem Roll(int seed)
        {
            var roll = new Random(seed).Next(0, _weightingTotal);

            return _lootItems
                .Single(item => item.LowerRange <= roll && item.UpperRange >= roll)
                .Item;
        }

        private IReadOnlyList<LootWeightRange> CreateWeightedRanges(
            IReadOnlyList<LootItemWeighting> items)
        {
            var runningTotal = 0;
            var list = new List<LootWeightRange>();
            foreach (var lootItemWeighting in items)
            {
                list.Add(new LootWeightRange(
                    item: lootItemWeighting.Item, 
                    lowerRange: runningTotal, 
                    upperRange: runningTotal+lootItemWeighting.DropWeighting-1));
                runningTotal += lootItemWeighting.DropWeighting;
            }

            _weightingTotal = runningTotal-1;
            return list;
        }

        private class LootWeightRange
        {
            public readonly LootItem Item;
            public readonly int LowerRange;
            public readonly int UpperRange;

            public LootWeightRange(LootItem item, int lowerRange, int upperRange)
            {
                Item = item;
                LowerRange = lowerRange;
                UpperRange = upperRange;
            }
        }
    }
}
