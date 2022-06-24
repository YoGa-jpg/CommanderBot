using System;
using System.Linq;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using ProfileBot.Model;

namespace ProfileBot.Commands
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

        [Command("set"), RequirePermissions(Permissions.Administrator)]
        public async Task SetAccount(CommandContext ctx, string url, string mention)
        {
            using (ProfileContext db = new ProfileContext())
            {
                switch (url)
                {
                    case var x when x.Contains("steam"):
                        try
                        {
                            db.Profiles.Single(profile => profile.DiscordId == ctx.Message.MentionedUsers.First().Id).DotaId =
                                Steam.GetSteam32(url);
                        }
                        catch (Exception e)
                        {
                            db.Profiles.Add(new Profile()
                            {
                                DiscordId = ctx.Message.MentionedUsers.First().Id,
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