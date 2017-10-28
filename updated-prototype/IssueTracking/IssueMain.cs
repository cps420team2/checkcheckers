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
    public partial class Form2 : Form
    {
        public static string id;
        public static string proj;
        public static string title;
        public static string desc;
        public static string status;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "team2db.cy1sebpofkho.us-east-2.rds.amazonaws.com";
            conn_string.UserID = "team2";
            conn_string.Password = "Testpassword1";
            conn_string.Database = "ticket_master";
            conn_string.Port = 3306;

            try
            {
                MySqlCommand cmd = new MySqlCommand("Select * from join_tables", new MySqlConnection(conn_string.ToString()));
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable dataset = new DataTable();
                sda.Fill(dataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dataset;
                All_Grid.DataSource = bSource;
                sda.Update(dataset);
            }
            finally
            {

            }
        }

        private void All_Grid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void New_BTN_Click(object sender, EventArgs e)
        {
            Form1 newForm1 = new Form1();
            newForm1.Show();

        }

        private void Refresh_BT_Click(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "team2db.cy1sebpofkho.us-east-2.rds.amazonaws.com";
            conn_string.UserID = "team2";
            conn_string.Password = "Testpassword1";
            conn_string.Database = "ticket_master";
            conn_string.Port = 3306;

            try
            {
                MySqlCommand cmd = new MySqlCommand("Select * from join_tables", new MySqlConnection(conn_string.ToString()));
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable dataset = new DataTable();
                sda.Fill(dataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dataset;
                All_Grid.DataSource = bSource;
                sda.Update(dataset);
            }
            finally
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Edit_BT_Click(object sender, EventArgs e)
        {
            id = All_Grid.CurrentRow.Cells[0].Value.ToString();
            proj = All_Grid.CurrentRow.Cells[1].Value.ToString();
            title = All_Grid.CurrentRow.Cells[2].Value.ToString();
            desc = All_Grid.CurrentRow.Cells[3].Value.ToString();
            status = All_Grid.CurrentRow.Cells[4].Value.ToString();

            Edit_form newForm3 = new Edit_form();
            newForm3.Show();
        }

        private void Delete_BT_Click(object sender, EventArgs e)
        {
            string value = All_Grid.CurrentRow.Cells[0].Value.ToString();
            string query = $"DELETE FROM issue WHERE Issue_id={value};";
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
                    if(connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
