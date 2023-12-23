using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Wizard
{
    public partial class Home : Form
    {
        private DateTime exp = DateTime.Parse("01/01/2024");
        private Form activeForm;
        public Home()
        {
            InitializeComponent();
        }
        private void Home_Load(object sender, EventArgs e)
        {
            if(exp <= DateTime.Now)
            {
                sqlServerToolStripMenuItem.Enabled = false;
                editToolStripMenuItem.Enabled = false;
                toolsInfoToolStripMenuItem.Enabled = false;
                MessageBox.Show("Please Contact Developer","Application Expired", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                aboutToolStripMenuItem.PerformClick();

            }
            LoginForm loginForm = new LoginForm();
            DialogResult dialogLogin = loginForm.ShowDialog();

            if(dialogLogin != DialogResult.OK)
            {
                Application.Exit();
            }
        }


        //methods
        private void ShowFormInPanel(Form form)
        {
            label1.Hide();
            if (activeForm != null)
                activeForm.Close();

            activeForm = form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            panelFrag.Controls.Add(form);
            panelFrag.Tag = form;
            form.Show();
        }






        //sql server menu item clicks

        private void startDatabasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Under Development");
        }

        private void stopSQLServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Under Development");
        }
        private void databasesSQLServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new SQLServer_Databases());
        }

        private void changePassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new SQLServer_ChangePass());
        }

        private void servicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("services.msc");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Open Services Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        //edit menu item clicks
        private void changeFSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new Edit_fSettings());
        }

        private void daywiseTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new Edit_Tran_Daywise());
        }

        private void duplicateReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new Edit_Tran_Duplicate());
        }

        private void nonPostedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new Edit_Tran_Non_Posted());
        }

        private void serviceEngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new Edit_ServiceEng());
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new Edit_User());
        }

        private void customQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new Edit_Custom_Query());
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new About());
        }

        
    }
}
