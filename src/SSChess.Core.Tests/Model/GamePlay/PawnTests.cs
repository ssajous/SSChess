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
    public class PawnTests
    {
        private Pawn InitializeSut()
        {
            return new Pawn();
        }

        [Test]
        public void Value_Should_Be_1()
        {
            var sut = InitializeSut();
            sut.Value.Should().Be(1);
        }

        [Test, Category("AvailableMoves")]
        public void AvailableMoves_White_Pawn_Not_In_Start_Position_Should_Be_Up_One_Rank()
        {
            var sut = InitializeSut();
            sut.Color = ChessColor.White;

            Board board = new Board();
            board.AddPiece(sut, "c3");

            var result = sut.AvailableMoves;

            result.Count().Should().Be(1);
            result.First().EndPosition.ToString().Should().Be("c4");
        }

        [Test, Category("AvailableMoves")]
        public void AvailableMoves_White_Pawn_In_Start_Position_Should_Be_Up_1_Or_2_Ranks()
        {
            var sut = InitializeSut();
            sut.Color = ChessColor.White;

            Board board = new Board();
            board.AddPiece(sut, "c2");

            var result = sut.AvailableMoves;

            result.Count().Should().Be(2);
            result.Where(move => move.EndPosition.ToString() == "c3").Should().NotBeEmpty();
            result.Where(move => move.EndPosition.ToString() == "c4").Should().NotBeEmpty();
        }

        [Test, Category("AvailableMoves")]
        public void AvailableMoves_White_Pawn_Should_Detect_Standard_Right_Side_Capture()
        {
            var sut = InitializeSut();
            sut.Color = ChessColor.White;

            var victim = new Pawn
            {
                Color = ChessColor.Black
            };

            Board board = new Board();
            board.AddPiece(sut, "c3");
            board.AddPiece(victim, "d4");

            var result = sut.AvailableMoves;

            result.Where(move => move.EndPosition.ToString() == "d4").Should().NotBeEmpty();
        }

        [Test, Category("AvailableMoves")]
        public void AvailableMoves_White_Pawn_Should_Detect_Standard_Left_Side_Capture()
        {
            var sut = InitializeSut();
            sut.Color = ChessColor.White;

            var victim = new Pawn
            {
                Color = ChessColor.Black
            };

            Board board = new Board();
            board.AddPiece(sut, "c3");
            board.AddPiece(victim, "b4");

            var result = sut.AvailableMoves;

            result.Where(move => move.EndPosition.ToString() == "b4").Should().NotBeEmpty();
        }

        [Test, Category("AvailableMoves")]
        public void AvailableMoves_White_Blocked_Pawn_Should_Have_No_Moves()
        {
            var sut = InitializeSut();
            sut.Color = ChessColor.White;

            var blocker = new Pawn
            {
                Color = ChessColor.Black
            };

            Board board = new Board();
            board.AddPiece(sut, "c3");
            board.AddPiece(blocker, "c4");

            var result = sut.AvailableMoves;

            result.Should().BeEmpty();
        }

        [Test, Category("AvailableMoves")]
        public void AvailableMoves_Black_Pawn_Not_In_Start_Position_Should_Be_Down_One_Rank()
        {
            var sut = InitializeSut();
            sut.Color = ChessColor.Black;

            Board board = new Board();
            board.AddPiece(sut, "c5");

            var result = sut.AvailableMoves;

            result.Count().Should().Be(1);
            result.First().EndPosition.ToString().Should().Be("c4");
        }

        [Test, Category("AvailableMoves")]
        public void AvailableMoves_Black_Pawn_In_Start_Position_Should_Be_Down_1_Or_2_Ranks()
        {
            var sut = InitializeSut();
            sut.Color = ChessColor.Black;

            Board board = new Board();
            board.AddPiece(sut, "c7");

            var result = sut.AvailableMoves;

            result.Count().Should().Be(2);
            result.Where(move => move.EndPosition.ToString() == "c5").Should().NotBeEmpty();
            result.Where(move => move.EndPosition.ToString() == "c6").Should().NotBeEmpty();
        }

        [Test, Category("AvailableMoves")]
        public void AvailableMoves_Black_Pawn_Should_Detect_Standard_Right_Side_Capture()
        {
            var sut = InitializeSut();
            sut.Color = ChessColor.Black;

            var victim = new Pawn
            {
                Color = ChessColor.Black
            };

            Board board = new Board();
            board.AddPiece(sut, "c5");
            board.AddPiece(victim, "d4");

            var result = sut.AvailableMoves;

            result.Where(move => move.EndPosition.ToString() == "d4").Should().NotBeEmpty();
        }

        [Test, Category("AvailableMoves")]
        public void AvailableMoves_Black_Pawn_Should_Detect_Standard_Left_Side_Capture()
        {
            var sut = InitializeSut();
            sut.Color = ChessColor.Black;

            var victim = new Pawn
            {
                Color = ChessColor.Black
            };

            Board board = new Board();
            board.AddPiece(sut, "c5");
            board.AddPiece(victim, "b4");

            var result = sut.AvailableMoves;

            result.Where(move => move.EndPosition.ToString() == "b4").Should().NotBeEmpty();
        }

        [Test, Category("AvailableMoves")]
        public void AvailableMoves_Black_Blocked_Pawn_Should_Have_No_Moves()
        {
            var sut = InitializeSut();
            sut.Color = ChessColor.Black;

            var blocker = new Pawn
            {
                Color = ChessColor.White
            };

            Board board = new Board();
            board.AddPiece(sut, "c5");
            board.AddPiece(blocker, "c4");

            var result = sut.AvailableMoves;

            result.Should().BeEmpty();
        }






    }
}
