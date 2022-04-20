namespace CommanderBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var bot = new CommanderBot();
            bot.RunAsync().GetAwaiter().GetResult();
        }
    }
}
