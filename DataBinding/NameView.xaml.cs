using DataBinding.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace DataBinding
{
    public partial class NameView : UserControl
    {
        public static readonly DependencyProperty ModelProperty = DependencyProperty.Register("Model", typeof(NameViewModel), typeof(NameView));

        public NameViewModel Model
        {
            get { return (NameViewModel)this.GetValue(ModelProperty); }
            set { this.SetValue(ModelProperty, value); }
        }

        public NameView()
        {
            InitializeComponent();
        }
    }
}
