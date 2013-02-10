using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;
using SSChess.Core.Model.Gameplay;

namespace SSChess.Core.Tests.Model.Gameplay
{
    [TestFixture]
    public class RookTests
    {
        private Rook InitializeSut()
        {
            return new Rook();
        }

        [Test]
        public void Value_Should_Be_5()
        {
            var sut = InitializeSut();
            sut.Value.Should().Be(5);
        }

        [Test]
        public void AvailableMoves_In_Center_Should_Have_14_Moves()
        {
            var sut = InitializeSut();
            sut.Color = ChessColor.White;
            var board = new Board();

            board.AddPiece(sut, "d4");
            var result = sut.AvailableMoves;

            result.Count().Should().Be(14);
        }

        [Test]
        public void AvailableMoves_Surrounded_By_Same_Color_Should_Have_No_Moves()
        {
            var board = new Board();
            board.SetupStartingPieces();

            var sut = board.Pieces.Where(piece => piece.Color == ChessColor.White && piece.GetType() == typeof(Rook)).FirstOrDefault();
            var result = sut.AvailableMoves;

            result.Should().BeEmpty();
        }

        [Test]
        public void AvailableMoves_File_Should_Be_Open_Until_Capture()
        {
            var board = new Board();
            var victim = new Pawn { Color = ChessColor.Black };
            var sut = InitializeSut();
            sut.Color = ChessColor.White;

            board.AddPiece(victim, "a5");
            board.AddPiece(sut, "a1");

            var result = sut.AvailableMoves;
            var endPositions = result.Select(move => move.EndPosition.ToString());
            List<string> expectedMoves = new List<string> { "a2", "a3", "a4", "a5" };
            List<string> notAllowedMoves = new List<string> { "a6", "a7", "a8" };

            endPositions.Should().Contain(expectedMoves);
            endPositions.Should().NotContain(notAllowedMoves);
        }

        [Test]
        public void AvailableMoves_Rank_Should_Be_Open_Until_Capture()
        {
            var board = new Board();
            var victim = new Pawn { Color = ChessColor.Black };
            var sut = InitializeSut();
            sut.Color = ChessColor.White;

            board.AddPiece(victim, "d1");
            board.AddPiece(sut, "a1");

            var result = sut.AvailableMoves;
            var endPositions = result.Select(move => move.EndPosition.ToString());
            List<string> expectedMoves = new List<string> { "b1", "c1", "d1" };
            List<string> notAllowedMoves = new List<string> { "e1", "f1", "g1", "h1" };

            endPositions.Should().Contain(expectedMoves);
            endPositions.Should().NotContain(notAllowedMoves);
        }
    }
}