using System;
using System.Windows;
using System.Windows.Threading;

namespace CustomControlSample
{
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (timer == null)
            {
                timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(300) };
                timer.Tick += delegate { track.Text += "Boom! "; };
            }

            timer.Start();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (timer != null)
            {
                timer.Stop();
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
