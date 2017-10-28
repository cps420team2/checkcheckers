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
using System.Configuration;

namespace IssueTracking
{
    public partial class Form1 : Form
    {
        Dictionary<string, int> projects = new Dictionary<string, int>();

        private Boolean TxtCheck(string str)
        {
            Boolean check = false;
            if (str.Length >= 3)
            {
                check = str.All(c => Char.IsLetterOrDigit(c) || c.Equals(' '));
                
            }
            return check;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void FormLoad(object sender, EventArgs e)
        {
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
                        command.CommandText = "SELECT * FROM project";
                        using (MySqlDataReader rd = command.ExecuteReader())
                        {
                            while (rd.Read())
                            {
                                projects.Add(rd.GetString(1), rd.GetInt32(0));
                            }
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }
                foreach (KeyValuePair<string, int> entry in projects)
                {
                    Project_CB.Items.Add(entry.Key);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Submit_BT_Click(object sender, EventArgs e)
        {
            Boolean Proj_check = false;
            Boolean Title_check = false;
            Proj_check = TxtCheck(Project_CB.Text);
            Title_check = TxtCheck(Title_RTB.Text);
            if (Proj_check == false || Title_check == false)
            {
                MessageBox.Show("The project name and title should be greater than 3 characters and contain only alphanumeric characters.");
            }
            else { 

                MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
                conn_string.Server = "team2db.cy1sebpofkho.us-east-2.rds.amazonaws.com";
                conn_string.UserID = "team2";
                conn_string.Password = "Testpassword1";
                conn_string.Database = "ticket_master";
                conn_string.Port = 3306;

                using (MySqlConnection connection = new MySqlConnection(conn_string.ToString()))
                {
                    connection.Open();
                    //INSERT INTO `ticket_master`.`issue` (`Issue_title`, `Issue_desc`, `Stat_id`, `Proj_id`) VALUES ('Really Broken', 'not fixable', '1', '1');
                    try
                    {
                        using (MySqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = "INSERT INTO issue (Issue_title, Issue_desc, Stat_id, Proj_id) VALUES ('" +
                                Title_RTB.Text + "','" + Desc_RTB.Text + "',1 ," + projects[Project_CB.SelectedItem.ToString()] + ")";
                            command.CommandType = CommandType.Text;
                            command.ExecuteNonQuery();
                        }
                    }
                    finally
                    {
                        connection.Close();
                        this.Close();
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }
    }
}
