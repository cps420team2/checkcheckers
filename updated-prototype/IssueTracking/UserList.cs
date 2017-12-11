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
        DataTable test = new DataTable("User");

        private static string GetdbInfo(string call, NameValueCollection stuff)
        {
            using (WebClient client = new WebClient())
            {
                //MessageBox.Show("in web client");
                byte[] response =
                client.UploadValues("http://localhost:3000/" + call , stuff);

                //MessageBox.Show("getting respons");
                string result = System.Text.Encoding.UTF8.GetString(response);

                MessageBox.Show(result);
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
            col.Name = ""; //This will cause some problems with edit and delete double check this message ::: button[num] == line[num]
            DataGridViewButtonColumn del = new DataGridViewButtonColumn();
            del.UseColumnTextForButtonValue = true;
            del.Text = "Delete";
            del.Name = ""; //This will cause some problems with edit and delete double check this message ::: button[num] == line[num]

            dataGrid.Columns.Add(col);
            dataGrid.Columns.Add(del);

            try
            {
                //Users_load(this, EventArgs e);
            }
            catch(Exception e)
            {
                MessageBox.Show("an error has occured.\n\n\n\n\n" + e.ToString());
            }
            
        }

        private void Users_load(object sender, EventArgs e)
        {
            string results = GetdbInfo("getusers", new NameValueCollection { { "Username", user } });

            dataGrid.DataSource = test;


         }

        //taken from https://stackoverflow.com/questions/10769316/add-a-button-in-a-new-column-to-all-rows-in-a-datagrid
        void dataGridView1_EditingControlShowing(object sender,
                    DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is Button)
            {
                Button btn = e.Control as Button;
                if (btn.Name == "cmEdit")
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
            var log = new Checks(user, dbname);
            log.FormClosed += (s, args) => this.Close();
            log.Show();
        }
    }
}
