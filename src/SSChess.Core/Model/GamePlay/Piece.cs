using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSChess.Core.Model.GamePlay
{
    public abstract class Piece
    {
        public ChessColor Color { get; set; }
        public Position Square { get; set; }
        public bool IsCaptured { get; set; }
        public Board Board { get; set; }
        public int Value
        {
            get
            {
                return GetValue();
            }
        }

        protected abstract int GetValue();
    }
}
