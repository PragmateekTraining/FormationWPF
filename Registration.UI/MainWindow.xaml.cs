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

namespace MVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            RegistrationViewModel model = new RegistrationViewModel();
            RegistrationData data = new RegistrationData
            {
                FirstName = "...",
                LastName = "..."
            };

            model.RegistrationData = data;

            model.CommitData = new CommitDataCommand(data);

            registrationForm.Model = model;

            // this.Content = new RegistrationForm();
        }
    }
}
