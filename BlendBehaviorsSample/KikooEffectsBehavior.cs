using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Interactivity;
using System.Windows.Media.Animation;

namespace BlendBehaviorsSample
{
    public class KikooEffectsBehavior : Behavior<DependencyObject>
    {
        private bool isBlinking;
        public bool IsBlinking
        {
            get { return isBlinking; }
            set
            {
                if (value != isBlinking)
                {
                    isBlinking = value;
                    OnBlinkValueChanged();
                }
            }
        }

        static readonly IDictionary<DependencyObject, Storyboard> storyboards = new Dictionary<DependencyObject, Storyboard>();

        private void OnBlinkValueChanged()
        {
            if (IsBlinking)
            {
                if (!storyboards.ContainsKey(AssociatedObject))
                {
                    DoubleAnimation animation = new DoubleAnimation
                    {
                        Duration = new Duration(TimeSpan.FromSeconds(0.5)),
                        To = 0
                    };

                    Storyboard.SetTarget(animation, AssociatedObject);
                    Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

                    Storyboard storyboard = new Storyboard
                    {
                        AutoReverse = true,
                        RepeatBehavior = RepeatBehavior.Forever,
                    };

                    storyboard.Children.Add(animation);

                    storyboards[AssociatedObject] = storyboard;
                }

                storyboards[AssociatedObject].Begin();
            }
            else
            {
                Storyboard storyboard = null;

                if (storyboards.TryGetValue(AssociatedObject, out storyboard))
                {
                    storyboard.Stop();
                }
            }
        }
    }
}
