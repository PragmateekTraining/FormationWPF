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
using io = System.IO;

namespace TreeViewSample
{
    public interface IFileSystemElement
    {
        string Name
        {
            get;
            set;
        }
    }

    public class Directory : IFileSystemElement, INotifyPropertyChanged
    {
        public string Name
        {
            get;
            set;
        }

        private IList<IFileSystemElement> elements;
        public IList<IFileSystemElement> Elements
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

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }

    public class File : IFileSystemElement
    {
        public string Name
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            tree.ItemsSource = new[] { new Directory { Name = "C:\\" } };
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                // Directory directory = ((sender as TextBlock).TemplatedParent as ContentPresenter).Content as Directory;
                Directory directory = (sender as TextBlock).DataContext as Directory;

                if (directory.Elements == null)
                {
                    directory.Elements = io.Directory.GetFileSystemEntries(directory.Name)
                                                     .Select(fse => io.Directory.Exists(fse) ? new Directory { Name = fse } : new File { Name = fse } as IFileSystemElement)
                                                     .ToList();
                }
            }
        }
    }
}
