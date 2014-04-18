using System;
using System.Windows;

namespace NoWPF
{
    class RawDependencyPropertySample
    {
        public void Run()
        {
            DependencyProperty property = DependencyProperty.Register("**Interesting facts**", typeof(string), typeof(DependencyObject), new PropertyMetadata("..."));

            DependencyObject myObject = new DependencyObject();

            Console.WriteLine("Initial value: '{0}'", myObject.GetValue(property));

            myObject.SetValue(property, "Chuck Norris counted to infinity - twice.");

            Console.WriteLine("Final value: '{0}'", myObject.GetValue(property));
        }
    }
}
