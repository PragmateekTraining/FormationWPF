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

namespace CommandBindingsSample
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

        private void CommandUp_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            log.Text = "Up\n" + log.Text;
            input.Value++;
        }

        private void CommandDown_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            log.Text = "Down\n" + log.Text;
            input.Value--;
        }

        private void CommandUp_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            log.Text = "Checking Up\n" + log.Text;

            e.CanExecute = true;
        }

        private void CommandDown_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            log.Text = "Checking Down\n" + log.Text;

            e.CanExecute = true;
        }
    }
}
