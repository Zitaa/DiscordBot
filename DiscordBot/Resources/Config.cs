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
                Bot = Data.Load<BotConfig>(Data.ConfigPath);
                Menu.instance.Log("Config ready.");
                return true;
            }
            else
            {
                BotConfig config = new BotConfig();
                Data.Save(config, Data.ConfigPath);

                Menu.instance.Log(string.Format("Config file was not found. " +
                    "\nA config file has been created at [{0}]. " +
                    "\nPlease, open the config file and fill it with correct information.", Data.ConfigPath));
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
