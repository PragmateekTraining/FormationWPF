using System.Windows;
using System.Windows.Controls;

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
