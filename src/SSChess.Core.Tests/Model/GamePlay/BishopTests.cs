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
    public class BishopTests
    {
        private Bishop InitializeSut()
        {
            return new Bishop();
        }

        [Test]
        public void Value_Should_Be_3()
        {
            var sut = InitializeSut();
            sut.Value.Should().Be(3);
        }

        [Test]
        public void AvailableMoves_d4_Biship_Move_Count_Should_Be_13()
        {
            var sut = InitializeSut();
            sut.Color = ChessColor.White;
            var board = new Board();

            board.AddPiece(sut, "d4");

            var result = sut.AvailableMoves;

            result.Count().Should().Be(13);
        }

        [Test]
        public void AvailableMoves_Blocked_By_Same_Color_Should_Have_No_Moves()
        {
            var sut = InitializeSut();
            sut.Color = ChessColor.White;
            var board = new Board();
            var friendly = new Pawn { Color = ChessColor.White };
            board.AddPiece(sut, "a1");
            board.AddPiece(friendly, "b2");

            var result = sut.AvailableMoves;

            result.Should().BeEmpty();
        }

        [Test]
        public void AvailableMoves_Should_Detect_Capture()
        {
            var sut = InitializeSut();
            sut.Color = ChessColor.White;
            var board = new Board();
            var victim = new Pawn { Color = ChessColor.Black };
            board.AddPiece(sut, "a1");
            board.AddPiece(victim, "d4");

            var result = sut.AvailableMoves;

            result.Where(move => move.EndPosition.Equals(victim.Square)).Should().NotBeEmpty();
            result.Where(move => move.EndPosition.Equals(victim.Square)).FirstOrDefault()
                .CapturedPiece.ShouldBeEquivalentTo(victim);
        }

        [Test]
        public void AvailableMoves_Available_Capture_Should_Stop_Additional_Progress()
        {
            var sut = InitializeSut();
            sut.Color = ChessColor.White;
            var board = new Board();
            var victim = new Pawn { Color = ChessColor.Black };
            board.AddPiece(sut, "a1");
            board.AddPiece(victim, "d4");
            List<string> exclude = new List<string> { "e5", "f6", "g7", "h8" };

            var result = sut.AvailableMoves;

            result.Select(move => move.EndPosition.ToString()).Should().NotContain(exclude);
        }
    }
}