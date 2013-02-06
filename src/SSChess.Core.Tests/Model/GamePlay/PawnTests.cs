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
    }
}
