using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BroBot
{
    class DataStorage
    {
        private static Dictionary<string, string> data = new Dictionary<string, string>();
        public const string dataFile = "data.json";

        static DataStorage()
        {
            var fileExists = ValidateDataFile(dataFile);
            if (!fileExists)
            {
                return;
            }

            string json = File.ReadAllText(dataFile);
            data = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }

        public static void AddData(string key, string value)
        {
            data.Add(key, value);
            SaveData();
        }

        public static Dictionary<string, string> GetData()
        {
            return data;
        }


        #region Private Methods

        private static void SaveData()
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(dataFile, json);
        }

        private static bool ValidateDataFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "");
                SaveData();
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion
    }
}
