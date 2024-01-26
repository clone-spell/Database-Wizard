using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Database_Wizard
{
    public partial class SQLServer_Databases : Form
    {
        private string masterConnString = $"Server={Environment.MachineName};Database=master;Trusted_Connection=True;";
        public SQLServer_Databases()
        {
            InitializeComponent();
        }



        //methods
        private void loadDatabases()
        {
            try
            {
                listView1.Items.Clear();
                using(SqlConnection connection = new SqlConnection(masterConnString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SELECT database_id, name, state_desc, create_date FROM sys.databases WHERE database_id > 4", connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader["database_id"].ToString());
                            item.SubItems.Add(reader["name"].ToString());
                            item.SubItems.Add(reader["state_desc"].ToString());
                            item.SubItems.Add(reader["create_date"].ToString());

                            listView1.Items.Add(item);
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Source : Load Databases\n\nDescription : {ex.Message}", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteDatabase(string databaseName)
        {
            DialogResult r = MessageBox.Show($"Do you realy want to delete {databaseName}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection connection = new SqlConnection(masterConnString))
                {
                    connection.Open();

                    string deleteQuery = $"DROP DATABASE [{databaseName}]";
                    SqlCommand cmd = new SqlCommand(deleteQuery, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Source : Delete Database\n\nDescription : {ex.Message}", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AttachDatabase()
        {
            try
            {
                string dbPath = "";
                string dbLogPath = "";
                string dbName = "";


                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = @"D:\";
                openFileDialog.Multiselect = true;
                openFileDialog.Filter = "Database Files|*.mdf;*.ldf|All Files|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] selectedFiles = openFileDialog.FileNames;
                    foreach (string file in selectedFiles)
                    {
                        if (file.EndsWith(".mdf"))
                        {
                            dbPath = file;
                        }
                        else if (file.EndsWith(".ldf"))
                        {
                            dbLogPath = file;
                        }
                        else
                        {
                            MessageBox.Show("File Format not supported", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    dbName = System.IO.Path.GetFileName(dbPath).Substring(0, System.IO.Path.GetFileName(dbPath).IndexOf('.'));



                    using (SqlConnection connection = new SqlConnection(masterConnString))
                    {
                        connection.Open();

                        string attachQuery = $"sp_attach_db '{dbName}','{dbPath}','{dbLogPath}'";

                        SqlCommand cmd = new SqlCommand(attachQuery, connection);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Source : Attach Database\n\nDescription : {ex.Message}", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DetachDatabase(string databaseName)
        {
            DialogResult r = MessageBox.Show($"Do you realy want to detach {databaseName}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection connection = new SqlConnection(masterConnString))
                {
                    connection.Open();

                    string detachQuery = $"EXEC sp_detach_db '{databaseName}'";
                    SqlCommand cmd = new SqlCommand(detachQuery, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Source : Detach Database\n\nDescription : {ex.Message}", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //load form
        private void SQLServer_Databases_Load(object sender, EventArgs e)
        {
            loadDatabases();
        }



        //button clicks
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView1.FocusedItem != null)
                {
                    contextMenuStrip.Show(Cursor.Position);
                }
            }
        }

        private void btnAddDatabase_Click(object sender, EventArgs e)
        {
            AttachDatabase();
            loadDatabases();
        }

        private void detachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetachDatabase(listView1.FocusedItem.SubItems[1].Text);
            loadDatabases();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteDatabase(listView1.FocusedItem.SubItems[1].Text);
            loadDatabases();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadDatabases();
        }
    }
}
