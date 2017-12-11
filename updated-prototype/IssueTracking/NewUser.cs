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
    public partial class NewUser : Form
    {
        Dictionary<string, int> stores = new Dictionary<string, int>();
        string user;

        private static string GetdbInfo(string call, NameValueCollection stuff)
        {
            using (WebClient client = new WebClient())
            {
                //MessageBox.Show("in web client");
                byte[] response =
                client.UploadValues("http://localhost:3000/" + call, stuff);

                //MessageBox.Show("getting respons");
                string result = System.Text.Encoding.UTF8.GetString(response);

                MessageBox.Show(result);
                return result;
            }
        }

        public NewUser(string un)
        {
            InitializeComponent();
            user = un;
        }

        private void On_submit_click(object sender, EventArgs e)
        {
            if (fName.Text == "" || lName.Text == "" || uStore.Text == "")
            {
                MessageBox.Show("Incomplete data. Please supply a valid argument in each feild.");
            }
            try
            {
                int x = Int32.Parse(uStore.Text);

                string result = GetdbInfo("createclerk", new NameValueCollection
                    {
                      { "Username", user },
                      { "F_Name", fName.Text },
                      { "L_Name", lName.Text },
                      { "Store_ID", uStore.Text }
                    } );

                MessageBox.Show("Success!");
            }
            catch(Exception ef)
            {
                MessageBox.Show("An error has occured.\n\n\n\n" + ef.ToString());
            }
        }

        private void On_cancel_click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
