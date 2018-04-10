using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace BotLauncher
{
    class Launch
    {
        public void Main()
        {
            Process updater = new Process();
            updater.StartInfo.FileName = "dotnet";
            updater.StartInfo.Arguments = "BotUpdater.dll";
            updater.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
            Process bot = new Process();
            bot.StartInfo.FileName = "dotnet";
            bot.StartInfo.Arguments = "DiscordBotTemplate.dll";
            bot.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
            updater.Start();
            updater.WaitForExit();
            Clean.CleanUp().Wait();
            bot.Start();
            return;
        }
    }
}
