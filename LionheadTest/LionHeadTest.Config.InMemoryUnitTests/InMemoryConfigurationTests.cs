using FluentAssertions;
using LionheadTest.Config.InMemory;
using LionheadTest.Domain.Model;
using NUnit.Framework;

namespace LionHeadTest.Config.InMemoryUnitTests
{
    [TestFixture]
    public class InMemoryConfigurationTests
    {
        private InMemoryConfiguration _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new InMemoryConfiguration();
        }

        [Test]
        public void AddItem()
        {
            var newItem = new LootItem("6", "Funny Hat");
            _sut.GetWeightings().Should().HaveCount(0);
            _sut.AddItem(newItem, 50);
            _sut.GetWeightings().Should().HaveCount(1);
        }

        [Test]
        public void RemoveItem()
        {
            var newItem = new LootItem("6", "Funny Hat");
            _sut.AddItem(newItem, 50);
            _sut.GetWeightings().Should().HaveCount(1);
            _sut.RemoveItem("6");
            _sut.GetWeightings().Should().HaveCount(0);
        }
    }
}
