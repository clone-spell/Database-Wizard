using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Wizard
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();

            string s = "About Our SQL Database Management Application\r\n\r\nWelcome to Database Wizard! We are dedicated to providing you with a powerful and intuitive tool for managing your local SQL databases efficiently. Whether you're an experienced database administrator or just starting out, our application is designed to simplify your database management tasks and empower you to make changes with confidence.\r\n\r\nOur Mission\r\n\r\nAt Database Wizard, our mission is to streamline the process of managing local SQL databases. We understand the complexities and challenges that come with handling databases, from attaching and detaching databases to making structural changes to tables. Our application is built to be a reliable partner in your database management journey, helping you accomplish tasks with precision and speed.\r\n\r\nKey Features\r\n\r\nDatabase Attach and Detach: Our application simplifies the process of attaching and detaching databases. Whether you're connecting to an existing database or detaching one for maintenance, our intuitive interface guides you through the steps, making the process seamless and hassle-free.\r\n\r\nTable Management: Make structural changes to your tables with ease. Our application allows you to modify table schemas, add or remove columns, adjust data types, and more. Stay in control of your data's organization without the stress of complex SQL queries.\r\n\r\nData Integrity: We understand the importance of maintaining data integrity. Our application incorporates safeguards to help prevent accidental data loss or corruption during database operations. Your data's security and reliability are our top priorities.\r\n\r\nUser-Friendly Interface: Whether you're a seasoned database professional or a novice user, our user-friendly interface makes navigation and operation intuitive. You don't need to be an expert to wield the power of our database management tools effectively.\r\n\r\nOur Team\r\n\r\nOur team at Database Wizard consists of dedicated developers and database experts who share a passion for simplifying database management. With a deep understanding of SQL databases and a commitment to user-centered design, we have crafted an application that addresses real-world challenges faced by administrators and developers.\r\n\r\nGet Started\r\n\r\nAre you ready to experience the convenience and efficiency of modern SQL database management? Download our application today and take control of your local databases like never before. Whether you're an individual developer, part of a team, or managing databases for your business, our application is here to support your database management needs.\r\n\r\nThank you for choosing Database Wizard for your SQL database management journey. We are excited to be a part of your success in managing and optimizing your databases. If you have any questions, feedback, or suggestions, feel free to contact us. Your input drives our continuous improvement and innovation.\r\n\r\n";
            richTextBox1.Text = s;
            string c = "[Contact Information: bablushaikh0000@gmail.com]\n\n\n\n\n\n";
            richTextBox1.AppendText(c);

            richTextBox1.Select(richTextBox1.Text.Length - c.Length, c.Length);

            richTextBox1.SelectionColor = Color.Blue;
        }
    }
}
