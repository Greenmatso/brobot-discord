using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BroBot.Utils;
using BroBot.Core.Users;
using Discord;
using Discord.Commands;

namespace BroBot.Modules
{
    public class UserCommands : ModuleBase<SocketCommandContext>
    {
        [Command("stats")]
        public async Task UserStats()
        {
            try
            {
                var user = UserService.GetUser(Context.User);
                var userPoints = user.UserPoints;
                var xpPoints = user.ExperiencePoints;
                var embed = new EmbedBuilder();
                embed.WithTitle($"Statistics for {Context.User.Username}");
                embed.WithDescription(Utilities.GetFormattedUserCommand("STATS_&username", userPoints, xpPoints));
                embed.WithColor(new Color(0, 255, 0));

                await Context.Channel.SendMessageAsync("", false, embed);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
