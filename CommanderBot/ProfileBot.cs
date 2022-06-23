using System.IO;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using Newtonsoft.Json;
using ProfileBot.Commands;

namespace ProfileBot
{
    public class Bot
    {
        public DiscordClient Client;
        public CommandsNextExtension Commands;

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
