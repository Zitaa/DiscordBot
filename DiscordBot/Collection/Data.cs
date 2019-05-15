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
        public static string AccountPath { get; private set; }

        public static void Initialize()
        {
            AccountPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName
                + @"\Resources\Data\Users.json";

            Menu.instance.Log("Data ready.");
        }

        public static void SaveUsers(IEnumerable<User> users)
        {
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(AccountPath, json);
        }

        public static IEnumerable<User> LoadUsers()
        {
            if (File.Exists(AccountPath))
            {
                string json = File.ReadAllText(AccountPath);
                return JsonConvert.DeserializeObject<List<User>>(json);
            }
            else return null;
        }

        public static bool DataExists(string path)
        {
            if (File.Exists(path)) return true;
            return false;
        }
    }
}
