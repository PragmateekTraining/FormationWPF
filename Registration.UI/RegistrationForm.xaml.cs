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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVM
{
    /// <summary>
    /// Interaction logic for RegistrationForm.xaml
    /// </summary>
    public partial class RegistrationForm : UserControl
    {
        public RegistrationViewModel Model { get; set; }

        public RegistrationForm()
        {
            InitializeComponent();

            /*Model = new RegistrationData
            {
                FirstName = "...",
                LastName = "...",
                PhoneNumber = "..."
            };*/

            sexInput.ItemsSource = Enum.GetValues(typeof(Sex));

            DataContext = this;
        }

        /*private void Button_Click(object sender, RoutedEventArgs e)
        {
            Model.CommitData();
        }*/
    }
}
