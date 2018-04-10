using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace BroBot.Utils
{
    class Utilities
    {
        private static Dictionary<string, string> _alerts;
        private static Dictionary<string, string> _broCommands;

        /// <summary>
        /// Deserializes alerts from alerts.json
        /// </summary>
        static Utilities()
        {
            GetAlertsFromJson();
            GetBroCommandsFromJson();
        }

        /// <summary>
        /// Retrieves an alert from alert.json
        /// </summary>
        /// <param name="key">Key of alert to retrieve</param>
        /// <returns>alert string</returns>
        public static string GetAlert(string key)
        {
            if (_alerts.ContainsKey(key))
            {
                return _alerts[key];
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Retrieves abro command from bro-commands.json
        /// </summary>
        /// <param name="key">Key of command to retrieve</param>
        /// <returns>command string</returns>
        public static string GetBroCommand(string key)
        {
            if (_broCommands.ContainsKey(key))
            {
                return _broCommands[key];
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Returns an alert from the alerts.json formatted with an array of parameters
        /// (String format abstraction)
        /// </summary>
        /// <param name="key">Key of alert to retrieve</param>
        /// <param name="parameters">parameters to format the string with</param>
        /// <returns>alert string</returns>
        public static string GetFormattedAlert(string key, params object[] parameters)
        {
            if (_alerts.ContainsKey(key))
            {
                return String.Format(_alerts[key], parameters);
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Returns an alert from the alerts.json formatted with a paramter
        /// </summary>
        /// <param name="key">Key of alert to retrieve</param>
        /// <param name="parameter">parameter to format the string with</param>
        /// <returns>alert string</returns>
        public static string GetFormattedAlert(string key, object parameter)
        {
            return GetFormattedAlert(key, new object[] { parameter });
        }

        /// <summary>
        /// Returns a command from the bro-commands.json formatted with an array of parameters
        /// (String format abstraction)
        /// </summary>
        /// <param name="key">Key of command to retrieve</param>
        /// <param name="parameters">parameters to format the string with</param>
        /// <returns>command string</returns>
        public static string GetFormattedBroCommand(string key, params object[] parameters)
        {
            if (_broCommands.ContainsKey(key))
            {
                return String.Format(_broCommands[key], parameters);
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Returns a command from the bro-commands.json formatted with a parameter
        /// </summary>
        /// <param name="key">Key of command to retrieve</param>
        /// <param name="parameter">parameter to format the string with</param>
        /// <returns>command string</returns>
        public static string GetFormattedBroCommand(string key, object parameter)
        {
            return GetFormattedBroCommand(key, new object[] { parameter });
        }



        #region Private methods

        private static void GetAlertsFromJson()
        {
            string json = File.ReadAllText(Constants.AlertsPath);
            var data = JsonConvert.DeserializeObject<dynamic>(json);
            _alerts = data.ToObject<Dictionary<string, string>>();
        }

        private static void GetBroCommandsFromJson()
        {
            string json = File.ReadAllText("SystemLang/bro-commands.json");
            var data = JsonConvert.DeserializeObject<dynamic>(json);
            _broCommands = data.ToObject<Dictionary<string, string>>();
        }

        #endregion 
    }
}
