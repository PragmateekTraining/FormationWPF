using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Validation
{
    public class RegistrationViewModel : INotifyDataErrorInfo
    {
        private static readonly Regex nameRegex = new Regex(@"^[a-zA-Z]+\-?.[a-zA-Z]+$", RegexOptions.Compiled);

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                Validate();
            }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                Validate();
            }
        }

        private DateTime dateOfBirth;
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                dateOfBirth = value;
                Validate();
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                Validate();
            }
        }

        private string passwordConfirmation;
        public string PasswordConfirmation
        {
            get { return passwordConfirmation; }
            set
            {
                passwordConfirmation = value;
                Validate();
            }
        }

        private IDictionary<string, IEnumerable<string>> errors = new Dictionary<string, IEnumerable<string>>();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged = delegate { };

        public IEnumerable GetErrors(string propertyName)
        {
            return errors.ContainsKey(propertyName) ? errors[propertyName] : Enumerable.Empty<string>();
        }

        public bool HasErrors
        {
            get { return errors.Any(p => p.Value.Count() != 0); }
        }

        public RegistrationViewModel()
        {
            dateOfBirth = new DateTime(2000, 01, 01);
            password = "";
            passwordConfirmation = "";
            Validate();
        }

        private void Validate()
        {
            if (nameRegex.IsMatch(firstName ?? ""))
            {
                errors["FirstName"] = Enumerable.Empty<string>();
            }
            else
            {
                errors["FirstName"] = new[] { "First name must be at least two characters long and can only contain letters!" };
            }

            if (nameRegex.IsMatch(lastName ?? ""))
            {
                errors["LastName"] = Enumerable.Empty<string>();
            }
            else
            {
                errors["LastName"] = new[] { "Last name must be at least two characters long and can only contain letters!" };
            }

            if (dateOfBirth < DateTime.UtcNow)
            {
                errors["DateOfBirth"] = Enumerable.Empty<string>();
            }
            else
            {
                errors["DateOfBirth"] = new[] { "Sorry, but we don't accept time travelers!" }; ;
            }

            if (password.Length >= 3)
            {
                errors["Password"] = Enumerable.Empty<string>();
            }
            else
            {
                errors["Password"] = new[] { "Password must be at least 3 characters long!" };
            }

            if (passwordConfirmation == password)
            {                
                errors["PasswordConfirmation"] = Enumerable.Empty<string>();
            }
            else
            {
                errors["PasswordConfirmation"] = new[] { "Confirmation must match password!" };
            }

            ErrorsChanged(this, new DataErrorsChangedEventArgs("FirstName"));
            ErrorsChanged(this, new DataErrorsChangedEventArgs("LastName"));
            ErrorsChanged(this, new DataErrorsChangedEventArgs("DateOfBirth"));
            ErrorsChanged(this, new DataErrorsChangedEventArgs("Password"));
            ErrorsChanged(this, new DataErrorsChangedEventArgs("PasswordConfirmation"));
        }
    }
}
