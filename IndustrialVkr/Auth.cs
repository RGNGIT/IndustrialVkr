using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndustrialVkr
{
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var form = new App(textBoxUsername.Text, comboBoxRole.Text);
            form.Show();

            this.Hide();
        }
    }
}
