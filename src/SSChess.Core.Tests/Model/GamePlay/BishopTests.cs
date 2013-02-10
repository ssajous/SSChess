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
    }
}