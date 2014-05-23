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
    /// Interaction logic for SquareView.xaml
    /// </summary>
    public partial class SquareView : UserControl
    {
        public static readonly DependencyProperty PiecesSetProperty = DependencyProperty.Register("PiecesSet", typeof(PiecesSet), typeof(SquareView), new PropertyMetadata((s, a) =>
            {
                (s as SquareView).Refresh();
            }));

        public PiecesSet Pieces
        {
            get { return this.GetValue(PiecesSetProperty) as PiecesSet; }
            set { this.SetValue(PiecesSetProperty, value); }
        }

        public SquareViewModel Model { get; private set; }

        private void Refresh()
        {
            grid.Children.Clear();
            grid.Children.Add(Pieces[Model.Square.CurrentPiece]);
        }

        public SquareView(SquareViewModel model)
        {
            InitializeComponent();

            this.Model = model;

            this.Model.PropertyChanged += (s, a) =>
                {
                    if (a.PropertyName == "Square")
                    {
                        Refresh();
                    }
                };

            Refresh();
        }
    }
}
