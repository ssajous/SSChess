﻿using FluentAssertions;
using NUnit.Framework;
using SSChess.Core.Model.GamePlay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSChess.Core.Tests.Model.GamePlay
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
            result.Count.Should().Be(3);
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
    }
}
