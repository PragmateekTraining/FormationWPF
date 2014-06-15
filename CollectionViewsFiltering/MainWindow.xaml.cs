using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CollectionViewsFiltering
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private string fileName = null;
        public string Path
        {
            get { return fileName; }
            set
            {
                if (value != fileName)
                {
                    fileName = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Path"));
                }
            }
        }

        private IEnumerable<string> elements = null;
        public IEnumerable<string> Elements
        {
            get { return elements; }
            set
            {
                if (value != elements)
                {
                    elements = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Elements"));
                }
            }
        }

        private string filterText;
        public string FilterText
        {
            get { return filterText; }
            set
            {
                if (value != filterText)
                {
                    filterText = value;
                    RefreshFilter();
                }
            }
        }

        private FolderBrowserDialog dialog = new FolderBrowserDialog();

        private bool Filter(object element)
        {
            return (element as string).ToUpper().Contains((FilterText ?? "").ToUpper());
        }

        private void RefreshFilter()
        {
            if (Elements != null)
            {
                CollectionViewSource.GetDefaultView(Elements).Filter = Filter;
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Path = dialog.SelectedPath;
                Elements = Directory.GetFileSystemEntries(Path);
                RefreshFilter();
            }
        }
    }
}
