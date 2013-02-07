using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSChess.Core.Model.Gameplay
{
    public class King : Piece
    {

        protected override int GetValue()
        {
            return 0;
        }

        protected override IEnumerable<Move> GetAvailableMoves()
        {
            throw new NotImplementedException();
        }
    }
}
