using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BroBot.Core.Users;
using Newtonsoft.Json;

namespace BroBot.Core
{
    /// <summary>
    /// Class for storing users in a JSON format.
    /// TODO: Implement Entity Framework for data storage.
    /// </summary>
    public static class JsonStorage
    {
        /// <summary>
        /// Saves users to a JSON
        /// TODO: Implement exception handling for non-existant file
        /// </summary>
        /// <param name="users"></param>
        /// <param name="filePath"></param>
        public static void SaveUsers(IEnumerable<User> users, string filePath)
        {
            string json = JsonConvert.SerializeObject(users);
            File.WriteAllText(filePath, json);
        }

        /// <summary>
        /// Load users from JSON
        /// TODO: Implement exception handling for non-existant file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static IEnumerable<User> LoadUsers(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<User>>(json);
        }

        public static bool CheckIfFileExists(string filePath)
        {
            return File.Exists(filePath);
        }
    }
}
