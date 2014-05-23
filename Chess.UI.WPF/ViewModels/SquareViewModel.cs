using Chess.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.UI.WPF
{
    public class SquareViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private Square square = null;
        public Square Square
        {
            get
            {
                return square;
            }
            set
            {
                if (value != square)
                {
                    square = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Square"));
                }
            }
        }
    }
}
