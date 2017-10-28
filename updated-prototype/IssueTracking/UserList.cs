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
    public partial class UserList : Form
    {
        public UserList()
        {
            InitializeComponent();
        }

        private void Users_load(object sender, EventArgs e)
        {
            /*
            string dbconnect = "Server=localhost;Database=ccproject;Uid=root;Pwd=Password;";
            MySqlConnection connection = new MySqlConnection(dbconnect);
            MySqlCommand cmd = new MySqlCommand();
            using (connection)
            {
                connection.Open();
                try
                {
                    cmd = connection.CreateCommand();
                    cmd.CommandText = "Select * from users";
                    MySqlDataAdapter cData = new MySqlDataAdapter(cmd);
                    DataSet cDS = new DataSet();
                    cData.Fill(cDS);
                    BindingSource bSource = new BindingSource();
                    bSource.DataSource = cDS;
                    dataGrid.DataSource = bSource;
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

        private void On_newUser_Click(object sender, EventArgs e)
        {
            new NewUser().ShowDialog();
        }

        private void On_editUser_Click(object sender, EventArgs e)
        {
            new ChangePassword().ShowDialog();
        }

        private void On_delUser_Click(object sender, EventArgs e)
        {

        }

        private void On_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void On_checks_clicked(object sender, EventArgs e)
        {
            //show next window, pass permissions as level
            //idea modified from https://stackoverflow.com/questions/5548746/c-sharp-open-a-new-form-then-close-the-current-form
            this.Hide();
            var log = new Checks(2);
            log.FormClosed += (s, args) => this.Close();
            log.Show();
        }
    }
}
