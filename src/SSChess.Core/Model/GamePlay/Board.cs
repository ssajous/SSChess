using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSChess.Core.Model.GamePlay
{
    public class Board
    {
        public const int NumberOfSquares = 64;

        public Board()
        {
            Squares = new List<Position>(NumberOfSquares);
            Pieces = new List<Piece>();

            InitializeSquares();
        }

        public List<Position> Squares { get; private set; }
        public List<Piece> Pieces { get; private set; }

        private void InitializeSquares()
        {
            Parallel.For(Position.MinRank, Position.MaxRank + 1, (rank) =>
            {
                Parallel.For(BoardFile.MinIndex, BoardFile.MaxIndex + 1, (file) =>
                {
                    Squares.Add(new Position(rank, new BoardFile(file)));
                });
            });
        }

        public void SetupStartingPieces()
        {
            throw new NotImplementedException();
        }
    }
}
