using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model
{
    public class Board
    {
        public Square[,] Squares { get; private set; }

        public Board()
        {
            Squares = new Square[8, 8];

            for (int iCol = 0; iCol < 8; ++iCol)
            {
                for (int iRow = 0; iRow < 8; ++iRow)
                {
                    Squares[iCol, iRow] = new Square
                    {
                        Column = (Column)(iCol + 1),
                        Row = iRow + 1,
                        IsBlack = iRow % 2 == iCol % 2,
                        CurrentPiece = null
                    };
                }
            }
        }
    }
}
