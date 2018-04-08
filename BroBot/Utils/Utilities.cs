using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace BroBot.Utils
{
    class Utilities
    {
        private static readonly Dictionary<string, string> _alerts;

        /// <summary>
        /// Deserializes alerts from alerts.json
        /// </summary>
        static Utilities()
        {
            string json = File.ReadAllText(Constants.AlertsPath);
            var data = JsonConvert.DeserializeObject<dynamic>(json);
            _alerts = data.ToObject<Dictionary<string, string>>();
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
    }
}
