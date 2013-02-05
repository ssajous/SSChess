using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSChess.Core.Model.Gameplay
{
    public class Pawn : Piece
    {
        private const int PawnValue = 1;


        protected override int GetValue()
        {
            return PawnValue;
        }
    }
}
