using System.Linq;
using System.Threading.Tasks;
using BroBot.Utils;
using BroBot.Core.Users;
using Discord;
using Discord.Commands;

namespace BroBot.Modules
{
    public class UserCommands : ModuleBase<SocketCommandContext>
    {
        /// <summary>
        /// Add points to a user
        /// </summary>
        /// <param name="xp">The points to add</param>
        /// <param name="args">mentioned name</param>
        /// <returns>Task</returns>
        [Command("givePoints")]
        [RequireUserPermission(GuildPermission.ChangeNickname)]
        public async Task GiveUserPoints(ulong xp, [Remainder] string args = "")
        {
            if (xp > 10000)
            {
                var error = new EmbedBuilder();
                error.WithTitle("ABORT MISSION");
                error.WithDescription("Your point value was too powerful!");
                error.WithColor(new Color(255, 0, 0));
                await Context.Channel.SendMessageAsync("", false,error);
                return;
            }
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

        /// <summary>
        /// Review the stats of a User.
        /// </summary>
        /// <returns>Task</returns>
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
