using System;
using System.Timers;
using System.Windows;
using System.Windows.Threading;

namespace DispatcherTimerSample
{
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        Timer badTimer;

        public MainWindow()
        {
            InitializeComponent();

            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs args)
        {
            timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            timer.Tick += delegate { UpdateClock(); };
            timer.Start();

            badTimer = new Timer { Interval = 1000 };
            badTimer.Elapsed += delegate { UpdateClock(); };
            badTimer.Start();

            UpdateClock();
        }

        void UpdateClock()
        {
            DateTime now = DateTime.Now;

            hourHandRotation.Angle = (now.Hour % 12) * 360.0 / 12 + 1.0 * now.Minute / 60 * 1.0 / 12  + 1.0 * now.Second / 60 * 1.0 / 60;
            minuteHandRotation.Angle = now.Minute * 360.0 / 60 + 1.0 * now.Second / 60 * 1.0 / 60;
            secondHandRotation.Angle = now.Second * 360.0 / 60;
        }
    }
}
