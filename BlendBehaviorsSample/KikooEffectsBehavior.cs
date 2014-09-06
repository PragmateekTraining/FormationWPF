using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Interactivity;
using System.Windows.Media.Animation;

namespace BlendBehaviorsSample
{
    public class KikooEffectsBehavior : Behavior<DependencyObject>
    {
        //private bool isBlinking;
        //public bool IsBlinking
        //{
        //    get { return isBlinking; }
        //    set
        //    {
        //        if (value != isBlinking)
        //        {
        //            isBlinking = value;
        //            OnBlinkValueChanged();
        //        }
        //    }
        //}

        public bool IsBlinking
        {
            get { return (bool)GetValue(IsBlinkingProperty); }
            set { SetValue(IsBlinkingProperty, value); }
        }

        public static readonly DependencyProperty IsBlinkingProperty = DependencyProperty.Register("IsBlinking", typeof(bool), typeof(KikooEffectsBehavior), new PropertyMetadata(OnBlinkValueChanged));        

        static readonly IDictionary<DependencyObject, Storyboard> storyboards = new Dictionary<DependencyObject, Storyboard>();

        private static void OnBlinkValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs _2)
        {
            KikooEffectsBehavior @this = sender as KikooEffectsBehavior;

            if (@this.IsBlinking)
            {
                if (!storyboards.ContainsKey(@this.AssociatedObject))
                {
                    DoubleAnimation animation = new DoubleAnimation
                    {
                        Duration = new Duration(TimeSpan.FromSeconds(0.5)),
                        To = 0
                    };

                    Storyboard.SetTarget(animation, @this.AssociatedObject);
                    Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

                    Storyboard storyboard = new Storyboard
                    {
                        AutoReverse = true,
                        RepeatBehavior = RepeatBehavior.Forever,
                    };

                    storyboard.Children.Add(animation);

                    storyboards[@this.AssociatedObject] = storyboard;
                }

                storyboards[@this.AssociatedObject].Begin();
            }
            else
            {
                Storyboard storyboard = null;

                if (storyboards.TryGetValue(@this.AssociatedObject, out storyboard))
                {
                    storyboard.Stop();
                }
            }
        }
    }
}
