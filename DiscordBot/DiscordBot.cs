using Discord;
using Discord.Commands;
using Discord.WebSocket;
using DiscordBot.Modules;
using DiscordBot.Collection.Users;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscordBot.Collection;
using Victoria;
using DiscordBot.Resources;
using System.Linq;
using System.Collections.Generic;

namespace DiscordBot
{
    public class DiscordBot
    {
        private DiscordSocketClient client;
        private CommandService commands;
        private Lavalink lavalink;
        private IServiceProvider services;

        public async void Run(string token)
        {
            client = new DiscordSocketClient();
            commands = new CommandService();
            lavalink = new Lavalink();

            if (!Config.Initialize()) return;
            Data.Initialize();
            Users.Initialize();

            SetupServices();
            SetupEvents();

            await RegisterCommands();
            await client.LoginAsync(TokenType.Bot, Config.Bot.Token);
            await client.StartAsync();
        }

        private void SetupEvents()
        {
            Application.ApplicationExit += OnExit;
            lavalink.Log += Log;
            client.Log += Log;
            client.UserJoined += OnUserJoin;
            client.UserLeft += OnUserLeave;
            client.ReactionAdded += OnReact;
            client.Ready += OnReady;
        }

        private void SetupServices()
        {
            services = new ServiceCollection()
                .AddSingleton(client)
                .AddSingleton(commands)
                .AddSingleton(lavalink)
                .AddSingleton<Audio>()
                .BuildServiceProvider();
        }

        public async void Terminate()
        {
            Users.RemoveBotMessage();

            await client.LogoutAsync();
            await client.StopAsync();
        }

        private Task Log(LogMessage msg)
        {
            Menu.instance.Log(msg.Message);
            return Task.CompletedTask;
        }

        private Task Log(string message)
        {
            Menu.instance.Log(message);
            return Task.CompletedTask;
        }

        private async Task HandleCommands(SocketMessage msg)
        {
            SocketUserMessage message = msg as SocketUserMessage;
            if (message == null || message.Author.IsBot) return;

            Menu.instance.Log(string.Format("{0}: {1}", message.Author.Username, message.Content));
            User user = Users.GetUser(message.Author);

            user.Messages++;
            User.IncreaseXP(user, 10, message.Channel);

            int argPos = 0;
            if (message.HasStringPrefix(Config.Bot.Prefix, ref argPos) || message.HasMentionPrefix(client.CurrentUser, ref argPos))
            {
                SocketCommandContext context = new SocketCommandContext(client, message);
                IResult result = await commands.ExecuteAsync(context, argPos, services);

                if (!result.IsSuccess) Menu.instance.Log(result.ErrorReason);
            }
            else if (user.BotMessageID != 0)
            {
                SocketCommandContext context = new SocketCommandContext(client, message);
                IResult result = default;
                switch (user.EventPhase)
                {
                    case EventPhases.Description:
                        result = await commands.ExecuteAsync(context, "__UpdateEventDescription " + message.Content, services);
                        break;
                    case EventPhases.Players:
                        result = await commands.ExecuteAsync(context, "__UpdateEventPlayers " + message.Content, services);
                        break;
                }
                if (!result.IsSuccess)
                    await Log(result.ErrorReason);
            }
        }

        public async Task RegisterCommands()
        {
            client.MessageReceived += HandleCommands;
            await commands.AddModulesAsync(Assembly.GetEntryAssembly(), services);
        }

        private Task OnUserJoin(SocketGuildUser user)
        {
            Menu.instance.Log(string.Format("{0} joined at [{1}].", user.Username, DateTime.UtcNow.ToString("HH:mm")));
            return Task.CompletedTask;
        }

        private Task OnUserLeave(SocketGuildUser user)
        {
            Menu.instance.Log(string.Format("{0} left at [{1}].", user.Username, DateTime.UtcNow.ToString("HH:mm")));
            return Task.CompletedTask;
        }

        private async Task OnReact(Cacheable<IUserMessage, ulong> message, ISocketMessageChannel channel, SocketReaction reaction)
        {
            User user = Users.GetUser((SocketGuildUser)reaction.User);
            user.Reactions++;
            Users.SaveUsers();

            if (reaction.Emote.Name == "checkmark" || reaction.Emote.Name == "crossmark")
            {
                if (message.Value.Embeds.Count > 0)
                {
                    IMessage msg = message.Value;
                    IEmbed oldEmbed = msg.Embeds.First();

                    string players = oldEmbed.Fields.ElementAt(1).Name;
                    int max = Int32.Parse(players[11].ToString());
                    int amount = Int32.Parse(players[9].ToString());
                    amount++;

                    players = oldEmbed.Fields.ElementAt(1).Value;
                    players += "\n" + user.Name;
                     
                    List<EmbedFieldBuilder> fields = new List<EmbedFieldBuilder>()
                    {
                        new EmbedFieldBuilder() { Name = "Description", Value = oldEmbed.Fields.ElementAt(0).Value, IsInline = false },
                        new EmbedFieldBuilder() { Name = string.Format("Players [{0}/{1}]", amount, max), Value = players, IsInline = false }
                    };

                    Embed embed = new EmbedBuilder()
                        .WithAuthor(oldEmbed.Author.ToString())
                        .WithTitle(oldEmbed.Title)
                        .WithFields(fields)
                        .WithColor(EmbedHandler.color)
                        .WithCurrentTimestamp().Build();

                    await msg.DeleteAsync();
                    await channel.SendMessageAsync("", false, embed);
                }
            }
        }

        private async Task OnReady()
        {
            Menu.instance.AssignClient();

            LavaNode node = await lavalink.AddNodeAsync(client);
            node.TrackFinished += services.GetService<Audio>().OnFinished;
        }

        private void OnExit(object sender, EventArgs e)
        {
            Terminate();
        }

        public DiscordSocketClient GetClient() { return client; }
    }
}
