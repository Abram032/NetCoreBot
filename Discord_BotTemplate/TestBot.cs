using System;
using Discord;
using Discord.WebSocket;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Discord_BotTemplate
{
    class TestBot
    {
        public async Task MainAsync()
        {
            Info.CreateInfoFile();
            await Settings.Instance.LoadSettings();
            var client = InitClient();
            await Connect(client);
            await MessageHandler.Handler(client);
            await Task.Delay(-1);
        }

        private async Task Log(LogMessage message)
        {
            await LogHandler.Handle(message);
            await Task.CompletedTask;
        }

        private async Task Connect(DiscordSocketClient client)
        {
            client.Log += Log;
            if (Settings.Instance.GetValue("Token") != string.Empty &&
                ExceptionHandler.CheckToken(client, Settings.Instance.GetValue("Token")))
            {
                await client.LoginAsync(TokenType.Bot, Settings.Instance.GetValue("Token"));
                await client.StartAsync();
            }
            else
                Console.WriteLine("Invalid Token!");
            await Task.CompletedTask;
        }

        private DiscordSocketClient InitClient()
        {
            return new DiscordSocketClient(new DiscordSocketConfig { LogLevel = LogSeverity.Verbose });
        }

        private async Task Disconnect(DiscordSocketClient client)
        {
            await client.LogoutAsync();
        }
    }
}
