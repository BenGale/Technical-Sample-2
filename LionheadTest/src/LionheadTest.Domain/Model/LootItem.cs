namespace LionheadTest.Domain.Model
{
    public class LootItem
    {
        public readonly string Identifier;
        public readonly string Name;

        public LootItem(string identifier, string name)
        {
            Identifier = identifier;
            Name = name;
        }
    }
}