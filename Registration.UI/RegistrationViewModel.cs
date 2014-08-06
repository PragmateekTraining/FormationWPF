using Model;
using System.Windows;
using System.Windows.Input;

namespace MVVM
{
    public class RegistrationViewModel
    {
        public RegistrationData RegistrationData { get; set; }

        public ICommand CommitData { get; set; }

        public ICommand CommitDataWithRelay { get; set; }

        public RegistrationViewModel()
        {
            RegistrationData data = new RegistrationData
            {
                FirstName = "...",
                LastName = "..."
            };

            RegistrationData = data;

            CommitData = new CommitDataCommand(data);

            RelayCommand commitDataWithRelay = new RelayCommand
            (
                () =>
                {
                    string title = data.Sex == Sex.Female ? "Ms. " :
                                   data.Sex == Sex.Male ? "Mr. " :
                                   "";

                    MessageBox.Show(string.Format("Hello {0}{1} {2}.", title, data.FirstName, data.LastName));
                },
                () => data != null && data.IsAccepted
            );
            data.PropertyChanged += delegate { commitDataWithRelay.RaiseCanExecuteChanged(); };

            CommitDataWithRelay = commitDataWithRelay;
        }
    }
}
