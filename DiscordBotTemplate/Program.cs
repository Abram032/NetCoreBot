using System;

namespace DiscordBotTemplate
{
    class Program
    {
        public static void Bot() => new Bot().MainAsync().GetAwaiter().GetResult();

        static void Main(string[] args)
        {
            
        }
    }
}
