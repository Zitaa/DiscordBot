using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot
{
    class DiscordBot
    {
        private DiscordSocketClient client;
        private CommandService commands;
        private IServiceProvider services;

        public async void Run(string token)
        {
            client = new DiscordSocketClient();
            commands = new CommandService();

            services = new ServiceCollection()
                .AddSingleton(client)
                .AddSingleton(commands)
                .BuildServiceProvider();

            client.Log += Log;

            await RegisterCommands();
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
            Form1.instance.AssignClient();
        }

        public async void Terminate()
        {
            await client.LogoutAsync();
            await client.StopAsync();
        }

        private Task Log(LogMessage msg)
        {
            Form1.instance.Log(msg.Message);
            return Task.CompletedTask;
        }

        private async Task HandleCommands(SocketMessage msg)
        {
            SocketUserMessage message = msg as SocketUserMessage;
            Form1.instance.Log(string.Format("{0}: {1}", message.Author.Username, message.Content));

            if (message == null || message.Author.IsBot) return;

            int argPos = 0;
            if (message.HasStringPrefix(".", ref argPos) || message.HasMentionPrefix(client.CurrentUser, ref argPos))
            {
                SocketCommandContext context = new SocketCommandContext(client, message);
                IResult result = await commands.ExecuteAsync(context, argPos, services);

                if (!result.IsSuccess) Form1.instance.Log(result.ErrorReason);
            }
        }

        public async Task RegisterCommands()
        {
            client.MessageReceived += HandleCommands;
            await commands.AddModulesAsync(Assembly.GetEntryAssembly(), services);
        }

        public DiscordSocketClient GetClient() { return client; }
    }
}
