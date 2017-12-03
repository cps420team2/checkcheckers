namespace Prototype
{
    partial class Checks
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
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.cNewButton = new System.Windows.Forms.Button();
            this.cmCancelButton = new System.Windows.Forms.Button();
            this.refresh = new System.Windows.Forms.Button();
            this.uBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(12, 54);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(806, 512);
            this.dataGrid.TabIndex = 0;
            // 
            // cNewButton
            // 
            this.cNewButton.Location = new System.Drawing.Point(12, 25);
            this.cNewButton.Name = "cNewButton";
            this.cNewButton.Size = new System.Drawing.Size(75, 23);
            this.cNewButton.TabIndex = 1;
            this.cNewButton.Text = "New";
            this.cNewButton.UseVisualStyleBackColor = true;
            this.cNewButton.Click += new System.EventHandler(this.On_newCheck_Click);
            // 
            // cmCancelButton
            // 
            this.cmCancelButton.Location = new System.Drawing.Point(744, 572);
            this.cmCancelButton.Name = "cmCancelButton";
            this.cmCancelButton.Size = new System.Drawing.Size(75, 23);
            this.cmCancelButton.TabIndex = 4;
            this.cmCancelButton.Text = "Cancel";
            this.cmCancelButton.UseVisualStyleBackColor = true;
            this.cmCancelButton.Click += new System.EventHandler(this.On_Cancel_Click);
            // 
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(175, 25);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(75, 23);
            this.refresh.TabIndex = 5;
            this.refresh.Text = "Refresh";
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.Checks_load);
            // 
            // uBtn
            // 
            this.uBtn.Location = new System.Drawing.Point(94, 25);
            this.uBtn.Name = "uBtn";
            this.uBtn.Size = new System.Drawing.Size(75, 23);
            this.uBtn.TabIndex = 6;
            this.uBtn.Text = "Users";
            this.uBtn.UseVisualStyleBackColor = true;
            this.uBtn.Click += new System.EventHandler(this.On_Users_Click);
            // 
            // Checks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 607);
            this.Controls.Add(this.uBtn);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.cmCancelButton);
            this.Controls.Add(this.cNewButton);
            this.Controls.Add(this.dataGrid);
            this.Name = "Checks";
            this.Text = "View All Checks";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Button cNewButton;
        private System.Windows.Forms.Button cmCancelButton;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.Button uBtn;
    }
}