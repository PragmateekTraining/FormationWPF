using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.ViewModels
{
    public class ComputersViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public ObservableCollection<Computer> Computers { get; set; }

        private Computer selectedComputer;
        public Computer SelectedComputer
        {
            get
            {
                return selectedComputer;
            }
            set
            {
                if (value != selectedComputer)
                {
                    selectedComputer = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedComputer"));
                }
            }
        }

        public ComputersViewModel()
        {
            Computers = new ObservableCollection<Computer>
            {
                new Computer { Name = "Home"},
                new Computer { Name = "Work"}
            };
        }

        public void CreateNewComputer()
        {
            Computers.Add(new Computer { Name = "New computer" });
        }
    }
}
