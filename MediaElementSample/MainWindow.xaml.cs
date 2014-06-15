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

namespace MediaElementSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isPaused = true;

        const string imagesUriTemplate = "pack://application:,,,/Assets;component/images/icons/{0}.png";

        ImageSource playSource;
        ImageSource pauseSource;

        public MainWindow()
        {
            InitializeComponent();

            TypeConverter converter = new ImageSourceConverter();
            playSource = converter.ConvertFrom(new Uri(string.Format(imagesUriTemplate, "play"))) as ImageSource;
            pauseSource = converter.ConvertFrom(new Uri(string.Format(imagesUriTemplate, "pause"))) as ImageSource;

            UpdateImage();
        }

        private void UpdateImage()
        {
            image.Source = isPaused ? playSource : pauseSource;
        }

        private void video_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TogglePlayPause();
        }

        private void image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TogglePlayPause();
        }

        private void TogglePlayPause()
        {
            if (isPaused)
                video.Play();
            else
                video.Pause();

            isPaused = !isPaused;

            UpdateImage();
        }
    }
}
