using System;
using Discord;
using System.Threading.Tasks;
using Discord.WebSocket;
using NetCoreBot.Common.Abstract;
using NetCoreBot.Resources;
using System.Collections.Generic;
using System.Text;
using NetCoreBot.Repository.Abstract;

namespace NetCoreBot.Common.Concrete
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
            if(CheckToken(client, Token))
                await InitConnection(client);
            else
                Console.WriteLine("Invalid Token!");
            await client.SetGameAsync(_settings.GetValue(SettingKeys.CommandPrefix) + " help");
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
            DiscordSocketConfig discordSocketConfig = InitDiscordSocketConfig();            
            return new DiscordSocketClient(discordSocketConfig);
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

        private bool CheckToken(DiscordSocketClient client, string token)
        {
            try 
            {
                client.LoginAsync(TokenType.Bot, token).Wait();
            }
            catch
            {          
                return false;
            }
            client.LogoutAsync().Wait();
            return true;
        }

        private DiscordSocketConfig InitDiscordSocketConfig()
        {
            DiscordSocketConfig discordSocketConfig = new DiscordSocketConfig();
            if(_settings.GetValue(SettingKeys.LogSeverity) == "Critical")
                discordSocketConfig.LogLevel = LogSeverity.Critical;
            else if(_settings.GetValue(SettingKeys.LogSeverity) == "Debug")
                discordSocketConfig.LogLevel = LogSeverity.Debug;
            else if(_settings.GetValue(SettingKeys.LogSeverity) == "Error")
                discordSocketConfig.LogLevel = LogSeverity.Error;
            else if(_settings.GetValue(SettingKeys.LogSeverity) == "Info")
                discordSocketConfig.LogLevel = LogSeverity.Info;
            else if(_settings.GetValue(SettingKeys.LogSeverity) == "Verbose")
                discordSocketConfig.LogLevel = LogSeverity.Verbose;
            else if(_settings.GetValue(SettingKeys.LogSeverity) == "Warning")
                discordSocketConfig.LogLevel = LogSeverity.Warning;
            else
                discordSocketConfig.LogLevel = LogSeverity.Info;
            return discordSocketConfig;
        }
    }
}