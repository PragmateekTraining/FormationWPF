using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using WpfApplication;

namespace WpfIntegration
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            UserDataViewModel model = new UserDataViewModel { FirstName = "...", LastName = "..." };

            UserDataControl wpfControl = new UserDataControl { Model = model };
            wpfControl.DataUpdated += (s, a) =>
                {
                    MessageBox.Show(string.Format("Latest data are ({0}, {1}).", model.FirstName, model.LastName));
                };

            ElementHost host = new ElementHost{ Child = wpfControl, Dock = DockStyle.Fill };

            this.Controls.Add(host);
        }
    }
}
