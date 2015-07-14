using System;

namespace LionheadTest.API.ViewModel
{
    [Serializable]
    public class ChestItemViewModel
    {
        public readonly string Identifier;
        public readonly string Name;

        public ChestItemViewModel(string identifier, string name)
        {
            Identifier = identifier;
            Name = name;
        }
    }
}