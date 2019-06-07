using System.IO;
using Newtonsoft.Json;

namespace DiscordBot.Collection
{
    public static class Data
    {
        public static string AccountPath { get; private set; } =
            Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Resources\Data\Users.json";
        public static string ConfigPath { get; private set; } =
            Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Resources\Config.cfg";

        public static void Initialize()
        {
            Menu.instance.Log("Data ready.");
        }

        public static T Load<T>(string path)
        {
            if (DataExists(path))
            {
                string json = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<T>(json);
            }
            return default;
        }

        public static void Save<T>(T objectToSave, string path)
        {
            string json = JsonConvert.SerializeObject(objectToSave, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        public static bool DataExists(string path)
        {
            if (File.Exists(path)) return true;
            return false;
        }
    }
}
