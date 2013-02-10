using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSChess.Core.Model.Gameplay
{
    public class Move
    {
        public Piece MovingPiece { get; set; }
        public Position StartPosition { get; set; }
        public Position EndPosition { get; set; }

        public Piece CapturedPiece { get; set; }
    }
}
