using Chess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chess.UI.WPF
{
    /// <summary>
    /// Interaction logic for BoardView.xaml
    /// </summary>
    public partial class BoardView : UserControl
    {
        public BoardView(BoardViewModel model)
        {
            InitializeComponent();

            for (int iRow = 8; iRow >= 1; --iRow)
            {
                for (int iCol = 1; iCol <= 8; ++iCol)
                {
                    grid.Children.Add(new SquareView(new SquareViewModel { Square = model.Board[(Column)iCol, iRow] }));
                }
            }
        }
    }
}
