using System;
using System.Threading.Tasks;

namespace BotUpdater
{
    class Program
    {
        public static void UpdateBot() => new Update().MainAsync().GetAwaiter().GetResult();
        static Task updateBot = new Task(UpdateBot);

        static void Main(string[] args)
        {
            updateBot.Start();
            updateBot.Wait();
            
        }
    }
}
