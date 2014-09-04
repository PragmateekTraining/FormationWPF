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

namespace BadUserControlDataContext
{
    /// <summary>
    /// Interaction logic for BadUserControl.xaml
    /// </summary>
    public partial class BadUserControl : UserControl
    {
        public string SomeData
        {
            get { return (string)GetValue(SomeDataProperty); }
            set { SetValue(SomeDataProperty, value); }
        }

        public static readonly DependencyProperty SomeDataProperty = DependencyProperty.Register("SomeData", typeof(string), typeof(BadUserControl));        

        public BadUserControl()
        {
            InitializeComponent();
        }
    }
}
