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

namespace CanvasSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            availableBrushes = typeof(Brushes).GetProperties().Select(pi => pi.GetValue(null, null) as Brush).ToArray();
        }

        private readonly Random rand = new Random();

        private Brush[] availableBrushes = null;

        private Brush GetRandomBrush()
        {
            return availableBrushes[rand.Next(availableBrushes.Length)];
        }

        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBlock tb = new TextBlock
            {
                Text = "" + (char)(rand.Next(128 - 33) + 33),
                Foreground = GetRandomBrush(),
                FontWeight = FontWeights.Bold
            };
            tb.SetValue(Canvas.TopProperty, e.GetPosition(canvas).Y);
            Canvas.SetLeft(tb, e.GetPosition(canvas).X);

            canvas.Children.Add(tb);
        }
    }
}
