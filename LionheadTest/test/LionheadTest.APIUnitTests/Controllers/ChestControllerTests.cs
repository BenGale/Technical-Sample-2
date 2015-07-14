using System;
using FluentAssertions;
using LionheadTest.API.Controllers;
using LionheadTest.Domain;
using LionheadTest.Domain.Model;
using Moq;
using NUnit.Framework;

namespace LionheadTest.APIUnitTests.Controllers
{
    [TestFixture]
    public class ChestControllerTests
    {
        private Mock<ILootTable> _lootTableMock;
        private ChestController _sut;

        [SetUp]
        public void Setup()
        {
            _lootTableMock = new Mock<ILootTable>();
            _lootTableMock.Setup(m => m.Roll(It.IsAny<int>()))
                .Returns(new LootItem("1", "Special Hat"));
            _sut = new ChestController(_lootTableMock.Object);
        }

        [Test]
        public void GetReturnsViewModel()
        {
            var result = _sut.Get(new Guid());
            result.Identifier.Should().Be("01");
            result.Name.Should().Be("Special Hat");
        }
    }
}
