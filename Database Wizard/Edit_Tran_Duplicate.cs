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
    public partial class Edit_Tran_Duplicate : Form
    {
        private string connStr = $"Data Source={Environment.MachineName};Initial Catalog=WelkinATP;Integrated Security=SSPI;";
        public Edit_Tran_Duplicate()
        {
            InitializeComponent();
            cbDatabase.SelectedIndex = 0;
        }
        private void LoadTransactions(string date)
        {
            connStr = $"Data Source={Environment.MachineName};Initial Catalog={cbDatabase.Text};Integrated Security=SSPI;";
            string query = $"Select CON_ID, CON_NO, NAME, BILLAMOUNT, AMOUNT, RCPTNO, SERVERUPDATEDYN, SAPUPDATEDYN from transactions where PAY_DT >= '{date} 00:00:00.000' and PAY_DT <= '{date} 23:59:59.999' order by RCPTNO";
            try
            {
                SqlConnection conn = new SqlConnection(connStr);
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                List<string> receipts = new List<string>();
                foreach (DataRow dr in dt.Rows)
                {
                    receipts.Add(dr["RCPTNO"].ToString());
                }

                string prevRCPT = "", comRCPT = "";
                foreach (string receipt in receipts)
                {
                    if (receipt == prevRCPT)
                    {
                        comRCPT = receipt;
                        break;
                    }

                    prevRCPT = receipt;
                }

                if (comRCPT != "")
                {
                    query = $"Select SLNO, CON_ID, NAME, AMOUNT, RCPTNO, PAIDBILLMONTH, PAY_DT, OFF_NAME, SERVERUPDATEDYN, SAPUPDATEDYN from transactions where PAY_DT >= '{date} 00:00:00.000' and PAY_DT <= '{date} 23:59:59.999' and RCPTNO = {comRCPT}";
                    adapter = new SqlDataAdapter(query, conn);
                    dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("No Duplicate Transaction found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to load transactions\n\nDescription : {ex.Message}", "Load Failed");
            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            string dateTime = dateTimePicker.Value.ToString("yyyy-MM-dd");
            LoadTransactions(dateTime);
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
                    if(i > 0)
                    {
                        MessageBox.Show("Deleted Successfuly");
                    }
                    else
                    {
                        MessageBox.Show($"{i} rows effected");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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
    }
}
