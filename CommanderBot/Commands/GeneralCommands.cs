using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
            using (ProfileContext db = new ProfileContext())
            {
                switch (url)
                {
                    case var x when x.Contains("steam"):
                        try
                        {
                            db.Profiles.Single(profile => profile.DiscordId == ctx.User.Id).DotaId =
                                Steam.GetSteam32(url);
                        }
                        catch (Exception e)
                        {
                            db.Profiles.Add(new Profile()
                            {
                                DiscordId = ctx.User.Id,
                                DotaId = Steam.GetSteam32(url)
                            });
                        }
                        await db.SaveChangesAsync();

                        await ctx.RespondAsync("Профиль подключен!");
                        break;
                }
            }
        }
    }
}