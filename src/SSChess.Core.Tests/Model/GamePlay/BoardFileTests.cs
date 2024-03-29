﻿using NUnit.Framework;
using SSChess.Core.Model.Gameplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace SSChess.Core.Tests.Model.Gameplay
{
    [TestFixture]
    public class BoardFileTests
    {

        private BoardFile InitializeSut()
        {
            return new BoardFile(1);
        }

        [Test, Category("Constructor")]
        public void Constructor_Above_Range_File_Letter_Throws_Exception()
        {
            char badFile = 'k';

            Action action = () => new BoardFile(badFile);

            action.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test, Category("Constructor")]
        public void Constructor_Above_Range_File_Index_Throws_Exception()
        {
            int badFile = 11;

            Action action = () => new BoardFile(badFile);

            action.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test, Category("Constructor")]
        public void Constructor_Below_Range_File_Letter_Throws_Exception()
        {
            char badFile = 'A'; // capital is no good

            Action action = () => new BoardFile(badFile);

            action.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test, Category("Constructor")]
        public void Constructor_Below_Range_File_Index_Throws_Exception()
        {
            int badFile = -1;

            Action action = () => new BoardFile(badFile);

            action.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test, Category("Constructor")]
        public void Constructor_Good_File_Letter_Creates_File()
        {
            char name = 'c';

            var sut = new BoardFile(name);

            sut.Should().NotBeNull();
        }

        [Test, Category("Constructor")]
        public void Constructor_Good_File_Index_Creates_File()
        {
            int index = 0;

            for (index = 1; index < 9; index++)
            {
                var sut = new BoardFile(index);
                sut.Should().NotBeNull();
            }
        }

        [Test]
        public void Name_Below_Range_Throws_Exception()
        {
            char name = 'A'; //capitals are bad

            var sut = InitializeSut();
            Action action = () => sut.Name = name;

            action.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void Name_Above_Range_Throws_Exception()
        {
            char name = 'l'; //capitals are bad

            var sut = InitializeSut();
            Action action = () => sut.Name = name;

            action.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void Index_Below_Range_Throws_Exception()
        {
            int index = -1; 

            var sut = InitializeSut();
            Action action = () => sut.Index = index;

            action.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void Index_Above_Range_Throws_Exception()
        {
            int index = 9;

            var sut = InitializeSut();
            Action action = () => sut.Index = index;

            action.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void Index_In_Range_Sets_File()
        {
            int index = 0;
            var sut = InitializeSut();

            for (index = 1; index < 9; index++)
            {
                sut.Index = index;
                sut.Index.Should().Be(index);
            }
        }

        [Test]
        public void Name_In_Range_Sets_File()
        {
            char name = 'a';
            var sut = InitializeSut();

            for (name = 'a'; name < 'i'; name++)
            {
                sut.Name = name;
                sut.Name.Should().Be(name);
            }
        }

        [Test]
        public void Index_Set_Sets_Name()
        {
            char name = 'a';
            var sut = InitializeSut();
            for (int index = 1; index < 9; index++)
            {
                sut.Index = index;
                sut.Name.Should().Be(name);
                name++;
            }
        }

        [Test]
        public void Name_Set_Sets_Index()
        {
            int index = 1;
            var sut = InitializeSut();
            for (char name = 'a'; name < 'i'; name++)
            {
                sut.Name = name;
                sut.Index.Should().Be(index);
                index++;
            }
        }

        [Test]
        public void NextFile_Returns_Next_File()
        {
            var sut = new BoardFile('a');
            BoardFile result = sut.NextFile();
            result.Name.Should().Be('b');
        }

        [Test]
        public void NextFile_Last_File_Returns_Null()
        {
            var sut = new BoardFile('h');
            BoardFile result = sut.NextFile();
            result.Should().BeNull();
        }

        [Test]
        public void PreviousFile_Returns_Previous_File()
        {
            var sut = new BoardFile('h');
            BoardFile result = sut.PreviousFile();
            result.Name.Should().Be('g');
        }

        [Test]
        public void PreviousFile_First_File_Returns_Null()
        {
            var sut = new BoardFile('a');
            var result = sut.PreviousFile();
            result.Should().BeNull();
        }
    }
}
