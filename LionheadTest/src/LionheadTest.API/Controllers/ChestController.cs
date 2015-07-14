using System;
using System.Web.Http;
using LionheadTest.API.ViewModel;
using LionheadTest.Domain;
using LionheadTest.Domain.Logging;

namespace LionheadTest.API.Controllers
{
    [RoutePrefix("api/chest")]
    public class ChestController : ApiController
    {
        private readonly ILootTable _lootTable;
        private readonly ILogger _logger;

        public ChestController(ILootTable lootTable, ILogger logger)
        {
            _lootTable = lootTable;
            _logger = logger;
        }

        [Route("{chestIdentifier}")]
        [HttpGet]
        public ChestItemViewModel Get(string playerName, Guid chestIdentifier)
        {
            // I want to return an item with a deterministic id from the chest
            // so that each player gets the same item, and a returning player
            // cannot loot more than one item from the chest.
            // Different chests will drop different items depending on their id.

            var chestHashCode = chestIdentifier.GetHashCode();
            var lootItem = _lootTable.Roll(chestHashCode);
            var vm = new ChestItemViewModel(
                string.Concat(chestHashCode, lootItem.Identifier), lootItem.Name);

            _logger.Log(string.Format(
                "Player: {0}, Received: {1} {2}", playerName, vm.Identifier, vm.Name));

            return vm;
        }
    }
}