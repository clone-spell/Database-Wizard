using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Wizard
{
    public partial class Edit_Custom_Query : Form
    {
        private readonly string[] sqlKeywords = {
        "SELECT", "INSERT", "UPDATE", "DELETE",
        "FROM", "WHERE", "JOIN", "LEFT", "RIGHT", "INNER", "OUTER",
        "GROUP", "BY", "ORDER", "HAVING",
        "AND", "OR", "NOT",
        "NULL", "IS", "LIKE",
        "AS", "DISTINCT", "TOP",
        "INTO", "VALUES", "SET",
        "CREATE", "TABLE", "ALTER", "DROP",
        "INDEX", "VIEW", "PROCEDURE", "FUNCTION",
        "UNION", "ALL",
        "CASE", "WHEN", "THEN", "ELSE", "END",
        "ON", "USING",
        "ASC", "DESC",
        "LIMIT", "OFFSET",
        "BETWEEN", "IN",
        "JOIN", "CROSS", "NATURAL",
        "COUNT", "SUM", "AVG", "MAX", "MIN"
        };
        public Edit_Custom_Query()
        {
            InitializeComponent();
            KeyPreview = true;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            string connStr = $"Data Source={Environment.MachineName};Initial Catalog={cbDatabase.Text};Integrated Security=SSPI;";
            string query = richTextBox1.Text;
            try
            {
                using(SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    if(query.StartsWith("SELECT", StringComparison.OrdinalIgnoreCase))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridView.DataSource = dt;
                    }
                    else
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            int n = cmd.ExecuteNonQuery();
                            MessageBox.Show($"{n} rows effected", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DataTable dt = new DataTable();
                            dt.Clear();
                            dataGridView.DataSource = dt;
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

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void ColorKeywords(RichTextBox richTextBox)
        {
            string text = richTextBox.Text;
            richTextBox.SelectionStart = 0;
            richTextBox.SelectionLength = text.Length;
            richTextBox.SelectionColor = Color.Black; // Default color

            foreach (string keyword in sqlKeywords)
            {
                MatchCollection matches = Regex.Matches(text, "\\b" + keyword + "\\b", RegexOptions.IgnoreCase);
                foreach (Match match in matches)
                {
                    richTextBox.SelectionStart = match.Index;
                    richTextBox.SelectionLength = match.Length;
                    richTextBox.SelectionColor = Color.HotPink;
                }
            }

            richTextBox.SelectionStart = text.Length;
            richTextBox.SelectionLength = 0;
            richTextBox.SelectionColor = Color.Black; // Reset color
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                ColorKeywords(richTextBox1);
            }
        }

        private void Edit_Custom_Query_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.X)
            {
                e.SuppressKeyPress = true;
                btnRun.PerformClick();
            }
        }
    }
}
