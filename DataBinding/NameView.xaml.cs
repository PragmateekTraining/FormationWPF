using DataBinding.ViewModels;
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
    /// Interaction logic for NameView.xaml
    /// </summary>
    public partial class NameView : UserControl
    {
        public static readonly DependencyProperty ModelProperty = DependencyProperty.Register("Model", typeof(NameViewModel), typeof(NameView),);

        public NameViewModel Model
        {
            get
            {
                return (NameViewModel)this.GetValue(ModelProperty);
            }
            set
            {
                this.SetValue(ModelProperty, value);
            }
        }

        public NameView()
        {
            InitializeComponent();

            DataContext = this;
        }
    }
}
