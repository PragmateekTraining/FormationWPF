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

namespace GradeChooser
{
    /// <summary>
    /// Interaction logic for Star.xaml
    /// </summary>
    public partial class Star : Button
    {
        public static readonly DependencyProperty IsCheckedProperty = DependencyProperty.Register("IsChecked", typeof(bool), typeof(Star), null);

        public bool IsChecked
        {
            get
            {
                return (bool)this.GetValue(IsCheckedProperty);
            }
            set
            {
                this.SetValue(IsCheckedProperty, value);
            }
        }

        public Star()
        {
            InitializeComponent();

            DataContext = this;
        }
    }
}
