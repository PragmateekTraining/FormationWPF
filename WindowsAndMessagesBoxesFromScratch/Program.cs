using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WindowsAndMessagesBoxesFromScratch
{
    class Program
    {
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
