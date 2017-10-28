namespace IssueTracking
{
    partial class Form2
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
            this.All_Grid = new System.Windows.Forms.DataGridView();
            this.New_BTN = new System.Windows.Forms.Button();
            this.Refresh_BT = new System.Windows.Forms.Button();
            this.Edit_BT = new System.Windows.Forms.Button();
            this.Delete_BT = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.All_Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // All_Grid
            // 
            this.All_Grid.AllowUserToAddRows = false;
            this.All_Grid.AllowUserToDeleteRows = false;
            this.All_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.All_Grid.Location = new System.Drawing.Point(39, 42);
            this.All_Grid.Margin = new System.Windows.Forms.Padding(2);
            this.All_Grid.Name = "All_Grid";
            this.All_Grid.ReadOnly = true;
            this.All_Grid.RowTemplate.Height = 31;
            this.All_Grid.Size = new System.Drawing.Size(796, 359);
            this.All_Grid.TabIndex = 0;
            this.All_Grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.All_Grid_CellContentClick_1);
            // 
            // New_BTN
            // 
            this.New_BTN.Location = new System.Drawing.Point(39, 8);
            this.New_BTN.Margin = new System.Windows.Forms.Padding(2);
            this.New_BTN.Name = "New_BTN";
            this.New_BTN.Size = new System.Drawing.Size(77, 30);
            this.New_BTN.TabIndex = 1;
            this.New_BTN.Text = "New Item";
            this.New_BTN.UseVisualStyleBackColor = true;
            this.New_BTN.Click += new System.EventHandler(this.New_BTN_Click);
            // 
            // Refresh_BT
            // 
            this.Refresh_BT.Location = new System.Drawing.Point(39, 406);
            this.Refresh_BT.Name = "Refresh_BT";
            this.Refresh_BT.Size = new System.Drawing.Size(85, 34);
            this.Refresh_BT.TabIndex = 4;
            this.Refresh_BT.Text = "Refresh";
            this.Refresh_BT.UseVisualStyleBackColor = true;
            this.Refresh_BT.Click += new System.EventHandler(this.Refresh_BT_Click);
            // 
            // Edit_BT
            // 
            this.Edit_BT.Location = new System.Drawing.Point(121, 8);
            this.Edit_BT.Name = "Edit_BT";
            this.Edit_BT.Size = new System.Drawing.Size(82, 29);
            this.Edit_BT.TabIndex = 5;
            this.Edit_BT.Text = "Edit";
            this.Edit_BT.UseVisualStyleBackColor = true;
            this.Edit_BT.Click += new System.EventHandler(this.Edit_BT_Click);
            // 
            // Delete_BT
            // 
            this.Delete_BT.Location = new System.Drawing.Point(209, 8);
            this.Delete_BT.Name = "Delete_BT";
            this.Delete_BT.Size = new System.Drawing.Size(88, 28);
            this.Delete_BT.TabIndex = 6;
            this.Delete_BT.Text = "Delete";
            this.Delete_BT.UseVisualStyleBackColor = true;
            this.Delete_BT.Click += new System.EventHandler(this.Delete_BT_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 452);
            this.Controls.Add(this.Delete_BT);
            this.Controls.Add(this.Edit_BT);
            this.Controls.Add(this.Refresh_BT);
            this.Controls.Add(this.New_BTN);
            this.Controls.Add(this.All_Grid);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form2";
            this.Text = "Issue Tracking";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.All_Grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView All_Grid;
        private System.Windows.Forms.Button New_BTN;
        private System.Windows.Forms.Button Refresh_BT;
        private System.Windows.Forms.Button Edit_BT;
        private System.Windows.Forms.Button Delete_BT;
    }
}