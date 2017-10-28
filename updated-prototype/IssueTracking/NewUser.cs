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
    public partial class NewUser : Form
    {
        Dictionary<string, int> stores = new Dictionary<string, int>();

        public NewUser()
        {
            InitializeComponent();
        }

        private void NewUser_Load(object sender, EventArgs e)
        {
            string dbconnect = "Server=localhost;Database=ccproject;Uid=root;Pwd=Password;";
            MySqlConnection connection = new MySqlConnection(dbconnect);
            MySqlCommand cmd = new MySqlCommand();
            using (connection)
            {
                connection.Open();
                try
                {
                    cmd = connection.CreateCommand();
                    cmd.CommandText = "Select * from storefront";
                    MySqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        stores.Add(rd.GetString("Address"), rd.GetInt32("sfID"));
                    }
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
            this.uStore.DataSource = stores;
        }

        private void On_submit_click(object sender, EventArgs e)
        {
            if (fName.Text == "" || lName.Text == "" || uName.Text == "" || password.Text == "" || EmpNo.Text == "")
            {
                MessageBox.Show("Please fill all fields completely");
            }
            else
            {
                int role = 0;
                if (radioButton1.Checked || radioButton2.Checked) { role = 1; }
                else if (radioButton3.Checked) { role = 2; }
                else { role = 0; }
                string dbconnect = "Server=localhost;Database=ccproject;Uid=root;Pwd=Password;";
                MySqlConnection conn = new MySqlConnection(dbconnect);
                MySqlCommand cmd = new MySqlCommand();
                using (conn)
                {
                    conn.Open();
                    try
                    {
                        cmd = conn.CreateCommand();
                        cmd.CommandText = "Insert into users (FirstName, LastName, EmpNo, LoginName, Password, Role, UserStore)" +
                            "Values (" + fName.Text + lName.Text + Int32.Parse(EmpNo.Text) + uName.Text + password.Text + role + stores[uStore.Text] + ")";

                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception eex)
                    {
                        MessageBox.Show("An error with the values was detected. Please try again.\nIf the problem persists, please contact your manager or adminstrator.\n\n\n" + eex.ToString());
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        private void On_cancel_click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
