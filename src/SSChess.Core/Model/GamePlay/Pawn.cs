using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSChess.Core.Model.Gameplay
{
    public class Pawn : Piece
    {
        private const int PawnValue = 1;


        protected override int GetValue()
        {
            return PawnValue;
        }

        protected override IEnumerable<Move> GetAvailableMoves()
        {
            List<Move> moves = new List<Move>();
            Position forwardOne = GetForwardPosition(1);        
            Position forwardTwo = GetForwardPosition(2);
            Position captureLeft = GetLeftCapturePosition();
            Position captureRight = GetRightCapturePosition();

            bool isForwardBlocked = Board.Squares[forwardOne.ToString()].IsOccupied;

            if (!HasMoved() && !Board.Squares[forwardTwo.ToString()].IsOccupied && !isForwardBlocked)
            {
                AddMove(moves, forwardTwo);
            }
            if (!isForwardBlocked)
            {
                AddMove(moves, forwardOne);
            }
            if (IsCaptureAvailable(captureLeft))
            {
                AddMove(moves, captureLeft);
            }
            if (IsCaptureAvailable(captureRight))
            {
                AddMove(moves, captureRight);
            }
           
            return moves.AsEnumerable();
        }

        private void AddMove(List<Move> moves, Position newPosition)
        {
            Piece captureVictim = null;
            if (this.Board.Squares[newPosition.ToString()].IsOccupied)
            {
                captureVictim = this.Board.Squares[newPosition.ToString()].OccupyingPiece;
            }
            moves.Add(new Move
            {
                MovingPiece = this,
                StartPosition = this.Square,
                EndPosition = newPosition,
                CapturedPiece = captureVictim
            });
        }

        private bool IsCaptureAvailable(Position capturePosition)
        {
            return capturePosition != null && this.Board.Squares[capturePosition.ToString()].IsOccupied &&
                            this.Board.Squares[capturePosition.ToString()].OccupyingPiece.Color != this.Color;
        }

        private Position GetLeftCapturePosition()
        {
            int targetRank = GetForwardRank(1);
            if (this.Square.File.Index - 1 >= BoardFile.MinIndex)
            {
                return new Position(targetRank, new BoardFile(this.Square.File.Index - 1));
            }
            else
            {
                return null;
            }
        }

        private Position GetRightCapturePosition()
        {
            int targetRank = GetForwardRank(1);
            if (this.Square.File.Index + 1 <= BoardFile.MaxIndex)
            {
                return new Position(targetRank, new BoardFile(this.Square.File.Index + 1));
            }
            else
            {
                return null;
            }
        }

        private int GetForwardRank(int steps)
        {
            if (this.Color == ChessColor.White)
            {
                return this.Square.Rank + steps;
            }
            else
            {
                return this.Square.Rank - steps;
            }
        }

        private Position GetForwardPosition(int steps)
        {
            int targetRank = GetForwardRank(steps);
            if (Position.MinRank <= targetRank && Position.MaxRank >= targetRank)
            {
                return new Position(targetRank, this.Square.File);
            }
            else
            {
                return null;
            }
        }

        private bool HasMoved()
        {
            IReadOnlyList<string> pawnStartPositions = GetStartPositions();
            
            return !pawnStartPositions.Contains(this.Square.ToString());
        }

        private IReadOnlyList<string> GetStartPositions()
        {
            if (this.Color == ChessColor.White)
            {
                return StartingPositions.WhitePawnStartPositions;
            }
            else
            {
                return StartingPositions.BlackPawnStartPositions;
            }
        }
    }
}
