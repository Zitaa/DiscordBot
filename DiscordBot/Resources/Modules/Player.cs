using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Modules
{
    public class Player : ModuleBase<SocketCommandContext>
    {
        public Audio Audio { get; set; }

        [Command("Play")]
        public async Task Play([Remainder]string url)
        {
            await ReplyAsync("", false, await Audio.JoinOrPlay((SocketGuildUser)Context.User, Context.Channel, url));
        }

        [Command("Pause")]
        public async Task Pause()
        {
            await ReplyAsync("", false, await Audio.PauseCurrentTrack((SocketGuildUser)Context.User, Context.Channel));
        }

        [Command("Skip")]
        public async Task Skip()
        {
            await ReplyAsync("", false, await Audio.SkipCurrentlyPlayingTrack((SocketGuildUser)Context.User, Context.Channel));
        }

        [Command("queue")]
        public async Task Queue()
        {
            await ReplyAsync("", false, await Audio.ListQueue((SocketGuildUser)Context.User, Context.Channel));
        }

        [Command("Loop")]
        public async Task Loop()
        {
            await ReplyAsync("", false, await Audio.LoopTrack((SocketGuildUser)Context.User, Context.Channel));
        }

        [Command("Volume")]
        public async Task SetVolume(int volume = 50)
        {
            await ReplyAsync("", false, await Audio.SetVolume((SocketGuildUser)Context.User, Context.Channel, volume));
        }
    }
}
