using Discord.WebSocket;
using DiscordBot.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Collection.Users
{
    public static class Users
    {
        private static List<User> users;

        public static void Initialize()
        {
            if (Data.DataExists(Data.AccountPath))
                users = Data.Load<List<User>>(Data.AccountPath).ToList();
            else
            {
                users = new List<User>();
                SaveUsers();
            }

            Menu.instance.Log("Users ready.");
        }

        private static User GetOrCreateUser(SocketUser socketUser)
        {
            IEnumerable<User> users = from _user in Users.users
                                      where _user.ID == socketUser.Id
                                      select _user;

            User user = users.FirstOrDefault();
            if (user == null) user = CreateUser(socketUser);
            return user;
        }

        private static User CreateUser(SocketUser socketUser)
        {
            User user = new User()
            {
                Name = socketUser.Username,
                ID = socketUser.Id,
                Level = 0,
                XP = 0,
                RequiredXP = 50,
                Messages = 0,
                Reactions = 0
            };

            users.Add(user);
            SaveUsers();
            return user;
        }

        public static User GetUser(SocketUser socketUser)
        {
            return GetOrCreateUser(socketUser);
        }

        public static void SaveUsers() => Data.Save(users, Data.AccountPath);

        public static List<User> GetUsers() => users;
    }
}
