namespace Prototype
{
    partial class NewUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sub = new System.Windows.Forms.Button();
            this.can = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.fName = new System.Windows.Forms.TextBox();
            this.lName = new System.Windows.Forms.TextBox();
            this.uStore = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // sub
            // 
            this.sub.Location = new System.Drawing.Point(12, 168);
            this.sub.Name = "sub";
            this.sub.Size = new System.Drawing.Size(75, 23);
            this.sub.TabIndex = 0;
            this.sub.Text = "Submit";
            this.sub.UseVisualStyleBackColor = true;
            this.sub.Click += new System.EventHandler(this.On_submit_click);
            // 
            // can
            // 
            this.can.Location = new System.Drawing.Point(250, 168);
            this.can.Name = "can";
            this.can.Size = new System.Drawing.Size(75, 23);
            this.can.TabIndex = 1;
            this.can.Text = "Cancel";
            this.can.UseVisualStyleBackColor = true;
            this.can.Click += new System.EventHandler(this.On_cancel_click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "First Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "LastName";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Store";
            // 
            // fName
            // 
            this.fName.Location = new System.Drawing.Point(109, 38);
            this.fName.Name = "fName";
            this.fName.Size = new System.Drawing.Size(216, 20);
            this.fName.TabIndex = 10;
            // 
            // lName
            // 
            this.lName.Location = new System.Drawing.Point(109, 79);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(216, 20);
            this.lName.TabIndex = 11;
            // 
            // uStore
            // 
            this.uStore.Location = new System.Drawing.Point(109, 120);
            this.uStore.Name = "uStore";
            this.uStore.Size = new System.Drawing.Size(216, 20);
            this.uStore.TabIndex = 14;
            // 
            // NewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 209);
            this.Controls.Add(this.uStore);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.fName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.can);
            this.Controls.Add(this.sub);
            this.Name = "NewUser";
            this.Text = "New User";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sub;
        private System.Windows.Forms.Button can;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox fName;
        private System.Windows.Forms.TextBox lName;
        private System.Windows.Forms.TextBox uStore;
    }
}