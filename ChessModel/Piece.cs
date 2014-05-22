using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model
{
    public abstract class Piece
    {
        public Color Color { get; set; }
    }

    public class King : Piece
    {
    }

    public class Queen : Piece
    {
    }

    public class Rook : Piece
    {
    }

    public class Bishop : Piece
    {
    }

    public class Knight : Piece
    {
    }

    public class Pawn : Piece
    {
    }
}
