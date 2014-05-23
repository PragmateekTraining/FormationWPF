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

            Square fromSquare = Board[move.From.Column, move.From.Row];
            Square toSquare = Board[move.To.Column, move.To.Row];

            Piece piece = fromSquare.CurrentPiece;
            fromSquare.CurrentPiece = null;
            toSquare.CurrentPiece = piece;
        }
    }
}
