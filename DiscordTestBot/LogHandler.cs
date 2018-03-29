using System;
using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

//TODO: Log messages to file instead of console.

namespace DiscordTestBot
{
    public class LogHandler
    {
        public async Task Handle(object obj)
        {
            if(obj is SocketMessage)
                await LogMessage((SocketMessage)obj);
            if(obj is LogMessage)
                await LogMessage((LogMessage)obj);
            await Task.CompletedTask;
        }

        private async Task LogMessage(SocketMessage message)
        {
            DateTime dateTime = DateTime.Now;
            string _message = dateTime.ToString();
            _message += " { " + message.Channel + " } ( " + message.Author + " ) : " + message.Content;
            Console.WriteLine(_message);
            await Task.CompletedTask;
        }

        private async Task LogMessage(LogMessage message)
        {
            Console.WriteLine(message.ToString());
            await Task.CompletedTask;
        }
    }
}
