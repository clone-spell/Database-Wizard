using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Database_Wizard
{
    public partial class Edit_fSettings : Form
    {
        public Edit_fSettings()
        {
            InitializeComponent();
            cbDatabase.SelectedIndex = 0;
        }



        private void LoadfSettings(string database)
        {
            string connStr = $"Data Source={Environment.MachineName};Initial Catalog={database};Integrated Security=SSPI;";
            try
            {
                SqlConnection conn = new SqlConnection(connStr);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand("Select * from fsettings", conn);
                DataTable dt = new DataTable();

                adapter.Fill(dt);


                dgvWelkin.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            lblfSettings.Text = "fSettings - " + database;
        }

        private void dgvWelkin_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Get the new value from the changed cell
            object newValue = dgvWelkin.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            string column = dgvWelkin.Columns[e.ColumnIndex].Name;

            SqlConnection connection = new SqlConnection($"Data Source={Environment.MachineName};Initial Catalog={cbDatabase.Text};Integrated Security=SSPI;");
            using (SqlCommand updateCommand = new SqlCommand($"UPDATE fsettings SET {column} = @NewValue WHERE ID = @PrimaryKey", connection))
            {
                updateCommand.Parameters.AddWithValue("@NewValue", newValue);
                updateCommand.Parameters.AddWithValue("@PrimaryKey", dgvWelkin.Rows[e.RowIndex].Cells["ID"].Value);

                connection.Open();
                updateCommand.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            LoadfSettings(cbDatabase.Text);
        }
    }
}
