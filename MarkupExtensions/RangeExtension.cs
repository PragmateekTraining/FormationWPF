using System;
using System.Globalization;
using System.Linq;
using System.Windows.Markup;

namespace MarkupExtensions
{
    public class RangeExtension : MarkupExtension
    {
        private decimal from;
        private decimal to;
        private decimal step;

        public RangeExtension(object from, object to, object step)
        {
            this.from = Convert.ToDecimal(from, CultureInfo.InvariantCulture);
            this.to = Convert.ToDecimal(to, CultureInfo.InvariantCulture);
            this.step = Convert.ToDecimal(step ?? 1.0m, CultureInfo.InvariantCulture);
        }

        public RangeExtension(object from, object to)
            : this(from, to, 1.0m)
        {
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enumerable.Range(0, (int)((to - from + step) / step)).Select(i => from + i * step);
        }
    }
}
