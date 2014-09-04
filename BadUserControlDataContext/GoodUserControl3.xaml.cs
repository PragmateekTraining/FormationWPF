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
    public partial class GoodUserControl3 : UserControl
    {
        public string SomeData
        {
            get { return (string)GetValue(SomeDataProperty); }
            set { SetValue(SomeDataProperty, value); }
        }

        public static readonly DependencyProperty SomeDataProperty = DependencyProperty.Register("SomeData", typeof(string), typeof(GoodUserControl3));

        public GoodUserControl3()
        {
            InitializeComponent();

            this.root.DataContext = this;
        }
    }
}
