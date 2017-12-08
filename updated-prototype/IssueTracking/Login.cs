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


namespace Prototype
{
    public partial class Login : Form
    {
        private static string GetLoginAsync(string user, string pass)
        {
            using (WebClient client = new WebClient())
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
        }

        int permissions;

        public Login()
        {
            InitializeComponent();
        }

        private void On_OK_Click(object sender, EventArgs e)
        {
            string test = GetLoginAsync(unameText.Text, passText.Text);
            if (test.Contains("true"))
            {
                MessageBox.Show("Welcome!");
                //show next window, pass permissions as level
                //idea modified from https://stackoverflow.com/questions/5548746/c-sharp-open-a-new-form-then-close-the-current-form
                this.Hide();
                var log = new Checks(unameText.Text);
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
