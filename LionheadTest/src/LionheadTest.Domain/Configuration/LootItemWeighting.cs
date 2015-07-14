using System;
using LionheadTest.Domain.Model;

namespace LionheadTest.Domain.Configuration
{
    [Serializable]
    public class LootItemWeighting
    {
        public readonly LootItem Item;
        public readonly int DropWeighting;

        public LootItemWeighting(LootItem item, int dropWeighting)
        {
            Item = item;
            DropWeighting = dropWeighting;
        }
    }
}
