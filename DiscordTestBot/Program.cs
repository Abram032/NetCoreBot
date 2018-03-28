using System;
using System.Threading;

//TODO: Add the package source to a NuGet.Config file.
//TODO: Allow for admin-only commands in console.
//TODO: Make a thread for commands for the console.

namespace DiscordTestBot
{
    class Program
    {
        static Thread bot = new Thread(RunBot);
        public static void Main(string[] args)
        {
            bot.Start();
            string gowno;
            gowno = Console.ReadLine();
            Console.WriteLine(gowno);
        }

        public static void RunBot() => new TestBot().MainAsync().GetAwaiter().GetResult();
    }
}
