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
    public partial class Edit_Tran_Non_Posted : Form
    {
        private string connStr = $"Data Source={Environment.MachineName};Initial Catalog=WelkinATP;Integrated Security=SSPI;";
        public Edit_Tran_Non_Posted()
        {
            InitializeComponent();
            cbDatabase.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string dateTime = dateTimePicker.Value.ToString("yyyy-MM-dd");
            LoadTransactions(dateTime);
        }

        private void LoadTransactions(string date)
        {
            connStr = $"Data Source={Environment.MachineName};Initial Catalog={cbDatabase.Text};Integrated Security=SSPI;";
            try
            {
                string query = $"Select * from transactions where (PAY_DT >= '{date} 00:00:00.000' and PAY_DT <= '{date} 23:59:59.999') and (SAPUPDATEDYN = 'N' or SERVERUPDATEDYN='N')";
                SqlConnection conn = new SqlConnection(connStr);
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to load transactions\n\nDescription : {ex.Message}", "Load Failed");
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            object newValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            string column = dataGridView1.Columns[e.ColumnIndex].Name;

            SqlConnection connection = new SqlConnection($"Data Source={Environment.MachineName};Initial Catalog={cbDatabase.Text};Integrated Security=SSPI;");
            using (SqlCommand updateCommand = new SqlCommand($"UPDATE Transactions SET {column} = @NewValue WHERE SLNO = @PrimaryKey", connection))
            {
                updateCommand.Parameters.AddWithValue("@NewValue", newValue);
                updateCommand.Parameters.AddWithValue("@PrimaryKey", dataGridView1.Rows[e.RowIndex].Cells["slno"].Value);

                connection.Open();
                updateCommand.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
