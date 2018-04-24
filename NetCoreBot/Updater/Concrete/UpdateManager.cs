using NetCoreBot.Resources;
using NetCoreBot.Updater.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBot.Updater.Concrete
{
    public class UpdateManager : IUpdateManager
    {
        IUpdateChecker _updateChecker;
        IDownloader _downloader;
        IUpdater _updater;

        public UpdateManager(IUpdateChecker updateChecker, IDownloader downloader, IUpdater updater)
        {
            _updateChecker = updateChecker;
            _downloader = downloader;
            _updater = updater;
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
