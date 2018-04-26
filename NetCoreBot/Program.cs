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

//TODO: Implement removing messages.
//TODO: Implement database. Should I use JSON or something else?
//TODO: Check out CQRS pattern.
//TODO: TESTS!

namespace NetCoreBot
{
    class Program
    {   
        static ICleaner cleaner = new Cleaner();
        static IDownloader downloader = new Downloader();
        static IUpdateChecker updateChecker = new UpdateChecker();
        static IUpdater updater = new Updater.Concrete.Updater();
        static IUpdateManager updateManager = new UpdateManager(updateChecker, downloader, updater);
        static IConverter converter = new Converter();
        static ILogHandler logHandler = new LogHandler(Settings.Instance, converter);
        static IConnectionManager connectionHandler = new ConnectionManager(Settings.Instance);
        static ICommandService commandService = new CommandService(Settings.Instance);
        static IMessageHandler messageHandler = new MessageHandler(connectionHandler, Settings.Instance, logHandler, commandService);

        public static void BotUpdater() => new BotUpdater(updateManager, cleaner).MainAsync().GetAwaiter().GetResult();
        public static void Bot() => new Bot(connectionHandler, Settings.Instance, messageHandler).MainAsync().GetAwaiter().GetResult();
        public static void Terminal() => new Terminal(commandService).Main();
        static Task botUpdater = new Task(BotUpdater);
        static Task bot = new Task(Bot);
        static Task terminal = new Task(Terminal);

        public static string arg { get; private set; } = string.Empty;

        static void Main(string[] args)
        {
            if(args.Length > 0)
                arg = args[0];
            botUpdater.Start();
            botUpdater.Wait();
            bot.Start();
            terminal.Start();
            bot.Wait();
            terminal.Wait();
        }
    }
}
