using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace DataTemplateSelectorSample
{
    public class FileSystemElementTemplateSelector : DataTemplateSelector
    {
        public DataTemplate FolderTemplate { get; set; }
        public DataTemplate FileTemplate { get; set; }
        public DataTemplate TextFileTemplate { get; set; }
        public DataTemplate ApplicationTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            string path = (string)item;

            return Directory.Exists(path) ? FolderTemplate :
                path.EndsWith(".txt") ? TextFileTemplate :
                path.EndsWith(".exe") ? ApplicationTemplate :
                FileTemplate;
        }
    }
}
