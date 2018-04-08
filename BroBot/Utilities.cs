using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace BroBot
{
    class Utilities
    {
        private static Dictionary<string, string> alerts;

        /// <summary>
        /// Deserializes alerts from alerts.json
        /// </summary>
        static Utilities()
        {
            string json = File.ReadAllText("SystemLang/alerts.json");
            var data = JsonConvert.DeserializeObject<dynamic>(json);
            alerts = data.ToObject<Dictionary<string, string>>();
        }

        /// <summary>
        /// Retrieves an alert from alert.json
        /// </summary>
        /// <param name="key">Key of alert to retrieve</param>
        /// <returns>alert string</returns>
        public static string GetAlert(string key)
        {
            if (alerts.ContainsKey(key))
            {
                return alerts[key];
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
            if (alerts.ContainsKey(key))
            {
                return String.Format(alerts[key], parameters);
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
