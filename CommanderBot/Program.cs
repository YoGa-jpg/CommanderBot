namespace CommanderBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var bot = new CommanderBot.Bot();
            bot.RunAsync().GetAwaiter().GetResult();
        }
    }
}
