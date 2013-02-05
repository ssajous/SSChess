using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSChess.Core.Model.Gameplay
{
    public class Bishop : Piece
    {
        private const int BishopValue = 3;

        protected override int GetValue()
        {
            return BishopValue;
        }
    }
}
