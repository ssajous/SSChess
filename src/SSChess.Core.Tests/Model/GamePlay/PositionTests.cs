﻿using FluentAssertions;
using NUnit.Framework;
using SSChess.Core.Model.Gameplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSChess.Core.Tests.Model.Gameplay
{
    [TestFixture]
    public class PositionTests
    {
        private Position InitializeSut()
        {
            return new Position("a1");
        }

        [Test]
        public void Constructor_String_Coordinate_Creates_Position()
        {
            var sut = new Position("b4");
            sut.Rank.Should().Be(4);
            sut.File.Name.Should().Be('b');
        }

        [Test]
        public void Constructor_Bad_String_Coordinate_Throws_Exception()
        {
            Action action = () => new Position("z10");

            action.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void ToString_Returns_Proper_Coordinate_Code()
        {
            var sut = new Position(6, new BoardFile('d'));
            sut.ToString().Should().Be("d6");
        }

        [Test]
        public void GetAdjacentPostions_Bottom_Left_Corner_Square_Has_Three_Adjacent()
        {
            var sut = new Position("a1");
            var result = sut.GetAdjacentPositions();
            result.Count.Should().Be(3);
        }

        [Test]
        public void GetAdjacentPostions_Bottom_Right_Corner_Square_Has_Three_Adjacent()
        {
            var sut = new Position("h1");
            var result = sut.GetAdjacentPositions();
            result.Count.Should().Be(3);
        }

        [Test]
        public void GetAdjacentPostions_Top_Left_Corner_Square_Has_Three_Adjacent()
        {
            var sut = new Position("a8");
            var result = sut.GetAdjacentPositions();
            result.Count.Should().Be(3);
        }

        [Test]
        public void GetAdjacentPostions_Top_Right_Corner_Square_Has_Three_Adjacent()
        {
            var sut = new Position("h8");
            var result = sut.GetAdjacentPositions();
            result.Count.Should().Be(3);
        }

        [Test]
        public void GetAdjacentPositions_Central_Square_Has_Eight_Adjacent()
        {
            var sut = new Position("d4");
            var result = sut.GetAdjacentPositions();
            result.Count.Should().Be(8);
        }

        [Test]
        public void GetAdjacentPositions_Central_Square_Finds_Correct_Squares()
        {
            var sut = new Position("d4");
            var result = sut.GetAdjacentPositions();

            var actual = result.Select(pos => pos.ToString());
            actual.Should().Contain("d3");
            actual.Should().Contain("d5");
            actual.Should().Contain("c3");
            actual.Should().Contain("c4");
            actual.Should().Contain("c5");
            actual.Should().Contain("e3");
            actual.Should().Contain("e4");
            actual.Should().Contain("e5");
        }

        [Test]
        public void GetAdjacentPositions_Top_Left_Finds_Correct_Squares()
        {
            var sut = new Position("a8");
            var result = sut.GetAdjacentPositions();

            var actual = result.Select(pos => pos.ToString());
            actual.Should().Contain("a7");
            actual.Should().Contain("b7");
            actual.Should().Contain("b8");
        }

        [Test]
        public void GetAdjacentPositions_Bottom_Right_Finds_Correct_Squares()
        {
            var sut = new Position("h1");
            var result = sut.GetAdjacentPositions();

            var actual = result.Select(pos => pos.ToString());
            actual.Should().Contain("h2");
            actual.Should().Contain("g1");
            actual.Should().Contain("g2");
        }

        [Test]
        public void GetAdjacentPositions_Top_Right_Finds_Correct_Squares()
        {
            var sut = new Position("h8");
            var result = sut.GetAdjacentPositions();

            var actual = result.Select(pos => pos.ToString());
            actual.Should().Contain("h7");
            actual.Should().Contain("g7");
            actual.Should().Contain("g8");
        }

        [Test]
        public void GetAdjacentPositions_Bottom_Left_Finds_Correct_Squares()
        {
            var sut = new Position("a1");
            var result = sut.GetAdjacentPositions();

            var actual = result.Select(pos => pos.ToString());
            actual.Should().Contain("a2");
            actual.Should().Contain("b1");
            actual.Should().Contain("b2");
        }

        [Test]
        public void GetCurrentRankPositions_Finds_Eight_Squares()
        {
            var sut = InitializeSut();
            for (int i = Position.MinRank; i <= Position.MaxRank; i++)
            {
                sut.Rank = i;
                var result = sut.GetCurrentRankPositions();
                result.Count.Should().Be(8);
            }
        }

        [Test]
        public void GetCurrentFilePositions_Finds_Eight_Squares()
        {
            var sut = InitializeSut();
            for (int i = BoardFile.MinIndex; i <= BoardFile.MaxIndex; i++)
            {
                BoardFile file = new BoardFile(i);
                sut.File = file;
                var result = sut.GetCurrentFilePositions();
                result.Count.Should().Be(8);
            }
        }

        [Test]
        public void SquareColor_A1_Returns_Black()
        {
            var sut = new Position("a1");

            ChessColor result = sut.SquareColor;
            result.Should().Be(ChessColor.Black);
        }

        [Test]
        public void SquareColor_H1_Returns_White()
        {
            var sut = new Position("h1");

            ChessColor result = sut.SquareColor;
            result.Should().Be(ChessColor.White);
        }

        [Test]
        public void SquareColor_H8_Returns_Black()
        {
            var sut = new Position("h8");

            ChessColor result = sut.SquareColor;
            result.Should().Be(ChessColor.Black);
        }

        [Test]
        public void GetCurrentDiagonalPositions_Central_White_Returns_Correct_Squares()
        {
            var sut = new Position("d5");
            List<Position> result = sut.GetCurrentDiagonalPositions();

            var actual = result.Select(pos => pos.ToString());
            actual.Should().Contain("a2");
            actual.Should().Contain("b3");
            actual.Should().Contain("c4");
            actual.Should().Contain("d5");
            actual.Should().Contain("e6");
            actual.Should().Contain("f7");
            actual.Should().Contain("g8");
        }

        [Test]
        public void GetCurrentDiagonalPositions_Central_Black_Returns_Correct_Squares()
        {
            var sut = new Position("e5");
            List<Position> result = sut.GetCurrentDiagonalPositions();

            var actual = result.Select(pos => pos.ToString());
            actual.Should().Contain("a1");
            actual.Should().Contain("b2");
            actual.Should().Contain("c3");
            actual.Should().Contain("d4");
            actual.Should().Contain("e5");
            actual.Should().Contain("f6");
            actual.Should().Contain("g7");
            actual.Should().Contain("h8");
        }

        [Test]
        public void GetCurrentDiagonalPositions_Edge_White_Returns_Correct_Squares()
        {
            var sut = new Position("a4");
            List<Position> result = sut.GetCurrentDiagonalPositions();

            var actual = result.Select(pos => pos.ToString());
            actual.Should().Contain("a4");
            actual.Should().Contain("b3");
            actual.Should().Contain("c2");
            actual.Should().Contain("d1");
        }

        [Test]
        public void GetCurrentDiagonalPositions_Edge_Black_Returns_Correct_Squares()
        {
            var sut = new Position("g7");
            List<Position> result = sut.GetCurrentDiagonalPositions();

            var actual = result.Select(pos => pos.ToString());
            actual.Should().Contain("f8");
            actual.Should().Contain("g7");
            actual.Should().Contain("h6");
        }


        [Test]
        public void SquareColor_E4_Returns_White()
        {
            var sut = new Position("e4");

            ChessColor result = sut.SquareColor;
            result.Should().Be(ChessColor.White);
        }

        [Test]
        public void GetLMovePositions_Center_Returns_Correct_Squares()
        {
            var sut = new Position("e4");
            List<Position> result = sut.GetLMovePositions();
            var actual = result.Select(pos => pos.ToString());

            actual.Count().Should().Be(8);
            actual.Should().Contain("g3");
            actual.Should().Contain("f2");
            actual.Should().Contain("d2");
            actual.Should().Contain("c3");
            actual.Should().Contain("c5");
            actual.Should().Contain("d6");
            actual.Should().Contain("f6");
            actual.Should().Contain("g5");
        }

        [Test]
        public void GetLMovePositions_Bottom_Left_Returns_Correct_Squares()
        {
            var sut = new Position("a1");
            var result = sut.GetLMovePositions();
            var actual = result.Select(pos => pos.ToString());

            actual.Count().Should().Be(2);
            actual.Should().Contain("b3");
            actual.Should().Contain("c2");
        }

        [Test]
        public void GetLMovePositions_Bottom_Right_Returns_Correct_Squares()
        {
            var sut = new Position("h1");
            var result = sut.GetLMovePositions();
            var actual = result.Select(pos => pos.ToString());

            actual.Count().Should().Be(2);
            actual.Should().Contain("f2");
            actual.Should().Contain("g3");
        }

        [Test]
        public void GetLMovePositions_Top_Left_Returns_Correct_Squares()
        {
            var sut = new Position("a8");
            var result = sut.GetLMovePositions();
            var actual = result.Select(pos => pos.ToString());

            actual.Count().Should().Be(2);
            actual.Should().Contain("b6");
            actual.Should().Contain("c7");
        }

        [Test]
        public void GetLMovePositions_Top_Right_Returns_Correct_Squares()
        {
            var sut = new Position("h8");
            var result = sut.GetLMovePositions();
            var actual = result.Select(pos => pos.ToString());

            actual.Count().Should().Be(2);
            actual.Should().Contain("g6");
            actual.Should().Contain("f7");
        }

        [Test]
        public void Equals_Two_Positions_Same_Rank_And_File_Should_Be_Equal()
        {
            var sut = InitializeSut();
            var compare = new Position("a1");

            sut.Equals(compare).Should().BeTrue();
        }

        [Test]
        public void Equals_Two_Positions_Different_Rank_Same_File_Should_Not_Be_Equal()
        {
            var sut = InitializeSut();
            var compare = new Position("a2");

            sut.Equals(compare).Should().BeFalse();
        }

        [Test]
        public void Equals_Two_Positions_Same_Rank_Different_File_Should_Not_Be_Equal()
        {
            var sut = InitializeSut();
            var compare = new Position("d1");

            sut.Equals(compare).Should().BeFalse();
        }

        [Test]
        public void Equals_Two_Positions_Different_Rank_And_File_Should_Not_Be_Equal()
        {
            var sut = InitializeSut();
            var compare = new Position("d5");

            sut.Equals(compare).Should().BeFalse();
        }

        [Test]
        public void Equals_Non_Position_Object_Should_Be_False()
        {
            var sut = InitializeSut();

            sut.Equals(20).Should().BeFalse();
        }

        [Test]
        public void GetHashCode_Should_Be_Same_As_Coordinate_HashCode()
        {
            var sut = InitializeSut();
            sut.Rank = 1;
            sut.File = new BoardFile('a');

            sut.GetHashCode().Should().Be("a1".GetHashCode());
        }

        [Test]
        public void DistanceFrom_Adjacent_Same_File_Should_Be_1()
        {
            var sut = InitializeSut();
            sut.Rank = 1;
            sut.File = new BoardFile('a');
            var target = new Position("a2");

            var result = sut.DistanceFrom(target);
            result.Should().Be(1);
        }

        [Test]
        public void DistanceFrom_Adjacent_Same_Rank_Should_Be_1()
        {
            var sut = InitializeSut();
            sut.Rank = 1;
            sut.File = new BoardFile('a');
            var target = new Position("b1");

            var result = sut.DistanceFrom(target);
            result.Should().Be(1);
        }

        [Test]
        public void DistanceFrom_Adjacent_On_Diagonal_Should_Be_1()
        {
            var sut = InitializeSut();
            sut.Rank = 1;
            sut.File = new BoardFile('a');
            var target = new Position("b2");

            var result = sut.DistanceFrom(target);
            result.Should().Be(1);
        }

        [Test]
        public void DistanceFrom_Far_Side_Same_File_Should_Be_7()
        {
            var sut = InitializeSut();
            sut.Rank = 1;
            sut.File = new BoardFile('a');
            var target = new Position("a8");

            var result = sut.DistanceFrom(target);
            result.Should().Be(7);
        }

        [Test]
        public void DistanceFrom_Far_Side_Same_Rank_Should_Be_7()
        {
            var sut = InitializeSut();
            sut.Rank = 1;
            sut.File = new BoardFile('a');
            var target = new Position("h1");

            var result = sut.DistanceFrom(target);
            result.Should().Be(7);
        }

        [Test]
        public void DistanceFrom_Far_Side_Diagonal_Should_Be_7()
        {
            var sut = InitializeSut();
            sut.Rank = 1;
            sut.File = new BoardFile('a');
            var target = new Position("h8");

            var result = sut.DistanceFrom(target);
            result.Should().Be(7);
        }
    }
}
