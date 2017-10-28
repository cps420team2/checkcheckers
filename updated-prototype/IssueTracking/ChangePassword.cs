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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void cpButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OkCButton_Click(object sender, EventArgs e)
        {
            //check for semicolon and change the password in the database
            if(OldPassText.Text.Contains(";") || NewPassText.Text.Contains(";"))
            {
                MessageBox.Show("Invalid Character detected!\nPlease only use alphanumeric characters and/or '.'");
            }
            else
            {
                string dbconnect = "Server=localhost;Database=ccproject;Uid=root;Pwd=Password;";
                MySqlConnection connection = new MySqlConnection(dbconnect);
                
                using (connection)
                {
                    connection.Open();
                    try
                    { 
                        string quer = "Update users set Password = @newpass where Login = @uname";
                        MySqlCommand cmd = new MySqlCommand(quer,connection);
                        cmd.Parameters.AddWithValue("@newpass", NewPassText.Text);
                        cmd.Parameters.AddWithValue("@uname", unameText.Text);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("An Error has occured!\nPlease try modifying the data, or trying again in a short time.\nIf the problem persists, contact your Manager or System Administrator.");
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        this.Close();
                    }
                }
            }
        }
    }
}
