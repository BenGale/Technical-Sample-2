using System;
using FluentAssertions;
using LionheadTest.API.Controllers;
using LionheadTest.Domain;
using LionheadTest.Domain.Logging;
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
        private Mock<ILogger> _loggerMock;

        [SetUp]
        public void Setup()
        {
            _lootTableMock = new Mock<ILootTable>();
            _lootTableMock.Setup(m => m.Roll(It.IsAny<int>()))
                .Returns(new LootItem("1", "Special Hat"));
            _loggerMock = new Mock<ILogger>();
            _sut = new ChestController(_lootTableMock.Object, _loggerMock.Object);
        }

        [Test]
        public void GetReturnsViewModel()
        {
            var result = _sut.Get("Ben", new Guid());
            result.Identifier.Should().Be("01");
            result.Name.Should().Be("Special Hat");
        }

        [Test]
        public void GetLogsItemReceived()
        {
            _sut.Get("Ben", new Guid());
            _loggerMock.Verify(m => m.Log("Player: Ben, Received: 01 Special Hat"));
        }
    }
}
