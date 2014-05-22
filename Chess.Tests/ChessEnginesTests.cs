using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess.Engine;

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
    }
}
