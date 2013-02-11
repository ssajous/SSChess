using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSChess.Core.Model.Gameplay
{
    public class Bishop : SlideMovingPiece
    {
        private const int BishopValue = 3;

        protected override int GetValue()
        {
            return BishopValue;
        }

        protected override IEnumerable<Move> GetAvailableMoves()
        {
            List<Move> moves = base.AddDiagonalSlidingMoves();

            return moves.AsEnumerable();
        }
    }
}