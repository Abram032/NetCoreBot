using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BotUpdater
{
    class UpdateBot
    {
        public async Task MainAsync()
        {
            Console.WriteLine("Checking for updates...");
            await CheckUpdates.CheckVersion();
            if (Info.gitVersion.Equals(string.Empty) || Info.downloadURL.Equals(string.Empty))
            {
                Console.WriteLine("Update failed.");
            }
            else if (!Info.gitVersion.Equals(Info.GetValue("version")))
            {
                if (UpdateResponse().Equals("y"))
                    await Update();
            }
            else
            {
                Console.WriteLine("Bot is up to date.");
            }
            Console.WriteLine("Version: " + Info.GetValue("version"));
            await Task.CompletedTask;
        }

        private async Task Update()
        {
            await Downloader.DownloadUpdate();
            await Updater.UpdateFiles();
            Info.SetValue("version", Info.gitVersion);
        }

        private string UpdateResponse()
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
