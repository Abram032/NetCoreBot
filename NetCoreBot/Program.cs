using System;
using System.Threading.Tasks;
using NetCoreBot.Commands.Concrete;
using NetCoreBot.Commands.Abstract;
using NetCoreBot.Common.Concrete;
using NetCoreBot.Common.Abstract;
using NetCoreBot.Repository.Concrete;
using NetCoreBot.Repository.Abstract;
using NetCoreBot.Updater.Concrete;
using NetCoreBot.Updater.Abstract;

//TODO: Set bot status as playing game: "prefix help"
//TODO: Figure out the namespace for commands implementation. Separate it from command managers.
//TODO: Implement MessageWriter.
//TODO: Implement database. Should I use JSON or something else?
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
        static ICommandService commandService = new CommandService(Settings.Instance);
        static IMessageHandler messageHandler = new MessageHandler(connectionHandler, Settings.Instance, logHandler, commandService);

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
