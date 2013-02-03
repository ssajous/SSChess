using FluentAssertions;
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
        public void ToString_Returns_Proper_Coordinate_Code()
        {
            var sut = new Position(6, new BoardFile('d'));
            sut.ToString().Should().Be("d6");
        }

        [Test]
        public void AdjacentPostions_Bottom_Left_Corner_Square_Has_Three_Adjacent()
        {
            Assert.Fail();
        }

        [Test]
        public void AdjacentPostions_Bottom_Right_Corner_Square_Has_Three_Adjacent()
        {
            Assert.Fail();
        }

        [Test]
        public void AdjacentPostions_Top_Left_Corner_Square_Has_Three_Adjacent()
        {
            Assert.Fail();
        }

        [Test]
        public void AdjacentPostions_Top_Right_Corner_Square_Has_Three_Adjacent()
        {
            Assert.Fail();
        }

        [Test]
        public void AdjacentPositions_Central_Square_Has_Eight_Adjacent()
        {
            Assert.Fail();
        }

        [Test]
        public void AdjacentPositions_Finds_Correct_Squares()
        {
            Assert.Fail();
        }

        [Test]
        public void CurrentRankPositions_Finds_Eight_Squares()
        {
            var sut = InitializeSut();
            for (int i = Position.MinRank; i <= Position.MaxRank; i++)
            {
                sut.Rank = i;
                var result = sut.CurrentRankPositions();
                result.Count.Should().Be(8);
            }
        }

        [Test]
        public void CurrentFilePositions_Finds_Eight_Squares()
        {
            var sut = InitializeSut();
            for (int i = BoardFile.MinIndex; i <= BoardFile.MaxIndex; i++)
            {
                BoardFile file = new BoardFile(i);
                sut.File = file;
                var result = sut.CurrentFilePositions();
                result.Count.Should().Be(8);
            }
        }
    }
}
