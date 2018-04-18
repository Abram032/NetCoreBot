using System;
using System.Threading.Tasks;
using NetCoreBot.Common.Classes;
using NetCoreBot.Common.Interfaces;
using NetCoreBot.Repository.Classes;
using NetCoreBot.Repository.Interfaces;
using NetCoreBot.Updater.Classes;
using NetCoreBot.Updater.Interfaces;

//TODO: Check out CQRS pattern.
//TODO: Add Converter.
//TODO: Add CommandHandler.
//TODO: TESTS!

namespace NetCoreBot
{
    class Program
    {   
        static ICleaner cleaner = new Cleaner();
        static IUpdateManager updateManager = new UpdateManager();
        static ILogHandler logHandler = new LogHandler(Settings.Instance);
        static IConnectionManager connectionHandler = new ConnectionManager(Settings.Instance);
        static IMessageHandler messageHandler = new MessageHandler(connectionHandler, Settings.Instance, logHandler);

        public static void BotUpdater() => new BotUpdater(updateManager, cleaner).MainAsync().GetAwaiter().GetResult();
        public static void Bot() => new Bot(connectionHandler, Settings.Instance, messageHandler).MainAsync().GetAwaiter().GetResult();
        public static void Terminal() => new Terminal().Main();
        static Task botUpdater = new Task(BotUpdater);
        static Task bot = new Task(Bot);
        static Task terminal = new Task(Terminal);

        static void Main(string[] args)
        {
            botUpdater.Start();
            botUpdater.Wait();
            bot.Start();
            terminal.Start();
            bot.Wait();
            terminal.Wait();
        }
    }
}
