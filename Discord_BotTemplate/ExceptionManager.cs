using System;
using System.Collections.Generic;
using System.Text;
using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace Discord_BotTemplate
{
    class ExceptionManager
    {
        public bool CheckToken(DiscordSocketClient client, string token)
        {
            try
            {
                client.LoginAsync(TokenType.Bot, token).Wait();
                //client.StartAsync().Wait();
            }
            catch
            {
                Console.WriteLine("Invalid Token!");
                return false;
            }
            return true;
        }
    }
}
