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

namespace CollectionViews
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly string[] fruits =
        {
            "Pineapple",
            "Blackberry",
            "Apple",
            "Apricot",
            "Orange",
            "Pear",
            "Banana",
            "Plum",
            "Kiwi"
        };

        public string[] Fruits
        {
            get
            {
                return fruits;
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(Fruits);
            view.SortDescriptions.Clear();
            view.SortDescriptions.Add(new SortDescription(null, ListSortDirection.Ascending));
        }
    }
}
