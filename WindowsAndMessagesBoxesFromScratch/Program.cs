using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WindowsAndMessagesBoxesFromScratch
{
    class SomeComponent
    {
    }

    class Program : UIElement
    {
        public static readonly RoutedEvent SomethingHappenedEvent = EventManager.RegisterRoutedEvent("SomethingHappened", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(SomeComponent));

        public event RoutedEventHandler SomethingHappened
        {
            add { AddHandler(SomethingHappenedEvent, value); }
            remove { RemoveHandler(SomethingHappenedEvent, value); }
        }

        void DoSomething()
        {
            RaiseEvent(new RoutedEventArgs(SomethingHappenedEvent, this));
        }

        [STAThread]
        static void Main(string[] args)
        {
            Application application = new Application();

            Window mainWindow = new Window();
            mainWindow.Loaded += (s, a) => MessageBox.Show("Hello " + Environment.UserName);
            mainWindow.Closed += (s, a) => MessageBox.Show("Bye " + Environment.UserName);

            mainWindow.Show();

            application.MainWindow = mainWindow;

            application.Run();
        }
    }
}
