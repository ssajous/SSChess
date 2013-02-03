using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSChess.Core.Model.GamePlay
{
    public class BoardFile
    {
        public const int MaxIndex = 8;
        public const int MinIndex = 1;
        public const char MaxName = 'h';
        public const char MinName = 'a';

        private char _name;
        private int _index;

        public char Name 
        {
            get
            {
                return _name;
            }
            set
            {
                if (value < MinName || value > MaxName)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _name = value;
                TranslateNameToIndex(_name);
            }
        }
        
        public int Index 
        {
            get
            {
                return _index;
            }
            set 
            {
                if (value < MinIndex || value > MaxIndex)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _index = value;
                TranslateIndexToName(Index);
            }
        }

        public BoardFile(int index)
        {
            if (index < MinIndex || index > MaxIndex) throw new ArgumentOutOfRangeException("index");

            Index = index;
        }

        public BoardFile(char name)
        {
            if (name < MinName || name > MaxName) throw new ArgumentOutOfRangeException("name");

            Name = name;
        }

        private void TranslateIndexToName(int index)
        {
            int offset = index - MinIndex;
            char newName = MinName;

            for (int i = 0; i < offset; i++)
            {
                newName++;
            }
            _name = newName;
        }

        private void TranslateNameToIndex(char name)
        {
            int offset = ((int)name) - ((int)MinName);
            _index = MinIndex + offset;
        }


        public BoardFile NextFile()
        {
            BoardFile result = null;

            if (Index < MaxIndex)
            {
                result = new BoardFile(Index + 1);
            }
            return result;
        }

        public BoardFile PreviousFile()
        {
            BoardFile result = null;

            if (Index > MinIndex)
            {
                result = new BoardFile(Index - 1);
            }
            return result;
        }
    }
}
