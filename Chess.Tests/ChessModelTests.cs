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
    }
}
