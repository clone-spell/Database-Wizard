using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Database_Wizard
{
    public partial class Edit_ServiceEng : Form
    {
        private string connStr;
        private string engId;
        public Edit_ServiceEng()
        {
            InitializeComponent();
            cbDatabase.SelectedIndex = 0;
            txtDesig.SelectedIndex = 0;
        }

        private void LoadServiceEng(string database)
        {
            engId = "";
            txtName.Text = string.Empty;
            txtDesig.SelectedIndex = 0;
            try
            {
                connStr = $"Data Source={Environment.MachineName};Initial Catalog={database};Integrated Security=SSPI;";
                listServiceEng.Items.Clear();
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using(SqlCommand cmd = new SqlCommand("Select ID, Name, CreateDateTime, CSPYN from ServiceEng", conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader["ID"].ToString());
                            item.SubItems.Add(reader["Name"].ToString());
                            item.SubItems.Add(reader["CSPYN"].ToString());
                            item.SubItems.Add(reader["CreateDateTime"].ToString());

                            listServiceEng.Items.Add(item);
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            LoadServiceEng(cbDatabase.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            connStr = $"Data Source={Environment.MachineName};Initial Catalog={cbDatabase.Text};Integrated Security=SSPI;";
            
            string query;
            if(txtName.Text != "")
            {
                if(engId != "")//edit
                {
                    if (txtDesig.Text == "CSP")
                        query = $"update ServiceEng set Name='{txtName.Text.ToUpper()}', CSPYN=1 where id={engId}";
                    else
                        query = $"update ServiceEng set Name='{txtName.Text.ToUpper()}', CSPYN=0 where id={engId}";
                }
                else//create
                {
                    if (txtDesig.Text == "CSP")
                        query = $"insert into ServiceEng (Name, CSPYN, CreateDateTime) Values ('{txtName.Text.ToUpper()}', 1, GETDATE())";
                    else
                        query = $"insert into ServiceEng (Name, CSPYN, CreateDateTime) Values ('{txtName.Text.ToUpper()}', 0, GETDATE())";
                }
            }
            else
            {
                return;
            }
            try
            {
                using(SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using(SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }

                LoadServiceEng(cbDatabase.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Message : Unable to Save {txtName.Text}\n\nDescription : {ex.Message}");
            }
        }

        

        private void listServiceEng_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listServiceEng.FocusedItem != null)
                {
                    contextMenuStrip.Show(Cursor.Position);
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            engId = listServiceEng.FocusedItem.SubItems[0].Text;
            txtName.Text = listServiceEng.FocusedItem.SubItems[1].Text;
            if (listServiceEng.FocusedItem.SubItems[2].Text == "True")
            {
                txtDesig.SelectedIndex = 0;
            }
            else
            {
                txtDesig.SelectedIndex = 1;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = listServiceEng.FocusedItem.SubItems[0].Text;
            DialogResult r = MessageBox.Show($"Do you want to delete {listServiceEng.FocusedItem.SubItems[1].Text}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes)
                return;
            try
            {
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand cmd = new SqlCommand($"delete from serviceEng where id='{id}';", conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                LoadServiceEng(cbDatabase.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
