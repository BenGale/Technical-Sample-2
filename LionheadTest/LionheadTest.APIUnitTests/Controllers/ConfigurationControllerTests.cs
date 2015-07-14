using System.Collections.Generic;
using System.Web.Http.Results;
using FluentAssertions;
using LionheadTest.API.Controllers;
using LionheadTest.Domain.Configuration;
using LionheadTest.Domain.Model;
using Moq;
using NUnit.Framework;

namespace LionheadTest.APIUnitTests.Controllers
{
    [TestFixture]
    public class ConfigurationControllerTests
    {
        private ConfigurationController _sut;
        private Mock<ILootTableConfig> _configurationMock;

        [SetUp]
        public void Setup()
        {
            var itemsList = new List<LootItemWeighting>
            {
                new LootItemWeighting(new LootItem("1", "Sword"), 10),
                new LootItemWeighting(new LootItem("2", "Shield"), 10),
                new LootItemWeighting(new LootItem("3", "Health Potion"), 30),
                new LootItemWeighting(new LootItem("4", "Resurrection Phial"), 30),
                new LootItemWeighting(new LootItem("5", "Scroll of Wisdom"), 20)
            };
            _configurationMock = new Mock<ILootTableConfig>();
            _configurationMock.Setup(m => m.GetWeightings())
                .Returns(itemsList);
            _configurationMock.Setup(m => m.AddItem(It.IsAny<LootItem>(), It.IsAny<int>()));

            _sut = new ConfigurationController(_configurationMock.Object);
        }

        [Test]
        public void Get_ProvidesCurrentConfiguration()
        {
            var result = _sut.Get();
            result.Should().HaveCount(5);
        }

        [Test]
        public void Post_AddsNewItem()
        {
            var result = _sut.Post(new LootItem("6", "Funny Hat"), 50);
            result.Should().BeOfType<OkResult>();
        }
    }
}
