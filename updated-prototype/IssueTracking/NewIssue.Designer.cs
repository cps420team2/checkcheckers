namespace IssueTracking
{
    partial class Form1
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
            this.Title_RTB = new System.Windows.Forms.RichTextBox();
            this.Desc_RTB = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Submit_BT = new System.Windows.Forms.Button();
            this.Project_CB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Title_RTB
            // 
            this.Title_RTB.Location = new System.Drawing.Point(138, 108);
            this.Title_RTB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Title_RTB.Name = "Title_RTB";
            this.Title_RTB.Size = new System.Drawing.Size(293, 48);
            this.Title_RTB.TabIndex = 0;
            this.Title_RTB.Text = "";
            // 
            // Desc_RTB
            // 
            this.Desc_RTB.Location = new System.Drawing.Point(138, 183);
            this.Desc_RTB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Desc_RTB.Name = "Desc_RTB";
            this.Desc_RTB.Size = new System.Drawing.Size(293, 87);
            this.Desc_RTB.TabIndex = 1;
            this.Desc_RTB.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 120);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Title";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 217);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Description";
            // 
            // Submit_BT
            // 
            this.Submit_BT.Location = new System.Drawing.Point(200, 419);
            this.Submit_BT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Submit_BT.Name = "Submit_BT";
            this.Submit_BT.Size = new System.Drawing.Size(116, 40);
            this.Submit_BT.TabIndex = 4;
            this.Submit_BT.Text = "Submit";
            this.Submit_BT.UseVisualStyleBackColor = true;
            this.Submit_BT.Click += new System.EventHandler(this.Submit_BT_Click);
            // 
            // Project_CB
            // 
            this.Project_CB.FormattingEnabled = true;
            this.Project_CB.Location = new System.Drawing.Point(138, 39);
            this.Project_CB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Project_CB.Name = "Project_CB";
            this.Project_CB.Size = new System.Drawing.Size(293, 24);
            this.Project_CB.Sorted = true;
            this.Project_CB.TabIndex = 5;
            this.Project_CB.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 39);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Project";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 511);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Project_CB);
            this.Controls.Add(this.Submit_BT);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Desc_RTB);
            this.Controls.Add(this.Title_RTB);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "New";
            this.Load += new System.EventHandler(this.FormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox Title_RTB;
        private System.Windows.Forms.RichTextBox Desc_RTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Submit_BT;
        private System.Windows.Forms.ComboBox Project_CB;
        private System.Windows.Forms.Label label3;
    }
}

