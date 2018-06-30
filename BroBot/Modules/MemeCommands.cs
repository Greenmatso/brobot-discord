using System.Threading.Tasks;
using BroBot.Handlers;
using Discord;
using Discord.Commands;

namespace BroBot.Modules
{
    public class MemeCommands : ModuleBase<SocketCommandContext>
    {
        [Command("meme")]
        public async Task GenerateMeme([Remainder]string message)
        {
            var result = MemeHandler.SearchMemeOnBing(message);

            var embed = new EmbedBuilder();
            embed.WithTitle("Your meme, sir or ma'am.");
            embed.WithColor(new Color(0, 255, 0));
            embed.WithImageUrl(result);

            await Context.Channel.SendMessageAsync("", false, embed);
        }
    }
}
