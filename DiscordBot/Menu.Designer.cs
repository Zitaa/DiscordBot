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
            this.textChannelLabel = new System.Windows.Forms.Label();
            this.voiceChannelLabel = new System.Windows.Forms.Label();
            this.usersLabel = new System.Windows.Forms.Label();
            this.textChannelsDropdown = new System.Windows.Forms.ComboBox();
            this.voiceChannelsDropdown = new System.Windows.Forms.ComboBox();
            this.usersDropdown = new System.Windows.Forms.ComboBox();
            this.messageBox = new System.Windows.Forms.RichTextBox();
            this.messageUser = new System.Windows.Forms.Button();
            this.messageChannel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // logDisplay
            // 
            this.logDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logDisplay.Location = new System.Drawing.Point(62, 70);
            this.logDisplay.Name = "logDisplay";
            this.logDisplay.Size = new System.Drawing.Size(610, 393);
            this.logDisplay.TabIndex = 0;
            this.logDisplay.Text = "";
            // 
            // tokenText
            // 
            this.tokenText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tokenText.Location = new System.Drawing.Point(62, 23);
            this.tokenText.Name = "tokenText";
            this.tokenText.PasswordChar = '*';
            this.tokenText.Size = new System.Drawing.Size(610, 20);
            this.tokenText.TabIndex = 1;
            this.tokenText.Text = "Mzc0Njk3ODQ1ODQ2MTc5ODUw.XPpPIA.WUu7A4exLjluIHI28SpKlWIEs60";
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
            this.connectButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connectButton.Location = new System.Drawing.Point(62, 493);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(610, 86);
            this.connectButton.TabIndex = 3;
            this.connectButton.Text = "Connect...";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // textChannelLabel
            // 
            this.textChannelLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textChannelLabel.AutoSize = true;
            this.textChannelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textChannelLabel.Location = new System.Drawing.Point(699, 21);
            this.textChannelLabel.Name = "textChannelLabel";
            this.textChannelLabel.Size = new System.Drawing.Size(110, 20);
            this.textChannelLabel.TabIndex = 5;
            this.textChannelLabel.Text = "Text Channels";
            // 
            // voiceChannelLabel
            // 
            this.voiceChannelLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.voiceChannelLabel.AutoSize = true;
            this.voiceChannelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.voiceChannelLabel.Location = new System.Drawing.Point(699, 71);
            this.voiceChannelLabel.Name = "voiceChannelLabel";
            this.voiceChannelLabel.Size = new System.Drawing.Size(120, 20);
            this.voiceChannelLabel.TabIndex = 6;
            this.voiceChannelLabel.Text = "Voice Channels";
            // 
            // usersLabel
            // 
            this.usersLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.usersLabel.AutoSize = true;
            this.usersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usersLabel.Location = new System.Drawing.Point(699, 121);
            this.usersLabel.Name = "usersLabel";
            this.usersLabel.Size = new System.Drawing.Size(51, 20);
            this.usersLabel.TabIndex = 7;
            this.usersLabel.Text = "Users";
            // 
            // textChannelsDropdown
            // 
            this.textChannelsDropdown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textChannelsDropdown.FormattingEnabled = true;
            this.textChannelsDropdown.Location = new System.Drawing.Point(850, 20);
            this.textChannelsDropdown.Name = "textChannelsDropdown";
            this.textChannelsDropdown.Size = new System.Drawing.Size(179, 21);
            this.textChannelsDropdown.TabIndex = 9;
            // 
            // voiceChannelsDropdown
            // 
            this.voiceChannelsDropdown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.voiceChannelsDropdown.FormattingEnabled = true;
            this.voiceChannelsDropdown.Location = new System.Drawing.Point(850, 70);
            this.voiceChannelsDropdown.Name = "voiceChannelsDropdown";
            this.voiceChannelsDropdown.Size = new System.Drawing.Size(179, 21);
            this.voiceChannelsDropdown.TabIndex = 10;
            // 
            // usersDropdown
            // 
            this.usersDropdown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.usersDropdown.FormattingEnabled = true;
            this.usersDropdown.Location = new System.Drawing.Point(850, 120);
            this.usersDropdown.Name = "usersDropdown";
            this.usersDropdown.Size = new System.Drawing.Size(179, 21);
            this.usersDropdown.TabIndex = 11;
            // 
            // messageBox
            // 
            this.messageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.messageBox.Location = new System.Drawing.Point(703, 173);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(326, 290);
            this.messageBox.TabIndex = 12;
            this.messageBox.Text = "";
            // 
            // messageUser
            // 
            this.messageUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.messageUser.Location = new System.Drawing.Point(703, 493);
            this.messageUser.Name = "messageUser";
            this.messageUser.Size = new System.Drawing.Size(151, 86);
            this.messageUser.TabIndex = 13;
            this.messageUser.Text = "Send to User...";
            this.messageUser.UseVisualStyleBackColor = true;
            this.messageUser.Click += new System.EventHandler(this.MessageUser_Click);
            // 
            // messageChannel
            // 
            this.messageChannel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.messageChannel.Location = new System.Drawing.Point(878, 493);
            this.messageChannel.Name = "messageChannel";
            this.messageChannel.Size = new System.Drawing.Size(151, 86);
            this.messageChannel.TabIndex = 14;
            this.messageChannel.Text = "Send to Channel...";
            this.messageChannel.UseVisualStyleBackColor = true;
            this.messageChannel.Click += new System.EventHandler(this.MessageChannel_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 602);
            this.Controls.Add(this.messageChannel);
            this.Controls.Add(this.messageUser);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.usersDropdown);
            this.Controls.Add(this.voiceChannelsDropdown);
            this.Controls.Add(this.textChannelsDropdown);
            this.Controls.Add(this.usersLabel);
            this.Controls.Add(this.voiceChannelLabel);
            this.Controls.Add(this.textChannelLabel);
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
        private System.Windows.Forms.Label textChannelLabel;
        private System.Windows.Forms.Label voiceChannelLabel;
        private System.Windows.Forms.Label usersLabel;
        private System.Windows.Forms.ComboBox textChannelsDropdown;
        private System.Windows.Forms.ComboBox voiceChannelsDropdown;
        private System.Windows.Forms.ComboBox usersDropdown;
        private System.Windows.Forms.RichTextBox messageBox;
        private System.Windows.Forms.Button messageUser;
        private System.Windows.Forms.Button messageChannel;
    }
}

