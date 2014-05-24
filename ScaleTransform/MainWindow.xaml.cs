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

namespace ScaleTransform
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseWheel_1(object sender, MouseWheelEventArgs e)
        {
            double factor = Math.Pow(1.1, 1.0 * e.Delta / Mouse.MouseWheelDeltaForOneLine);

            transform.ScaleX = Math.Max(0.1, transform.ScaleX * factor);
            transform.ScaleY = Math.Max(0.1, transform.ScaleY * factor);
        }
    }
}
