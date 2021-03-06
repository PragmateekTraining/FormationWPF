﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;

namespace INPC
{
    public class NotifyPropertyChangedImpl_Simple : DependencyObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void UpdateAndNotify<T>(ref T field, T value, string propertyName)
        {
            if (!EqualityComparer<T>.Default.Equals(value, field))
            {
                field = value;

                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class NotifyPropertyChangedImpl_TypeSafe : DependencyObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void UpdateAndNotify<T>(ref T field, T value, Expression<Func<T>> expression)
        {
            if (!EqualityComparer<T>.Default.Equals(value, field))
            {
                field = value;

                MemberExpression me = expression.Body as MemberExpression;

                PropertyInfo pi = me.Member as PropertyInfo;

                PropertyChanged(this, new PropertyChangedEventArgs(pi.Name));
            }
        }
    }

    public class NotifyPropertyChangedImpl_CSharp5 : DependencyObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void UpdateAndNotify<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(value, field))
            {
                field = value;

                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class NotifyPropertyChangedImpl_Bad : DependencyObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void UpdateAndNotify<T>(T newValue)
        {
            StackFrame sf = new StackFrame(1);

            MethodBase m = sf.GetMethod();

            string propertyName = m.Name.Substring(4);

            PropertyInfo property = this.GetType().GetProperty(propertyName);

            T oldValue = (T)property.GetValue(this, null);

            if (!EqualityComparer<T>.Default.Equals(newValue, oldValue))
            {
                FieldInfo backingField = this.GetType().GetField(char.ToLower(property.Name[0]) + property.Name.Substring(1), BindingFlags.NonPublic | BindingFlags.Instance);

                backingField.SetValue(this, newValue);

                PropertyChanged(this, new PropertyChangedEventArgs(property.Name));
            }
        }
    }

    class Program
    {
        interface IA
        {
            int N { get; set; }
        }

        class A_Simple : NotifyPropertyChangedImpl_Simple, IA
        {
            private int n;
            public int N
            {
                get { return n; }
                set { UpdateAndNotify(ref n, value, "N"); }
            }

            public override string ToString()
            {
                return "A_Simple";
            }
        }

        class A_TypeSafe : NotifyPropertyChangedImpl_TypeSafe, IA
        {
            private int n;
            public int N
            {
                get { return n; }
                set { UpdateAndNotify(ref n, value, () => N); }
            }

            public override string ToString()
            {
                return "A_TypeSafe";
            }
        }

        class A_CSharp5 : NotifyPropertyChangedImpl_CSharp5, IA
        {
            private int n;
            public int N
            {
                get { return n; }
                set { UpdateAndNotify(ref n, value); }
            }

            public override string ToString()
            {
                return "A_CSharp5";
            }
        }

        class A_Bad : NotifyPropertyChangedImpl_Bad, IA
        {
            private int n;
            public int N
            {
                get { return n; }
                set { UpdateAndNotify(value); }
            }

            public override string ToString()
            {
                return "A_Bad";
            }
        }

        static void Main(string[] args)
        {
            A_Simple a_simple = new A_Simple();
            A_TypeSafe a_typeSafe = new A_TypeSafe();
            A_CSharp5 a_CSharp5 = new A_CSharp5();
            A_Bad a_Bad = new A_Bad();

            PropertyChangedEventHandler onPropertyChanged = (s, a) =>
                {
                    if (a.PropertyName == "N")
                    {
                        Console.WriteLine("New value of N for '{0}' is {1}.", s, (s as IA).N);
                    }
                };

            a_simple.PropertyChanged += onPropertyChanged;
            a_typeSafe.PropertyChanged += onPropertyChanged;
            a_CSharp5.PropertyChanged += onPropertyChanged;
            a_Bad.PropertyChanged += onPropertyChanged;

            a_simple.N = 1;
            a_typeSafe.N = 1;
            a_CSharp5.N = 1;
            a_Bad.N = 1;

            Console.WriteLine(new string('=', 20));

            a_simple.N = 1;
            a_typeSafe.N = 1;
            a_CSharp5.N = 1;
            a_Bad.N = 1;

            Console.WriteLine(new string('=', 20));

            a_simple.N = 2;
            a_typeSafe.N = 2;
            a_CSharp5.N = 2;
            a_Bad.N = 2;

            Console.WriteLine(new string('=', 20));

            a_simple.N = 3;
            a_typeSafe.N = 3;
            a_CSharp5.N = 3;
            a_Bad.N = 3;

            Console.ReadLine();
        }
    }
}
