using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model
{
    public class Game
    {
        public IList<Move> Moves { get; private set; }

        public Game()
        {
            Moves = new List<Move>();
        }

        public void Execute(Move move)
        {
            Moves.Add(move);
        }
    }
}
