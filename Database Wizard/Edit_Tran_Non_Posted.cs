using System;
using System.Data;
using System.Data.SqlClient;
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

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex < 0 && e.RowIndex < dataGridView1.Rows.Count-1) // Right-click on row header cell
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Selected = false;
                }
                dataGridView1.Rows[e.RowIndex].Selected = true;
                contextMenuStrip.Show(Cursor.Position);
            }
        }

        private void copyForRepaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    string s = "REPAYMENT ID DETAILS:\n\n" +
                        $"\nKiosk Name : {selectedRow.Cells["OFF_NAME"].Value}" +
                        $"\nConsumer Name : {selectedRow.Cells["NAME"].Value}" +
                        $"\nConsumer ID : {selectedRow.Cells["CON_ID"].Value}" +
                        $"\nPaid Amount : {selectedRow.Cells["AMOUNT"].Value}" +
                        $"\nPayment Date : {selectedRow.Cells["PAY_DT"].Value}" +
                        $"\nPayment Month : {selectedRow.Cells["PAIDBILLMONTH"].Value}";

                    Clipboard.SetText(s);
                }
                catch
                {

                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connStr = $"Data Source={Environment.MachineName};Initial Catalog={cbDatabase.Text};Integrated Security=SSPI;";

            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string slNO = selectedRow.Cells["SLNO"].Value.ToString();
                DialogResult r = MessageBox.Show($"Do you realy want to delete {selectedRow.Cells["RCPTNO"].Value}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r != DialogResult.Yes)
                    return;

                try
                {
                    SqlConnection conn = new SqlConnection(connStr);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand($"delete from transactions where slno='{slNO}';", conn);
                    int i = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (i > 0)
                    {
                        MessageBox.Show("Deleted Successfuly", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"{i} rows effected", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }



    }
}
