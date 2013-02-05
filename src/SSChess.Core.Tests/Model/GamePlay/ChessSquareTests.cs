using NUnit.Framework;
using SSChess.Core.Model.Gameplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace SSChess.Core.Tests.Model.Gameplay
{
    [TestFixture]
    public class ChessSquareTests
    {
        private ChessSquare InitializeSut()
        {
            return new ChessSquare();
        }

        [Test]
        public void IsOccupied_Null_Piece_Should_Be_False()
        {
            var sut = InitializeSut();
            sut.OccupyingPiece = null;

            sut.IsOccupied.Should().BeFalse();
        }

        [Test]
        public void IsOccupied_Not_Null_Piece_Should_Be_True()
        {
            var sut = InitializeSut();
            sut.OccupyingPiece = new King();

            sut.IsOccupied.Should().BeTrue();
        }
    }
}
