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

namespace Prototype
{
    public partial class UserList : Form
    {
        string user;
        string dbname;
        //DataTable test = new DataTable("User");

        private static string GetdbInfo(string call, NameValueCollection stuff)
        {
            using (WebClient client = new WebClient())
            {
                //MessageBox.Show("in web client");
                byte[] response =
                client.UploadValues("http://localhost:3000/" + call, stuff);

                //MessageBox.Show("getting respons");
                string result = System.Text.Encoding.UTF8.GetString(response);

                //MessageBox.Show(result);
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
            DataGridViewButtonColumn fname = new DataGridViewButtonColumn();
            del.UseColumnTextForButtonValue = false;
            del.Text = "First Name";
            del.Name = "First Name"; //This will cause some problems with edit and delete double check this message ::: button[num] == line[num]
            DataGridViewButtonColumn lname = new DataGridViewButtonColumn();
            del.UseColumnTextForButtonValue = false;
            del.Text = "Last Name";
            del.Name = "Last Name"; //This will cause some problems with edit and delete double check this message ::: button[num] == line[num]
            DataGridViewButtonColumn pos = new DataGridViewButtonColumn();
            del.UseColumnTextForButtonValue = false;
            del.Text = "Position";
            del.Name = "Position"; //This will cause some problems with edit and delete double check this message ::: button[num] == line[num]
            DataGridViewButtonColumn compy = new DataGridViewButtonColumn();
            del.UseColumnTextForButtonValue = false;
            del.Text = "Company Name";
            del.Name = "Compnay Name"; //This will cause some problems with edit and delete double check this message ::: button[num] == line[num]


            dataGrid.Columns.Add(fname);
            dataGrid.Columns.Add(lname);
            dataGrid.Columns.Add(pos);
            dataGrid.Columns.Add(compy);
            dataGrid.Columns.Add(col);
            dataGrid.Columns.Add(del);

            MessageBox.Show("Users Loaded.\n\nPlease press refresh to view recent changes.");
        }

        private void FillData(string info)
        {

            info = info.Substring(info.IndexOf(':') + 1);
            string fname = "";
            string lname = "";
            string pos = "";
            string compy = "";
            int start = 0;
            int end = 0;
            int i = 0;
            info = info.Substring(info.IndexOf(':') + 1);
            while (info.Contains("Company_Name"))
            {
                while (i < 4)
                {

                    start = info.IndexOf(':');
                    if (info.IndexOf('\"') < start) { info = info.Substring(1); end = info.IndexOf('\"'); start += 2; }
                    else { end = info.IndexOf('\"'); start += 1; }
                    switch
                    (i)
                    {
                        case 0:
                            fname = info.Substring(start, end - 1);
                            break;
                        case 1:
                            lname = info.Substring(start, end - 1);
                            break;
                        case 2:
                            pos = info.Substring(start, end - 1);
                            break;
                        case 3:
                            compy = info.Substring(start, end - 1);
                            break;
                    }
                    ++i;
                    info = info.Substring(end - 1);
                }
                this.dataGrid.Rows.Add(fname, lname, pos, compy);
            }
        }

        private void Users_load(object sender, EventArgs e)
        {
            try
            {
                string results = GetdbInfo("getusers", new NameValueCollection { { "Username", user } });
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
                if (btn.Name == "Edit")
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