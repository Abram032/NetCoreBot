using System;
using Discord;
using System.Threading.Tasks;
using Discord.WebSocket;
using NetCoreBot.Common.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBot.Common.Classes
{
    class Connect : IConnect
    {
        public async Task ClientConnect(string token)
        {
            var client = InitClient();
            await InitConnection(client, token);
            await Task.Delay(-1);
        }

        private DiscordSocketClient InitClient()
        {
            return new DiscordSocketClient(new DiscordSocketConfig { LogLevel = LogSeverity.Verbose });
        }

        private async Task Log(LogMessage message)
        {
            Console.WriteLine(message.ToString());
            await Task.CompletedTask;
        }

        private async Task InitConnection(DiscordSocketClient client, string token)
        {
            client.Log += Log;
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
            await Task.CompletedTask;
        }
    }
}