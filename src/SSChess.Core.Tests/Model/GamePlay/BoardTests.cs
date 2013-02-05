using NUnit.Framework;
using SSChess.Core.Model.GamePlay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace SSChess.Core.Tests
{
    [TestFixture]
    public class BoardTests
    {
        [Test]
        public void Constructor_Initializes_Squares()
        {
            var sut = new Board();

            sut.Squares.Should().NotBeNull();
        }

        [Test]
        public void Constructor_Initializes_With_64_Squares()
        {
            var sut = new Board();

            sut.Squares.Count.Should().Be(64);
        }
    }
}
