using System;
using Discord;
using System.Threading.Tasks;
using Discord.WebSocket;
using NetCoreBot.Common.Interfaces;
using System.Collections.Generic;
using System.Text;
using NetCoreBot.Repository.Interfaces;

namespace NetCoreBot.Common.Classes
{
    class ConnectionManager : IConnectionManager
    {
        private ISettings _settings;
        private string Token { get; set; }
        private DiscordSocketClient client { get; set; }

        public ConnectionManager(ISettings settings)
        {
            _settings = settings;
        }

        public async Task ClientConnect()
        {
            client = InitClient();
            Token = GetToken();
            client.Log += Log;
            if(ExceptionHandler.CheckToken(client, Token))
                await InitConnection(client);
            else
                Console.WriteLine("Invalid Token!");
            await Task.CompletedTask;
        }

        public object GetClient()
        {
            return client;
        }

        private string GetToken()
        {
            return _settings.GetValue(SettingKeys.Token);
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

        private async Task InitConnection(DiscordSocketClient client)
        {
            await client.LoginAsync(TokenType.Bot, Token);
            await client.StartAsync();
            await Task.CompletedTask;
        }
    }
}