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
        public async Task Test()
        {
            User user = Users.GetUser(Context.User);

            List<EmbedFieldBuilder> fields = new List<EmbedFieldBuilder>()
            {
                new EmbedFieldBuilder() { Name = "Description", Value = "Write the description for your event.", IsInline = false }
            };

            Embed embed = new EmbedBuilder()
                .WithAuthor(user.Name)
                .WithColor(EmbedHandler.color)
                .WithCurrentTimestamp().Build();

            IMessage message = await ReplyAsync("", false, embed);
            user.BotMessageID = message.Id;
            Users.SaveUsers();
        }

        [Command("test2")]
        public async Task Test2([Remainder] string description)
        {
            User user = Users.GetUser(Context.User);
            IMessage message = await Context.Channel.GetMessageAsync(user.BotMessageID);

            IEmbed oldEmbed = message.Embeds.First();
            List<EmbedFieldBuilder> fields = new List<EmbedFieldBuilder>()
            {
                new EmbedFieldBuilder() { Name = "Description", Value = description, IsInline = false }
            };

            Embed embed = new EmbedBuilder()
                .WithAuthor(oldEmbed.Author.ToString())
                .WithFields(fields)
                .WithColor(EmbedHandler.color)
                .WithCurrentTimestamp().Build();

            await Context.Channel.DeleteMessageAsync(Context.Message);
            await message.DeleteAsync();
            IMessage newMessage = await ReplyAsync("", false, embed);
            user.BotMessageID = newMessage.Id;
        }
    }
}
