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
    public class KnightTests
    {
        private Knight InitializeSut()
        {
            return new Knight();
        }

        [Test]
        public void Value_Should_Be_3()
        {
            var sut = InitializeSut();
            sut.Value.Should().Be(3);
        }

        [Test]
        public void Available_Moves_Center_Should_Have_8_Moves()
        {
            var sut = InitializeSut();
            sut.Color = ChessColor.White;
            var board = new Board();

            board.AddPiece(sut, "d4");
            var result = sut.AvailableMoves;

            result.Count().Should().Be(8);
        }

        [Test]
        public void Available_Moves_Bottom_Left_Corner_Should_Have_2_Moves()
        {
            var sut = InitializeSut();
            sut.Color = ChessColor.White;
            var board = new Board();

            board.AddPiece(sut, "a1");
            var result = sut.AvailableMoves;

            result.Count().Should().Be(2);
        }

        [Test]
        public void Available_Moves_Bottom_Right_Corner_Should_Have_2_Moves()
        {
            var sut = InitializeSut();
            sut.Color = ChessColor.White;
            var board = new Board();

            board.AddPiece(sut, "h1");
            var result = sut.AvailableMoves;

            result.Count().Should().Be(2);
        }

        [Test]
        public void Available_Moves_Top_Left_Corner_Should_Have_2_Moves()
        {
            var sut = InitializeSut();
            sut.Color = ChessColor.White;
            var board = new Board();

            board.AddPiece(sut, "a8");
            var result = sut.AvailableMoves;

            result.Count().Should().Be(2);
        }

        [Test]
        public void Available_Moves_Top_Right_Corner_Should_Have_2_Moves()
        {
            var sut = InitializeSut();
            sut.Color = ChessColor.White;
            var board = new Board();

            board.AddPiece(sut, "h8");
            var result = sut.AvailableMoves;

            result.Count().Should().Be(2);
        }

        [Test]
        public void AvailableMoves_White_Knight_Should_Detect_Capture()
        {
            string victimCoordinate = "b5";
            var sut = InitializeSut();
            sut.Color = ChessColor.White;
            var board = new Board();
            var victim = new Pawn();
            victim.Color = ChessColor.Black;

            board.AddPiece(sut, "d4");
            board.AddPiece(victim, victimCoordinate);
            var result = sut.AvailableMoves;

            result.Where(move => move.EndPosition.ToString() == victimCoordinate).Should().NotBeEmpty();
            result.Where(move => move.EndPosition.ToString() == victimCoordinate).FirstOrDefault().CapturedPiece
                .Should().BeSameAs(victim);
        }

        [Test]
        public void AvailbleMoves__White_Knight_Should_Not_Contain_Friendly_Occupied_Squares()
        {
            string friendlyCoordinate = "b5";
            var sut = InitializeSut();
            sut.Color = ChessColor.White;
            var board = new Board();
            var friendly = new Pawn();
            friendly.Color = ChessColor.White;

            board.AddPiece(sut, "d4");
            board.AddPiece(friendly, friendlyCoordinate);
            var result = sut.AvailableMoves;

            result.Where(move => move.EndPosition.ToString() == friendlyCoordinate).Should().BeEmpty();
        }

        [Test]
        public void AvailableMoves_Black_Knight_Should_Detect_Capture()
        {
            string victimCoordinate = "b5";
            var sut = InitializeSut();
            sut.Color = ChessColor.Black;
            var board = new Board();
            var victim = new Pawn();
            victim.Color = ChessColor.White;

            board.AddPiece(sut, "d4");
            board.AddPiece(victim, victimCoordinate);
            var result = sut.AvailableMoves;

            result.Where(move => move.EndPosition.ToString() == victimCoordinate).Should().NotBeEmpty();
            result.Where(move => move.EndPosition.ToString() == victimCoordinate).FirstOrDefault().CapturedPiece
                .Should().BeSameAs(victim);
        }

        [Test]
        public void AvailbleMoves__Black_Knight_Should_Not_Contain_Friendly_Occupied_Squares()
        {
            string friendlyCoordinate = "b5";
            var sut = InitializeSut();
            sut.Color = ChessColor.Black;
            var board = new Board();
            var friendly = new Pawn();
            friendly.Color = ChessColor.Black;

            board.AddPiece(sut, "d4");
            board.AddPiece(friendly, friendlyCoordinate);
            var result = sut.AvailableMoves;

            result.Where(move => move.EndPosition.ToString() == friendlyCoordinate).Should().BeEmpty();
        }

        [Test]
        public void AvailableMoves_Should_Not_Be_Blocked_By_Other_Pieces()
        {
            Assert.Fail();
        }
    }
}