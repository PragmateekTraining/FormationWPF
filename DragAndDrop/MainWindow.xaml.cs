using System;
using System.Collections.Generic;
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

namespace DragAndDrop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private Shape draggedShape;
        private Point clickPosition;

        private void Shape_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            draggedShape = sender as Shape;
            clickPosition = e.GetPosition(draggedShape);
            //draggedShape.CaptureMouse();

            e.Handled = true;
        }

        private void Shape_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            surface.Children.Remove(sender as Shape);
        }

        private void Shape_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //draggedShape.ReleaseMouseCapture();
            draggedShape = null;
        }

        private void Shape_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggedShape != null)
            {
                Point currentPosition = e.GetPosition(surface);

                /*Transform originalTransform = draggedShape.RenderTransform;

                draggedShape.RenderTransform = originalTransform is TranslateTransform ? originalTransform : new TranslateTransform();

                TranslateTransform transform = draggedShape.RenderTransform as TranslateTransform;

                transform.X = currentPosition.X - clickPosition.X - draggedShape.Margin.Left;
                transform.Y = currentPosition.Y - clickPosition.Y - draggedShape.Margin.Right;

                Console.WriteLine(transform.X);*/

                draggedShape.SetValue(Canvas.LeftProperty, currentPosition.X - clickPosition.X);
                draggedShape.SetValue(Canvas.TopProperty, currentPosition.Y - clickPosition.Y);
            }
        }

        private void surface_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Shape shape = new Ellipse { Width = 20, Height = 20, Fill = Brushes.Yellow, Stroke = Brushes.Red, StrokeThickness = 2 };
            
            Point position = e.GetPosition(surface);

            shape.SetValue(Canvas.LeftProperty, position.X - shape.Width / 2);
            shape.SetValue(Canvas.TopProperty, position.Y - shape.Height / 2);

            shape.MouseLeftButtonDown += Shape_MouseLeftButtonDown;
            shape.MouseRightButtonDown += Shape_MouseRightButtonDown;
            shape.MouseLeftButtonUp += Shape_MouseLeftButtonUp;
            shape.MouseMove += Shape_MouseMove;

            surface.Children.Add(shape);
        }
    }
}
