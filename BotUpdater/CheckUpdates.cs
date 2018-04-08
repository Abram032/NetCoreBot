using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

//TODO: Change link from /dev/ tree to /master/ tree after tests.

namespace BotUpdater
{
    class CheckUpdates
    {
        public static async Task CheckVersion()
        {
            string version = string.Empty;
            if(!ExceptionHandler.CheckConnection())
            {
                Console.WriteLine("Connection could not be established.");
                Console.WriteLine("Please check your internet connection and try again.");
                return;
            }
            using (WebClient client = new WebClient())
            {
                string[] htmlCode = client.DownloadString
                    ("https://github.com/Maissae/Discord_BotTemplate/blob/dev/README.md").Split('\n');
                foreach(string line in htmlCode)
                {
                    //Console.WriteLine(line);
                    if(line.Contains("Current version"))
                        version = line;
                }
            }
            //Console.WriteLine(version);
            version = version.Trim();
            version = version.Replace(" ", string.Empty);
            version = version.Replace("</p>", string.Empty);
            version = Split(version);
            //Console.WriteLine(version);
            Info.gitVersion = version;
            await Task.CompletedTask;
        }

        private static string Split(string line)
        {
            string[] info = line.Split(':');
            return info[info.Length-1];
        }
    }
}
