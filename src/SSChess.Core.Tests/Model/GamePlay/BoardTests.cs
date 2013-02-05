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
        private Board InitializeSut()
        {
            return new Board();
        }

        [Test]
        public void Constructor_Initializes_Squares()
        {
            var sut = InitializeSut();

            sut.Squares.Should().NotBeNull();
        }

        [Test]
        public void Constructor_Initializes_Pieces()
        {
            var sut = InitializeSut();

            sut.Pieces.Should().NotBeNull();
        }

        [Test]
        public void SetupStartingPieces_Should_Have_32_Pieces()
        {
            var sut = InitializeSut();
            sut.SetupStartingPieces();

            sut.Pieces.Count.Should().Be(32);
        }

        [Test]
        public void Constructor_Initializes_With_64_Squares()
        {
            var sut = InitializeSut();

            sut.Squares.Count.Should().Be(64);
        }
    }
}
