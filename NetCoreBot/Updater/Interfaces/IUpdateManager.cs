using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBot.Updater.Interfaces
{
    interface IUpdateManager
    {
        Task MainAsync();
    }
}
