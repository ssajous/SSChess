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
            List<Move> moves = new List<Move>();

            List<Position> targetSquares = this.Square.GetLMovePositions();
            targetSquares.ForEach(square =>
            {
                ChessSquare boardTarget = this.Board.Squares[square.ToString()];
                if (!boardTarget.IsOccupied)
                {
                    moves.Add(new Move 
                    { 
                        StartPosition = this.Square, 
                        EndPosition = square 
                    });
                }
                else if (boardTarget.OccupyingPiece.Color != this.Color) // enemy occupation
                {
                    moves.Add(new Move
                    {
                        StartPosition = this.Square,
                        EndPosition = square,
                        CapturedPiece = boardTarget.OccupyingPiece
                    });
                }
            });

            return moves.AsEnumerable();
        }
    }
}
