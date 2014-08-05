using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum Sex
    {
        Unspecified = 0,
        Female,
        Male        
    }

    public class RegistrationData : INotifyPropertyChanged
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public Sex Sex { get; set; }
        public uint ProtectionLevel { get; set; }

        private bool isAccepted;
        public bool IsAccepted
        {
            get { return isAccepted; }
            set
            {
                if (value != isAccepted)
                {
                    isAccepted = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("IsAccepted"));
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
