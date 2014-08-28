using DataBinding.ViewModels;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*public NameViewModel NameViewModel
        {
            get
            {
                return new NameViewModel
                {
                    Computer = new Computer
                    {
                        Name = "..."
                    }
                };
            }
        }*/

        public IDictionary<string, string> Dictionary { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Dictionary = new Dictionary<string, string>
            {
                { "SomeExistingKey", "Some existing value" }
            };

            DataContext = this;
        }
    }
}
