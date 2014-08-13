using System;
using System.ComponentModel;
using System.Timers;
using System.Windows.Threading;

namespace DispatcherTimerSample
{
    public class ClockViewModel : INotifyPropertyChanged
    {
        DispatcherTimer timer;
        Timer badTimer;

        private DateTime time;
        public DateTime Time
        {
            get { return time; }
            set
            {
                if (value != time)
                {
                    time = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Time"));
                }
            }
        }

        public void Run()
        {
            timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            timer.Tick += delegate { Time = DateTime.Now; };
            timer.Start();

            badTimer = new Timer { Interval = 1000 };
            badTimer.Elapsed += delegate { Time = DateTime.Now; };
            badTimer.Start();

            Time = DateTime.Now;
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
