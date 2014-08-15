using System.Windows;

namespace AsyncEventHandlerSample
{
    public partial class MainWindow : Window
    {
        bool isCanceled;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void loadDataButton_Click(object sender, RoutedEventArgs e)
        {
            loadDataButton.IsEnabled = false;
            cancelButton.IsEnabled = true;
            progressMarker.IsActive = true;
            
            while (!isCanceled)
            {
                string data = await DataSource.GetNextDataAsync();

                dataOutput.Text += data + "\n";

                scrollViewer.ScrollToBottom();
            }

            loadDataButton.IsEnabled = true;
            progressMarker.IsActive = false;
            isCanceled = false;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            isCanceled = true;

            cancelButton.IsEnabled = false;
        }
    }
}
