using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace IssueTracking
{
    public partial class Edit_form : Form
    {
        public Edit_form()
        {
            InitializeComponent();
            
        }

        private void Edit_form_Load(object sender, EventArgs e)
        {
            textBox1.Text = Form2.title;
            textBox2.Text = Form2.proj;
            richTextBox1.Text = Form2.desc;
            comboBox1.Text = Form2.status;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string proj = textBox2.Text;
            string title = textBox1.Text;
            string desc = richTextBox1.Text;
            string status = comboBox1.Text;
            string value = Form2.id;
            status = status.ToUpper();

            switch (status)
            {
                case "NEW":
                    status = "1";
                    break;
                case "IN PROGRESS":
                    status = "2";
                    break;
                case "COMPLETED":
                    status = "3";
                    break;
                case "WONT FIX":
                    status = "4";
                    break;
            }

            string query = $"update issue set Issue_title='{title}', Issue_desc='{desc}', Stat_id={status} where Issue_id={value};";
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "team2db.cy1sebpofkho.us-east-2.rds.amazonaws.com";
            conn_string.UserID = "team2";
            conn_string.Password = "Testpassword1";
            conn_string.Database = "ticket_master";
            conn_string.Port = 3306;


            using (MySqlConnection connection = new MySqlConnection(conn_string.ToString()))
            {
                connection.Open();
                try
                {
                    using (MySqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = query;
                        command.ExecuteNonQuery();
                    }
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                        this.Close();
                    }
                }
            }

        }
    }
}
