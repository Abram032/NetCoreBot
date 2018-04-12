using System;
using System.Threading;
using System.Threading.Tasks;

//TODO: Should I use Interfaces?
//TODO: Clean up code.
//TODO: Make more unit tests.

namespace Discord_BotTemplate
{
    class Program
    {
        static Task bot = new Task(RunBot);
        static Task console = new Task(CLI);
        public static void Main(string[] args)
        {
            bot.Start();
            console.Start();
            bot.Wait();
            console.Wait();
        }

        public static void RunBot() => new TestBot().MainAsync().GetAwaiter().GetResult();
        public static void CLI() => new CLI().Main();
    }
}
