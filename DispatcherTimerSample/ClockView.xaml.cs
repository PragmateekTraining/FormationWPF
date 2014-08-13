using System;
using System.Windows;
using System.Windows.Controls;

namespace DispatcherTimerSample
{
    public partial class ClockView : UserControl
    {
        public ClockViewModel Model
        {
            get { return (ClockViewModel)GetValue(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }

        public static readonly DependencyProperty ModelProperty = DependencyProperty.Register("Model", typeof(ClockViewModel), typeof(ClockView), new PropertyMetadata(OnModelChanged));

        public ClockView()
        {
            InitializeComponent();
        }

        private static void OnModelChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            ClockView clockView = sender as ClockView;
            ClockViewModel model = args.NewValue as ClockViewModel;

            model.PropertyChanged += (s, a) =>
                {
                    if (a.PropertyName == "Time")
                    {
                        // Snapshot the latest time
                        DateTime now = model.Time;

                        clockView.hourHandRotation.Angle = (now.Hour % 12) * 360.0 / 12 + 1.0 * now.Minute / 60 * 1.0 / 12 + 1.0 * now.Second / 60 * 1.0 / 60;
                        clockView.minuteHandRotation.Angle = now.Minute * 360.0 / 60 + 1.0 * now.Second / 60 * 1.0 / 60;
                        clockView.secondHandRotation.Angle = now.Second * 360.0 / 60;
                    }
                };

            model.Run();
        }
    }
}
