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
using Microsoft.JScript;
using System.Net;
using System.Collections.Specialized;


namespace Prototype
{
    public partial class Checks : Form
    {

        string user;
        string dbname;

        public Checks(string uname, string db)
        {
            InitializeComponent();
            dbname = db;
            user = uname;
        }

        private void Checks_load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.UseColumnTextForButtonValue = true;
            col.Text = "Edit";
            col.Name = ""; //This will cause some problems with edit and delete double check this message ::: button[num] == line[num]
            DataGridViewButtonColumn del = new DataGridViewButtonColumn();
            del.UseColumnTextForButtonValue = true;
            del.Text = "Delete";
            del.Name = ""; //This will cause some problems with edit and delete double check this message ::: button[num] == line[num]

            DataTable test = new DataTable("users");


            dataGrid.Columns.Add(col);
            dataGrid.Columns.Add(del);
            dataGrid.DataSource = test;

        }

        private void On_newCheck_Click(object sender, EventArgs e)
        {
            new NewCheck().ShowDialog();
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
                    btn.Click -= new EventHandler(On_editCheck_Click);
                    btn.Click += new EventHandler(On_editCheck_Click);
                }
                else
                {
                    btn.Click -= new EventHandler(On_delCheck_Click);
                    btn.Click += new EventHandler(On_delCheck_Click);
                }
            }
        }

        private void On_editCheck_Click(object sender, EventArgs e)
        {

        }

        private void On_delCheck_Click(object sender, EventArgs e)
        {
            
        }

        private void On_Users_Click(object sender, EventArgs e)
        {
            //show next window, pass permissions as level
            //idea modified from https://stackoverflow.com/questions/5548746/c-sharp-open-a-new-form-then-close-the-current-form
            this.Hide();
            var log = new UserList(user, dbname);
            log.FormClosed += (s, args) => this.Close();
            log.Show();
        }

        private void On_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
