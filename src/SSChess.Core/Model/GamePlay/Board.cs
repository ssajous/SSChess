using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSChess.Core.Model.Gameplay
{
    public class Board
    {
        public const int NumberOfSquares = 64;

        public Board()
        {
            Squares = new Dictionary<string, Position>(NumberOfSquares);
            Pieces = new List<Piece>();

            InitializeSquares();
        }

        /// <summary>
        /// IDictionary of squares on the board, indexed by their {file letter}{rank number} coordinates
        /// </summary>
        public IDictionary<string, Position> Squares { get; private set; }
        public List<Piece> Pieces { get; private set; }

        private void InitializeSquares()
        {
            Parallel.For(Position.MinRank, Position.MaxRank + 1, (rank) =>
            {
                Parallel.For(BoardFile.MinIndex, BoardFile.MaxIndex + 1, (file) =>
                {
                    Position position = new Position(rank, new BoardFile(file));
                    Squares.Add(position.ToString(), position);
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
            AddPieceToBoard(currentPiece, Squares[StartingPositions.BLACK_A_ROOK]);
            currentPiece = new Rook();
            AddPieceToBoard(currentPiece, Squares[StartingPositions.BLACK_H_ROOK]);

            // Knights
            currentPiece = new Knight();
            AddPieceToBoard(currentPiece, Squares[StartingPositions.BLACK_B_KNIGHT]);
            currentPiece = new Knight();
            AddPieceToBoard(currentPiece, Squares[StartingPositions.BLACK_G_KNIGHT]);

            // Bishops
            currentPiece = new Bishop();
            AddPieceToBoard(currentPiece, Squares[StartingPositions.BLACK_LIGHT_BISHOP]);
            currentPiece = new Bishop();
            AddPieceToBoard(currentPiece, Squares[StartingPositions.BLACK_DARK_BISHOP]);

            // Royalty
            currentPiece = new King();
            AddPieceToBoard(currentPiece, Squares[StartingPositions.BLACK_KING]);
            currentPiece = new Queen();
            AddPieceToBoard(currentPiece, Squares[StartingPositions.BLACK_QUEEN]);
        }

        private void CreatePawnAtPosition(string position)
        {
            Pawn pawn = new Pawn();
            AddPieceToBoard(pawn, Squares[position]);
        }
    }
}
