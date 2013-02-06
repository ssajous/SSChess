using NUnit.Framework;
using SSChess.Core.Model.Gameplay;
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
        public void SetupStartingPieces_Board_Should_Have_32_Occupied_Squares()
        {
            var sut = InitializeSut();
            sut.SetupStartingPieces();

            var result = sut.Squares.Values.Where(square => square.IsOccupied).Count();

            result.Should().Be(32);
        }

        [Test]
        public void Constructor_Initializes_With_64_Squares()
        {
            var sut = InitializeSut();

            sut.Squares.Count.Should().Be(64);
        }

        [Test]
        public void OccupiedSquares_Two_Pieces_On_Board_Should_Contain_Two_Elements()
        {
            var sut = InitializeSut();
            var piece1 = new Pawn();
            var piece2 = new Pawn();

            sut.AddPiece(piece1, "c1");
            sut.AddPiece(piece2, "c8");

            sut.OccupiedSquares.Count().Should().Be(2);
        }

        [Test]
        public void OccupiedSquares_Two_Pieces_On_Board_Should_Contain_Correct_Squares()
        {
            var sut = InitializeSut();
            var piece1 = new Pawn();
            var piece2 = new Pawn();

            sut.AddPiece(piece1, "c1");
            sut.AddPiece(piece2, "c8");

            var result = sut.OccupiedSquares;
            result.Where(square => square.BoardPosition.ToString() == "c1").Should().NotBeEmpty();
            result.Where(square => square.BoardPosition.ToString() == "c8").Should().NotBeEmpty();
        }

        [Test]
        public void AddPiece_To_Empty_Square_Should_Set_OccupiedPiece()
        {
            var sut = InitializeSut();
            var pawn = new Pawn();

            sut.AddPiece(pawn, "d4");
            sut.Squares["d4"].IsOccupied.Should().BeTrue();
        }

        [Test]
        public void AddPiece_To_Occupied_Squre_Should_Throw_InvalidOperationException()
        {
            string coordinate = "h2";
            var sut = InitializeSut();
            var knight = new Knight();
            var pawn = new Pawn();

            sut.AddPiece(knight, coordinate);
            Action action = () => sut.AddPiece(pawn, coordinate);

            action.ShouldThrow<InvalidOperationException>();
        }
    }
}
