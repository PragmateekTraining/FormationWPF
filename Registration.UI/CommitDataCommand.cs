using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVM
{
    /// <summary>
    /// 
    /// </summary>
    public class CommitDataCommand : ICommand
    {
        private RegistrationData data;

        public CommitDataCommand(RegistrationData data)
        {
            this.data = data;

            data.PropertyChanged += data_PropertyChanged;
        }

        void data_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }

        public bool CanExecute(object parameter)
        {
            // RegistrationData data =  (RegistrationData)parameter;

            return data != null && data.IsAccepted;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            // RegistrationData data = (RegistrationData)parameter;

            string title = data.Sex == Sex.Female ? "Ms. " :
                data.Sex == Sex.Male ? "Mr. " :
                "";
            
            MessageBox.Show(string.Format("Hello {0}{1} {2}.", title, data.FirstName, data.LastName));
        }
    }
}
