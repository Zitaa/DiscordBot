using Discord;
using Discord.Commands;
using Discord.WebSocket;
using DiscordBot.Collection;
using DiscordBot.Collection.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Modules
{
    public class General : ModuleBase<SocketCommandContext>
    {
        [Command("Info")]
        public async Task Info(SocketGuildUser socketUser = null)
        {
            User user = null;

            if (socketUser is null)
                user = Users.GetUser(Context.User);
            else user = Users.GetUser(socketUser);

            List<EmbedFieldBuilder> fields = new List<EmbedFieldBuilder>()
                {
                    new EmbedFieldBuilder() { Name = "Level", Value = user.Level },
                    new EmbedFieldBuilder() { Name = "XP", Value = user.XP, IsInline = true },
                    new EmbedFieldBuilder() { Name = "Required XP", Value = user.RequiredXP, IsInline = true },
                    new EmbedFieldBuilder() { Name = "Messages Sent", Value = user.Messages },
                    new EmbedFieldBuilder() { Name = "Times Reacted", Value = user.Reactions },
                };

            Embed embed = new EmbedBuilder()
                .WithTitle(user.Name)
                .WithFields(fields)
                .WithColor(EmbedHandler.color)
                .WithCurrentTimestamp().Build();

            await ReplyAsync("", false, embed);
        }

        [Command("delete")]
        public async Task DeleteMessages(int amount = 1)
        {
            IEnumerable<IMessage> messages = await Context.Channel.GetMessagesAsync(amount + 1).FlattenAsync();
            await ((ITextChannel)Context.Channel).DeleteMessagesAsync(messages);
            await ReplyAsync(string.Format("{0} deleted {1} messages.", Context.User.Username, amount));
        }

        [Command("event")]
        public async Task InitializeEvent([Remainder] string name)
        {
            User user = Users.GetUser(Context.User);

            List<EmbedFieldBuilder> fields = new List<EmbedFieldBuilder>()
            {
                new EmbedFieldBuilder() { Name = "Description", Value = "Write the description for your event.", IsInline = false }
            };

            Embed embed = new EmbedBuilder()
                .WithAuthor(user.Name)
                .WithTitle(name)
                .WithFields(fields)
                .WithColor(EmbedHandler.color)
                .WithCurrentTimestamp().Build();

            IMessage message = await ReplyAsync("", false, embed);
            user.BotMessageID = message.Id;
            user.EventPhase = EventPhases.Description;
            Users.SaveUsers();
        }

        [Command("__UpdateEventDescription")]
        public async Task UpdateEventDescription([Remainder] string description)
        {
            User user = Users.GetUser(Context.User);
            IMessage message = await Context.Channel.GetMessageAsync(user.BotMessageID);

            IEmbed oldEmbed = message.Embeds.First();
            List<EmbedFieldBuilder> fields = new List<EmbedFieldBuilder>()
            {
                new EmbedFieldBuilder() { Name = "Description", Value = description, IsInline = false },
                new EmbedFieldBuilder() { Name = "Players", Value = "Specifiy the Maximum Amount of Players", IsInline = false }
            };

            Embed embed = new EmbedBuilder()
                .WithAuthor(oldEmbed.Author.ToString())
                .WithTitle(oldEmbed.Title)
                .WithFields(fields)
                .WithColor(EmbedHandler.color)
                .WithCurrentTimestamp().Build();

            await Context.Channel.DeleteMessageAsync(Context.Message);
            await message.DeleteAsync();
            IMessage newMessage = await ReplyAsync("", false, embed);
            user.BotMessageID = newMessage.Id;
            user.EventPhase = EventPhases.Players;
        }

        [Command("__UpdateEventPlayers")]
        public async Task UpdateEventPlayers(int amount)
        {
            SocketGuild guild = Context.Guild;

            User user = Users.GetUser(Context.User);
            IMessage message = await Context.Channel.GetMessageAsync(user.BotMessageID);

            IEmbed oldEmbed = message.Embeds.First();
            List<EmbedFieldBuilder> fields = new List<EmbedFieldBuilder>()
            {
                new EmbedFieldBuilder() { Name = "Description", Value = oldEmbed.Fields.First().Value, IsInline = false },
                new EmbedFieldBuilder() { Name = string.Format("Players [1/{0}]", amount), Value = user.Name, IsInline = false }
            };

            Embed embed = new EmbedBuilder()
                .WithAuthor(oldEmbed.Author.ToString())
                .WithTitle(oldEmbed.Title)
                .WithFields(fields)
                .WithColor(EmbedHandler.color)
                .WithCurrentTimestamp().Build();

            await Context.Channel.DeleteMessageAsync(Context.Message);
            await message.DeleteAsync();
            IUserMessage newMessage = await ReplyAsync("", false, embed);

            foreach (Emote emote in Context.Guild.Emotes)
            {
                if (emote.Name == "checkmark" || emote.Name == "crossmark")
                    await newMessage.AddReactionAsync(emote);
            }

            user.BotMessageID = 0;
            user.EventPhase = EventPhases.None;
        }
    }
}
