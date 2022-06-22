using System;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommanderBot.Commands;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.Net;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CommanderBot
{
    class CommanderBot
    {
        public class Bot
        {
            public DiscordClient Client;
            public CommandsNextExtension Commands;
            private CancellationTokenSource _cts;

            public Bot()
            {
                var json = "";
                using (var fs = File.OpenRead("config.json"))
                using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                    json = sr.ReadToEndAsync().Result;
                var configJson = JsonConvert.DeserializeObject<ConfigJson>(json);

                var botConfig = new DiscordConfiguration
                {
                    Token = configJson.Token,
                    TokenType = TokenType.Bot,
                    AutoReconnect = true,
                    Intents = DiscordIntents.AllUnprivileged,
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
            }

            public async Task RunAsync()
            {
                await Client.ConnectAsync();

                await Task.Delay(-1);
            }
        }
    }
}
