using System.Collections.Generic;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

namespace CommanderBot.Commands
{
    public class GeneralCommands : BaseCommandModule
    {
        [Command("menu")]
        public async Task MenuCommand(CommandContext ctx)
        {
            var user = ctx.User;

            var a = new DiscordButtonComponent(ButtonStyle.Success, "ratingButton", "Рейтинг");

            var options = new List<DiscordButtonComponent>()
            {
                new DiscordButtonComponent(ButtonStyle.Success, "ratingButton", "Рейтинг"),
                new DiscordButtonComponent(ButtonStyle.Primary, "guildButton", "Сервер"),
                new DiscordButtonComponent(ButtonStyle.Danger, "powerButton", "Власть")
            };

            var builder = await new DiscordMessageBuilder()
                .WithContent("Ваш главный штаб")
                .AddComponents(options)
                .SendAsync(ctx.Channel);
        }
    }
}