using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BroBot.Utils;
using Discord;
using Discord.Commands;

namespace BroBot.Modules
{
    /// <summary>
    /// A set of Brolosophy specific commands for BroBot
    /// </summary>
    public class BroCommands : ModuleBase<SocketCommandContext>
    {
        /// <summary>
        /// Sends a BroBot introduction message.
        /// TODO: Implement JSON parser for BroCommands
        /// </summary>
        /// <returns></returns>
        [Command("owner")]
        public async Task Owner()
        {
            var embed = new EmbedBuilder();
            embed.WithTitle("Hail to the King, Baby.");
            //embed.WithDescription(Utilities.GetFormattedAlert("HELLO", Config.bot.cmdPrefix));
            embed.WithColor(new Color(0, 255, 0));

            await Context.Channel.SendMessageAsync("", false, embed);
        }

        /// <summary>
        /// Sends a BroBot introduction message.
        /// TODO: Implement JSON parser for BroCommands
        /// </summary>
        /// <returns></returns>
        [Command("betterdiscord")]
        public async Task BetterDiscord()
        {
            var embed = new EmbedBuilder();
            embed.WithTitle("Check out Better Discord!");
            //embed.WithDescription(Utilities.GetFormattedAlert("HELLO", Config.bot.cmdPrefix));
            embed.WithColor(new Color(0, 255, 0));

            await Context.Channel.SendMessageAsync("", false, embed);
        }
    }
}
