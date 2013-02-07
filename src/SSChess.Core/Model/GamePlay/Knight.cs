using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSChess.Core.Model.Gameplay
{
    public class Knight : Piece
    {
        private const int KnightValue = 3;

        protected override int GetValue()
        {
            return KnightValue;
        }

        protected override IEnumerable<Move> GetAvailableMoves()
        {
            throw new NotImplementedException();
        }
    }
}
