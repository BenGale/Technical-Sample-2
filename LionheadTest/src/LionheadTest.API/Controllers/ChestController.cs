using System;
using System.Web.Http;
using LionheadTest.API.ViewModel;
using LionheadTest.Domain;

namespace LionheadTest.API.Controllers
{
    [RoutePrefix("api/chest")]
    public class ChestController : ApiController
    {
        private readonly ILootTable _lootTable;

        public ChestController(ILootTable lootTable)
        {
            _lootTable = lootTable;
        }

        [Route("{chestIdentifier}")]
        [HttpGet]
        public ChestItemViewModel Get(Guid chestIdentifier)
        {
            // I want to return an item with a deterministic id from the chest
            // so that each player gets the same item, and a returning player
            // cannot loot more than one item from the chest.
            // Different chests will drop different items depending on their id.

            var chestHashCode = chestIdentifier.GetHashCode();
            var lootItem = _lootTable.Roll(chestHashCode);
            return new ChestItemViewModel(
                string.Concat(chestHashCode, lootItem.Identifier), lootItem.Name);
        }
    }
}