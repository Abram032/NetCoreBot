using Discord.WebSocket;
using NetCoreBot.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

//TODO: Figure out how to pass interfaces between classes. Can and should I do that?

namespace NetCoreBot.Common.Classes
{
    class MessageHandler : IMessageHandler
    {
        public static async Task Handler(DiscordSocketClient client)
        {
            client.MessageReceived += MessageRecieved;
            await Task.CompletedTask;
        }

        private static async Task MessageRecieved(SocketMessage message)
        {
            //await LogHandler.Handle(message);
            //if(message.Content.StartsWith(Settings.Instance.GetValue("CommandPrefix")) 
            //    && message.Content.Length >= 2)
            //{
            //    Console.WriteLine("Command recieved!");
            //}
            Console.WriteLine(message.ToString());
            await Task.CompletedTask;
        }
    }
}
