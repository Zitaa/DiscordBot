using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordBot.Collection.Users;
using Newtonsoft.Json;

namespace DiscordBot.Collection
{
    public static class Data
    {
        public static string DirectoryPath { get; private set; }
        public static string AccountPath { get; private set; }
        public static string ConfigPath { get; private set; }

        public static void Initialize()
        {
            DirectoryPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            AccountPath = DirectoryPath + @"\Resources\Data\Users.json";
            ConfigPath = DirectoryPath + @"\Resources\Config.cfg";

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
