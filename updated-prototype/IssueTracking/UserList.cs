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
using System.Net;
using System.Collections.Specialized;
using Newtonsoft.Json;

namespace Prototype
{
    public class User
    {
        public int User_Id { get; set; }
        public string Username { get; set; }
        public string F_Name { get; set; }
        public string L_Name { get; set; }
        public string User_Stat { get; set; }
        public string Company_Name { get; set; }
    }


    public class RootObject
    {
        public object Error { get; set; }
        public List<User> Users { get; set; }
    }

    public partial class UserList : Form
    {
        string user;
        string dbname;

        private static RootObject GetdbInfo(string call, NameValueCollection stuff)
        {
            using (WebClient client = new WebClient())
            {
                //MessageBox.Show("in web client");
                byte[] response =
                client.UploadValues("http://localhost:3000/" + call, stuff);

                //MessageBox.Show("getting respons");
                string view = System.Text.Encoding.UTF8.GetString(response);
                var result = JsonConvert.DeserializeObject<RootObject>( System.Text.Encoding.UTF8.GetString(response));
                MessageBox.Show(view);
                return result;
            }
        }

        public UserList(string uname, string db)
        {
            InitializeComponent();
            user = uname;
            dbname = db;

            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.UseColumnTextForButtonValue = true;
            col.Text = "Edit";
            col.Name = "Edit User"; //This will cause some problems with edit and delete double check this message ::: button[num] == line[num]
            DataGridViewButtonColumn del = new DataGridViewButtonColumn();
            del.UseColumnTextForButtonValue = true;
            del.Text = "Delete";
            del.Name = "Delete User"; //This will cause some problems with edit and delete double check this message ::: button[num] == line[num]

            dataGrid.Columns.Add("User ID", "Test");
            dataGrid.Columns.Add("User Name", "Test");
            dataGrid.Columns.Add("First Name", "Test");
            dataGrid.Columns.Add("Last Name", "Test");
            dataGrid.Columns.Add("Position", "Test");
            dataGrid.Columns.Add("Company", "Test");
            dataGrid.Columns.Add(col);
            dataGrid.Columns.Add(del);

            MessageBox.Show("Users Loaded.\n\nPlease press refresh to view recent changes.");
        }

        private void FillData(RootObject info)
        {
            
        }

        private void Users_load(object sender, EventArgs e)
        {
            try
            {
                var results = GetdbInfo("getusers", new NameValueCollection { { "Username", user } });
                //string clerk_results = GetdbInfo("getclerks", new NameValueCollection { { "Username", user } }); //-----leads to 404 error
                FillData(results);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured:\n\n\n" + ex);
            }
        }

        //taken from https://stackoverflow.com/questions/10769316/add-a-button-in-a-new-column-to-all-rows-in-a-datagrid
        void dataGridView1_EditingControlShowing(object sender,
                    DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is Button)
            {
                Button btn = e.Control as Button;
                if (btn.Name == "Edit User")
                {
                    btn.Click -= new EventHandler(On_editUser_Click);
                    btn.Click += new EventHandler(On_editUser_Click);
                }
                else
                {
                    btn.Click -= new EventHandler(On_delUser_Click);
                    btn.Click += new EventHandler(On_delUser_Click);
                }
            }
        }

        private void On_newUser_Click(object sender, EventArgs e)
        {
            new NewUser(user).ShowDialog();
        }

        private void On_editUser_Click(object sender, EventArgs e)
        {

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
            var log = new Checks(user, dbname);
            log.FormClosed += (s, args) => this.Close();
            log.Show();
        }
    }
}