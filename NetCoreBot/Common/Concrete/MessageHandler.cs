using Discord.WebSocket;
using NetCoreBot.Commands.Concrete;
using NetCoreBot.Resources;
using NetCoreBot.Commands.Abstract;
using NetCoreBot.Common.Abstract;
using NetCoreBot.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBot.Common.Concrete
{
    class MessageHandler : IMessageHandler
    {
        private ISettings _settings;
        private IConnectionManager _connectionManager;
        private ILogHandler _logHandler;
        private ICommandService _commandService;
        private DiscordSocketClient client { get; set; } = null;
        private string commandPrefix { get; set; } = null;

        public MessageHandler(IConnectionManager connectionManager, ISettings settings, ILogHandler logHandler, ICommandService commandService)
        {
            _connectionManager = connectionManager;
            _settings = settings;
            _logHandler = logHandler;
            _commandService = commandService;
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
            if (message.Content.StartsWith(commandPrefix)
                && message.Content.Length >= 2)
            {
                string _message = message.ToString();
                var messageDetails = (object) new MessageDetails(message);
                await _commandService.ExecuteCommand(_message, messageDetails);
            }
            await Task.CompletedTask;
        }
    }
}
