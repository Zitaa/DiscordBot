using Discord;
using Discord.WebSocket;
using DiscordBot.Collection.Users;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using ST = System.Timers;
using DiscordBot.Collection;
using DiscordBot.Resources;

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

            DatabaseMenu databaseMenu = new DatabaseMenu();
            databaseMenu.Show();
        }

        public void Log(string msg)
        {
            if (msg == "Ready") msg += Environment.NewLine + 
                    "-----------------------";
            string time = DateTime.Now.ToString("HH:mm");
            logDisplay.AppendText(string.Format("[{0}] {1}", time, msg + Environment.NewLine));
        }

        public void AssignClient()
        {
            client = bot.GetClient();
            FillDropdowns();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            bot = new DiscordBot();
            bot.Run(tokenText.Text);

            ST::Timer timer = new ST::Timer(1000 * (60 * 5));
            timer.Elapsed += OnElapsed;
            timer.Enabled = true;
        }

        private void OnElapsed(object sender, ST.ElapsedEventArgs e)
        {
            IReadOnlyCollection<SocketGuildUser> users = client.GetGuild(Config.Bot.ServerID).Users;
            IReadOnlyCollection<IRole> roles = client.GetGuild(Config.Bot.ServerID).Roles;

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

        public void FillDropdowns()
        {
            SocketGuild guild = client.GetGuild(Config.Bot.ServerID);

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

            voiceChannelsDropdown.SelectedItem = voiceChannelsDropdown.Items[0];
            textChannelsDropdown.SelectedItem = textChannelsDropdown.Items[0];
            usersDropdown.SelectedItem = usersDropdown.Items[0];
        }

        private async void MessageUser_Click(object sender, EventArgs e)
        {
            string username = usersDropdown.SelectedItem.ToString();
            SocketGuildUser user = null;

            foreach (var guildUser in client.GetGuild(Config.Bot.ServerID).Users)
            {
                if (guildUser.ToString().Equals(username))
                {
                    user = guildUser;
                    break;
                }
            }

            string message = messageBox.Text;
            messageBox.Text = string.Empty;

            IDMChannel channel = await user.GetOrCreateDMChannelAsync();
            await channel.SendMessageAsync(message);
        }

        private async void MessageChannel_Click(object sender, EventArgs e)
        {
            string channelName = textChannelsDropdown.SelectedItem.ToString();
            SocketTextChannel channel = null;

            foreach (var guildChannel in client.GetGuild(Config.Bot.ServerID).TextChannels)
            {
                if (guildChannel.Name.Equals(channelName))
                {
                    channel = guildChannel;
                    break;
                }
            }

            string message = messageBox.Text;
            messageBox.Text = string.Empty;

            await channel.SendMessageAsync(message);
        }
    }
}
