using System;
using System.Reflection;
using System.Threading.Tasks;
using BroBot.Core.LevelingSystem;
using Discord.Commands;
using Discord.WebSocket;

namespace BroBot.Handlers
{
    /// <summary>
    /// Handles commands read in from Discord
    /// </summary>
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
            if (context.User.IsBot)
            {
                return;
            }

            //Leveling up
            LevelUtil.AddExperienceFromMessage((SocketGuildUser)context.User, (SocketTextChannel)context.Channel);

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
