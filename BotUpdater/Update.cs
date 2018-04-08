using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BotUpdater
{
    class Update
    {
        public async Task MainAsync()
        {
            await CheckUpdates.CheckVersion();
            await Task.Delay(-1);
        }
    }
}
