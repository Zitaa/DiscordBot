using Discord;
using Discord.Commands;
using Discord.WebSocket;
using DiscordBot.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victoria;
using Victoria.Entities;
using Victoria.Entities.Enums;

namespace DiscordBot.Modules
{
    public class Audio
    {
        public bool Loop { get; private set; } = false;
        public bool WasSkipped { get; private set; } = false;

        private Lavalink lavalink;

        public Audio(Lavalink lavalink)
        {
            this.lavalink = lavalink;
        }

        public async Task<Embed> JoinOrPlay(SocketGuildUser user, IMessageChannel channel, string query = null)
        {
            if (user.VoiceChannel == null)
                return await EmbedHandler.CreateErrorEmbed("Audio, Join/Play", "You Need To Be In a Voice Channel.");

            await lavalink.DefaultNode.ConnectAsync(user.VoiceChannel);

            if (query != null)
            {
                LavaPlayer player = lavalink.DefaultNode.GetPlayer(DiscordBot.GuildID);
                player.TextChannel = channel;

                IUserMessage message = await player.TextChannel.SendMessageAsync("Searching...");

                LavaTrack track;
                LavaResult search = await lavalink.DefaultNode.SearchYouTubeAsync(query);

                if (search.LoadResultType == LoadResultType.NoMatches)
                {
                    await message.DeleteAsync();
                    return await EmbedHandler.CreateErrorEmbed("Audio, Query", "There Were No Query Results.");
                }
                else
                {
                    track = search.Tracks.FirstOrDefault();
                    await message.DeleteAsync();

                    if (player.CurrentTrack != null && player.IsPlaying || player.IsPaused)
                    {
                        player.Queue.Enqueue(track);
                        return await EmbedHandler.CreateEmbed("Audio", string.Format("{0} has been added to the queue.", track.Title));
                    }
                    else
                    {
                        await player.PlayAsync(track);
                        return await EmbedHandler.CreateEmbed("Audio", string.Format("Now Playing: {0}.", track.Title));
                    }
                }
            }
            return await EmbedHandler.CreateEmbed("Audio", "Joined voice channel " + user.VoiceChannel + ".");
        }

        public async Task<Embed> PauseCurrentTrack(SocketGuildUser user, IMessageChannel channel)
        {
            LavaPlayer player = lavalink.DefaultNode.GetPlayer(DiscordBot.GuildID);
            player.TextChannel = channel;

            if (player.CurrentTrack != null)
            {
                if (player.IsPlaying && !player.IsPaused)
                {
                    await player.PauseAsync();
                    return await EmbedHandler.CreateEmbed("Audio", string.Format("{0} set the player to pause.", user.Username));
                }
                else
                {
                    await player.PauseAsync();
                    return await EmbedHandler.CreateEmbed("Audio", string.Format("{0} unpaused the player.", user.Username));
                }
            }
            else return await EmbedHandler.CreateEmbed("Audio", "There's nothing to pause currently.\nPerhaps add a track first, you retard.");
        }

        public async Task<Embed> SkipCurrentlyPlayingTrack(SocketGuildUser user, IMessageChannel channel)
        {
            LavaPlayer player = lavalink.DefaultNode.GetPlayer(DiscordBot.GuildID);
            player.TextChannel = channel;

            if (player.CurrentTrack != null && player.IsPlaying)
            {
                WasSkipped = true;
                LavaTrack track = player.CurrentTrack;
                await player.StopAsync();

                if (player.Queue.Count > 0)
                {
                    await player.PlayAsync(player.Queue.Items.ElementAt(0));
                    return await EmbedHandler.CreateEmbed("Audio", string.Format("{0} was skipped.\nNext song: {1}.", track.Title, player.CurrentTrack.Title));
                }
                else return await EmbedHandler.CreateEmbed("Audio", string.Format("{0} was skipped.\nThere are no more tracks in the queue.", track.Title));
            }
            else return await EmbedHandler.CreateErrorEmbed("Audio, Current Track", "There Are No Current Track.");
        }

        public async Task<Embed> SetVolume(SocketGuildUser user, IMessageChannel channel, int volume)
        {
            LavaPlayer player = lavalink.DefaultNode.GetPlayer(DiscordBot.GuildID);

            if (player.VoiceChannel != null)
            {
                await player.SetVolumeAsync(volume);
                return await EmbedHandler.CreateEmbed("Audio", string.Format("{0} changed volume to {1}.", user.Username, volume.ToString()));
            }
            else return await EmbedHandler.CreateErrorEmbed("Audio, Volume", "Not In a Voice Channel.");
        }

        public async Task<Embed> ListQueue(SocketGuildUser user, IMessageChannel channel)
        {
            LavaPlayer player = lavalink.DefaultNode.GetPlayer(DiscordBot.GuildID);
            player.TextChannel = channel;

            string trackTitles = "Currently Playing: " + player.CurrentTrack.Title + "\n\n";
            foreach (LavaTrack track in player.Queue.Items)
            {
                trackTitles += string.Format("• {0} | {1}\n\n", track.Title, track.Length);
            }

            return await EmbedHandler.CreateEmbed("Audio", trackTitles);
        }

        public async Task<Embed> LoopTrack(SocketGuildUser user, IMessageChannel channel)
        {
            LavaPlayer player = lavalink.DefaultNode.GetPlayer(DiscordBot.GuildID);

            Loop = !Loop;

            if (Loop) return await EmbedHandler.CreateEmbed("Audio", "Loop has been turned on.");
            else return await EmbedHandler.CreateEmbed("Audio", "Loop has been turned off.");
        }

        public async Task OnFinished(LavaPlayer player, LavaTrack track, TrackReason reason)
        {
            if (reason is TrackReason.LoadFailed || reason is TrackReason.Cleanup)
                return;

            if (Loop && !WasSkipped)
            {
                await player.PlayAsync(track);
                await player.TextChannel.SendMessageAsync("", false,
                        await EmbedHandler.CreateEmbed("Audio", string.Format("{0} is on repeat.", track.Title)));
            }
            else
            {
                WasSkipped = false;
                player.Queue.TryDequeue(out LavaTrack nextTrack);

                if (nextTrack is null)
                {
                    await player.StopAsync();
                }
                else
                {
                    await player.PlayAsync(nextTrack);
                    await player.TextChannel.SendMessageAsync("", false,
                        await EmbedHandler.CreateEmbed("Audio", string.Format("Now playing: {0}", nextTrack.Title)));
                }
            }
        }
    }
}
