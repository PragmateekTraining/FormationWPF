using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private int grade = 0;

        public int Grade
        {
            get { return grade; }
            set
            {
                if (value != grade)
                {
                    grade = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Grade"));
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;
        }
    }
}
