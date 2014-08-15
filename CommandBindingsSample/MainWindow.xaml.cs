using System.Windows;
using System.Windows.Input;

namespace CommandBindingsSample
{
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
