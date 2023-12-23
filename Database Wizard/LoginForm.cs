using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Wizard
{
    public partial class LoginForm : Form
    {
        List<string> _users = new List<string>();
        List<string> _pass = new List<string>();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            panel1.Hide();
            _users.Add("Welkin");
            _pass.Add("wtil");
            _users.Add("Admin");
            _pass.Add("n0!nternet");

            foreach (string user in _users)
            {
                cbUsers.Items.Add(user);
            }

            cbUsers.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            bool accPass = false;
            foreach (string user in cbUsers.Items)
            {
                if (cbUsers.Text == _users[i] && txtPass.Text == _pass[i])
                {
                    DialogResult = DialogResult.OK;
                    accPass = true;
                }
                i++;
            }
            if (!accPass)
            {
                panel1.Show();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }
    }
}
