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
        /// TODO: Implement custom posessed text.
        /// </summary>
        /// <returns></returns>
        [Command("owner")]
        public async Task Owner()
        {
            var embed = new EmbedBuilder();
            embed.WithTitle("BroBots Back");
            embed.WithDescription(Utilities.GetFormattedBroCommand("OWNER"));
            embed.WithColor(new Color(0, 255, 0));

            await Context.Channel.SendMessageAsync("", false, embed);
        }

        /// <summary>
        /// Sends a BroBot introduction message.
        /// </summary>
        /// <returns></returns>
        [Command("betterdiscord")]
        public async Task BetterDiscord()
        {
            var embed = new EmbedBuilder();
            embed.WithTitle("Check out Better Discord!");
            embed.WithDescription(Utilities.GetFormattedBroCommand("BETTER_DISCORD"));
            embed.WithColor(new Color(0, 255, 0));
            embed.WithImageUrl("https://cdn.dribbble.com/users/744913/screenshots/2855627/betterdiscord2_1x.png");

            await Context.Channel.SendMessageAsync("", false, embed);
        }

        /// <summary>
        /// Sends a BroBot information message.
        /// </summary>
        /// <returns></returns>
        [Command("brobot")]
        public async Task BroBotInformation()
        {
            var embed = new EmbedBuilder();
            embed.WithTitle("BroBot");
            embed.WithDescription(Utilities.GetFormattedBroCommand("BROBOT"));
            embed.WithColor(new Color(0, 255, 0));

            await Context.Channel.SendMessageAsync("", false, embed);
        }

        /// <summary>
        /// Sends a message with Highnoon on it.
        /// </summary>
        /// <returns></returns>
        [Command("highnoon")]
        public async Task Highnoon()
        {
            var embed = new EmbedBuilder();
            embed.WithTitle("It's hiiiiiighnoon");
            embed.WithDescription(Utilities.GetFormattedBroCommand("HIGHNOON"));
            embed.WithColor(new Color(0, 255, 0));
            embed.WithImageUrl("http://0.media.dorkly.cvcdn.com/28/83/3eff0977d0aeb25bc42da76e6fa3484b.jpg");

            await Context.Channel.SendMessageAsync("", false, embed);
        }

        [Command("pileon")]
        public async Task PileOn()
        {
            var herePing = Utilities.GetFormattedBroCommand("HERE_PING");
            var embed = new EmbedBuilder();
            embed.WithTitle("Pile On!");
            embed.WithColor(new Color(0, 255, 0));
            embed.WithImageUrl("http://i0.kym-cdn.com/photos/images/original/000/944/543/af7.png");

            await Context.Channel.SendMessageAsync(herePing, false, embed);
        }

        [Command("fuckthemods")]
        public async Task ModGif()
        {
            await Context.Channel.SendMessageAsync("https://i.imgur.com/tHAKqha.gifv");
        }

        [Command("givenickalcohol")]
        public async Task Alcohol(uint alc)
        {
            var embed = new EmbedBuilder();
            embed.WithTitle("Here you go champ!");
            embed.WithDescription($"Gave Nick {alc} Alcohol");
            embed.WithColor(new Color(0, 255, 0));
            await Context.Channel.SendMessageAsync("", false, embed);
        }

        [Command("minecraft")]
        public async Task Minecraft()
        {
            var embed = new EmbedBuilder();
            embed.WithTitle("Minecraft Servers!");
            embed.WithDescription(Utilities.GetFormattedBroCommand("MINECRAFT"));
            embed.WithColor(new Color(0, 255, 0));
            await Context.Channel.SendMessageAsync("", false, embed);
        }
    }
}
