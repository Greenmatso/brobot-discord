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
    /// A set of basic commands for the BroBot.
    /// </summary>
    public class Misc : ModuleBase<SocketCommandContext>
    {
        /// <summary>
        /// Sends a BroBot introduction message.
        /// </summary>
        /// <returns></returns>
        [Command("hello")]
        public async Task Hello()
        {
            var embed = new EmbedBuilder();
            embed.WithTitle("Hello!");
            embed.WithDescription(Utilities.GetFormattedAlert("HELLO", Config.bot.cmdPrefix));
            embed.WithColor(new Color(0, 255, 0));

            await Context.Channel.SendMessageAsync("", false, embed);
        }

        /// <summary>
        /// Sends a BroBot help message.
        /// TODO: Implement help text.
        /// </summary>
        /// <returns></returns>
        [Command("help")]
        public async Task Help()
        {
            var embed = new EmbedBuilder();
            embed.WithTitle("BroBot Help");
            embed.WithDescription(Utilities.GetFormattedAlert("HELP"));
            embed.WithColor(new Color(0, 255, 0));

            var embedMisc = new EmbedBuilder();
            embedMisc.WithTitle("General Commands");
            embedMisc.WithDescription(Utilities.GetFormattedAlert("HELP_MISC"));
            embedMisc.WithColor(new Color(0, 255, 0));

            var embedBro = new EmbedBuilder();
            embedBro.WithTitle("BroBot Help");
            embedBro.WithDescription(Utilities.GetFormattedAlert("HELP_BRO"));
            embedBro.WithColor(new Color(0, 255, 0));

            await Context.Channel.SendMessageAsync("", false, embed);
            await Context.Channel.SendMessageAsync("", false, embedMisc);
            await Context.Channel.SendMessageAsync("", false, embedBro);
        }

        /// <summary>
        /// Echoes input message using >echo {message}.
        /// Embeds in a green embed.
        /// </summary>
        /// <param name="message">The message to echo</param>
        /// <returns></returns>
        [Command("echo")]
        public async Task Echo([Remainder]string message)
        {
            var embed = new EmbedBuilder();
            embed.WithTitle(Utilities.GetFormattedAlert("ECHO_MESSAGE_&username", Context.User.Username));
            embed.WithDescription(message);
            embed.WithColor(new Color(0, 255, 0));

            await  Context.Channel.SendMessageAsync("", false, embed);
        }

        /// <summary>
        /// Picks an options split by '|' and sends the result.
        /// If an option is empty, it cant be chosen
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [Command("pick")]
        public async Task Pick([Remainder]string message)
        {
            string[] options = message.Split(new char[] {'|'}, StringSplitOptions.RemoveEmptyEntries);

            Random random = new Random();
            string selection = options[random.Next(0, options.Length)];

            var embed = new EmbedBuilder();
            embed.WithTitle(Utilities.GetFormattedAlert("PICK_MESSAGE_&username", Context.User.Username));
            embed.WithDescription(selection);
            embed.WithColor(new Color(0, 255, 0));

            await Context.Channel.SendMessageAsync("", false, embed);
        }
    }
}
