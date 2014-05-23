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
    /// Interaction logic for ChessGameView.xaml
    /// </summary>
    public partial class ChessGameView : UserControl
    {
        public ChessGameView(ChessGameViewModel model)
        {
            InitializeComponent();

            grid.Children.Add(new BoardView(new BoardViewModel { Board = model.Game.Board }));
        }
    }
}
