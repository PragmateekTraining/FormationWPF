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

namespace ProtectedTextBox
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

        private void TextBox_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (!new[] { Key.NumPad0, Key.NumPad1, Key.NumPad2, Key.NumPad3 }.Contains(e.Key) || input1.Text.Length >= 4)
            {
                e.Handled = true;
            }
        }

        private void Grid_PreviewKeyDown_1(object sender, KeyEventArgs e)
        {
            if (!new[] { Key.NumPad0, Key.NumPad1, Key.NumPad2, Key.NumPad3 }.Contains(e.Key) || input2.Text.Length >= 4)
            {
                e.Handled = true;
            }
        }
    }
}
