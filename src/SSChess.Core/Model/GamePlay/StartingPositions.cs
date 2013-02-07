using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSChess.Core.Model.Gameplay
{
    public static class StartingPositions
    {
        public const string WHITE_A_PAWN = "a2";
        public const string WHITE_B_PAWN = "b2";
        public const string WHITE_C_PAWN = "c2";
        public const string WHITE_D_PAWN = "d2";
        public const string WHITE_E_PAWN = "e2";
        public const string WHITE_F_PAWN = "f2";
        public const string WHITE_G_PAWN = "g2";
        public const string WHITE_H_PAWN = "h2";

        public const string WHITE_A_ROOK = "a1";
        public const string WHITE_B_KNIGHT = "b1";
        public const string WHITE_DARK_BISHOP = "c1";
        public const string WHITE_QUEEN = "d1";
        public const string WHITE_KING = "e1";
        public const string WHITE_LIGHT_BISHOP = "f1";
        public const string WHITE_G_KNIGHT = "g1";
        public const string WHITE_H_ROOK = "h1";

        public const string BLACK_A_PAWN = "a7";
        public const string BLACK_B_PAWN = "b7";
        public const string BLACK_C_PAWN = "c7";
        public const string BLACK_D_PAWN = "d7";
        public const string BLACK_E_PAWN = "e7";
        public const string BLACK_F_PAWN = "f7";
        public const string BLACK_G_PAWN = "g7";
        public const string BLACK_H_PAWN = "h7";

        public const string BLACK_A_ROOK = "a8";
        public const string BLACK_B_KNIGHT = "b8";
        public const string BLACK_LIGHT_BISHOP = "c8";
        public const string BLACK_QUEEN = "d8";
        public const string BLACK_KING = "e8";
        public const string BLACK_DARK_BISHOP = "f8";
        public const string BLACK_G_KNIGHT = "g8";
        public const string BLACK_H_ROOK = "h8";

        public static IReadOnlyList<string> WhitePawnStartPositions
        {
            get
            {
                return new List<string> {
                    WHITE_A_PAWN,
                    WHITE_B_PAWN,
                    WHITE_C_PAWN,
                    WHITE_D_PAWN,
                    WHITE_E_PAWN,
                    WHITE_F_PAWN,
                    WHITE_G_PAWN,
                    WHITE_H_PAWN
                }.AsReadOnly();
            }
        }

        public static IReadOnlyList<string> BlackPawnStartPositions
        {
            get
            {
                return new List<string> {
                    BLACK_A_PAWN,
                    BLACK_B_PAWN,
                    BLACK_C_PAWN,
                    BLACK_D_PAWN,
                    BLACK_E_PAWN,
                    BLACK_F_PAWN,
                    BLACK_G_PAWN,
                    BLACK_H_PAWN
                }.AsReadOnly();
            }
        }
    }
}
