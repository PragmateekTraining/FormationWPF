using Chess.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.Error.WriteLine("You must provide the path of an UCI engine!");

                Environment.Exit(1);
            }

            string UCIEnginePath = args[0];

            using (IEngine engine = new UCIEngine(UCIEnginePath))
            {
                engine.Start();
                engine.StartNewGame();

                ChessGameUIConsole game = new ChessGameUIConsole(engine);

                game.Run();
            }
        }
    }
}
