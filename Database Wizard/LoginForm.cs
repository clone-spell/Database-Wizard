using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceProcess;
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

        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("osk.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Description:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSqlServer_Click(object sender, EventArgs e)
        {
            ServiceController[] services = ServiceController.GetServices();
            ServiceController sqlServer = services.Where(x => x.DisplayName.StartsWith("SQL Server (")).FirstOrDefault();
            ServiceController sqlServerAgent = services.Where(x => x.DisplayName.StartsWith("SQL Server Agent (")).FirstOrDefault();


            EnableService(sqlServer);
            EnableService(sqlServerAgent);

            if(sqlServer.StartType == ServiceStartMode.Disabled || sqlServerAgent.StartType == ServiceStartMode.Disabled)
            {
                btnSqlServer.ForeColor = Color.Red;
            }
            else if(sqlServer.Status == ServiceControllerStatus.Stopped)
            {
                btnSqlServer.ForeColor = Color.Yellow;
            }
            else
            {
                btnSqlServer.ForeColor = Color.Green;
            }
        }

        private void EnableService(ServiceController service)
        {
            if(service == null)
            {
                MessageBox.Show("Services Unavailable!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (service.StartType == ServiceStartMode.Disabled)
                {
                    using (Process process = new Process())
                    {
                        process.StartInfo.FileName = "sc";
                        process.StartInfo.Arguments = $"config \"{service.ServiceName}\" start= auto";
                        process.StartInfo.UseShellExecute = false;
                        process.StartInfo.CreateNoWindow = true;
                        process.Start();
                        process.WaitForExit();
                    }
                    MessageBox.Show($"The Service({service.DisplayName}) is Enabled", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"The Service({service.DisplayName}) is Enabled", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (service.Status == ServiceControllerStatus.Stopped)
                {
                    service.Start();
                    MessageBox.Show($"The Service({service.DisplayName}) Started", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"The Service({service.DisplayName}) Started", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error enabling {service.DisplayName}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
