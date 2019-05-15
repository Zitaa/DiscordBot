namespace DiscordBot
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.logDisplay = new System.Windows.Forms.RichTextBox();
            this.tokenText = new System.Windows.Forms.TextBox();
            this.tokenLabel = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.guildLabel = new System.Windows.Forms.Label();
            this.textChannelLabel = new System.Windows.Forms.Label();
            this.voiceChannelLabel = new System.Windows.Forms.Label();
            this.usersLabel = new System.Windows.Forms.Label();
            this.guildsDropdown = new System.Windows.Forms.ComboBox();
            this.textChannelsDropdown = new System.Windows.Forms.ComboBox();
            this.voiceChannelsDropdown = new System.Windows.Forms.ComboBox();
            this.usersDropdown = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // logDisplay
            // 
            this.logDisplay.Location = new System.Drawing.Point(62, 70);
            this.logDisplay.Name = "logDisplay";
            this.logDisplay.Size = new System.Drawing.Size(610, 393);
            this.logDisplay.TabIndex = 0;
            this.logDisplay.Text = "";
            // 
            // tokenText
            // 
            this.tokenText.Location = new System.Drawing.Point(62, 23);
            this.tokenText.Name = "tokenText";
            this.tokenText.PasswordChar = '*';
            this.tokenText.Size = new System.Drawing.Size(610, 20);
            this.tokenText.TabIndex = 1;
            // 
            // tokenLabel
            // 
            this.tokenLabel.AutoSize = true;
            this.tokenLabel.Location = new System.Drawing.Point(12, 26);
            this.tokenLabel.Name = "tokenLabel";
            this.tokenLabel.Size = new System.Drawing.Size(44, 13);
            this.tokenLabel.TabIndex = 2;
            this.tokenLabel.Text = "TOKEN";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(62, 493);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(610, 86);
            this.connectButton.TabIndex = 3;
            this.connectButton.Text = "Connect...";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // guildLabel
            // 
            this.guildLabel.AutoSize = true;
            this.guildLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guildLabel.Location = new System.Drawing.Point(695, 26);
            this.guildLabel.Name = "guildLabel";
            this.guildLabel.Size = new System.Drawing.Size(46, 20);
            this.guildLabel.TabIndex = 4;
            this.guildLabel.Text = "Guild";
            // 
            // textChannelLabel
            // 
            this.textChannelLabel.AutoSize = true;
            this.textChannelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textChannelLabel.Location = new System.Drawing.Point(695, 76);
            this.textChannelLabel.Name = "textChannelLabel";
            this.textChannelLabel.Size = new System.Drawing.Size(110, 20);
            this.textChannelLabel.TabIndex = 5;
            this.textChannelLabel.Text = "Text Channels";
            // 
            // voiceChannelLabel
            // 
            this.voiceChannelLabel.AutoSize = true;
            this.voiceChannelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.voiceChannelLabel.Location = new System.Drawing.Point(695, 126);
            this.voiceChannelLabel.Name = "voiceChannelLabel";
            this.voiceChannelLabel.Size = new System.Drawing.Size(120, 20);
            this.voiceChannelLabel.TabIndex = 6;
            this.voiceChannelLabel.Text = "Voice Channels";
            // 
            // usersLabel
            // 
            this.usersLabel.AutoSize = true;
            this.usersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usersLabel.Location = new System.Drawing.Point(695, 176);
            this.usersLabel.Name = "usersLabel";
            this.usersLabel.Size = new System.Drawing.Size(51, 20);
            this.usersLabel.TabIndex = 7;
            this.usersLabel.Text = "Users";
            // 
            // guildsDropdown
            // 
            this.guildsDropdown.FormattingEnabled = true;
            this.guildsDropdown.Location = new System.Drawing.Point(846, 25);
            this.guildsDropdown.Name = "guildsDropdown";
            this.guildsDropdown.Size = new System.Drawing.Size(179, 21);
            this.guildsDropdown.TabIndex = 8;
            this.guildsDropdown.SelectedIndexChanged += new System.EventHandler(this.guildsDropdown_SelectedIndexChanged);
            // 
            // textChannelsDropdown
            // 
            this.textChannelsDropdown.FormattingEnabled = true;
            this.textChannelsDropdown.Location = new System.Drawing.Point(846, 75);
            this.textChannelsDropdown.Name = "textChannelsDropdown";
            this.textChannelsDropdown.Size = new System.Drawing.Size(179, 21);
            this.textChannelsDropdown.TabIndex = 9;
            // 
            // voiceChannelsDropdown
            // 
            this.voiceChannelsDropdown.FormattingEnabled = true;
            this.voiceChannelsDropdown.Location = new System.Drawing.Point(846, 125);
            this.voiceChannelsDropdown.Name = "voiceChannelsDropdown";
            this.voiceChannelsDropdown.Size = new System.Drawing.Size(179, 21);
            this.voiceChannelsDropdown.TabIndex = 10;
            // 
            // usersDropdown
            // 
            this.usersDropdown.FormattingEnabled = true;
            this.usersDropdown.Location = new System.Drawing.Point(846, 175);
            this.usersDropdown.Name = "usersDropdown";
            this.usersDropdown.Size = new System.Drawing.Size(179, 21);
            this.usersDropdown.TabIndex = 11;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 669);
            this.Controls.Add(this.usersDropdown);
            this.Controls.Add(this.voiceChannelsDropdown);
            this.Controls.Add(this.textChannelsDropdown);
            this.Controls.Add(this.guildsDropdown);
            this.Controls.Add(this.usersLabel);
            this.Controls.Add(this.voiceChannelLabel);
            this.Controls.Add(this.textChannelLabel);
            this.Controls.Add(this.guildLabel);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.tokenLabel);
            this.Controls.Add(this.tokenText);
            this.Controls.Add(this.logDisplay);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu";
            this.Text = "Nix";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox logDisplay;
        private System.Windows.Forms.TextBox tokenText;
        private System.Windows.Forms.Label tokenLabel;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Label guildLabel;
        private System.Windows.Forms.Label textChannelLabel;
        private System.Windows.Forms.Label voiceChannelLabel;
        private System.Windows.Forms.Label usersLabel;
        private System.Windows.Forms.ComboBox guildsDropdown;
        private System.Windows.Forms.ComboBox textChannelsDropdown;
        private System.Windows.Forms.ComboBox voiceChannelsDropdown;
        private System.Windows.Forms.ComboBox usersDropdown;
    }
}

