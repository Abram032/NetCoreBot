using Discord.WebSocket;
using NetCoreBot.Common.Interfaces;
using NetCoreBot.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

//TODO: Figure out how to pass interfaces between classes. Can and should I do that?

namespace NetCoreBot.Common.Classes
{
    class MessageHandler : IMessageHandler
    {
        private ISettings _settings;
        private IConnectionManager _connectionManager;
        private DiscordSocketClient client { get; set; } = null;
        private string commandPrefix { get; set; } = null;

        public MessageHandler(IConnectionManager connectionManager, ISettings settings)
        {
            _connectionManager = connectionManager;
            _settings = settings;
        }

        public async Task Handler()
        {
            if(client == null)
                client = (DiscordSocketClient)_connectionManager.GetClient();
            if(commandPrefix == null)
                commandPrefix = _settings.GetValue(SettingKeys.CommandPrefix);
            client.MessageReceived += MessageRecieved;
            await Task.CompletedTask;
        }

        private string GetCommandPrefix()
        {
            return _settings.GetValue(SettingKeys.CommandPrefix);
        }

        private async Task MessageRecieved(SocketMessage message)
        {
            //await LogHandler.Handle(message);
            if (message.Content.StartsWith(commandPrefix)
                && message.Content.Length >= 2)
            {
                Console.WriteLine("Command recieved!");
            }
            Console.WriteLine(message.ToString());
            await Task.CompletedTask;
        }
    }
}
