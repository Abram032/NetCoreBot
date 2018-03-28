using System;
using System.Threading.Tasks;
using Discord;
using System.Collections.Generic;
using System.Text;
using Discord.WebSocket;

//TODO: Should I change the way message is handled if it's a command?

namespace DiscordTestBot
{
    public class MessageHandler
    {
        Logger logger = new Logger();

        private async Task MessageRecieved(SocketMessage message)
        {
            await logger.LogHandler(message);
            if(message.Content.StartsWith('!') && message.Content.Length >= 2)
            {
                string _message = message.Content.Substring(0,2);
                if (_message == "!t")
                   Console.WriteLine("Command recieved!");
            }
            await Task.CompletedTask;
        }

        public async Task HandleMessages(DiscordSocketClient client)
        {
            client.MessageReceived += MessageRecieved;
            await Task.CompletedTask;
        }
    }
}
