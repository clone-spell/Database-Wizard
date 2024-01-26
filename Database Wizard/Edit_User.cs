using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Database_Wizard
{
    public partial class Edit_User : Form
    {
        private string connStr;
        private string userTabelId;
        public Edit_User()
        {
            InitializeComponent();
            cbDatabase.SelectedIndex = 0;
        }

        private void LoadUser(string database)
        {
            txtPass.Clear();
            txtUserType.Clear();
            txtUserId.Clear();
            listView1.Items.Clear();
            userTabelId = "";
            try
            {
                connStr = $"Data Source={Environment.MachineName};Initial Catalog={database};Integrated Security=SSPI;";
                using(SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();
                    using(SqlCommand cmd = new SqlCommand("Select ID, UserID, Pwd, UserType from Users", con))
                    {
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ListViewItem listViewItem = new ListViewItem(reader["ID"].ToString());
                                listViewItem.SubItems.Add(reader["UserID"].ToString());
                                listViewItem.SubItems.Add(reader["Pwd"].ToString());
                                listViewItem.SubItems.Add(reader["UserType"].ToString());

                                listView1.Items.Add(listViewItem);
                            }
                        }
                    }
                    con.Close();
                }
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
            connStr = $"Data Source={Environment.MachineName};Initial Catalog={cbDatabase.Text};Integrated Security=SSPI;";
            
            string query;
            if (txtUserId.Text != "" && txtPass.Text != "" && txtUserType.Text != "")
            {
                if (userTabelId == "")
                    query = $"insert into Users (UserID, PWD, UserType) Values ('{txtUserId.Text}', '{txtPass.Text}', '{txtUserType.Text}');";
                else
                    query = $"update Users set UserID='{txtUserId.Text}', PWD='{txtPass.Text}', UserType='{txtUserType.Text}' where id={userTabelId};";
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
                MessageBox.Show($"Message : Unable to Save {txtUserType.Text} name\n\nDescription : {ex.Message}");
            }
            LoadUser(cbDatabase.Text);
        }


        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userTabelId = listView1.FocusedItem.SubItems[0].Text;
            txtUserId.Text = listView1.FocusedItem.SubItems[1].Text;
            txtPass.Text = listView1.FocusedItem.SubItems[2].Text;
            txtUserType.Text = listView1.FocusedItem.SubItems[3].Text;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = listView1.FocusedItem.SubItems[0].Text;
            DialogResult r = MessageBox.Show($"Do you want to delete {listView1.FocusedItem.SubItems[3].Text}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

            LoadUser(cbDatabase.Text);
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView1.FocusedItem != null)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }
    }
}
