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
    public partial class Login : Form
    {
        int permissions;

        public Login(int level)
        {
            permissions = level;
            InitializeComponent();
        }

        private void On_OK_Click(object sender, EventArgs e)
        {
            /*
            string dbconnect = "Server=localhost;Database=ccproject;Uid=root;Pwd=Password;";
            MySqlConnection connection = new MySqlConnection(dbconnect);
            using (connection)
            {
                connection.Open();
                try
                {
                    string quer = "Select * from users where LoginName = @uname and Password = @pass";
                    MySqlCommand cmd = new MySqlCommand(quer, connection);
                    cmd.Parameters.AddWithValue("@pass", passText.Text);
                    cmd.Parameters.AddWithValue("@uname", unameText.Text);
                    MySqlDataReader read = cmd.ExecuteReader();
                    if (cmd == null)
                    {
                        MessageBox.Show("Login Information Invalid. Please try again.");
                        connection.Close();
                    }
                    else
                    {
                        MySqlDataAdapter cData = new MySqlDataAdapter(cmd);
                        DataSet cDS = new DataSet();
                        cData.Fill(cDS);
                        if (read.GetChar("Role") == 'M' || read.GetChar("Role") == 'A') { permissions = 1; }
                        else if (read.GetChar("Role") == 'S') { permissions = 2; }
                        else { permissions = 0; }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("An Error has occured!\nPlease try again in a short time.\nIf the problem persists, contact your Manager or System Administrator.\n\n");
                    this.Hide();
                    var llog = new IssueTracking.MainForm();
                    llog.FormClosed += (s, args) => this.Close();
                    llog.Show();
                }
                finally
                {
                    connection.Close();
                }
            }
            */
            //show next window, pass permissions as level
            //idea modified from https://stackoverflow.com/questions/5548746/c-sharp-open-a-new-form-then-close-the-current-form
            this.Hide();
            var log = new Checks(2);
            log.FormClosed += (s, args) => this.Close();
            log.Show();
        }

            private void On_lCancel_Click(object sender, EventArgs e)
        {
            //idea modified from https://stackoverflow.com/questions/5548746/c-sharp-open-a-new-form-then-close-the-current-form
            this.Hide();
            var log = new IssueTracking.MainForm();
            log.FormClosed += (s, args) => this.Close();
            log.Show();
        }

 
    }
}
