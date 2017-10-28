namespace Prototype
{
    partial class ChangePassword
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
            this.lcButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.OldPassText = new System.Windows.Forms.TextBox();
            this.unameText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NewPassText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lcButton
            // 
            this.lcButton.Location = new System.Drawing.Point(259, 200);
            this.lcButton.Name = "lcButton";
            this.lcButton.Size = new System.Drawing.Size(75, 23);
            this.lcButton.TabIndex = 11;
            this.lcButton.Text = "Back";
            this.lcButton.UseVisualStyleBackColor = true;
            this.lcButton.Click += new System.EventHandler(this.cpButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(108, 200);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 10;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkCButton_Click);
            // 
            // OldPassText
            // 
            this.OldPassText.Location = new System.Drawing.Point(147, 63);
            this.OldPassText.Name = "OldPassText";
            this.OldPassText.Size = new System.Drawing.Size(235, 20);
            this.OldPassText.TabIndex = 9;
            this.OldPassText.UseSystemPasswordChar = true;
            // 
            // unameText
            // 
            this.unameText.Location = new System.Drawing.Point(147, 19);
            this.unameText.Name = "unameText";
            this.unameText.Size = new System.Drawing.Size(235, 20);
            this.unameText.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Old Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Username";
            // 
            // NewPassText
            // 
            this.NewPassText.Location = new System.Drawing.Point(147, 104);
            this.NewPassText.Name = "NewPassText";
            this.NewPassText.Size = new System.Drawing.Size(235, 20);
            this.NewPassText.TabIndex = 13;
            this.NewPassText.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "New Password";
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 261);
            this.Controls.Add(this.NewPassText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lcButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.OldPassText);
            this.Controls.Add(this.unameText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ChangePassword";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button lcButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.TextBox OldPassText;
        private System.Windows.Forms.TextBox unameText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NewPassText;
        private System.Windows.Forms.Label label3;
    }
}