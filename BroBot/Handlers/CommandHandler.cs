using System;
using System.Reflection;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;

namespace BroBot.Handlers
{
    class CommandHandler
    {
        DiscordSocketClient _client;
        CommandService _service;

        public async Task InitializeAsync(DiscordSocketClient client)
        {
            _client = client;
            _service = new CommandService();
            await _service.AddModulesAsync(Assembly.GetEntryAssembly());
            _client.MessageReceived += HandleCommandAsync;
        }

        private async Task HandleCommandAsync(SocketMessage message)
        {
            var userMessage = message as SocketUserMessage;
            if (userMessage == null)
            {
                return;
            }

            var context = new SocketCommandContext(_client, userMessage);
            int argPos = 0;
            if (userMessage.HasStringPrefix(Config.bot.cmdPrefix, ref argPos) ||
                userMessage.HasMentionPrefix(_client.CurrentUser, ref argPos))
            {
                var result = await _service.ExecuteAsync(context, argPos);
                if (!result.IsSuccess && result.Error != CommandError.UnknownCommand)
                {
                    Console.WriteLine(result.Error);
                }
            }
        }
    }
}
