using Collections.ViewModels;
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

namespace Collections
{
    /// <summary>
    /// Interaction logic for ComputersView.xaml
    /// </summary>
    public partial class ComputersView : UserControl
    {
        public static readonly DependencyProperty ModelProperty = DependencyProperty.Register("Model", typeof(ComputersViewModel), typeof(ComputersView));

        public ComputersViewModel Model
        {
            get
            {
                return (ComputersViewModel)this.GetValue(ModelProperty);
            }
            set
            {
                this.SetValue(ModelProperty, value);
            }
        }

        public ComputersView()
        {
            InitializeComponent();

            DataContext = this;
        }

        private void AddComputerButton_Click(object sender, RoutedEventArgs e)
        {
            Model.CreateNewComputer();
        }
    }
}
