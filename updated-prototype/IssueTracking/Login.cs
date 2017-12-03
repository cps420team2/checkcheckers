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

namespace Prototype
{

    public partial class Login : Form
    {
        private static async Task<bool> GetLoginAsync(string user, string pass)
        {
            var values = new Dictionary<string, string>
            {
               { "username", user },
               { "password", pass }
            };
            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync(requestUri("file:\\\\\\C:\\Users\\djpbj\\Desktop\\School\\420\\FinalProject\\checkcheckers\api\app\\models\\user.js"), content);

            var responseString = await response.Content.ReadAsStringAsync();

            return false;
        }

        private static string requestUri(string v)
        {
            throw new NotImplementedException();
        }

        private static readonly HttpClient client = new HttpClient();
        int permissions;

        public Login(int level)
        {
            permissions = level;
            InitializeComponent();
        }

        private void On_OK_Click(object sender, EventArgs e)
        {
            /*
            if (!GetLoginAsync(unameText.Text, passText.Text).Result)
            {
                MessageBox.Show("Error. Incorrect Credentials.");
                this.Close();
            }
            */
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
