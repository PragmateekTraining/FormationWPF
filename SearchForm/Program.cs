using System;
using System.Windows;
using System.Windows.Controls;

namespace SearchForm
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application application = new Application();

            Thickness margin = new Thickness(5);

            TextBox searchBox = new TextBox
            {
                Width = 150,
                Margin = margin
            };

            Button searchButton = new Button
            {
                Content = "Search",
                Width = 50,
                Margin = margin
            };

            DockPanel.SetDock(searchButton, Dock.Right);

            Button cancelButton = new Button
            {
                Content = "Cancel",
                Width = 50,
                Margin = margin,
                Visibility = Visibility.Collapsed
            };

            DockPanel.SetDock(cancelButton, Dock.Right);

            TextBlock statusBlock = new TextBlock
            {
                Text = "Searching...",
                Margin = margin,
                Visibility = Visibility.Hidden
            };

            DockPanel.SetDock(statusBlock, Dock.Bottom);

            searchButton.Click += (s, e) =>
                {
                    searchBox.IsEnabled = false;
                    statusBlock.Visibility = Visibility.Visible;
                    searchButton.Visibility = Visibility.Collapsed;
                    cancelButton.Visibility = Visibility.Visible;
                };

            cancelButton.Click += (s, e) =>
                {
                    searchBox.IsEnabled = true;
                    statusBlock.Visibility = Visibility.Hidden;
                    cancelButton.Visibility = Visibility.Collapsed;
                    searchButton.Visibility = Visibility.Visible;
                };

            DockPanel panel = new DockPanel();
            panel.Children.Add(statusBlock);
            panel.Children.Add(searchButton);
            panel.Children.Add(cancelButton);
            panel.Children.Add(searchBox);

            Window mainWindow = new Window
            {
                Content = panel,
                SizeToContent = SizeToContent.WidthAndHeight
            };

            mainWindow.Show();

            application.MainWindow = mainWindow;

            application.Run();
        }
    }
}
