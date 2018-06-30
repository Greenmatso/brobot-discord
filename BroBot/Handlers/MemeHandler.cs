using System;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace BroBot.Handlers
{
    class MemeHandler
    {
        private const string AccessKey = "access-code-here";
        private const string UriBase = "https://api.cognitive.microsoft.com/bing/v7.0/images/search?q=";
        private const string SearchPrefix = "meme+";

        public static string SearchMemeOnBing(string query)
        {
            var uriQuery = UriBase + SearchPrefix + Uri.EscapeDataString(query);

            WebRequest req = HttpWebRequest.Create(uriQuery);
            req.Headers["Ocp-Apim-Subscription-Key"] = AccessKey;

            HttpWebResponse res = (HttpWebResponse)req.GetResponseAsync().Result;
            string json = new StreamReader(res.GetResponseStream()).ReadToEnd();

            JObject jsonObject = JObject.Parse(json);

            return (string)jsonObject["value"][0]["contentUrl"];
        }
    }
}
