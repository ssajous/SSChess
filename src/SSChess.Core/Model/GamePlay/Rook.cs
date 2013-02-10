using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSChess.Core.Model.Gameplay
{
    public class Rook : Piece
    {
        private const int RookValue = 5;

        protected override int GetValue()
        {
            return RookValue;
        }

        protected override IEnumerable<Move> GetAvailableMoves()
        {
            List<Move> moves = new List<Move>();
            List<Position> filePositions = this.Square.GetCurrentFilePositions();
            List<Position> rankPositions = this.Square.GetCurrentRankPositions();

            return moves.AsEnumerable();
        }
    }
}
