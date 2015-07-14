using System;
using System.Collections.Generic;
using FluentAssertions;
using LionheadTest.Domain.Configuration;
using LionheadTest.Domain.Model;
using Moq;
using NUnit.Framework;

namespace LionheadTest.DomainUnitTests.Model
{
    [TestFixture]
    public class LootTableTests
    {
        private LootTable _sut;
        private Mock<ILootTableConfigProvider> _configurationMock;

        [SetUp]
        public void Setup()
        {
            _configurationMock = new Mock<ILootTableConfigProvider>();
            _configurationMock.Setup(m => m.GetWeightings())
                .Returns(new List<LootItemWeighting>
                {
                    new LootItemWeighting(new LootItem("1", "Sword"), 10),
                    new LootItemWeighting(new LootItem("2", "Shield"), 10),
                    new LootItemWeighting(new LootItem("3", "Health Potion"), 30),
                    new LootItemWeighting(new LootItem("4", "Resurrection Phial"), 30),
                    new LootItemWeighting(new LootItem("5", "Scroll of Wisdom"), 20)
                });

            _sut = new LootTable(_configurationMock.Object);
        }

        [Test]
        public void OnCreationLootTableLoadsItemsFromConfig()
        {
            _configurationMock.Verify(m => m.GetWeightings(), Times.Once);
        }

        [Test]
        public void WithSeed_RollIsIdempotent()
        {
            var randomSeed = new Random().Next();
            var firstItem = _sut.Roll(randomSeed);
            for (var i = 0; i < 100; i++)
            {
                var nextItem = _sut.Roll(randomSeed);
                firstItem.Should().Be(nextItem);
            }
        }
    }
}
