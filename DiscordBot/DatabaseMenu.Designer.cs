namespace DiscordBot
{
    partial class DatabaseMenu
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
            this.components = new System.ComponentModel.Container();
            this.userTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.UsersLabel = new System.Windows.Forms.Label();
            this.UsersList = new System.Windows.Forms.ListBox();
            this.DataList = new System.Windows.Forms.ListBox();
            this.DataLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.userTableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // UsersLabel
            // 
            this.UsersLabel.AutoSize = true;
            this.UsersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsersLabel.Location = new System.Drawing.Point(12, 9);
            this.UsersLabel.Name = "UsersLabel";
            this.UsersLabel.Size = new System.Drawing.Size(58, 24);
            this.UsersLabel.TabIndex = 0;
            this.UsersLabel.Text = "Users";
            // 
            // UsersList
            // 
            this.UsersList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsersList.FormattingEnabled = true;
            this.UsersList.ItemHeight = 24;
            this.UsersList.Location = new System.Drawing.Point(16, 36);
            this.UsersList.Name = "UsersList";
            this.UsersList.Size = new System.Drawing.Size(256, 604);
            this.UsersList.TabIndex = 1;
            this.UsersList.SelectedIndexChanged += new System.EventHandler(this.UsersList_SelectedIndexChanged);
            // 
            // DataList
            // 
            this.DataList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataList.FormattingEnabled = true;
            this.DataList.ItemHeight = 24;
            this.DataList.Location = new System.Drawing.Point(298, 36);
            this.DataList.Name = "DataList";
            this.DataList.Size = new System.Drawing.Size(256, 604);
            this.DataList.TabIndex = 3;
            // 
            // DataLabel
            // 
            this.DataLabel.AutoSize = true;
            this.DataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataLabel.Location = new System.Drawing.Point(294, 9);
            this.DataLabel.Name = "DataLabel";
            this.DataLabel.Size = new System.Drawing.Size(47, 24);
            this.DataLabel.TabIndex = 2;
            this.DataLabel.Text = "Data";
            // 
            // DatabaseMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 664);
            this.Controls.Add(this.DataList);
            this.Controls.Add(this.DataLabel);
            this.Controls.Add(this.UsersList);
            this.Controls.Add(this.UsersLabel);
            this.Name = "DatabaseMenu";
            this.Text = "DatabaseMenu";
            this.Load += new System.EventHandler(this.DatabaseMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userTableBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private System.Windows.Forms.BindingSource userTableBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.Label UsersLabel;
        private System.Windows.Forms.ListBox UsersList;
        private System.Windows.Forms.ListBox DataList;
        private System.Windows.Forms.Label DataLabel;
    }
}