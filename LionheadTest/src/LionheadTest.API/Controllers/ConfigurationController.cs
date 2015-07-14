using System.Collections.Generic;
using System.Web.Http;
using LionheadTest.Domain.Configuration;
using LionheadTest.Domain.Model;

namespace LionheadTest.API.Controllers
{
    [RoutePrefix("api/configuration")]
    public class ConfigurationController : ApiController
    {
        private readonly ILootTableConfig _lootTableConfig;

        public ConfigurationController(ILootTableConfig lootTableConfig)
        {
            _lootTableConfig = lootTableConfig;
        }

        [Route("")]
        [HttpGet]
        public IReadOnlyList<LootItemWeighting> Get()
        {
            return _lootTableConfig.GetWeightings();
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Post(LootItem lootItem, int dropWeighting)
        {
            _lootTableConfig.AddItem(lootItem, dropWeighting);
            return Ok();
        }

        [Route("{itemIdentifier}")]
        [HttpDelete]
        public IHttpActionResult Delete(string itemIdentifier)
        {
           _lootTableConfig.RemoveItem(itemIdentifier);
            return Ok();
        }
    }
}