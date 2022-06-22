using System.Collections.Generic;
using System.Threading.Tasks;
using CommanderBot.Model;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

namespace CommanderBot.Commands
{
    public class GeneralCommands : BaseCommandModule
    {
        [Command("link")]
        public async Task LinkAccount(CommandContext ctx, string url)
        {
            Steam steam = new Steam();
            var profile = await steam.GetProfile(url);
            await ctx.RespondAsync(profile.ToString());
        }
    }
}