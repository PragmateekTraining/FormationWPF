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
        public Board Board { get; private set; }

        public Game()
        {
            Moves = new List<Move>();
            Board = new Board();
        }

        public void Execute(Move move)
        {
            Moves.Add(move);

            Square fromSquare = Board.Squares[(int)(move.From.Column - 1), move.From.Row - 1];
            Square toSquare = Board.Squares[(int)(move.To.Column - 1), move.To.Row - 1];

            Piece piece = fromSquare.CurrentPiece;
            fromSquare.CurrentPiece = null;
            toSquare.CurrentPiece = piece;
        }
    }
}
