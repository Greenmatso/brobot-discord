using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace BroBot.Core.Users
{
    public static class UserService
    {
        private static List<User> users;
        private static string userFile = "Resources/users.json";
        static UserService()
        {
            if (JsonStorage.CheckIfFileExists(userFile))
            {
                users = JsonStorage.LoadUsers(userFile).ToList();
            }
            else
            {
                users = new List<User>();
                SaveAccounts();
            }
        }

        /// <summary>
        /// Returns a user from the users list
        /// </summary>
        /// <param name="user">The user to retrieve</param>
        /// <returns>a User</returns>
        public static User GetUser(SocketUser user)
        {
            return GetOrCreateUser(user.Id, user.Username);
        }

        /// <summary>
        /// Updates the level of a User if the XP is greater than the XP required.
        /// </summary>
        /// <param name="user">The user to update the level of</param>
        /// <returns>The user with updated level</returns>
        public static User UpdateUserLevel(User user)
        {
            const ulong baseExp = 155;
            ulong levelExperience = 0;

            var experience = user.ExperiencePoints;
            var level = user.UserLevel;

            for (ulong i = 0; i <= level; i++)
            {
                levelExperience += baseExp + (10 * i);
            }


            if (experience >= levelExperience)
            {
                user.UserLevel = level + 1;
            }

            SaveAccounts();
            return user;
        }

        /// <summary>
        /// Saves users to the user list
        /// </summary>
        public static void SaveAccounts()
        {
            JsonStorage.SaveUsers(users, userFile);
        }

        #region Private methods

        /// <summary>
        /// Gets a user or creates a user if it doesn't exist
        /// </summary>
        /// <param name="id">The ID of the user to retrieve</param>
        /// <returns>The User</returns>
        private static User GetOrCreateUser(ulong id, string username)
        {
            var result = from a in users where a.UserId == id select a;
            var user = result.FirstOrDefault();
            if (user == null)
            {
                user = CreateUserAccount(id, username);
            }
            return user;
        }

        /// <summary>
        /// Creates a user with an ID
        /// </summary>
        /// <param name="id">The ID of the user to create</param>
        /// <returns>The new User</returns>
        private static User CreateUserAccount(ulong id, string username)
        {
            var newUser = new User
            {
                Username = username,
                UserId = id,
                UserPoints = 0,
                ExperiencePoints = 0,
                UserLevel = 0
            };
            users.Add(newUser);
            SaveAccounts();
            return newUser;
        }

        #endregion
    }
}
