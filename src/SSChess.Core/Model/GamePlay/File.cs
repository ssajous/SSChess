using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSChess.Core.Model.GamePlay
{
    public class File
    {
        public const int MaxIndex = 8;
        public const int MinIndex = 1;
        public const char MaxName = 'h';
        public const char MinName = 'a';

        public char Name 
        { 
            get; 
            set; 
        }
        public int Index 
        { 
            get; 
            set; 
        }

        public File(int index)
        {

        }

        public File(char name)
        {

        }
    }
}
