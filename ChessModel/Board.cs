using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model
{
    public class Board
    {
        private Square[,] squares = new Square[8, 8];

        private static readonly IDictionary<char, Piece> FENCodeToPieceMapping = new Dictionary<char, Piece>
        {
            { 'k', Piece.BlackKing},
            { 'q', Piece.BlackQueen},
            { 'r', Piece.BlackRook},
            { 'b', Piece.BlackBishop},
            { 'n', Piece.BlackKnight},
            { 'p', Piece.BlackPawn},
            { 'K', Piece.WhiteKing},
            { 'Q', Piece.WhiteQueen},
            { 'R', Piece.WhiteRook},
            { 'B', Piece.WhiteBishop},
            { 'N', Piece.WhiteKnight},
            { 'P', Piece.WhitePawn}
        };

        public const string StartPositionFEN = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR";

        public Square this[Column col, int row]
        {
            get
            {
                return squares[(int)col - 1, row - 1];
            }
        }

        public Board()
        {
            // Squares = new Square[8, 8];

            for (int iCol = 0; iCol < 8; ++iCol)
            {
                for (int iRow = 0; iRow < 8; ++iRow)
                {
                    squares[iCol, iRow] = new Square
                    {
                        Column = (Column)(iCol + 1),
                        Row = iRow + 1,
                        IsBlack = iRow % 2 == iCol % 2,
                        CurrentPiece = null
                    };
                }
            }

            FromFEN(StartPositionFEN);
        }

        public void FromFEN(string FEN)
        {
            int iRow = 7;
            int iCol = 0;

            for (int i = 0; i < FEN.Length; ++i)
            {
                char c = FEN[i];

                int emptyCount;
                if (int.TryParse("" + c, out emptyCount))
                {
                    for (int iEmpty = 1; iEmpty <= emptyCount; ++iEmpty)
                    {
                        squares[iCol, iRow].CurrentPiece = null;
                        ++iCol;
                    }
                }
                else if (c == '/')
                {
                    --iRow;
                    iCol = 0;
                }
                else
                {
                    squares[iCol, iRow].CurrentPiece = FENCodeToPieceMapping[c];
                    ++iCol;
                }
            }
        }

        public static Board Parse(string FEN)
        {
            Board board = new Board();
            board.FromFEN(FEN);
            return board;
        }
    }
}
