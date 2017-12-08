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

        private static readonly HttpClient client = new HttpClient();
        int permissions;

        public Login(int level)
        {
            permissions = level;
            InitializeComponent();
        }

        public static async Task GetLoginAsync(string user, string pass)
        {
            /*
            var values = new Dictionary<string, string>
            {
               { "Username", user },
               { "Password", pass }
            };
            var content = new FormUrlEncodedContent(values);
            
            var response = await client.PostAsync("http://localhost:3000/login", content);
            
            var responseString = await response.Content.ReadAsStringAsync();
            */
            using (WebClient client = new WebClient())
            {
                MessageBox.Show("in web client");
                byte[] response =
                client.UploadValues("http://localhost:3000/login", new NameValueCollection()
                {
                   { "Username", user },
                   { "Password", pass }
                });

                MessageBox.Show("getting respons");
                string result = System.Text.Encoding.UTF8.GetString(response);
                MessageBox.Show(result);
            }
        }

        private void On_OK_Click(object sender, EventArgs e)
        {
            GetLoginAsync(unameText.Text, passText.Text).Wait();
      
            //show next window, pass permissions as level
            //idea modified from https://stackoverflow.com/questions/5548746/c-sharp-open-a-new-form-then-close-the-current-form
            this.Hide();
            var log = new Checks(2);
            log.FormClosed += (s, args) => this.Close();
            log.Show();
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
