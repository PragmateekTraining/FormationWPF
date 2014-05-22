using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess.Engine;
using Chess.Model;

namespace Chess.Tests
{
    [TestClass]
    public class ChessEnginesTests
    {
        [TestMethod]
        public void CanStartAndUseAnUCIChessEngine()
        {
            IEngine engine = new UCIEngine("C:/opt/UCI/Strelka6.exe");
            engine.Start();
            engine.CheckStatus();

            Assert.IsTrue(engine.IsRunning());

            engine.Stop();

            Assert.IsFalse(engine.IsRunning());
        }

        [TestMethod]
        public void CanComputeNextBestMove()
        {
            // Simulate a fool's mate (french: "mat du lion")
            using (IEngine engine = new UCIEngine("C:/opt/UCI/Strelka6.exe"))
            {
                engine.Start();
                engine.StartNewGame();

                engine.Execute(Move.Parse("f2f3"));
                engine.Execute(Move.Parse("e7e5"));
                engine.Execute(Move.Parse("g2g4"));

                Move nextBestMove = engine.GetBestMove();

                Assert.AreEqual("d8h4", nextBestMove.ToString());

                engine.Execute(Move.Parse("d8h4"));

                // Detect mate
                nextBestMove = engine.GetBestMove();

                Assert.IsNull(nextBestMove);

                Assert.IsTrue(engine.AreWhitesMated);
                Assert.IsFalse(engine.AreBlacksMated);
            }
        }
    }
}
