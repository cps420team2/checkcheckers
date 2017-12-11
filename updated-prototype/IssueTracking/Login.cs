using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace Prototype
{
    public partial class Login : Form
    {

        string dbname;

        private static string GetLoginAsync(string user, string pass)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    //MessageBox.Show("in web client");
                    byte[] response =
                    client.UploadValues("http://localhost:3000/login", new NameValueCollection()
                    {
                       { "Username", user },
                       { "Password", pass }
                    });

                    //MessageBox.Show("getting respons");
                    string result = System.Text.Encoding.UTF8.GetString(response);
                    //MessageBox.Show(result);
                    return result;
                }
                catch(Exception e)
                {
                    MessageBox.Show("Bad things have happened.\n\n\n\n" + e.ToString());
                    return "null";
                }
            }
        }

        private static string GetDbName(string user)
        {
            using (WebClient client = new WebClient())
            {
                //MessageBox.Show("in web client");
                byte[] response =
                client.UploadValues("http://localhost:3000/getdb", new NameValueCollection()
                {
                   { "Username", user }
                });

                //MessageBox.Show("getting respons");
                string result = System.Text.Encoding.UTF8.GetString(response);
                //MessageBox.Show(result);
                int end = result.LastIndexOf('\"');
                string test = result.Substring(0, end);
                end = test.LastIndexOf('\"');
                result = test.Substring(end+1);
                //MessageBox.Show(test);
                return result;
            }
        }

        public Login()
        {
            InitializeComponent();
        }

        private void On_OK_Click(object sender, EventArgs e)
        {
            string test = GetLoginAsync(unameText.Text, passText.Text);
            if (test.Contains("true"))
            {
                //MessageBox.Show("Welcome!");

                dbname = GetDbName(unameText.Text);
                //show next window, pass permissions as level
                //idea modified from https://stackoverflow.com/questions/5548746/c-sharp-open-a-new-form-then-close-the-current-form
                this.Hide();
                var log = new Checks(unameText.Text, dbname);
                log.FormClosed += (s, args) => this.Close();
                log.Show();
            }
            else
            {
                MessageBox.Show("Incorrect creditials");
            }
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
