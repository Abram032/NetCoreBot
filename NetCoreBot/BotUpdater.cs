using NetCoreBot.Updater.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBot
{
    class BotUpdater
    {
        IUpdateManager _updateManager;
        ICleaner _cleaner;

        public BotUpdater(IUpdateManager updateManager, ICleaner cleaner)
        {
            _updateManager = updateManager;
            _cleaner = cleaner;
        }

        public async Task MainAsync()
        {
            await _cleaner.CleanUp();
            await _updateManager.MainAsync();
            await Task.CompletedTask;
        }
    }
}
