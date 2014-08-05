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

namespace EnumsBinding
{
    public enum Sex
    {
        [Description("Ø")]
        Unspecified = 0,
        [Description("♀")]
        Female,
        [Description("♂")]
        Male
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private static readonly Dictionary<Sex, string> sexMapping = new Dictionary<Sex, string>()
        {
            { Sex.Female, "♀" },
            { Sex.Male, "♂" },
            { Sex.Unspecified, "Ø" },
        };

        public Dictionary<Sex, string> SexMapping
        {
            get
            {
                return sexMapping;
            }
        }

        private Sex sex;
        public Sex Sex
        {
            get { return sex; }
            set
            {
                if (value != sex)
                {
                    sex = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Sex"));
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            withProceduralCodeOnly.ItemsSource = Enum.GetValues(typeof(Sex));

            root.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
