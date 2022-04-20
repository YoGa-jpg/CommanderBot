using System;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommanderBot.Commands;
using DSharpPlus.Entities;
using Newtonsoft.Json;

namespace CommanderBot
{
    class CommanderBot
    {
        public DiscordClient Client { get; private set; }
        public CommandsNextExtension Commands { get; private set; }

        public async Task RunAsync()
        {
            var json = "";
            using (var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync();
            var configJson = JsonConvert.DeserializeObject<ConfigJson>(json);

            var botConfig = new DiscordConfiguration
            {
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                //Intents = DiscordIntents.Guilds | DiscordIntents.GuildMembers | DiscordIntents.GuildMessages,
                Intents = DiscordIntents.All,
                MinimumLogLevel = Microsoft.Extensions.Logging.LogLevel.Debug
            };
            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefixes = new[] { configJson.CommandPrefix },
                EnableDms = true,
                EnableMentionPrefix = true,
                DmHelp = true
            };

            Client = new DiscordClient(botConfig);
            Commands = Client.UseCommandsNext(commandsConfig);

            Commands.RegisterCommands<GeneralCommands>();

            Client.ComponentInteractionCreated += async (sender, args) =>
            {
                var guild = await sender.GetGuildAsync((ulong) args.Interaction.GuildId);
                    if (args.Id == "guildButton")
                    {
                        await args.Message.ModifyAsync(new DiscordMessageBuilder()
                            .AddEmbed(new DiscordEmbedBuilder()
                            {
                                Author = new DiscordEmbedBuilder.EmbedAuthor()
                                {
                                    Name = guild.Name,
                                    IconUrl = guild.IconUrl
                                },
                                Color = new Optional<DiscordColor>(DiscordColor.Rose),
                                Description = guild.Members.Values.ToList().Select((q, i) => $"{Formatter.Bold($"{i + 1}. {q.DisplayName}")}").Aggregate((x, y) => x + "\n" + y),
                                ImageUrl = "https://api.reboot.su/image/baka/ctuZROAAh6HLJce.gif",
                                Footer = new DiscordEmbedBuilder.EmbedFooter()
                                {
                                    Text = "Футер"
                                },
                                Timestamp = DateTimeOffset.Now,
                                Title = "Рейтинг властителей"
                            }));
                    }
                    else
                    {
                        await args.Message.ModifyAsync(new DiscordMessageBuilder()
                            .AddEmbed(new DiscordEmbedBuilder()
                            {
                                Author = new DiscordEmbedBuilder.EmbedAuthor()
                                {
                                    Name = "Автор",
                                    IconUrl = "https://tenor.com/view/obviii-ibvii-gif-24894454"
                                },
                                Color = new Optional<DiscordColor>(DiscordColor.Rose),
                                Description = "Описание",
                                ImageUrl = "https://api.reboot.su/image/baka/ctuZROAAh6HLJce.gif",
                                Footer = new DiscordEmbedBuilder.EmbedFooter()
                                {
                                    Text = "Футер"
                                },
                                Timestamp = DateTimeOffset.Now,
                                Title = "Title"
                            }));
                    }
                };

            await Client.ConnectAsync();

            await Task.Delay(-1);
        }
    }
}
