namespace Prototype
{
    partial class UserList
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
            this.cEditButton = new System.Windows.Forms.Button();
            this.delButton = new System.Windows.Forms.Button();
            this.cmCancelButton = new System.Windows.Forms.Button();
            this.refresh = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
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
            this.cNewButton.Click += new System.EventHandler(this.On_newUser_Click);
            // 
            // cEditButton
            // 
            this.cEditButton.Location = new System.Drawing.Point(93, 25);
            this.cEditButton.Name = "cEditButton";
            this.cEditButton.Size = new System.Drawing.Size(75, 23);
            this.cEditButton.TabIndex = 2;
            this.cEditButton.Text = "Edit";
            this.cEditButton.UseVisualStyleBackColor = true;
            // 
            // delButton
            // 
            this.delButton.Location = new System.Drawing.Point(174, 25);
            this.delButton.Name = "delButton";
            this.delButton.Size = new System.Drawing.Size(75, 23);
            this.delButton.TabIndex = 3;
            this.delButton.Text = "Delete";
            this.delButton.UseVisualStyleBackColor = true;
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
            this.refresh.Location = new System.Drawing.Point(336, 25);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(75, 23);
            this.refresh.TabIndex = 6;
            this.refresh.Text = "Refresh";
            this.refresh.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(255, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Checks";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // UserList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 607);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.cmCancelButton);
            this.Controls.Add(this.delButton);
            this.Controls.Add(this.cEditButton);
            this.Controls.Add(this.cNewButton);
            this.Controls.Add(this.dataGrid);
            this.Name = "UserList";
            this.Text = "View All Users";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Button cNewButton;
        private System.Windows.Forms.Button cEditButton;
        private System.Windows.Forms.Button delButton;
        private System.Windows.Forms.Button cmCancelButton;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.Button button1;
    }
}