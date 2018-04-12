using System;
using System.Threading.Tasks;
using NetCoreBot.Common.Interfaces;
using NetCoreBot.Repository.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBot
{
    class Bot
    {
        IConnect connect;
        ISettings settings;

        public Bot(IConnect _connect, ISettings _settings)
        {
            connect = _connect;
            settings = _settings;
        }

        public async Task MainAsync()
        {
            await settings.LoadSettings();
            await connect.ClientConnect(settings.GetValue("Token"));
            await Task.Delay(-1);
        }
    }
}
