using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BroBot.Utils;
using BroBot.Core.Users;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace BroBot.Modules
{
    public class UserCommands : ModuleBase<SocketCommandContext>
    {
        [Command("givePoints")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task GiveUserPoints(ulong xp, [Remainder] string args = "")
        {
            var mentionedUser = Context.Message.MentionedUsers.FirstOrDefault();
            var user = UserService.GetUser(mentionedUser);
            user.UserPoints += xp;
            UserService.SaveAccounts();

            var embed = new EmbedBuilder();
            embed.WithTitle($"Points Added");
            embed.WithDescription(Utilities.GetFormattedUserCommand("ADD_POINTS_&xp_&username", xp, mentionedUser.Username));
            embed.WithColor(new Color(0, 255, 0));

            await Context.Channel.SendMessageAsync("", false, embed);
        }

        [Command("stats")]
        public async Task UserStats()
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
    }
}
