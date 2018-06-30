using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BroBot.Core.Users;
using BroBot.Utils;
using Discord;
using Discord.WebSocket;

namespace BroBot.Core.LevelingSystem
{
    internal static class LevelUtil
    {
        internal static async void AddExperienceFromMessage(SocketGuildUser socketUser, SocketTextChannel channel)
        {
            // if timeout, ignore
            var user = UserService.GetUser(socketUser);

            if (user.XpTimeout.AddMinutes(1.0) > DateTime.UtcNow)
            {
                return;
            }

            //Set timeout time
            user.XpTimeout = DateTime.UtcNow;

            var oldLevel = user.UserLevel;
            var r = new Random();
            user.ExperiencePoints += (ulong)r.Next(15, 25);
            UserService.UpdateUserLevel(user);


            if (oldLevel != user.UserLevel)
            {
                var embed = new EmbedBuilder();
                embed.WithTitle("DING!");
                embed.WithDescription(Utilities.GetFormattedAlert("LEVEL_UP", user.UserLevel));
                embed.WithColor(new Color(0, 255, 0));
                await channel.SendMessageAsync("", false, embed);
            }
        }
    }
}
