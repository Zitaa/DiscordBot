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
    }
}
