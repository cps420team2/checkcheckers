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

namespace Prototype
{
    public partial class Checks : Form
    {
        int level;
        public Checks(int perm)
        {
            level = perm;
            InitializeComponent();
        }

        private void Checks_load(object sender, EventArgs e)
        {
            /*
            string dbconnect = "Server=localhost;Database=ccproject;Uid=root;Pwd=Password;";
            MySqlConnection connection = new MySqlConnection(dbconnect);
            MySqlCommand cmd;
            using (connection)
            {
                connection.Open();
                try
                {
                    cmd = connection.CreateCommand();
                    cmd.CommandText = "Select * from badchecks";
                    MySqlDataAdapter cData = new MySqlDataAdapter(cmd);
                    DataSet cDS = new DataSet();
                    cData.Fill(cDS);
                    dataGrid.DataSource = cDS.Tables[0].DefaultView;
                    cData.Update(cDS);
                }
                catch (Exception)
                {
                    MessageBox.Show("An Error has occured!\nPlease try again in a short time.\nIf the problem persists, contact your Manager or System Administrator.");
                }
                finally
                {
                    connection.Close();
                }
            }
            */
        }

        private void On_newCheck_Click(object sender, EventArgs e)
        {
            new NewCheck().ShowDialog();
        }

        private void On_editCheck_Click(object sender, EventArgs e)
        {

        }

        private void On_delCheck_Click(object sender, EventArgs e)
        {
            string value = dataGrid.CurrentRow.Cells[0].Value.ToString();
            /*
            string query = $"DELETE FROM issue WHERE Issue_id={value};";
            string dbconnect = "Server=localhost;Database=ccproject;Uid=root;Pwd=Password;";
            MySqlConnection connection = new MySqlConnection(dbconnect);

            using (connection)
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
                    }
                }
            }
            */
        }

        private void On_Users_Click(object sender, EventArgs e)
        {
            if(level != 2) { MessageBox.Show("Incorrect Permissions."); }
            else
            {
                //show next window, pass permissions as level
                //idea modified from https://stackoverflow.com/questions/5548746/c-sharp-open-a-new-form-then-close-the-current-form
                this.Hide();
                var log = new UserList();
                log.FormClosed += (s, args) => this.Close();
                log.Show();
            }
        }

        private void On_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void On_refresh_click(object sender, EventArgs e)
        {
            /*
            string dbconnect = "Server=localhost;Database=ccproject;Uid=root;Pwd=Password;";
            MySqlConnection connection = new MySqlConnection(dbconnect);
            MySqlCommand cmd;
            using (connection)
            {
                connection.Open();
                try
                {
                    cmd = connection.CreateCommand();
                    cmd.CommandText = "Select * from badchecks";
                    MySqlDataAdapter cData = new MySqlDataAdapter(cmd);
                    DataSet cDS = new DataSet();
                    cData.Fill(cDS);
                    dataGrid.DataSource = cDS.Tables[0].DefaultView;
                    cData.Update(cDS);
                }
                catch (Exception)
                {
                    MessageBox.Show("An Error has occured!\nPlease try again in a short time.\nIf the problem persists, contact your Manager or System Administrator.");
                }
                finally
                {
                    connection.Close();
                }
            }
            */
        }
    }
}
