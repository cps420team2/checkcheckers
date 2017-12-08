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
            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.UseColumnTextForButtonValue = true;
            col.Text = "Edit";
            col.Name = ""; //This will cause some problems with edit and delete double check this message ::: button[num] == line[num]
            DataGridViewButtonColumn del = new DataGridViewButtonColumn();
            del.UseColumnTextForButtonValue = true;
            del.Text = "Delete";
            del.Name = ""; //This will cause some problems with edit and delete double check this message ::: button[num] == line[num]

            DataTable test = new DataTable("info");
            test.Columns.Add("First Name");
            test.Columns.Add("Last Name");
            test.Columns.Add("AccountType");
            test.Rows.Add("Andrew", "Price", "Administrator");
            test.Rows.Add("Brad", "Mays", "Manager");


            dataGrid.DataSource = test;
            dataGrid.Columns.Add(col);
            dataGrid.Columns.Add(del);

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
            var log = new Checks(2);
            log.FormClosed += (s, args) => this.Close();
            log.Show();
        }
    }
}
