using LionheadTest.Domain.Model;

namespace LionheadTest.Domain
{
    public interface ILootTable
    {
        LootItem Roll(int seed);
    }
}