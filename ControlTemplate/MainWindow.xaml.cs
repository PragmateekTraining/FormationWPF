using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ControlTemplate
{
    public class PercentageConverter : IValueConverter
    {
        public object Convert(object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            return System.Convert.ToDouble(value) * System.Convert.ToDouble(parameter);
        }

        public object ConvertBack(object value,
            Type targetType,
            object parameter,
            System.Globalization.CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    public class ProgressConverter : IValueConverter
    {
        public static readonly ProgressConverter Default = new ProgressConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double progress = System.Convert.ToDouble(value);

            double angle = 2 * Math.PI * progress / 100 - Math.PI / 2;

            double x = 50 + 40 * Math.Cos(angle);
            double y = 50 + 40 * Math.Sin(angle);

            if (progress == 100)
            {
                x -= 0.1;
            }

            Console.WriteLine("{0}, {1}", x, y);

            return new Point(x, y);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    public class ProgressLargeArcConverter : IValueConverter
    {
        public static readonly ProgressLargeArcConverter Default = new ProgressLargeArcConverter();

        public object Convert(object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            Console.WriteLine(System.Convert.ToDouble(value) > 50);

            return System.Convert.ToDouble(value) > 50;
        }

        public object ConvertBack(object value,
            Type targetType,
            object parameter,
            System.Globalization.CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private int progress = 0;
        public int Progress
        {
            get { return progress; }
            set
            {
                if (value != progress)
                {
                    progress = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Progress"));
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;
        }

        private void Button_Click(object _, RoutedEventArgs __)
        {
            BackgroundWorker worker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            worker.DoWork += (object sender, DoWorkEventArgs e) =>
            {
                for (int p = 0; p <= 100 && !e.Cancel; ++p)
                {
                    Thread.Sleep(50);

                    (sender as BackgroundWorker).ReportProgress(p);

                    // if ((sender as BackgroundWorker).CancellationPending) e.Cancel = true;
                }
            };

            worker.ProgressChanged += (object sender, ProgressChangedEventArgs args) => Progress = args.ProgressPercentage;

            //worker.RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs args) => Console.WriteLine("\r{0}", !args.Cancelled ? args.Result : "---");

            //Console.WriteLine("Press enter to stop...");

            worker.RunWorkerAsync();
        }
    }
}
