using DiscordBot.Collection;

namespace DiscordBot.Resources
{
    public static class Config
    {
        public static BotConfig Bot { get; private set; }

        public static bool Initialize()
        {
            if (Data.DataExists(Data.ConfigPath))
            {
                Menu.instance.Log("Config ready.");
                return true;
            }
            else
            {
                Menu.instance.Log("Config file was not found." +
                    "\nPlease, make sure there is a config file present in the [Resources] folder.");
                return false;
            }
        }

        public struct BotConfig
        {
            public string Token { get; set; }
            public ulong ServerID { get; set; }
            public string Prefix { get; set; }
        }
    }
}
