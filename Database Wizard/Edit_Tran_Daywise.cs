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
    public partial class Edit_Tran_Daywise : Form
    {
        private string connStr = $"Data Source={Environment.MachineName};Initial Catalog=WelkinATP;Integrated Security=SSPI;";
        public Edit_Tran_Daywise()
        {
            InitializeComponent();
            cbDatabase.SelectedIndex = 0;
        }
        private void LoadTransactions(string date)
        {
            connStr = $"Data Source={Environment.MachineName};Initial Catalog={cbDatabase.Text};Integrated Security=SSPI;";
            string query = $"Select CON_ID, CON_NO, NAME, BILLAMOUNT, AMOUNT, RCPTNO, SERVERUPDATEDYN, SAPUPDATEDYN from transactions where PAY_DT >= '{date} 00:00:00.000' and PAY_DT <= '{date} 23:59:59.999' order by rcptno desc";
            try
            {
                SqlConnection conn = new SqlConnection(connStr);
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;

                decimal totalAmt = 0;
                List<string> amounts = new List<string>();
                foreach (DataRow dr in dt.Rows)
                {
                    amounts.Add(dr["AMOUNT"].ToString());
                }

                foreach (string amount in amounts)
                {
                    if (decimal.TryParse(amount, out decimal number))
                    {
                        totalAmt += number;
                    }
                }
                txtTotalTans.Text = dt.Rows.Count.ToString();
                txtTotalAmt.Text = totalAmt.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to load transactions\n\nDescription : {ex.Message}", "Load Failed");
            }
        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string dateTime = dateTimePicker.Value.ToString("yyyy-MM-dd");
            LoadTransactions(dateTime);
        }
    }
}
