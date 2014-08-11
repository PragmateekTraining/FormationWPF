using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ExceptionsSample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static bool HandleThem { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            this.DispatcherUnhandledException += (s, a) =>
                {
                    if (HandleThem)
                    {
                        a.Handled = true;

                        MessageBox.Show(string.Format("Got one: {0}!", a.Exception));
                    }
                };
        }
    }
}
