﻿using Discord;
using System.Threading.Tasks;

namespace DiscordBot.Collection.Users
{
    public enum EventPhases
    {
        None = 0,
        Description = 1,
        Players = 2
    }

    public class User
    {
        public string Name { get; set; }
        public ulong ID { get; set; }
        public uint Level { get; set; }
        public int XP { get; set; }
        public int RequiredXP { get; set; }
        public uint Messages { get; set; }
        public uint Reactions { get; set; }
        public ulong BotMessageID { get; set; }
        public EventPhases EventPhase { get; set; }

        public async static Task<Embed> IncreaseLevel(User user)
        {
            user.Level++;
            return await EmbedHandler.CreateEmbed("Level Up", string.Format("{0} reached level {1}!", user.Name, user.Level));
        }

        public async static void IncreaseXP(User user, int amount, IMessageChannel channel)
        {
            user.XP += amount;
            if (user.XP >= user.RequiredXP)
            {
                await channel.SendMessageAsync("", false, await IncreaseLevel(user));

                user.XP = 0;
                user.RequiredXP = (int)(user.RequiredXP * 1.25f);
            }
            Users.SaveUsers();
        }

        public static void DecreaseLevel(User user)
        {
            user.Level--;
        }

        public static void DecreaseXP(User user, int amount)
        {
            int difference = user.XP - amount;
            if (difference < 0)
            {
                DecreaseLevel(user);
                user.RequiredXP = (int)(user.RequiredXP / 1.25f) + 1;
                user.XP = user.RequiredXP - -(difference) + 1;
            }
            else user.XP -= amount;
            Users.SaveUsers();
        }
    }
}
