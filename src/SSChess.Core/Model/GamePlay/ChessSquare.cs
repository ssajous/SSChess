using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSChess.Core.Model.Gameplay
{
    public class ChessSquare
    {
        public Position BoardPosition { get; set; }
        public Piece OccupyingPiece { get; set; }

        public bool IsOccupied
        {
            get
            {
                return OccupyingPiece != null;
            }
        }
    }
}
