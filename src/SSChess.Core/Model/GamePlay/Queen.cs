using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSChess.Core.Model.Gameplay
{
    public class Queen : Piece
    {
        private const int QueenValue = 9;

        protected override int GetValue()
        {
            return QueenValue;
        }

        protected override IEnumerable<Move> GetAvailableMoves()
        {
            throw new NotImplementedException();
        }
    }
}
