using Discord;
using Discord.WebSocket;
using DiscordBot.Collection.Users;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using ST = System.Timers;
using DiscordBot.Collection;

namespace DiscordBot
{
    public partial class Menu : Form
    {
        public static Menu instance;

        private DiscordBot bot;
        private DiscordSocketClient client;

        public Menu()
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
            if (msg == "Ready") msg += Environment.NewLine + 
                    "====================================================================================================";
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

            Data.Initialize();
            Users.Initialize();
            Log("Audio ready.");

            guildsDropdown.DropDown += PopulateGuilds;

            ST::Timer timer = new ST::Timer(1000 * (60 * 5));
            timer.Elapsed += OnElapsed;
            timer.Enabled = true;
        }

        private void OnElapsed(object sender, ST.ElapsedEventArgs e)
        {
            IReadOnlyCollection<SocketGuildUser> users = client.GetGuild(DiscordBot.GuildID).Users;
            IReadOnlyCollection<IRole> roles = client.GetGuild(DiscordBot.GuildID).Roles;

            foreach (SocketGuildUser user in users)
            {
                IActivity activity = user.Activity;
                if (activity != null)
                {
                    foreach (IRole role in roles)
                    {
                        bool haveRole = false;
                        foreach (IRole userRole in user.Roles)
                        {
                            if (role == userRole)
                            {
                                haveRole = true;
                                break;
                            }
                        }

                        if (haveRole) continue;

                        if (role.Name.Contains(activity.Name))
                        {
                            user.AddRoleAsync(role);
                            Log(string.Format("{0} was added to {1}.", role.Name, user.Username));
                        }
                        else if (activity.Name.Contains("Visual Studio")
                            && role.Name == "Developer")
                        {
                            user.AddRoleAsync(role);
                            Log(string.Format("{0} was added to {1}.", role.Name, user.Username));
                        }
                    }
                }
            }
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
