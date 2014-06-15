using System;
using System.Windows.Forms;

namespace WindowsFormsApplication
{
    public partial class UserDataControl : UserControl
    {
        TextBox firstNameInput = new TextBox();
        TextBox lastNameInput = new TextBox();
        Button button = new Button { Text = "OK" };

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                firstNameInput.Text = firstName;
            }
        }
        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                lastNameInput.Text = lastName;
            }
        }

        public event EventHandler DataUpdated = delegate { };

        public UserDataControl()
        {
            InitializeComponent();

            TableLayoutPanel panel = new TableLayoutPanel
            {
                RowCount = 3,
                ColumnCount = 2,
                Dock = DockStyle.Fill
            };

            panel.Controls.Add(new Label { Text = "First Name : " }, 0, 0);
            panel.Controls.Add(firstNameInput, 1, 0);

            panel.Controls.Add(new Label { Text = "Last Name : " }, 0, 1);
            panel.Controls.Add(lastNameInput, 1, 1);

            panel.Controls.Add(button, 0, 2);
            panel.SetColumnSpan(button, 2);

            GroupBox groupBox = new GroupBox { Text = "User", Dock = DockStyle.Fill };
            groupBox.Controls.Add(panel);

            this.Controls.Add(groupBox);

            button.Click += (s, a) =>
            {
                FirstName = firstNameInput.Text;
                LastName = lastNameInput.Text;
                DataUpdated(this, EventArgs.Empty);
            };
        }
    }
}
