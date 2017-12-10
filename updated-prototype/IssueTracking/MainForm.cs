using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IssueTracking
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
             
        }

        private void On_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void On_Login_Click(object sender, EventArgs e)
        {
            //idea modified from https://stackoverflow.com/questions/5548746/c-sharp-open-a-new-form-then-close-the-current-form
            this.Hide();
            var log = new Prototype.Login();
            log.FormClosed += (s, args) => this.Close();
            log.Show();

        }

    }
}
