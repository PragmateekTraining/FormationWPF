using sys = System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Controls;
using System;

namespace Animations.Console
{
    class Line : Button
    {
        public double Length
        {
            get { return (int)GetValue(LengthProperty); }
            set { SetValue(LengthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Length.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LengthProperty =
            DependencyProperty.Register("Length", typeof(double), typeof(Line), new PropertyMetadata(0.0, OnValueChanged));

        private static void OnValueChanged(DependencyObject target, DependencyPropertyChangedEventArgs args)
        {
            sys.Console.WriteLine(new string('*', (int)(double)args.NewValue));
        }
    }

    class MyWindow : Window
    {
        Storyboard storyboard;

        public MyWindow()
        {
            this.Content = new Button { Content = "123449689189198" };

            this.Loaded += (s, a) =>
                {
                    DoubleAnimation animation = new DoubleAnimation
                    {
                        Duration = new Duration(sys.TimeSpan.FromSeconds(1)),
                        From = 0,
                        To = 50
                    };

                    animation.EasingFunction = new SineEase();

                    Line line = new Line();

                    Storyboard.SetTarget(animation, line);
                    // Storyboard.SetTarget(animation, this.Content as DependencyObject);
                    Storyboard.SetTargetProperty(animation, new PropertyPath("Length"));
                    // Storyboard.SetTargetProperty(animation, new PropertyPath("Width"));

                    storyboard = new Storyboard
                    {
                        Duration = new Duration(sys.TimeSpan.FromSeconds(1)),
                        AutoReverse = true,
                        RepeatBehavior = RepeatBehavior.Forever,
                    };

                    storyboard.Children.Add(animation);

                    storyboard.Begin();
                };
        }
    }

    class Program
    {
        [sys.STAThread]
        static void Main(string[] args)
        {
            DoubleAnimation animation = new DoubleAnimation
            {
                Duration = new Duration(sys.TimeSpan.FromSeconds(1)),
                From = 0,
                To = 50
            };

            animation.EasingFunction = new SineEase();

            Line line = new Line();

            Storyboard.SetTarget(animation, line);
            // Storyboard.SetTarget(animation, this.Content as DependencyObject);
            Storyboard.SetTargetProperty(animation, new PropertyPath("Length"));
            // Storyboard.SetTargetProperty(animation, new PropertyPath("Width"));

            Storyboard storyboard = new Storyboard
            {
                Duration = new Duration(sys.TimeSpan.FromSeconds(1)),
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever,
            };

            storyboard.Children.Add(animation);

            storyboard.Begin();

            // new Application().Run(new MyWindow());
            new Application().Run(new Window { Visibility = Visibility.Hidden });
        }
    }
}
