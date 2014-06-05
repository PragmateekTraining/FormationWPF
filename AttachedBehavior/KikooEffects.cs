using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace AttachedBehavior
{
    public class KikooEffects
    {
        public static bool GetIsBlinking(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsBlinkingProperty);
        }

        public static void SetIsBlinking(DependencyObject obj, bool value)
        {
            obj.SetValue(IsBlinkingProperty, value);
        }

        public static readonly DependencyProperty IsBlinkingProperty =
            DependencyProperty.RegisterAttached("IsBlinking", typeof(bool), typeof(KikooEffects), new PropertyMetadata(false, OnBlinkValueChanged));

        static readonly IDictionary<DependencyObject, Storyboard> storyboards = new Dictionary<DependencyObject, Storyboard>();

        private static void OnBlinkValueChanged(DependencyObject target, DependencyPropertyChangedEventArgs args)
        {
            if ((bool)args.NewValue)
            {
                if (!storyboards.ContainsKey(target))
                {
                    DoubleAnimation animation = new DoubleAnimation
                    {
                        Duration = new Duration(TimeSpan.FromSeconds(0.5)),
                        To = 0
                    };

                    Storyboard.SetTarget(animation, target);
                    Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

                    Storyboard storyboard = new Storyboard
                    {
                        AutoReverse = true,
                        RepeatBehavior = RepeatBehavior.Forever,
                    };

                    storyboard.Children.Add(animation);

                    storyboards[target] = storyboard;
                }

                storyboards[target].Begin();
            }
            else
            {
                Storyboard storyboard = null;

                if (storyboards.TryGetValue(target, out storyboard))
                {
                    storyboard.Stop();
                }
            }
        }
    }
}
