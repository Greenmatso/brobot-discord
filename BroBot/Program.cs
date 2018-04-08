using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace BroBot
{
    class Program
    {
        DiscordSocketClient _client;
        CommandHandler _handler;

        /// <summary>
        /// Starts bot by calling StartAsync
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
            => new Program().StartAsync().GetAwaiter().GetResult();

        /// <summary>
        /// Starts Bot Asyncronously
        /// </summary>
        /// <returns></returns>
        public async Task StartAsync()
        {
            if (String.IsNullOrEmpty(Config.bot.token))
            {
                return;
            }
            _client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Verbose
            });
            _client.Log += Log;
            await _client.LoginAsync(TokenType.Bot, Config.bot.token);
            await _client.StartAsync();

            _handler = new CommandHandler();
            await _handler.InitializeAsync(_client);
            await Task.Delay(-1);
        }

        /// <summary>
        /// Writes a log message
        /// </summary>
        /// <param name="message">The log message</param>
        /// <returns></returns>
        private async Task Log(LogMessage message)
        {
            Console.WriteLine(message);
        }
    }
}
