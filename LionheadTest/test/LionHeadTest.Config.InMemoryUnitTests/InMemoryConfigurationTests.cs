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
            _sut.GetWeightings().Should().HaveCount(5);
            _sut.AddItem(newItem, 50);
            _sut.GetWeightings().Should().HaveCount(6);
        }

        [Test]
        public void RemoveItem()
        {
            _sut.GetWeightings().Should().HaveCount(5);
            _sut.RemoveItem("1");
            _sut.GetWeightings().Should().HaveCount(4);
        }
    }
}
