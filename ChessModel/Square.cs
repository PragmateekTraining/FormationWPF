using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model
{
    public enum Column
    {
        Undefined = 0,
        A,
        B,
        C,
        D,
        E,
        F,
        G,
        H
    }

    public class Square
    {
        public Column Column { get; set; }
        public int Row { get; set; }

        public bool IsBlack { get; set; }

        public Piece CurrentPiece { get; set; }

        public override string ToString()
        {
            return Column.ToString().ToLower() + Row;
        }

        public static Square Parse(string squareString)
        {
            Column column = (Column)(squareString[0] - 'a' + 1);
            int row = int.Parse("" + squareString[1]);

            Square square = new Square
            {
                Column = column,
                Row = row,
                IsBlack = (int)column % 2 == row % 2
            };

            return square;
        }
    }
}
