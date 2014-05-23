using Chess.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Tests
{
    [TestClass]
    public class ChessModelTests
    {
        [TestMethod]
        public void CanParseAndStringifyMove()
        {
            string inMoveString = "e2e4";

            Move move = Move.Parse(inMoveString);

            Assert.AreEqual(Column.E, move.From.Column);
            Assert.AreEqual(2, move.From.Row);

            Assert.AreEqual(Column.E, move.To.Column);
            Assert.AreEqual(4, move.To.Row);

            string outMoveString = move.ToString();

            Assert.AreEqual(inMoveString, outMoveString);
        }

        [TestMethod]
        public void CanParseAFENString()
        {
            Board board = Board.Parse("k7/8/8/4Q3/4q3/8/8/7K");

            Assert.AreEqual(Piece.BlackKing, board[Column.A, 8].CurrentPiece);
            Assert.AreEqual(Piece.WhiteKing, board[Column.H, 1].CurrentPiece);
            Assert.AreEqual(Piece.BlackQueen, board[Column.E, 4].CurrentPiece);
            Assert.AreEqual(Piece.WhiteQueen, board[Column.E, 5].CurrentPiece);

            board[Column.A, 8].CurrentPiece = null;
            board[Column.H, 1].CurrentPiece = null;
            board[Column.E, 4].CurrentPiece = null;
            board[Column.E, 5].CurrentPiece = null;

            for (int iRow = 0; iRow < 8; ++iRow)
            {
                for (int iCol = 0; iCol < 8; ++iCol)
                {
                    Assert.IsNull(board[(Column)(iCol + 1), iRow + 1].CurrentPiece);
                }
            }
        }
    }
}
