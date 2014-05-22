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
            if (args.Length == 0)
            {
                Console.Error.WriteLine("You must provide the path of an UCI engine!");

                Environment.Exit(1);
            }

            if (args.Length > 2)
            {
                Console.Error.WriteLine("You can't provide more than 2 parameters: a path and a flag!");

                Environment.Exit(1);
            }

            string UCIEnginePath = args[0];

            bool autoPlay = args.Length == 2 ? bool.Parse(args[1]) : false;

            using (IEngine engine = new UCIEngine(UCIEnginePath))
            {
                engine.Start();
                engine.StartNewGame();

                ChessGameUIConsole game = new ChessGameUIConsole(engine);

                game.Run(autoPlay);
            }

            Console.Write("End of game, press enter to exit...");

            Console.ReadLine();
        }
    }
}
