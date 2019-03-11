using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscordBot
{
    public partial class Form1 : Form
    {
        public static Form1 instance;

        private DiscordBot bot;
        private DiscordSocketClient client;

        public Form1()
        {
            InitializeComponent();
            instance = this;
        }

        private void PopulateGuilds(object sender, EventArgs e)
        {
            guildsDropdown.Items.Clear();

            foreach (SocketGuild guild in client.Guilds)
            {
                guildsDropdown.Items.Add(guild.Name);
            }
            guildsDropdown.SelectedIndexChanged += guildsDropdown_SelectedIndexChanged;
        }

        public void Log(string msg)
        {
            if (msg == "Ready") msg += Environment.NewLine + "===========";
            string time = DateTime.Now.ToString("HH:mm");
            logDisplay.AppendText(string.Format("[{0}] {1}", time, msg + Environment.NewLine));
        }

        public void AssignClient()
        {
            client = bot.GetClient();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            bot = new DiscordBot();
            bot.Run(tokenText.Text);

            guildsDropdown.DropDown += PopulateGuilds;
        }

        private void guildsDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            textChannelsDropdown.Items.Clear();
            voiceChannelsDropdown.Items.Clear();
            usersDropdown.Items.Clear();

            foreach (SocketGuild guild in client.Guilds)
            {
                if (guild.Name == guildsDropdown.Text)
                {
                    foreach (SocketVoiceChannel channel in guild.VoiceChannels)
                    {
                        voiceChannelsDropdown.Items.Add(channel);
                    }

                    foreach (SocketTextChannel channel in guild.TextChannels)
                    {
                        textChannelsDropdown.Items.Add(channel);
                    }

                    foreach (SocketUser user in guild.Users)
                    {
                        usersDropdown.Items.Add(user);
                    }
                }
            }
        }
    }
}
