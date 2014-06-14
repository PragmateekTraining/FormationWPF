using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;

namespace NoWPF
{
    class Data
    {
        public IDictionary<string, string[]> Messages
        {
            get
            {
                return new Dictionary<string, string[]>
                {
                    { "English", new []{ "Hello", "World" } },
                    { "French", new []{ "Bonjour", "Monde" } }
                };
            }
        }
    }

    class PropertyPathSample
    {
        public void Run()
        {
            DependencyProperty property = DependencyProperty.Register("Length", typeof(int), typeof(DependencyObject));

            Data source = new Data();
            DependencyObject destination = new DependencyObject();

            Binding binding = new Binding
            {
                Source = source,
                Path = new PropertyPath("Messages[French][1].Length"),
                Mode = BindingMode.OneWay,
            };

            BindingOperations.SetBinding(destination, property, binding);

            Console.WriteLine("Length is {0}.", destination.GetValue(property));
        }
    }
}
