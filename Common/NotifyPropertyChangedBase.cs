using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Common
{
    public abstract class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        protected bool UpdateAndNotify<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            bool wasChanged = false;

            if (!EqualityComparer<T>.Default.Equals(value, field))
            {
                field = value;
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                wasChanged = true;
            }

            return wasChanged;
        }

        protected void Notify([CallerMemberName] string propertyName = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
