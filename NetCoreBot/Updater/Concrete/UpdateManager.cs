using NetCoreBot.Resources;
using NetCoreBot.Updater.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

//TODO: Loose coupling, Implement interfaces for each classes.

namespace NetCoreBot.Updater.Concrete
{
    class UpdateManager : IUpdateManager
    {
        UpdateChecker _updateChecker;
        Downloader _downloader;
        Updater _updater;

        public UpdateManager()
        {
            _updateChecker = new UpdateChecker();
            _downloader = new Downloader();
            _updater = new Updater();
        }

        public async Task MainAsync()
        {
            Console.WriteLine("Checking for updates...");
            await _updateChecker.CheckVersion();
            if (Info.GitVersion.Equals(string.Empty) || Info.DownloadLink.Equals(string.Empty))
            {
                Console.WriteLine("Update failed.");
            }
            else if (!Info.GitVersion.Equals(Info.version))
            {
                if (Response().Equals("y"))
                    await Update();
            }
            else
            {
                Console.WriteLine("Bot is up to date.");
            }
            Console.WriteLine("Version: " + Info.version);
            await Task.CompletedTask;
        }

        private async Task Update()
        {
            await _downloader.DownloadUpdate();
            await _updater.UpdateFiles();
            Info.version = Info.GitVersion;
        }

        private string Response()
        {
            while (true)
            {
                Console.WriteLine("Update is avaible, do you wish to download it now? (y/n)");
                string reply = Console.ReadLine();
                if (reply.Equals("y") || reply.Equals("n"))
                    return reply;
            }
        }
    }
}
