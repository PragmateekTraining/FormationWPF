using System;
using System.Windows.Markup;

namespace Xaml
{
    public class RandomExtension : MarkupExtension
    {
        private static readonly Random rand = new Random();

        public int Min { get; set; }

        public int Max { get; set; }

        public RandomExtension()
        {
        }

        public RandomExtension(int min)
        {
            Min = min;
        }

        public RandomExtension(int min, int max)
        {
            Min = min;
            Max = max;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return rand.Next(Min, Max);
        }
    }
}
