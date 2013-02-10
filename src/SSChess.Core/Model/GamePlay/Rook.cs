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

            IEnumerable<Position> north = rankPositions.Where(pos => pos.Rank > this.Square.Rank)
                .OrderBy(pos => pos.DistanceFrom(this.Square));
            IEnumerable<Position> south = rankPositions.Where(pos => pos.Rank < this.Square.Rank)
                .OrderBy(pos => pos.DistanceFrom(this.Square)); ;
            IEnumerable<Position> east = filePositions.Where(pos => pos.File.Index > this.Square.File.Index)
                .OrderBy(pos => pos.DistanceFrom(this.Square)); ;
            IEnumerable<Position> west = filePositions.Where(pos => pos.File.Index < this.Square.File.Index)
                .OrderBy(pos => pos.DistanceFrom(this.Square));

            AddAvailableMoves(north, moves);
            AddAvailableMoves(south, moves);
            AddAvailableMoves(east, moves);
            AddAvailableMoves(west, moves);

            return moves.AsEnumerable();
        }

        /// <summary>
        /// Adds available moves from a segment of positions
        /// </summary>
        /// <param name="targets">Must be sorted by distance from current piece</param>
        /// <param name="moves"></param>
        private void AddAvailableMoves(IEnumerable<Position> targets, List<Move> moves)
        {
            // Add moves until we hit an obstruction
            foreach (Position position in targets)
            {
                ChessSquare target = this.Board.Squares[position.ToString()];
                if (!target.IsOccupied)
                {
                    moves.Add(new Move
                    {
                        StartPosition = this.Square,
                        EndPosition = position
                    });
                }
                else if (target.OccupyingPiece.Color != this.Color)
                {
                    moves.Add(new Move
                    {
                        StartPosition = this.Square,
                        EndPosition = position,
                        CapturedPiece = target.OccupyingPiece
                    });
                    break;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
