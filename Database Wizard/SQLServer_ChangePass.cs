using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Database_Wizard
{
    public partial class SQLServer_ChangePass : Form
    {
        private string masterConnString = $"Server={Environment.MachineName};Database=master;Trusted_Connection=True;";
        public SQLServer_ChangePass()
        {
            InitializeComponent();
            cbProject.SelectedIndex = 0;
        }

        //save
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if((txtPass.Text != txtConf.Text) || txtPass.Text == "")
            {
                if(txtPass.Text == "" && txtConf.Text == "")
                    MessageBox.Show("Please enter new password", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Passwords didn't match", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string password = txtPass.Text ;
            try
            {
                using (SqlConnection con = new SqlConnection(masterConnString))
                {
                    con.Open();
                    string query = $"ALTER LOGIN sa WITH PASSWORD = '{password}'";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
                MessageBox.Show("Password Changed Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Source : sa\n\nDescription : {ex.Message}", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //change password
        private void button1_Click(object sender, EventArgs e)
        {
            string password = "";
            if(cbProject.Text == "150")
            {
                password = "WelC0me_pass@WtiL$kioSK*12017";
            }
            else if(cbProject.Text == "63")
            {
                password = "WelC0me_pass@WtiL$kioSK125*52017";
            }
            else if(cbProject.Text == "210")
            {
                password = "WelC0me_pass@WtiL$kioSK*32017";
            }
            else
            {
                MessageBox.Show("Error in Application", "Error");
            }

            try
            {
                using (SqlConnection con = new SqlConnection(masterConnString))
                {
                    con.Open();
                    string query = $"ALTER LOGIN sa WITH PASSWORD = '{password}'";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
                MessageBox.Show("Password Changed Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Source : sa\n\nDescription : {ex.Message}", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
