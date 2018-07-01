using System;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace BroBot.Handlers
{
    class MemeHandler
    {
        private const string UriBase = "https://api.cognitive.microsoft.com/bing/v7.0/images/search?q=meme+{0}&offset={1}";
        private static readonly string AccessKey = Config.bot.bingToken;

        public static string SearchMemeOnBing(string query)
        {
            var offset = GenerateOffset();
            var uriQuery = String.Format(UriBase, Uri.EscapeDataString(query), offset);

            WebRequest req = HttpWebRequest.Create(uriQuery);
            req.Headers["Ocp-Apim-Subscription-Key"] = AccessKey;

            HttpWebResponse res = (HttpWebResponse)req.GetResponseAsync().Result;
            string json = new StreamReader(res.GetResponseStream()).ReadToEnd();

            JObject jsonObject = JObject.Parse(json);

            return (string)jsonObject["value"][0]["contentUrl"];
        }

        private static int GenerateOffset()
        {
            return new Random().Next(0, 15);
        }
    }
}
