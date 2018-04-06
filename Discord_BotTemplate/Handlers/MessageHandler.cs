using System;
using System.Threading.Tasks;
using Discord;
using System.Collections.Generic;
using System.Text;
using Discord.WebSocket;

//TODO: Should I change the way message is handled if it's a command?

namespace Discord_BotTemplate
{
    class MessageHandler
    {
        public static async Task Handler(DiscordSocketClient client)
        {
            client.MessageReceived += MessageRecieved;
            await Task.CompletedTask;
        }

        private static async Task MessageRecieved(SocketMessage message)
        {
            await LogHandler.Handle(message);
            if(message.Content.StartsWith("!t") && message.Content.Length >= 2)
            {
                Console.WriteLine("Command recieved!");
            }
            await Task.CompletedTask;
        }
    }
}
