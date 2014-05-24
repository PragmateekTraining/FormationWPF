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

namespace MouseEvents
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

        private void rectangle_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            rectangle.BorderBrush = Brushes.Red;
            rectangle.CaptureMouse();
        }

        private void rectangle_MouseUp_1(object sender, MouseButtonEventArgs e)
        {
            rectangle.BorderBrush = null;
            rectangle.ReleaseMouseCapture();
        }

        private void Window_MouseMove_1(object sender, MouseEventArgs e)
        {
            absolutePosition.Text = e.GetPosition(null).ToString();
            relativePosition.Text = e.GetPosition(rectangle).ToString();
        }
    }
}
