using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Wizard
{
    public partial class Edit_User : Form
    {
        private string connStr;
        public Edit_User()
        {
            InitializeComponent();
        }

        private void LoadUser(string database)
        {
            try
            {
                connStr = $"Data Source={Environment.MachineName};Initial Catalog={database};Integrated Security=SSPI;";
                SqlConnection conn = new SqlConnection(connStr);
                SqlDataAdapter adapter = new SqlDataAdapter("Select * from Users", conn);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnGenerate_Click(object sender, EventArgs e)
        {
            LoadUser(cbDatabase.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbDatabase.Text != "")
            {
                connStr = $"Data Source={Environment.MachineName};Initial Catalog={cbDatabase.Text};Integrated Security=SSPI;";
            }
            else
            {
                MessageBox.Show("Select a database first");
                return;
            }
            string query;
            if (txtUserId.Text != "" && txtPass.Text != "" && txtUserType.Text != "")
            {
                query = $"insert into Users (UserID, PWD, UserType) Values ('{txtUserId.Text}', '{txtPass.Text}', '{txtUserType.Text}')";
            }
            else
            {
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Message : Unable to insert {txtUserId.Text} name\n\nDescription : {ex.Message}");
            }
            txtPass.Clear();
            txtUserType.Clear();
            txtUserId.Clear();
            LoadUser(cbDatabase.Text);
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (dataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                string id = selectedRow.Cells["ID"].Value.ToString();
                DialogResult r = MessageBox.Show($"Do you want to delete {selectedRow.Cells["Usertype"].Value}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r != DialogResult.Yes)
                    return;
                try
                {
                    SqlConnection conn = new SqlConnection(connStr);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand($"delete from Users where id='{id}';", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Select a row to delete");
            }

            LoadUser(cbDatabase.Text);
        }
    }
}
