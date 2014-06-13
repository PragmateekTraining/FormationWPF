using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTemplateSelectorSample
{
    public class FileSystemViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private void UpdateElements()
        {
            if (string.IsNullOrWhiteSpace(path)) FileSystemElements = null;

            FileSystemElements = Directory.EnumerateFileSystemEntries(path);
        }

        private string path;
        public string Path
        {
            get { return path; }
            set
            {
                path = value;
                UpdateElements();
            }
        }

        private IEnumerable<string> fileSystemElements;
        public IEnumerable<string> FileSystemElements
        {
            get { return fileSystemElements; }
            set
            {
                if (value != fileSystemElements)
                {
                    fileSystemElements = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("FileSystemElements"));
                }
            }
        }
    }
}
