using Chess.Engine;
using Chess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChessGame
{
    class ChessGameUIConsole
    {
        private readonly IEngine engine = null;

        public ChessGameUIConsole(IEngine engine)
        {
            this.engine = engine;
        }

        public void Run(bool autoPlay = false)
        {
            while (true)
            {
                if (!autoPlay)
                {
                    Console.WriteLine("Your move? ");

                    string moveString = Console.ReadLine();

                    if (moveString == "")
                    {
                        continue;
                    }

                    Move move = Move.Parse(moveString);

                    engine.Execute(move);
                }

                Move AIMove = engine.GetBestMove();

                engine.Execute(AIMove);

                Console.WriteLine("My move: {0}", AIMove);

                Console.ReadLine();
            }
        }
    }
}
