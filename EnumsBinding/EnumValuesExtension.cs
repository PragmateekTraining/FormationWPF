using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Markup;

namespace EnumsBinding
{
    public class EnumValuesExtension : MarkupExtension
    {
        private readonly Type type;

        public bool ValueAndDescription { get; set; }

        public EnumValuesExtension(Type type)
        {
            this.type = type;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            Array values = Enum.GetValues(type);

            if (!ValueAndDescription)
            {
                return values;
            }

            return values.Cast<object>()
                         .Select(o => new
                         {
                             Value = o,
                             DescriptionAttribute = type.GetField(o.ToString())
                                                        .GetCustomAttributes(typeof(DescriptionAttribute), false)
                                                        .SingleOrDefault() as DescriptionAttribute
                         })
                         .Select(o => new
                         {
                            Value = o.Value,
                            Description = o.DescriptionAttribute != null ? o.DescriptionAttribute.Description : o.Value.ToString()
                         });
        }
    }
}
