using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CustomControlSample
{
    public class ImageButton : Button
    {
        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register("Image", typeof(ImageSource), typeof(ImageButton), new PropertyMetadata(OnImagePropertyChanged));
        public static readonly DependencyProperty ImageWidthProperty = DependencyProperty.Register("ImageWidth", typeof(int), typeof(ImageButton), new PropertyMetadata(OnImagePropertyChanged));
        public static readonly DependencyProperty ImageHeightProperty = DependencyProperty.Register("ImageHeight", typeof(int), typeof(ImageButton), new PropertyMetadata(OnImagePropertyChanged));

        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        public int ImageWidth
        {
            get { return (int)GetValue(ImageWidthProperty); }
            set { SetValue(ImageWidthProperty, value); }
        }
        
        public int ImageHeight
        {
            get { return (int)GetValue(ImageHeightProperty); }
            set { SetValue(ImageHeightProperty, value); }
        }        

        private bool updatingContent = false;

        public ImageButton()
        {
            HorizontalContentAlignment = System.Windows.HorizontalAlignment.Stretch;
        }

        private static void OnImagePropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs args)
        {
            (source as ImageButton).UpdateImage();
        }

        private Image image = null;

        private void UpdateImage()
        {
            if (image != null)
            {
                image.Source = Image;
                image.Width = ImageWidth;
                image.Height = ImageHeight;
                image.Margin = new Thickness(0, 0, 5, 0);
            }
        }

        protected override void OnContentChanged(object oldContent, object newContent)
        {
            if (!updatingContent)
            {
                updatingContent = true;

                try
                {
                    DockPanel panel = new DockPanel();

                    image = new Image();

                    image.SetValue(DockPanel.DockProperty, Dock.Left);
                    image.SetValue(RenderOptions.BitmapScalingModeProperty, BitmapScalingMode.HighQuality);

                    UpdateImage();

                    FrameworkElement originalContent = newContent is string ? new TextBlock { Text = newContent as string } :
                                                       newContent as FrameworkElement;

                    originalContent.VerticalAlignment = VerticalAlignment.Center;

                    panel.Children.Add(image);
                    panel.Children.Add(originalContent);

                    Content = panel;
                }
                finally
                {
                    updatingContent = false;
                }
            }
        }
    }
}
