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
            SetupWhitePieces();
            SetupBlackPieces();
        }

        private void AddPieceToBoard(Piece piece, Position square)
        {
            piece.Board = this;
            piece.Square = square;
            Pieces.Add(piece);
        }

        private void SetupWhitePieces() 
        {
            Piece currentPiece;

            CreatePawnAtPosition(StartingPositions.WHITE_A_PAWN);
            CreatePawnAtPosition(StartingPositions.WHITE_B_PAWN);
            CreatePawnAtPosition(StartingPositions.WHITE_C_PAWN);
            CreatePawnAtPosition(StartingPositions.WHITE_D_PAWN);
            CreatePawnAtPosition(StartingPositions.WHITE_E_PAWN);
            CreatePawnAtPosition(StartingPositions.WHITE_F_PAWN);
            CreatePawnAtPosition(StartingPositions.WHITE_G_PAWN);
            CreatePawnAtPosition(StartingPositions.WHITE_H_PAWN);

            // Rooks
            currentPiece = new Rook();
            AddPieceToBoard(currentPiece, new Position(StartingPositions.WHITE_A_ROOK));
            currentPiece = new Rook();
            AddPieceToBoard(currentPiece, new Position(StartingPositions.WHITE_H_ROOK));

            // Knights
            currentPiece = new Knight();
            AddPieceToBoard(currentPiece, new Position(StartingPositions.WHITE_B_KNIGHT));
            currentPiece = new Knight();
            AddPieceToBoard(currentPiece, new Position(StartingPositions.WHITE_G_KNIGHT));

            // Bishops
            currentPiece = new Bishop();
            AddPieceToBoard(currentPiece, new Position(StartingPositions.WHITE_LIGHT_BISHOP));
            currentPiece = new Bishop();
            AddPieceToBoard(currentPiece, new Position(StartingPositions.WHITE_DARK_BISHOP));

            // Royalty
            currentPiece = new King();
            AddPieceToBoard(currentPiece, new Position(StartingPositions.WHITE_KING));
            currentPiece = new Queen();
            AddPieceToBoard(currentPiece, new Position(StartingPositions.WHITE_QUEEN));
        }

        private void SetupBlackPieces()
        {
            Piece currentPiece;

            CreatePawnAtPosition(StartingPositions.BLACK_A_PAWN);
            CreatePawnAtPosition(StartingPositions.BLACK_B_PAWN);
            CreatePawnAtPosition(StartingPositions.BLACK_C_PAWN);
            CreatePawnAtPosition(StartingPositions.BLACK_D_PAWN);
            CreatePawnAtPosition(StartingPositions.BLACK_E_PAWN);
            CreatePawnAtPosition(StartingPositions.BLACK_F_PAWN);
            CreatePawnAtPosition(StartingPositions.BLACK_G_PAWN);
            CreatePawnAtPosition(StartingPositions.BLACK_H_PAWN);

            // Rooks
            currentPiece = new Rook();
            AddPieceToBoard(currentPiece, new Position(StartingPositions.BLACK_A_ROOK));
            currentPiece = new Rook();
            AddPieceToBoard(currentPiece, new Position(StartingPositions.BLACK_H_ROOK));

            // Knights
            currentPiece = new Knight();
            AddPieceToBoard(currentPiece, new Position(StartingPositions.BLACK_B_KNIGHT));
            currentPiece = new Knight();
            AddPieceToBoard(currentPiece, new Position(StartingPositions.BLACK_G_KNIGHT));

            // Bishops
            currentPiece = new Bishop();
            AddPieceToBoard(currentPiece, new Position(StartingPositions.BLACK_LIGHT_BISHOP));
            currentPiece = new Bishop();
            AddPieceToBoard(currentPiece, new Position(StartingPositions.BLACK_DARK_BISHOP));

            // Royalty
            currentPiece = new King();
            AddPieceToBoard(currentPiece, new Position(StartingPositions.BLACK_KING));
            currentPiece = new Queen();
            AddPieceToBoard(currentPiece, new Position(StartingPositions.BLACK_QUEEN));
        }

        private void CreatePawnAtPosition(string position)
        {
            Pawn pawn = new Pawn();
            AddPieceToBoard(pawn, new Position(position));
        }
    }
}
