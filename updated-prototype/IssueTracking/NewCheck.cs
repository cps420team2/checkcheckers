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
    public partial class NewCheck : Form
    {
        Dictionary<string, int> stores = new Dictionary<string, int>();

        public NewCheck()
        {
            InitializeComponent();
        }

        private void NewCheck_Load(object sender, EventArgs e)
        {
            var source = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            var source2 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31 };
            this.monthCombo.DataSource = source;
            this.monthCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.dayCombo.DataSource = source2;
            this.dayCombo.DropDownStyle = ComboBoxStyle.DropDownList;

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
            this.storeCombo.DataSource = stores;
            */
        }

        private void On_submit_Click(object sender, EventArgs e)
        {
            if (addr.Text == "" || fName.Text =="" ||lName.Text == "" || cAmount.Text == "" || aNo.Text == "" || rNo.Text == "" || st.Text == "" || zCode.Text == "" || cAmount.Text == "" || monthCombo.Text == "" || dayCombo.Text == "" || year.Text == "")
            {
                MessageBox.Show("Please fill all fields completely");
            }
            /*
            else
            {
                string dbconnect = "Server=localhost;Database=ccproject;Uid=root;Pwd=Password;";
                MySqlConnection conn = new MySqlConnection(dbconnect);
                MySqlCommand cmd = new MySqlCommand();
                using (conn)
                {
                    conn.Open();
                    try
                    {
                        cmd = conn.CreateCommand();
                        cmd.CommandText = "Insert into badchecks (FirstName, LastName, CheckNo, AccountNo, RoutingNo, Address, Zip, State, Amount, Store, Month, Day, Year)" +
                            "Values (" + fName.Text + lName.Text + Int32.Parse(cNo.Text) + Int32.Parse(aNo.Text) + Int32.Parse(rNo.Text) + addr.Text + Int32.Parse(zCode.Text) + st.Text + Int32.Parse(cAmount.Text) + stores[storeCombo.Text] + Int32.Parse(monthCombo.Text) + Int32.Parse(dayCombo.Text) + Int32.Parse(year.Text) + ")";

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
            */
        }
        
        private void On_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
