using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSChess.Core.Model.Gameplay
{
    public class Queen : SlideMovingPiece
    {
        private const int QueenValue = 9;

        protected override int GetValue()
        {
            return QueenValue;
        }

        protected override IEnumerable<Move> GetAvailableMoves()
        {
            List<Move> moves = new List<Move>();

            moves.AddRange(base.AddFileSlidingMoves());
            moves.AddRange(base.AddRankSlidingMoves());
            moves.AddRange(base.AddDiagonalSlidingMoves());

            return moves.AsEnumerable();
        }
    }
}
