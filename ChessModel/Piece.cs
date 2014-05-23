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

        public override string ToString()
        {
            return Color + " " + this.GetType().Name;
        }

        public static readonly Piece BlackKing = new King { Color = Color.Black };
        public static readonly Piece BlackQueen = new Queen { Color = Color.Black };
        public static readonly Piece BlackRook = new Rook { Color = Color.Black };
        public static readonly Piece BlackBishop = new Bishop { Color = Color.Black };
        public static readonly Piece BlackKnight = new Knight { Color = Color.Black };
        public static readonly Piece BlackPawn = new Pawn { Color = Color.Black };

        public static readonly Piece WhiteKing = new King { Color = Color.White };
        public static readonly Piece WhiteQueen = new Queen { Color = Color.White };
        public static readonly Piece WhiteRook = new Rook { Color = Color.White };
        public static readonly Piece WhiteBishop = new Bishop { Color = Color.White };
        public static readonly Piece WhiteKnight = new Knight { Color = Color.White };
        public static readonly Piece WhitePawn = new Pawn { Color = Color.White };
    }

    public class King : Piece
    {
        internal King()
        {
        }
    }

    public class Queen : Piece
    {
        internal Queen()
        {
        }
    }

    public class Rook : Piece
    {
        internal Rook()
        {
        }
    }

    public class Bishop : Piece
    {
        internal Bishop()
        {
        }
    }

    public class Knight : Piece
    {
        internal Knight()
        {
        }
    }

    public class Pawn : Piece
    {
        internal Pawn()
        {
        }
    }
}
