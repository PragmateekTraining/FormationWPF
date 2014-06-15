using System;
using System.Collections;
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

namespace CollectionViewsPropertyGroups
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

        private class StringToFirstLetterConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return (value as string)[0];
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return DependencyProperty.UnsetValue;
            }
        }

        public class FirstLetterAscendingThenDescending : IComparer
        {
            public int Compare(object first, object second)
            {
                string s1 = first as string;
                string s2 = second as string;

                int byFirstLetter = s1[0].CompareTo(s2[0]);

                return byFirstLetter != 0 ? byFirstLetter : -1 * s1.CompareTo(s2);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(Fruits);

            view.GroupDescriptions.Clear();
            view.SortDescriptions.Clear();

            view.GroupDescriptions.Add(new PropertyGroupDescription(null, new StringToFirstLetterConverter()));

            (view as ListCollectionView).CustomSort = new FirstLetterAscendingThenDescending();

            view.SortDescriptions.Add(new SortDescription(null, ListSortDirection.Ascending));
            view.SortDescriptions.Add(new SortDescription(null, ListSortDirection.Descending));

            //view.Filter = x => (int)x > 0;
        }
    }
}
