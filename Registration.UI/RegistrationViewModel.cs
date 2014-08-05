using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace MVVM
{
    public class RegistrationViewModel
    {
        public RegistrationData RegistrationData { get; set; }

        public ICommand CommitData { get; set; }

        /*/// <summary>
        /// izaondoiazndaiodnaizndaziond
        /// </summary>
        public ICommand CD
        {
            get
            {
                /// Generte commid command
                return new DelegateCommand(
                    parameter =>
                    {
                        RegistrationData data = (RegistrationData)parameter;

                        MessageBox.Show(string.Format("Hello {0} {1}.", data.FirstName, data.LastName));
                    }
                ,parameter => (parameter as RegistrationData).IsAccepted
            }
        }*/

        /*public void CommitData()
        {
            
        }*/
    }
}
