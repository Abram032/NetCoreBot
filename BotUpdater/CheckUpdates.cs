using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace BotUpdater
{
    class CheckUpdates
    {
        public static async Task CheckVersion()
        {
            using (WebClient client = new WebClient())
            {
                string[] htmlCode = client.DownloadString
                    ("https://github.com/Maissae/Discord_BotTemplate/blob/master/README.md").Split('\n');
                foreach(string line in htmlCode)
                {
                    Console.WriteLine(line);
                }
            }
            await Task.CompletedTask;
        }
    }
}
