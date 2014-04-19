using System;
using System.Windows;
using System.Windows.Data;

namespace NoWPF
{
    class RawDataBindingSample
    {
        public void Run()
        {
            DependencyProperty property = DependencyProperty.Register("**Interesting facts**", typeof(string), typeof(DependencyObject), new PropertyMetadata("..."));

            DependencyObject source = new DependencyObject();
            DependencyObject destination = new DependencyObject();

            Binding binding = new Binding
            {
                Source = source,
                Path = new PropertyPath("**Interesting facts**"),
                Mode = BindingMode.TwoWay
            };

            BindingOperations.SetBinding(destination, property, binding);

            Console.WriteLine("Source initial value: '{0}'.", source.GetValue(property));
            Console.WriteLine("Destination initial value: '{0}'.", destination.GetValue(property));

            source.SetValue(property, "Water wets.");

            Console.WriteLine("Source intermediate value: '{0}'.", source.GetValue(property));
            Console.WriteLine("Destination intermediate value: '{0}'.", destination.GetValue(property));

            destination.SetValue(property, "The sky is blue.");

            Console.WriteLine("Source final value: '{0}'.", source.GetValue(property));
            Console.WriteLine("Destination final value: '{0}'.", destination.GetValue(property));
        }
    }
}
