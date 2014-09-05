using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Common
{
    public abstract class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        protected void UpdateAndNotify<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(value, field))
            {
                field = value;
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
