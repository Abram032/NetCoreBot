using System;
using System.Threading;
using System.Threading.Tasks;

//TODO: Add the package source to a NuGet.Config file.

namespace DiscordTestBot
{
    class Program
    {
        static Thread bot = new Thread(RunBot);
        static Thread console = new Thread(CLI);
        public static void Main(string[] args)
        {
            bot.Start();
            console.Start();
        }

        public static void RunBot() => new TestBot().MainAsync().GetAwaiter().GetResult();
        public static void CLI() => new CLI().Main();
    }
}
