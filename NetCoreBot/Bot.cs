using System;
using System.Threading.Tasks;
using NetCoreBot.Common.Abstract;
using NetCoreBot.Repository.Abstract;
using System.Collections.Generic;
using System.Text;
using NetCoreBot.Updater.Abstract;

//Command Pattern
//Repository Pattern

namespace NetCoreBot
{
    class Bot
    {
        IConnectionManager _connectionManager;
        IMessageHandler _messageHandler;
        ISettings _settings;

        public Bot(IConnectionManager connect, ISettings settings, IMessageHandler messageHandler)
        {
            _connectionManager = connect;
            _messageHandler = messageHandler;
            _settings = settings;
        }

        public async Task MainAsync()
        {
            await _settings.LoadSettings();
            await _connectionManager.ClientConnect();
            await _messageHandler.Handler();
            await Task.Delay(-1);
        }
    }
}
